
import sys
import matplotlib.pyplot as plt
from pylab import *
from matplotlib.collections import LineCollection
#from matplotlib.collections import CircleCollection
from matplotlib.collections import PatchCollection
from matplotlib.colors import colorConverter
from xml.etree import ElementTree as ET

if len( sys.argv ) < 2 or len( sys.argv ) > 3:
	print 'usage: python ', sys.argv[0], ' [line geometry file] [optional point geometry file]'
	exit()


pointFile = None

if len( sys.argv ) >= 2:
	lfName = sys.argv[1]
        lineFile  = open(lfName, 'r' )
if len( sys.argv ) >= 3:
	pfName = sys.argv[2]
        pointFile  = open(pfName, 'r' )

#set up axes
ax = axes()
segs = []
minx = 0
maxx = 0
miny = 0
maxy = 0
count = 0
for id, line in enumerate(lineFile):
        # if id > 0: break
        line = line[line.find( ':' )+1:]
        item = ET.fromstring( line )
        for t in item.iter():
                if t.text != None:
                        coords = t.text.strip( ' ')
                        coords = coords.split( ' ')
                        for i in range( len( coords)-1 ):
                                p1 = coords[i].split( ',' )
                                p2 = coords[i+1].split( ',' )
                                x1 = float( p1[0]  )
                                y1 = float( p1[1] )
                                x2 = float( p2[0] )
                                y2 = float( p2[1] )

                                segs.append( [ [ x1,  y1 ], [x2 ,  y2 ] ]  )
                                if count == 0:
                                        minx = x1
                                        maxx =x2
                                        miny =  y1
                                        maxy =  y2
                                        
                                if x1 < minx:
                                        minx = x1
                                if x2 < minx:
                                        minx = x2
                                if x1 > maxx:
                                        maxx = x1
                                if x2 > maxx:
                                        maxx = x2
                                if y1 < miny:
                                        miny = y1
                                if y2 < miny:
                                        miny = y2
                                if y1 > maxy:
                                        maxy = y1
                                if y2 > maxy:
                                        maxy = y2
                                        
                                count = count+1

pois = []
count = 1
if pointFile == None:
        pointFile = []
for id, line in enumerate(pointFile):
        # if id > 0: break
        line = line[line.find( ':' )+1:]
        item = ET.fromstring( line )
        for t in item.iter():
                if t.text != None:
                        coords = t.text.strip( ' ')
                        coords = coords.split( ' ')
                        for i in range( len( coords) ):
                                p1 = coords[i].split( ',' )
                                x1 = float( p1[0]  )
                                y1 = float( p1[1] )

                                pois.append( ( x1,  y1 ) )
                                if count == 0:
                                        minx = x1
                                        maxx = x1
                                        miny =  y1
                                        maxy =  y1
                                        
                                if x1 < minx:
                                        minx = x1
                                if x1 > maxx:
                                        maxx = x1
                                if y1 < miny:
                                        miny = y1
                                if y1 > maxy:
                                        maxy = y1
                                        
                                count = count+1
difXVal = (maxx - minx) * .05
difYVal = (maxy - miny) * .05
ax.set_xlim((minx - difXVal,maxx + difXVal))
ax.set_ylim((miny - difYVal,maxy + difYVal))


colors = [colorConverter.to_rgba(c) for c in ('r','g','b','c','y','m','k')]
print 'make a collection'
line_segments = LineCollection( segs, # Make a sequence of x,y pairs
                                linewidths    = (1),
                                linestyles = 'solid',
				colors = colors)
print 'formatting input'

endPointCircles = []
endPointSet = set()
for s in segs:
        endPointSet |= set([(s[0][0],s[0][1]), (s[1][0],s[1][1])])

for p in endPointSet:
	endPointCircles.append( Circle((p[0],p[1]), 20 ) )

#constraintPointCircles = []
#for p in pois:
#        constraintPointCircles.append( Circle((p[0],p[1]),50 ) )

endPatches = PatchCollection( endPointCircles, alpha=0.4,linewidths=6, edgecolor='k', facecolor='g')
#constraintPatches = PatchCollection( constraintPointCircles, alpha=1, facecolors = ['r'], linewidths=10, edgecolors='k')
#offs = []
#for s in segs:
#	offs.append( (s[0][0], s[0][1]) )
#        offs.append( (s[1][0], s[1][1]) )
#print offs
#circles = CircleCollection(sizes=(50,), offsets = offs ) 
print 'adding to collection'
ax.add_collection(line_segments)
ax.add_collection(endPatches )
#ax.add_collection(constraintPatches )

print 'plot it'
plt.plot([x for (x,y) in pois], [y for (x,y) in pois], 'ro' )
#sci(line_segments) 
show()
