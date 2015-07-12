import os, sys, datetime, math, struct, StringIO, time
import region as reg

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

ReflectivityColors = [Aqua, DeepSkyBlue, Blue, Lime, LimeGreen, Green, Yellow, GoldenRod, Orange, MediumRed, DarkRed, Magenta, MediumOrchid]

class FakeRCC:
    def __init__(self, listofsegs):
        self.clouds = [Cloud()]
        self.cloudIndexMapping = dict()
        self.cloudIndexMapping[Lime]=[]
        for segs in listofsegs:
            newCloud = Cloud()
            for seg in segs:
                newCloud.edgePoints.append(seg[0])
                newCloud.edgePoints.append(seg[1])
            self.cloudIndexMapping[Lime].append(len(self.clouds))
            self.clouds.append(newCloud)
        
class Cloud:
    def __init__(self):
        self.edgePoints = []
    
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


segs1_TS_1=[((0,0),(0,2)), ((0,2),(2,3)), ((2,3),(2,0)), ((2,0),(0,0))]# area: 5  
segs1_TS_2=[((0,2),(0,3)), ((0,3),(3,3)), ((3,3),(3,2)), ((3,2),(0,2))]# area: 3    overlap: 1
segs2_TS_2=[((1,0),(1,2)), ((1,2),(3,2)), ((3,2),(3,0)), ((3,0),(1,0))]# area: 4    overlap: 2 <--this should be chosen over other 
segs1_TS_3=[((2,2),(2,9)), ((2,9),(9,9)), ((9,9),(9,2)), ((9,2),(2,2))]# area: 49   overlap: 1
rcc=None
listOfCurrentRegions = []
currentRegionMap = dict()
region_index=0

currentDirectory = os.getcwd() + "/"

if not os.path.exists(currentDirectory + "Bin Dump"):
    os.makedirs(currentDirectory + "Bin Dump")

for i in range(2):  
    if i==0:
        rcc = FakeRCC([segs1_TS_1])
    elif i==1:
        rcc = FakeRCC([segs1_TS_2, segs2_TS_2])
    else:
        rcc = FakeRCC([segs1_TS_3])
    #each bin file has it's own region and will be formatted as shown below:
    #
    #[countOfRegionsPerMovingRegion][colorID]
    #[TS][countofSegsPerRegion][segs*]
    #[TS][countofSegsPerRegion][segs*]...
    #
    #segs = [(long1, lat1, long2, lat2), (long1, lat1, long2, lat2), (long1, lat1, long2, lat2), etc...]
    print "\rPhase 2 - Write to Binary"
    TS = str(datetime.datetime.now())#timestamp
    TS = TS[2:4] + TS[5:7] + TS[8:10] + TS[11:13] + TS[14:16]
    for color in rcc.cloudIndexMapping.keys():
        if not currentRegionMap.has_key(color):
            currentRegionMap[color] = []
        for cloudIndex in rcc.cloudIndexMapping[color]:
            edgePoints = rcc.clouds[cloudIndex].edgePoints
            segs=[] #segId will be index in array
            regionCount=0
            for i in range(len(edgePoints)-1):
                coords1 = edgePoints[i]
                coords2 = edgePoints[i+1 if i <= len(edgePoints)-1 else 0] #circles back around to close the region
                #latLong1 = convertLatLong(coords1[0], coords1[1], xScale, yScale, xMap, yMap)
                #latLong2 = convertLatLong(coords2[0], coords2[1], xScale, yScale, xMap, yMap)
                #segs.append(((latLong1[0], latLong1[1]), (latLong2[0], latLong2[1])))
                segs.append(((float(coords1[0]), float(coords1[1])), (float(coords2[0]), float(coords2[1]))))
                
            hsegs=reg.createRegionFromSegs(segs)
            maxIntersectArea = 0
            maxRegionIndex = None
            for i, oldhsegs in enumerate(currentRegionMap[color]):
                area = computeAreaOfIntersections(hsegs, oldhsegs[0])
                if area > maxIntersectArea:
                    maxIntersectArea = area
                    maxRegionIndex=i
                
            if maxIntersectArea == 0:
                pointOriginHsegs= [((segs[0][0], segs[0][1]), -1, 1)] #i'm not sure if this will cause any issues 
                while(os.path.exists(currentDirectory + "Bin Dump/" + str(region_index) +'.bin')):
                    region_index+=1
                currentRegionMap[color].append((pointOriginHsegs, region_index))
                listOfCurrentRegions.append((hsegs, region_index))
                maxRegionIndex=len(currentRegionMap[color]) - 1
                num_regions_data= struct.pack('i', 1)
                data = num_regions_data + struct.pack('i', ReflectivityColors.index(color)) #add this on so that the color isn't lost when updating num_regions_data
            else:
                listOfCurrentRegions.append((hsegs, currentRegionMap[color][maxRegionIndex][1]))
                ins = open(currentDirectory + "Bin Dump/" + str(currentRegionMap[color][maxRegionIndex][1]) +'.bin', 'rb')
                data = ins.read()
                updatedNumber = struct.unpack('i', data[0:4])[0] + 1
                num_regions_data = struct.pack('i', updatedNumber)
    
            region = []
            for hseg in currentRegionMap[color][maxRegionIndex][0]:
                region += [hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1], float(hseg[1]), float(hseg[2])]
            
            
            if not region is None:
                data = num_regions_data + data[4:len(data)]# updates countOfRegionsPerMovingRegion in front
                data += struct.pack('i', int(TS))#TimeStamp
                data += struct.pack('i', len(region)/6)#size of array/6 because there are 6 entries per segment
                data += struct.pack('%if' % len(region), *region)#array of segs
    
            #write binary file
            f = open(currentDirectory + "Bin Dump/" + str(currentRegionMap[color][maxRegionIndex][1]) +'.bin','wb')
            f.write(data)
            f.close()
            currentRegionMap[color].pop(maxRegionIndex)
            data = struct.pack('i', ReflectivityColors.index(color))#pushes the colorID from the map that correlates with the dbz level
        for unusedHsegs in currentRegionMap[color]:
            ins = open(currentDirectory + "Bin Dump/" + str(unusedHsegs[1]) +'.bin', 'rb')
            num_regions_data =struct.pack('i', struct.unpack('i', ins.read()[0:4])[0] + 2) #+2 because we're finishing this region with a final point region
    
            region = []
            maxXPair=(0,0)
            for hseg in unusedHsegs[0]:
                region += [hseg[0][0][0], hseg[0][0][1], hseg[0][1][0], hseg[0][1][1], float(hseg[1]), float(hseg[2])]
                if hseg[0][0][0] > maxXPair[0]:
                    maxXPair = hseg[0][0]
            pointDestinationHsegs=[maxXPair[0], maxXPair[1], maxXPair[1], maxXPair[0], float(-1), float(1)]
            if not region is None:
                data += num_regions_data + data[4:len(data)]
                data += struct.pack('i', int(TS))#TimeStamp
                data += struct.pack('i', len(region)/6)
                data += struct.pack('%if' % len(region), *region)
                data += struct.pack('i', int(TS))#TimeStamp
                data += struct.pack('i', len(pointDestinationHsegs)/6)
                data += struct.pack('%if' % len(pointDestinationHsegs), *pointDestinationHsegs)
            #write binary file
            f = open(currentDirectory + "Bin Dump/" + str(unusedHsegs[1]) +'.bin','ab')
            f.write(data)
            f.close()
            data = struct.pack('i', ReflectivityColors.index(color))#pushes the colorID from the map that correlates with the dbz level
        currentRegionMap[color] = listOfCurrentRegions
        listOfCurrentRegions=[]
    #The main idea from here is to take the current previous region from the map and write it to a binary file along with the
    #index in the array it should be pointing to. Then wipe out the previous current map with all the new regions.
        sys.stdout.write("\r%d%%" %(float(rcc.cloudIndexMapping.keys().index(color) + 1)/len(rcc.cloudIndexMapping.keys())*100))
        sys.stdout.flush()
        rcc = None
        

