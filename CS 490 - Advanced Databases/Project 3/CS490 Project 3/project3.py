'''
Created on Mar 3, 2014

@author: Brian Olsen
@author: Matt Lievens
'''
import sys, time
from xml.etree import ElementTree as ET
from copy import deepcopy as deepCopy


###################################CONSOLE VERIFICATION##########################################


if len( sys.argv ) < 2 or len( sys.argv ) > 5:
    print 'usage: python ', sys.argv[0], ' [line geometry file] [optional point geometry file]'
    exit()


pointFile = None
lineFile = None

if len( sys.argv ) >= 2:
    lfName = sys.argv[1]
    lineFile  = open(lfName, 'r' )
if len( sys.argv ) >= 3:
    pfName = sys.argv[2]
    pointFile  = open(pfName, 'r' )


###################################FUNCTIONS##########################################
class MyLine:
    def __init__(self):
        #start point
        self.start = ()
        #end point
        self.end = ()
        #all points in between not including stat and end point
        self.points = []
        
def pointsEqual(p1,p2):
    if(p1[0]==p2[0] and p1[1]==p2[1]):
        return True
    return False

def pointInPolygon(x,y,poly):

    n = len(poly)
    inside = False

    p1x,p1y = poly[0]
    for i in range(n+1):
        p2x,p2y = poly[i % n]
        if y > min(p1y,p2y):
            if y <= max(p1y,p2y):
                if x <= max(p1x,p2x):
                    if p1y != p2y:
                        xints = (y-p1y)*(p2x-p1x)/(p2y-p1y)+p1x
                    if p1x == p2x or x <= xints:
                        inside = not inside
        p1x,p1y = p2x,p2y

    return inside
    

#get lines from the lines_out.txt
def getLines():
    lines = []
    
    for line in lineFile:
            line = line[line.find( ':' )+1:]
            item = ET.fromstring( line )
            for t in item.iter():
                    if t.text != None:
                            coords = t.text.strip( ' ')
                            coords = coords.split( ' ')
                            line = MyLine()
                            for i in range( len(coords)):
                                    p1 = coords[i].split( ',' )
                                    x1 = float( p1[0] )
                                    y1 = float( p1[1] )
    
                                    line.points.append(( x1,  y1 ))
                                    if i == 0:
                                        line.start = ( x1,  y1 )
    
                                    elif i == len( coords)-1:
                                        
                                        line.end = ( x1,  y1 )

    
                            lines.append(line)
    return lines

#get points from the points_out.txt
def getPoints():
    points = []
    for line in pointFile:
            line = line[line.find( ':' )+1:]
            item = ET.fromstring( line )
            for t in item.iter():
                    if t.text != None:
                            coords = t.text.strip( ' ')
                            coords = coords.split( ' ')
                            for i in range( len( coords) ):
                                    p1 = coords[i].split( ',' )
                                    x1 = float( p1[0] )
                                    y1 = float( p1[1] )
    
                                    points.append( ( x1,  y1 ) )
    return points

def binarySearchLow(points, value):
    low = 0
    high = len(points) - 1
    while (low <= high):
        mid = (low + high) / 2
        if (points[mid][0] >= value):
            high = mid - 1
        else:
            low = mid + 1

    return low

def binarySearchHigh(points, value):
    low = 0
    high = len(points) - 1
    while (low <= high):
        mid = (low + high) / 2
        if (points[mid][0] > value):
            high = mid - 1
        else:
            low = mid + 1

    return low

def makeXMLDoc(lines):
    lineStringElement = ET.Element("gml:LineString")
        
    lineStringElement.attrib["srsName"] = "EPSG:54004"
    lineStringElement.attrib["xmlns:gml"]="http://www.opengis.net/gml"
    
    
    attributes = dict()
    attributes["decimal"]="."
    attributes["cs"]=","
    attributes["ts"]=" "
    
    count = 1
    with open('outputLines.txt','w') as f: ## Write document to file
        f.write("")
    for l in lines:

        coordinates = ET.SubElement(lineStringElement, "gml:coordinates", attributes)
        coordinates.text = ""

        for p in l.points:
            if len(p) > 0:
                coordinates.text += str(p[0]) + attributes["cs"]
                coordinates.text += str(p[1]) + attributes["ts"]
        with open('outputLines.txt','a') as f: ## Write document to file
            f.write(str(count) + ":" + ET.tostring(lineStringElement) + "\n")
                
        lineStringElement = ET.Element("gml:LineString")
        
        lineStringElement.attrib["srsName"] = "EPSG:54004"
        lineStringElement.attrib["xmlns:gml"]="http://www.opengis.net/gml"

#################MAIN###############################  

start = time.time()
linesTemplate = getLines()
points = getPoints()
points.sort()

totalKeepPoints = ["Place holder so total keep Points is > 0 to start"]

while(len(totalKeepPoints)>0):
    totalKeepPoints = []
    lines = deepCopy(linesTemplate)

    for l in lines:
        keepPoints = []
        #Add start point
        keepPoints.append(l.points[0])
        
        beforeIndex = 0
        for i in range(1,len(l.points) - 1):
            p = l.points[i]
            before = l.points[beforeIndex]
            after = l.points[i+1]
            polygon = [before, p, after]
            minx = min(before[0],min(after[0],p[0]))
            miny = min(before[1],min(after[1],p[1]))
            maxx = max(before[0],max(after[0],p[0]))
            maxy = max(before[1],max(after[1],p[1]))
            for j in range(binarySearchLow(points,minx),binarySearchHigh(points,maxx)):
                px = points[j][0]
                py = points[j][1]
                if(py > miny and py < maxy and pointInPolygon(px,py,polygon)):
                    keepPoints.append(p)
                    beforeIndex = i

        #Add last end point
        keepPoints.append(l.points[len(l.points) - 1])
        if(len(keepPoints)==2):
            keepPoints.insert(1, l.points[1])

        for pnt in keepPoints:
            if pnt not in points:
                totalKeepPoints.append(pnt)
        l.points = keepPoints
        
    points = points + totalKeepPoints
    points.sort()

finish = time.time() - start
makeXMLDoc(lines)

numLinePoints = 0
numLinePointsKept = 0

for l in linesTemplate:
    numLinePoints = numLinePoints + len(l.points)
    
for l in lines:
    numLinePointsKept = numLinePointsKept + len(l.points)
    
score = numLinePoints - numLinePointsKept

print "Total number of line points: ", numLinePoints
print "Points Removed: ", score
print "Percentage Removed: ", (float(score)/float(numLinePoints))*100, "%"
print "Ran in: ",finish, " sec."
print "Score(numPoints/time(sec)): ", score/finish

###May add this back later
##This goes with original declarations and under while(len(totalKeepPoints)>0):
#twoPointLines = set()

##This goes below the if(len(keepPoints)==2):        
#            p1 = l.points[0]
#            p2 = l.points[1]
#            for tpl in twoPointLines:
#                p3 = tpl.points[0]
#                p4 = tpl.points[1]
#                if(pointsEqual(p1, p3) and pointsEqual(p2, p4) or 
#                   pointsEqual(p1,p4) and pointsEqual(p2,p3)):
                    #append any point that is not the end point
#                    keepPoints.insert(1, l.points[1])
#                    points.append(l.points[1])
#                    break
#            twoPointLines.add(l)