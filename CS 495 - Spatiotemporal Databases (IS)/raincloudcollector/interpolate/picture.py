

import readBin as b
import regionInterpolator as RI
import region
import sys
import matplotlib.pyplot as plt
from mpl_toolkits.basemap import Basemap
import numpy as np
from matplotlib.collections import LineCollection

if len( sys.argv ) < 2:
    print 'enter file name'
    exit()

mr = b.readBin( sys.argv[1] )

segList = []
print len( mr )
# item 0 is the dbz value.  the rest of the items are regions
for i, reg in enumerate( mr ):
   if i == 0:
       continue
  #  if i>2:
  #      break
   snap = [ (r[0][0],r[0][1]) for r in reg if r[0][0][0] < r[0][1][0] or (r[0][0][0] == r[0][1][0] and r[0][0][1] < r[0][1][1] ) ]
   segList.append( snap )
    
# print on the map
map = Basemap(projection='ortho',lat_0=30,lon_0=-60, resolution='l',area_thresh=1000)
map.fillcontinents(color='coral')
map.drawcoastlines()
map.drawcountries()
map.drawstates()
map.drawmapboundary( )
map.drawmeridians(np.arange(0,360,30))
map.drawparallels(np.arange(-90,90,30))

print 'numregions: ', len( segList )
for snap in segList:
    print 'len of region: ', len( snap )
    for s in snap:
        map.drawgreatcircle( -s[0][0], s[0][1], -s[1][0],s[1][1],  linewidth=2, color='purple' )
plt.show()

# output for plotting
print '---'
for snap in segList:
    print '&&&\n'
    for s in snap:
        print s[0][0], s[0][1], s[1][0], s[1][1]

print '--- interping'

#interpolate
r1 = region.createRegionFromSegs( segList[0] )
r2 = region.createRegionFromSegs( segList[1] )
triTup = RI.interpolate( r1, r2, 1, 2, False)

# output 3d plot
RI.writeTrisToFile( triTup, 'z_tris.txt' )

# crate animation file. 
#MUST USE makeFrameFiles.py in visualization/plot to create the  individual pics
# then use ffmpeg -qscale 5 -r 20 -b 9600 -i z%05d.png movie.mp4
# to make the movie
f = open('debug_animated_tris.txt', 'w')
for interval in triTup:
	RI.appendToAnimationFile( interval, f, 20)
f.close()


