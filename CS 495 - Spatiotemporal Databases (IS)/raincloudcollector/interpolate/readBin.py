'''
Created on May 17, 2013

@author: Brian
'''
import struct, os
ColorMapping = ["5 dBZ", "10 dBZ", "15 dBZ","20 dBZ","25 dBZ","30 dBZ","35 dBZ","40 dBZ","45 dBZ","55 dBZ","60 dBZ","65 dBZ","70 dBZ"]


#each bin file has it's own color and will be formatted as shown below:
#
#[countOfRegionsPerMovingRegion][colorID]
#[TS][countofSegsPerRegion][segs*]
#[TS][countofSegsPerRegion][segs*]...
#
#segs = [(long1, lat1, long2, lat2), (long1, lat1, long2, lat2), (long1, lat1, long2, lat2), etc...]

#for filename in fileList:
def readBin(filename):
    returnList = []
    
    ins = open( filename, 'rb')
    data = ins.read()
    offset = 0
    print data
    num_regions = struct.unpack('i', data[offset:offset+4])[0]
    if num_regions > 1:
        offset+=4
        dbzLevel = ColorMapping[struct.unpack('i', data[offset:offset+4])[0]]
        offset+=4
        returnList.append( dbzLevel )
        for i in range(num_regions):
            timeStamp = struct.unpack('i', data[offset:offset+4])[0]
            offset+=4
            num_segs = struct.unpack('i', data[offset:offset+4])[0]
            offset+=4
            regList = []
            for i in range(num_segs):
                x1 = struct.unpack('f', data[offset:offset+4])[0]
                offset+=4
                y1 = struct.unpack('f', data[offset:offset+4])[0]
                offset+=4
                x2 = struct.unpack('f', data[offset:offset+4])[0]
                offset+=4
                y2 = struct.unpack('f', data[offset:offset+4])[0]
                offset+=4
                above = struct.unpack('f', data[offset:offset+4])[0]
                offset+=4
                below = struct.unpack('f', data[offset:offset+4])[0]
                offset+=4
                regList.append(  (((float(x1), float(y1)),(float(x2),float(y2))), int(above), int( below )) )
            returnList.append( regList )
    return returnList
