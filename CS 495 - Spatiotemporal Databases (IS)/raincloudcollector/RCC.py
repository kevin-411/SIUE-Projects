'''
Created on Jan 10, 2013

@author: Brian

Running instructions:
If you want to just generate some test data locally then you may run this locally with a user that has sudo powers like so:

    $ nohup python RCC.py

If you want this script to push files up to the HDFS then you must run this with the hadoop user using this command:

    $ nohup python RCC.py -hadoop hdfs://n0:54310/regions

    Also, the parameter after -hadoop is the hdfs directory currently you can go to [Main Node IP]:50070 to find out 
    what the name of your region is (n0:54310 in the above example).

TODO:
Make sure we write the first snapshot time and updated snapshot time for every time we get a new snapshot (in case of crash or stop)

'''
import os, sys, datetime, math, struct, StringIO, time, hsegLibrary
import urllib2 as urllib
import region as reg
from PIL import Image
from subprocess import call
#########################################Class Definitions#############################################
#####################################################################################################
#Cloud Class
#Holds the objects needed to define a "cloud". A cloud in this context refers to list of
#connected pixels and it knows the color of it's pixels.
#startPoint is a (x,y) coordinate where the origin of the cloud started being "traced"
#edgePoints is a list that holds all of the coordinates of the cloud in order.
#color holds a 3 value tuple that holds (R,G,B) values.
##################################################################################################### 
class Cloud:
    def __init__(self):
        self.startPoint = None
        self.edgePoints = []
        self.color = None

#####################################################################################################
#RainCloudCollector Class
#Is responsible for collecting the points for a given color 
#clouds is a list containing all added clouds 
#cloudIndexMapping is a dictionary (hash-table) that maps each color to a list of indices in the clouds array 
#checkedPix is a CheckedPixels type (defined below) that keeps a set of pixels (with count) to determine if
###it should or shouldn't and it is determined that a pixel can be visited 3 times before it is no longer valid.
#totalCloudPoints global set of points that keeps track of all (x,y) values that has been iterated over to avoid repeats
#colors is a set of the colors within a given image.
#edgeMinimum is the minimum number of pixels present in a cloud list for the cloud to qualify else it will be discarded
#####################################################################################################       
class RainCloudCollector:
    def __init__(self, imgWidth, imgHeight, edgeMinimum = 0):
        self.clouds = [Cloud()]
        self.cloudIndexMapping = dict()
        self.checkedPix = CheckedPixels()
        self.totalCloudPoints = set()
        self.colors = set()
        self.edgeMinimum = edgeMinimum
        self.getColors(imgWidth, imgHeight)

##Initializes a cloud and adds it to the clouds array and returns it's index in the cloud array
    def foundCloud(self, x, y, color):
        newCloud = Cloud()
        newCloud.startPoint = (x, y)
        newCloud.edgePoints.append(newCloud.startPoint)
        self.clouds.append(newCloud)
        return (len(self.clouds) - 1)
    
##Returns a (x,y) coordinate that will contain the next optimum check bounds coordinate for the cloud
    def checkBounds(self, x, y, fromPos, color):
        up = y - 1
        down = y + 1
        right = x + 1
        left = x - 1
        
        upIsInRange = (up >= 0)
        leftIsInRange = (left >= 0)
        rightIsInRange = (right <= imgWidth - 1)
        downIsInRange = (down <= imgHeight - 1)

        bounds = []
        bounds.append((left, up) if upIsInRange and leftIsInRange else None)
        bounds.append((x, up) if upIsInRange else None)
        bounds.append((right, up) if upIsInRange and rightIsInRange else None)
        bounds.append((right, y) if rightIsInRange else None)
        bounds.append((right, down) if downIsInRange and rightIsInRange else None)
        bounds.append((x, down) if downIsInRange else None)
        bounds.append((left, down) if downIsInRange and leftIsInRange else None)
        bounds.append((left, y) if leftIsInRange else None)
        
        bounds = bounds[fromPos + 1:len(bounds)] + bounds[0: fromPos + 1]
        
        for bound in bounds: #takes care of center clouds
            if bound in rcc.totalCloudPoints or (color==White and bound==None):
                rcc.totalCloudPoints.add((x,y))
                return "Invalid"

        for bound in bounds:
            if bound != None and pix[bound[0], bound[1]] == color:
                return bound
        return "Invalid"
    
##Determines which direction the last pixel was coming from to predict where to find the next
##pixel to go to. (Reference the Direction Globals).
    def determineFromPos(self, currentPos, nextPos):
        cPos = (currentPos[0], currentPos[1])
        nX = nextPos[0]
        nY = nextPos[1]

        if cPos == (nX - 1, nY - 1):
            return UpL
        elif cPos == (nX, nY - 1):
            return UpM
        elif cPos == (nX + 1, nY - 1):
            return UpR
        elif cPos == (nX + 1, nY):
            return MidR
        elif cPos == (nX + 1, nY + 1):
            return LowR
        elif cPos == (nX, nY + 1):
            return LowM
        elif cPos == (nX - 1, nY + 1):
            return LowL
        elif cPos == (nX - 1, nY):
            return MidL
        elif cPos == (nX, nY):
            return "Same"
        
##Primary algorithm that is given a 3-tuple color and will return all lists of (x,y) coordinates of clouds in a given region
    def analyzeCloud(self, color):
        for y in range(imgHeight): 
            for x in range(imgWidth):
                if pix[x,y] == color and not (x,y) in self.checkedPix.collection:
                    newCloudIndex = self.foundCloud(x,y, color)   
                    nextPoint = self.checkBounds(x,y,MidL, color)
                    currentPoint = (x, y)
                    self.checkedPix.add(currentPoint)
                    while not nextPoint == self.clouds[newCloudIndex].startPoint and not nextPoint == "Invalid" and self.checkedPix.getCount(currentPoint) <= 3:
                        ##NOTE: 3 is the number of times a single pixel can be returned to until it has to move on to the next pixel if it's a "peninsula pixel"
                        if not nextPoint in self.clouds[newCloudIndex].edgePoints:
                            self.clouds[newCloudIndex].edgePoints.append(nextPoint)
                        fromPos = self.determineFromPos(currentPoint, nextPoint)
                        currentPoint = nextPoint
                        nextPoint = self.checkBounds(nextPoint[0], nextPoint[1], fromPos, color)
                        self.checkedPix.add(currentPoint)
                    if len(self.clouds[newCloudIndex].edgePoints) <= self.edgeMinimum or nextPoint=="Invalid": ##30 is just a random number to get rid of small single clouds
                        self.clouds.pop()
                    else: 
                        if(not self.cloudIndexMapping.has_key(color)):
                            self.cloudIndexMapping[color] = []
                        self.clouds[newCloudIndex].edgePoints.append(self.clouds[newCloudIndex].startPoint)
                        self.checkedPix.collection.update(set(self.clouds[newCloudIndex].edgePoints))
                        self.totalCloudPoints.update(set(self.clouds[newCloudIndex].edgePoints))
                        self.cloudIndexMapping[color].append(newCloudIndex)
                else:
                    self.checkedPix.add((x,y))
        self.totalCloudPoints = set()
        self.checkedPix.collection = set()
        self.checkedPix.count = dict()

##Initializes the RCC with a list of colors that are in the given image.
    def getColors(self, imgWidth, imgHeight):
        for y in range(imgHeight): 
            for x in range(imgWidth):
                self.colors.add(pix[x,y])
                
#####################################################################################################
#Checked Pixels Class
#This is an extension of a set with the capability of counting how many times a specific item
#in the subset has been added to the set.
#collection is just use a standard set.
#count is a dictionary (hash-table) to map a (x,y) point to a specific count.
#####################################################################################################                  
class CheckedPixels:
    def __init__(self):
        self.collection = set()
        self.count = dict()
        
    def add(self, pixPoint):
        if not pixPoint in self.collection:    
            self.collection.add(pixPoint)
            self.count[pixPoint] = 1
        else:
            self.count[pixPoint]+=1
        
    def getCount(self, pixPoint):
        return self.count[pixPoint]
#####################################End Class Definitions#############################################
######################################Function Definitions#############################################
##converts from a (x,y) coordinate to a (Longitude, Latitude) coordinate
def convertLatLong(x, y ,xScale ,yScale ,xMap ,yMap):
    longitude=math.fabs(xScale*x+xMap) #x
    latitude=math.fabs(yScale*y+yMap) #y
    return (longitude, latitude)#y, x

def computeAreaOfIntersections(r1, r2):
    interReg = reg.intersection(r1, r2)
    if len(interReg) > 0:
        lowestYVal = None
        for hseg in interReg:
            if hseg[0][0][1] > lowestYVal :
                lowestYVal = hseg[0][0][1]
                
        overallArea = 0
        floorVal = lowestYVal + 1
        for hseg in interReg:
            if hseg[1] == -1 or hseg[2] == -1:
                x1 = hseg[0][0][0]
                y1 = hseg[0][0][1]
                x2 = hseg[0][1][0]
                y2 = hseg[0][1][1]
                if x1 != x2:#removes a case that will return an area of zero
                    b1 = math.sqrt(math.pow((floorVal - y1),2))##distance formula but x's or y's cancel out in each
                    b2 = math.sqrt(math.pow((floorVal - y2),2))
                    h = math.sqrt(math.pow((x1 - x2),2))
                    area = (h/2) * (b1+b2)
                    
                    if hseg[1] == -1:
                        overallArea-=area
                    elif hseg[2] == -1:
                        overallArea+=area
            else:
                print "Boys we got us an error on our hands...now this particular error seems to be caused by an hseg "
                print "that doesn't have an above value or below value equal to -1. Have fun with that one..."
        return overallArea
    else:
        return 0
    

##################################End Function Definitions#############################################
#######################################Global Definitions##############################################
#####Color Constants#####
White = (255,255,255)
Black = (0,0,0)
Aqua = (4, 233, 231) ## 5 dBZ
DeepSkyBlue = (1, 159, 244) ## 10 dBZ
Blue = (3, 0, 244) ## 15 dBZ
Lime = (2, 253, 2) ## 20 dBZ
LimeGreen = (1, 197, 1)## 25 dBZ
Green = (0, 142, 0) ## 30 dBZ
Yellow = (253, 248, 2)## 35 dBZ
GoldenRod = (229, 188, 0) ## 40 dBZ
Orange = (253, 139, 0)## 45 dBZ
#Red=()## 50 dBZ
MediumRed = (212, 0, 0) ## 55 dBZ
DarkRed = (188, 0, 0)## 60 dBZ
Magenta = (248, 0, 253)## 65 dBZ
MediumOrchid = (152, 84, 198)## 70 dBZ
#######FUZZ######## "Fuzz" is simply a few shades of gray that show up where there is "noise" in the reflectivity readings
FUZZ1 = (235, 235, 235)
FUZZ2 = (232, 232, 232)
FUZZ3 = (225, 225, 225)
FUZZ4 = (238, 238, 238)
FUZZ5 = (230, 230, 230)
FUZZ6 = (227, 227, 227)
FUZZ7 = (240, 240, 240)
#######ARRAYS AND DICTS######
ReflectivityColors = [Aqua, DeepSkyBlue, Blue, Lime, LimeGreen, Green, Yellow, GoldenRod, Orange, MediumRed, DarkRed, Magenta, MediumOrchid]
ColorMapping = ["5 dBZ", "10 dBZ", "15 dBZ","20 dBZ","25 dBZ","30 dBZ","35 dBZ","40 dBZ","45 dBZ","55 dBZ","60 dBZ","65 dBZ","70 dBZ"]
TheFuzz = [FUZZ1, FUZZ2, FUZZ2, FUZZ3, FUZZ4, FUZZ5, FUZZ6, FUZZ7]
TotalColors = ReflectivityColors + TheFuzz + [White, Black]
###End Color Constants###
###DIRECTIONS###### 
#    0 1 2        Clockwise Rotation
#    7 C 3        C = Current Pixel
#    6 5 4
UpL = 0
UpM = 1
UpR = 2
MidR = 3
LowR = 4
LowM = 5
LowL = 6
MidL = 7
###END DIRECTIONS######
###MAP CONSTANTS###
HSEGS = 0
FILENAME = 1
ISUSED = 2
##END MAP CONSTANTS###
TenMinuteMillis = 10 * 60 * 1000
##The cloudEdgePointMinimum is a variable used to define how many pixel points are required to define a "cloud".
##The higher the cloudEdgePointMinimum is the less small insignificant clouds will be included. 
cloudEdgePointMinimum = 10

regionCode = "CONUS"

if regionCode == "CONUS":
    radarFilename = "latest_radaronly"
    radarUrl = "http://radar.weather.gov/ridge/Conus/RadarImg/" + radarFilename + ".gif"
    gfwFileUrl = "http://radar.weather.gov/ridge/Conus/RadarImg/" + radarFilename + ".gfw"
    mosaicTimes = "http://radar.weather.gov/ridge/Conus/RadarImg/mosaic_times.txt"
else:
    radarFilename = regionCode + "_N0R_0.gif"
    radarUrl = "http://radar.weather.gov/ridge/RadarImg/N0R/" + radarFilename + ".gif"
    gfwFileUrl = "http://radar.weather.gov/ridge/RadarImg/N0R/" + radarFilename + ".gfw"

if len(sys.argv) > 1 and sys.argv[1]=="-hadoop" and len(sys.argv) != 3:
    raise Exception.message("Hadoop paramater passed with no destination path found!")
    sys.exit()

keep_trying=True

while keep_trying:
    keep_trying=False
    try:
        ur = urllib.urlopen(gfwFileUrl)#open url
        contents = ur.readlines()#readlines from url file
        
        xScale = float(contents[0]) #expected 
        yScale = float(contents[3])
        xMap = float(contents[4])
        yMap = float(contents[5])
    except Exception:
        keep_trying=True

#currentDirectory = os.getcwd() + "/"
currentDirectory = "./"
if not os.path.exists(currentDirectory + "BinDump"):
    os.makedirs(currentDirectory + "BinDump")

#timestamp = str(datetime.datetime.now())[0:13] + "." + str(datetime.datetime.now())[14:16]  + "." + str(datetime.datetime.now())[17:19]
#radarImage.save(currentDirectory + regionCode + "/" + timestamp  + "_" + radarFilename + ".gif")
listOfAllRegions = []
listOfCurrentRegions = []
previousRegionMap = dict()

###################################End Global Definitions##############################################
###########################################Main########################################################
tenMinuteInterval = 0
region_index=0

while(True):
    time.sleep( 3 )
    if(tenMinuteInterval <= int(round(time.time() * 1000))):
        keep_trying = True
        while keep_trying:
            keep_trying=False
            try:
                img_file = urllib.urlopen(radarUrl)
                imgstring = StringIO.StringIO(img_file.read())
                radarImage = Image.open(imgstring)
            except Exception:
                keep_trying=True
            
        tenMinuteInterval = int(round(time.time() * 1000)) + TenMinuteMillis
        radarImage = radarImage.convert('RGB')
        pix = radarImage.load()
        imgWidth = radarImage.size[0]
        imgHeight = radarImage.size[1]
        rcc = RainCloudCollector(imgWidth, imgHeight, cloudEdgePointMinimum)
        colors = list(rcc.colors)
        
        print "Phase 1 - Cloud Collector"
        for color in colors:
            if (color in ReflectivityColors):# and color == Lime):
                rcc.analyzeCloud(color)
            sys.stdout.write("\r%d%%" %(float(colors.index(color)+1)/len(colors) * 100))
            sys.stdout.flush()
        #each bin file has it's own region and will be formatted as shown below:
        #
        #[countOfRegionsPerMovingRegion][colorID]
        #[TS][countofSegsPerRegion][segs*]
        #[TS][countofSegsPerRegion][segs*]...
        #
        #segs = [(long1, lat1, long2, lat2), (long1, lat1, long2, lat2), (long1, lat1, long2, lat2), etc...]
        print "\rPhase 2 - Write to Binary"
        TS = str(datetime.datetime.now())#timestamp
        TS = TS[0:4] + TS[5:7] + TS[8:10] + TS[11:13] + TS[14:16]
        for color in rcc.cloudIndexMapping.keys():

            if not previousRegionMap.has_key(color):
                previousRegionMap[color] = []
            counter = 0
            for cloudIndex in rcc.cloudIndexMapping[color]:
                try:
                    edgePoints = rcc.clouds[cloudIndex].edgePoints
                    segs=[] #segId will be index in array
                    regionCount=0
                    for i in range(len(edgePoints)-1):
                        coords1 = edgePoints[i]
                        coords2 = edgePoints[i+1 if i <= len(edgePoints)-1 else 0] #circles back around to close the region
                        latLong1 = convertLatLong(coords1[0], coords1[1], xScale, yScale, xMap, yMap)
                        latLong2 = convertLatLong(coords2[0], coords2[1], xScale, yScale, xMap, yMap)
                        segs.append(((latLong1[0], latLong1[1]), (latLong2[0], latLong2[1])))
                        
                    hsegs=reg.createRegionFromSegs(segs)
    
                    maxIntersectArea = 0
                    maxRegionIndex = None
    
                    print 'color:', color, '   area ',counter,'/', len( rcc.cloudIndexMapping[color] ), 'vs' ,len(previousRegionMap[color])
                    counter +=1
                    filename = ""
                    for i, oldhsegs in enumerate(previousRegionMap[color]):
                        if len( oldhsegs[HSEGS]) >= 6:
                            area = computeAreaOfIntersections(hsegs, oldhsegs[HSEGS])
                            if area > maxIntersectArea:
                                maxIntersectArea = area
                                maxRegionIndex=i
                        
                    if maxIntersectArea == 0:
                        pointOriginHsegs= [((segs[0][1], segs[0][0]), 1, -1), ((segs[0][0], segs[0][1]), -1, 1)]
                        filename = TS + "%05d" % (region_index)
                        while(os.path.exists(currentDirectory + "BinDump/" + filename +'.bin')):
                            region_index+=1
                            filename = TS + "%05d" % (region_index)
                        previousRegionMap[color].append([pointOriginHsegs, filename, False])
                        listOfCurrentRegions.append([hsegs, filename, False])
                        maxRegionIndex=len(previousRegionMap[color]) - 1
                        num_regions_data= struct.pack('i', 1)
                        data = num_regions_data + struct.pack('i', ReflectivityColors.index(color))
                        #if os.path.exists(currentDirectory + "BinDump/" + filename +'.bin'):
                        writer = open(currentDirectory + "BinDump/" + filename +'.bin', 'wb')
                        writer.write(data)# updates countOfRegionsPerMovingRegion in front
                        writer.close()
                        #else:
                            #raise IOError 
                        
                    else:
                        filename = previousRegionMap[color][maxRegionIndex][FILENAME]
                        listOfCurrentRegions.append([hsegs, filename, False])
                        
                        #First get current region count
                        if os.path.exists(currentDirectory + "BinDump/" + filename +'.bin'):
                            reader = open(currentDirectory + "BinDump/" + filename +'.bin', 'rb')
                            data = reader.read(4)
                            reader.close()
                        else:
                            raise IOError 
                        #Then update region count and overwrite count
                        num_regions_data = struct.pack('i', struct.unpack('i', data[0:4])[0] + 1)
                        
                        if os.path.exists(currentDirectory + "BinDump/" + filename +'.bin'):
                            writer = open(currentDirectory + "BinDump/" + filename +'.bin', 'r+b')
                            writer.seek(0)
                            writer.write("".join(num_regions_data))# updates countOfRegionsPerMovingRegion in front
                            writer.close()
                        else:
                            raise IOError 
            
                    regions = []
                    for hseg in previousRegionMap[color][maxRegionIndex][HSEGS]:
                        if(hsegLibrary.isLeft(hseg)):
                            regions += [hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1]]
                    
                    
                    if not regions is None:
                        data = struct.pack('q', long(TS))#TimeStamp
                        data += struct.pack('i', len(regions)/4)#size of array/4 because there are 4 entries per segment
                        data += struct.pack('%if' % len(regions), *regions)#array of segs
            
                    #append to binary file
                    if os.path.exists(currentDirectory + "BinDump/" + filename +'.bin'):
                        appender = open(currentDirectory + "BinDump/" + filename +'.bin','ab')
                        appender.write(data)
                        appender.close()
                        previousRegionMap[color][maxRegionIndex][ISUSED] = True #sets isUsed to True
                    else:
                            raise IOError 
                    data = None
                except IOError:
                    print "There was an IO Error"
                except Exception:
                    print "There was an issue with specific region error(UIOP) ", counter, " of Color: ", color, " cloudIndex: ", cloudIndex
                    print "\n*******printing current hsegs**************\n"
                    for hseg in hsegs:
                        print hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1]
                    if not maxRegionIndex==None:  
                        print "\n*******printing max Region Index hsegs**************\n"
                        for hseg in previousRegionMap[color][maxRegionIndex][HSEGS]:
                            print hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1]
                    else:
                        print "\n*******There are no max Region Index hsegs**************\n"
                    
            for unusedHsegs in previousRegionMap[color]:
                if not unusedHsegs[ISUSED] and os.path.exists(currentDirectory + "BinDump/" + unusedHsegs[FILENAME] +'.bin'):
                    reader = open(currentDirectory + "BinDump/" + unusedHsegs[FILENAME] +'.bin', 'rb')
                    data=reader.read(4)
                    reader.close()
                    
                    #Then update region count and overwrite count
                    num_regions_data =struct.pack('i', struct.unpack('i', data[0:4])[0] + 2) #+2 because we're finishing this region with a final point region
                    writer = open(currentDirectory + "BinDump/" + filename +'.bin', 'r+b')
                    writer.seek(0)
                    writer.write("".join(num_regions_data))# updates countOfRegionsPerMovingRegion in front
                    writer.close()
                    
                    regions = []
                    maxXPair=(0,0)
                    for hseg in unusedHsegs[HSEGS]:
                        if(hsegLibrary.isLeft(hseg)):
                            regions += [hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1]]
                            if hseg[0][0][0] > maxXPair[0]:
                                maxXPair = hseg[0][0]
                    pointDestinationHsegs=[maxXPair[0], maxXPair[1], maxXPair[1], maxXPair[0]]
                    if not regions is None:
                        data = struct.pack('q', long(TS))#TimeStamp
                        data += struct.pack('i', len(regions)/4)
                        data += struct.pack('%if' % len(regions), *regions)
                        data += struct.pack('q', long(TS))#TimeStamp
                        data += struct.pack('i', len(pointDestinationHsegs)/4)
                        data += struct.pack('%if' % len(pointDestinationHsegs), *pointDestinationHsegs)
                    #write binary file
                    finishedLocalFile = currentDirectory + "BinDump/" + unusedHsegs[FILENAME] +'.bin'
                    appender = open(finishedLocalFile,'ab')
                    appender.write(data)
                    appender.close()
                    previousRegionMap[color].remove(unusedHsegs)
                    if sys.argv[1]=="-hadoop":
                        if(os.path.exists(finishedLocalFile)):
                            command = "/mnt/hadoop/hadoop/bin/hadoop fs -put {0} {1}".format(finishedLocalFile, sys.argv[2])
                            call(command.split(), shell = False)
                            command = "rm {0}".format(finishedLocalFile)
                            call(command.split(), shell = False)
                        else:
                            print "Command not called on file {0}.".format(finishedLocalFile)
                    data = None 
            previousRegionMap[color] = listOfCurrentRegions
            
            listOfCurrentRegions=[]
        #and now to make holes
        for color in rcc.cloudIndexMapping.keys():
            for i, regionTuple in enumerate(previousRegionMap[color]):
                reg1 = regionTuple[HSEGS]
                for color2 in rcc.cloudIndexMapping.keys():
                    for regionTuple2 in previousRegionMap[color2]:
                        reg2 = regionTuple2[HSEGS]
                        if len( reg1 ) >=6 and len(reg2) >= 6:
                            try:
                                difference = reg.difference(reg1, reg2)
                                if(len(difference) != 0):
                                    previousRegionMap[color][i][HSEGS] = difference
                            except:
                                previousRegionMap[color].remove(previousRegionMap[color][i])
                                print "\n*******printing reg1**************\n"
                                for hseg in reg1:
                                    print hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1]
                                print "\n*******printing reg2**************\n"
                                for hseg in reg2:
                                    print hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1]

                                
#######################################End Main########################################################
