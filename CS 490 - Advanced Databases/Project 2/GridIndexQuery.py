from __future__ import division # this changes / to floating division and // to integer division
import struct
import math

print "Welcome to the Nearest Neighbor Point Finder!!"
print "To generate a point enter an (x,y) coordinate and we will find the nearest neighbor(s) to your value!!"
gridLength = 100000000

keepGoing = True
while(keepGoing):
    queryX = int(raw_input("Please enter an x value [0 - " + str(gridLength) +"]: "))
    queryY = int(raw_input("Please enter a y value [0 - " + str(gridLength) +"]: "))
    while not (queryX >= 0 and queryX <= gridLength and queryY >= 0 and queryY <= gridLength):
        print "Invalid value for queryX and/or queryY!!"
        queryX = int(raw_input("Please enter an x value [0 - " + str(gridLength) + "]: "))
        queryY = int(raw_input("Please enter a y value [0 - " + str(gridLength) + "]: "))
        
    
    oFile = open( "output", 'rb' )
    
    recordSize=struct.unpack('i', oFile.read(4))[0]
    gridSplitVal=struct.unpack('i',oFile.read(4))[0]
    
    gridSize = gridLength // gridSplitVal
    
    gridX = int(math.floor(queryX // gridSize))
    gridY = int(math.floor(queryY // gridSize))
    gridX = (gridX if gridX <=5 else gridX - 1)
    gridY = (gridY if gridY <=5 else gridY - 1)
    
    def checkBounds(x, y,bounds, checkedGrids):
        up = y + 1
        down = y - 1
        right = x + 1
        left = x - 1
        
        upIsInRange = (up <= gridSplitVal - 1)
        leftIsInRange = (left >= 0)
        rightIsInRange = (right <= gridSplitVal - 1)
        downIsInRange = (down >= 0)
        
        if((x,y) not in checkedGrids): bounds.append((x,y))
        if((left, up) not in checkedGrids and upIsInRange and leftIsInRange): bounds.append((left, up))
        if((x, up) not in checkedGrids and upIsInRange): bounds.append((x, up))
        if((right, up) not in checkedGrids and upIsInRange and rightIsInRange): bounds.append((right, up))
        if((right, y) not in checkedGrids and rightIsInRange): bounds.append((right, y))
        if((right, down) not in checkedGrids and downIsInRange and rightIsInRange): bounds.append((right, down))
        if((x, down) not in checkedGrids and downIsInRange): bounds.append((x, down))
        if((left, down) not in checkedGrids and downIsInRange and leftIsInRange): bounds.append((left, down))
        if((left, y) not in checkedGrids and leftIsInRange): bounds.append((left, y))
    
    def translateIndex(valX, valY):
        val = valX + (valY * gridSplitVal)
        index = 8 + ((recordSize * 16 + 4) * val)
        return index
    
    bounds = []
    checkedGrids = set()
    nearestNeighbor = ()
    
    while(len(nearestNeighbor)==0):
        if(len(checkedGrids)>0):
            tempbounds = []
            for bound in bounds:
                checkBounds(bound[0], bound[1], tempbounds, checkedGrids)
            bounds = tempbounds
            
        else:
            checkBounds(gridX, gridY, bounds, checkedGrids)
            checkedGrids.add((gridX, gridY))
        for bound in bounds:
            i = translateIndex(bound[0], bound[1])
            oFile.seek(i)
            count = struct.unpack('i', oFile.read(4))[0]
            gridRec = oFile.read(recordSize * 16)
            for j in range(count):
                offset = j * 16
                ex=struct.unpack('q', gridRec[0 + offset : 8 + offset])[0]
                why=struct.unpack('q', gridRec[8 + offset : 16 + offset])[0]
                distance = math.pow((ex - queryX),2) + math.pow((why - queryY),2)
                if(len(nearestNeighbor) > 0 and distance == nearestNeighbor[0]):
                    nearestNeighbor = nearestNeighbor + ((ex, why),)
                elif((len(nearestNeighbor) > 0 and distance < nearestNeighbor[0]) or (len(nearestNeighbor) == 0)):
                    nearestNeighbor = (distance, (ex, why))
            checkedGrids.add((bound[0], bound[1]))
    print "grids checked: "
    
    for checks in checkedGrids:
        print checks
    
    print "distance: " + str(math.sqrt(nearestNeighbor[0])) + "\n"
    
    print "nearest neighbor(s): "
    
    for i in range(len(nearestNeighbor)-1):
        print str(nearestNeighbor[i + 1])
    
    oFile.close()
    val = raw_input("Would you like to enter another query(Y) or (N)? ")
    keepGoing = (True if val == 'Y' or val == 'y' else False)
