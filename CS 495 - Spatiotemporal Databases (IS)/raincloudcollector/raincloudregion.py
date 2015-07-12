'''
Created on May 17, 2013

@author: Brian
'''
import struct, os
import region as reg
ColorMapping = ["5 dBZ", "10 dBZ", "15 dBZ","20 dBZ","25 dBZ","30 dBZ","35 dBZ","40 dBZ","45 dBZ","55 dBZ","60 dBZ","65 dBZ","70 dBZ"]

class RainCloudRegionsContiainer:
    def __init__(self, imgWidth, imgHeight, edgeMinimum = 0):
        self.regions = []
        self.color = None
        
class RainCloudRegion:
        self.hsegs = []
        self.timeStamp = None
        
#each bin file has it's own color and will be formatted as shown below:
#
#[countOfRegionsPerMovingRegion][colorID]
#[TS][countofSegsPerRegion][segs*]
#[TS][countofSegsPerRegion][segs*]...
#
#segs = [(long1, lat1, long2, lat2), (long1, lat1, long2, lat2), (long1, lat1, long2, lat2), etc...]
filename="20131116144301398.bin"
dir = "./BinDump"
testRegionBin(dir,filename)

def testRegionBin(directory, filename):
    if (os.path.exists(directory +  filename)):
        ins=None
        try:
            text_file=open(directory + "output.txt", 'w')
            ins = open(directory +  filename, 'rb')
            data = ins.read()
            offset = 0
            num_regions = struct.unpack('i', data[offset:offset+4])[0]
            if num_regions > 1:
                offset+=4
                dbzLevel = ColorMapping[struct.unpack('i', data[offset:offset+4])[0]]
                offset+=4
                text_file.write("Number Of Regions: {0}\nDBZ Level: {1}\n".format(num_regions, dbzLevel))
                print num_regions
                print dbzLevel
                
                for i in range(num_regions):
                    timeStamp = struct.unpack('q', data[offset:offset+8])[0]
                    offset+=8
                    num_segs = struct.unpack('i', data[offset:offset+4])[0]
                    offset+=4
                    text_file.write("Region {0} @TimeStamp: {1}\n".format(i, timeStamp))
                    print "Region " + str(i) + " @TimeStamp:" + str(timeStamp)
                    for i in range(num_segs):
                        x1 = struct.unpack('f', data[offset:offset+4])[0]
                        offset+=4
                        y1 = struct.unpack('f', data[offset:offset+4])[0]
                        offset+=4
                        x2 = struct.unpack('f', data[offset:offset+4])[0]
                        offset+=4
                        y2 = struct.unpack('f', data[offset:offset+4])[0]
                        offset+=4
                        text_file.write("(({0},{1}), ({2},{3}))\n".format(x1, y1, x2, y2))
                        print "((" + str(x1) + "," + str(y1) + "), (" + str(x2) + "," + str(y2) + "))\n"
        #             
        finally:
            if ins is not None:
                ins.close()
                text_file.close()
                

                
def translateMovingRegion(ins):
    #ins=handle
    rcrc = RainCloudRegionsContiainer()
    try:
        data = ins.read()
        offset = 0
        num_regions = struct.unpack('i', data[offset:offset+4])[0]
        if num_regions > 1:
            offset+=4
            rcr.color = ColorMapping[struct.unpack('i', data[offset:offset+4])[0]]
            rcr.color
            offset+=4
            print "Number Of Regions: {0}\nDBZ Level: {1}\n".format(num_regions, rcr.color)
            
            for i in range(num_regions):
                rcr = RainCloudRegion()
                segs = []
                rcr.timeStamp = struct.unpack('q', data[offset:offset+8])[0]
                offset+=8
                num_segs = struct.unpack('i', data[offset:offset+4])[0]
                offset+=4
                print "Region {0} @TimeStamp: {1}\n".format(i, rcr.timeStamp)
                for i in range(num_segs):
                    x1 = struct.unpack('f', data[offset:offset+4])[0]
                    offset+=4
                    y1 = struct.unpack('f', data[offset:offset+4])[0]
                    offset+=4
                    x2 = struct.unpack('f', data[offset:offset+4])[0]
                    offset+=4
                    y2 = struct.unpack('f', data[offset:offset+4])[0]
                    offset+=4
                    segs.append(((x1, y1), (x2, y2)))
                    print "Appending (({0},{1}), ({2},{3}))\n".format(x1, y1, x2, y2)
                rcr.hsegs=reg.createRegionFromSegs(segs)
            rcrc.regions.append(rcr)
        return rcrc
    finally:
        if ins is not None:
            ins.close()