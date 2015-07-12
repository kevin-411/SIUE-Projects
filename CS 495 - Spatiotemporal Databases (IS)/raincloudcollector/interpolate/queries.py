import matplotlib.pyplot as plt
from mpl_toolkits.basemap import Basemap
import numpy as np
from matplotlib.collections import LineCollection

import struct

segs = []
laList = []
lbList = []
infile = open('zcountPartNo_Rob_Check.txt','r')

for line in infile:
	if len(line ) == 0:
		continue
	if line[0] == '#':
#		print '-----'
		continue
	contents = line.split( );
	x1 = struct.unpack('!d', contents[0].decode('hex'))[0]
	y1 = struct.unpack('!d', contents[1].decode('hex'))[0]
	x2 = struct.unpack('!d', contents[2].decode('hex'))[0]
	y2 = struct.unpack('!d', contents[3].decode('hex'))[0]
	la = int( contents[4] )
	lb = int( contents[5] )
        segs.append(  ((x1,y1),(x2,y2)) )
        laList.append( la )
        lbList.append( lb )

r = range(6,11)
qSegs = []
for i in range( len(segs) ):
    if (laList[i] in r and lbList[i] not in r) or (laList[i] not in r and lbList[i] in r ):
        s = segs[i]
        print s[0][0], s[0][1], s[1][0], s[1][1]
        qSegs.append( s )




map = Basemap(projection='ortho',lat_0=30,lon_0=-60, resolution='l',area_thresh=1000)
map.fillcontinents(color='coral')
map.drawcoastlines()
map.drawcountries()
map.drawstates()
map.drawmapboundary( )
map.drawmeridians(np.arange(0,360,30))
map.drawparallels(np.arange(-90,90,30))


#line_segments = LineCollection( segs, # Make a sequence of x,y pairs
 #                               linewidths    = (2),
 #                               linestyles = 'solid',
#				)
for s in qSegs:
    map.drawgreatcircle( s[0][0], s[0][1], s[1][0],s[1][1],  linewidth=3, color='purple' )
plt.show()
