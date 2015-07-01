from __future__ import division
import struct, os
numberOfGrids = 6
gridSize = 100000000/(numberOfGrids)

oFile = open( "zorder.bin", 'rb' )
output = open('./output','wb')
fileOutputs = []
fileCounts = []

for i in range(numberOfGrids):
    for j in range(numberOfGrids):
        gridNumber = j + i * numberOfGrids
        fileOutputs.append(open('./' + str(gridNumber),'wb+'))
        fileCounts.append(0)

chunks = os.path.getsize("zorder.bin") // 4
rec = oFile.read(chunks)
count = 0
while len(rec) > count:
    while chunks > count:
        line = struct.unpack( 'qq', rec[count:count + 16] ) 
        x = int( line[0] )
        y = int( line[1] )
        xGrid = int(x//gridSize)
        yGrid = int(y//gridSize)
        gridNumber = xGrid + yGrid * numberOfGrids
        fileOutputs[gridNumber].write(rec[count:count + 16])
        fileCounts[gridNumber]+=1
        count += 16
    count = 0
    rec = oFile.read( chunks )
    
maxVal = 0
for count in fileCounts:
    if count > maxVal:
        maxVal = count

###OUTPUT

output.write(struct.pack('i',maxVal))
output.write(struct.pack('i',numberOfGrids))
for i,out in enumerate(fileOutputs):
    output.write(struct.pack('i',fileCounts[i]))
    out.seek(0)
    output.write(out.read())
    padLength = maxVal - fileCounts[i]
    for k in range(padLength):
        for a in range(16):
            output.write(struct.pack('c', ' '))
    fileOutputs[i].close()
    os.remove("./" + str(i))

oFile.close()
output.close()

raw_input("Are you finished? Click any button to exit...")
