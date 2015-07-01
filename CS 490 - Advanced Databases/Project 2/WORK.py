from __future__ import division

import struct
numberOfGrids = 6
gridSize = 100000000/(numberOfGrids)


class grid:
    def __init__(self):
        self.grids = [[list()for i in range(numberOfGrids)] for j in range(numberOfGrids)]
        
    def insert(self, x,y, point):  
        self.grids[int(x//gridSize)][int(y//gridSize)].append(point)
        
    def largestValue(self):    
        maxVal = 0
        for i in range(numberOfGrids):
            for j in range(numberOfGrids):
                if len(self.grids[i][j]) > maxVal:
                    maxVal = len(self.grids[i][j])
        return maxVal
        
    def counts(self, x, y):
        return len(self.grids[x][y])

start = 0
end = 0





oFile = open( "zorder.bin", 'rb' )
print gridSize
count = 0
gUnit = grid()
while True:
    count += 1.
    rec = oFile.read( 16 )
    if len(rec) < 16 :
        break
    if end != 0 and count > end :
        break
    if count < start+1:
        continue
    line = struct.unpack( 'qq', rec ) 
    
    n1 = int( line[0] );
    n2 = int( line[1] );
    gUnit.insert(n1, n2, rec)
    
oFile.close()

largest = gUnit.largestValue()

###OUTPUT

output = open('./output','wb')
output.write(struct.pack('i',largest))
output.write(struct.pack('i',numberOfGrids))
for i in range(numberOfGrids):
    for j in range(numberOfGrids):
        count = 0
        output.write(struct.pack('i',gUnit.counts(i,j)))
        for rec in gUnit.grids[i][j]:
            count +=1
            output.write(rec)
        while count < largest:
            for a in range(8):
                output.write(struct.pack('c', ' '))
            count +=1




