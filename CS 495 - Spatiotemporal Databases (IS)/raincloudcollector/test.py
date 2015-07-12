import region
import segLibrary
import profile
import timeit
import time
r1 = region.getRandomRegion( 200 )
r2 = region.getRandomRegion( 200 )
print len( r1 ), ' ', len(r2 )
start = time.clock()
#timeit.timeit('region.intersection( r1, r2  )','from __main__ import *', number=1)
#profile.run( 'region.intersection( r1, r2  )')
region.intersection( r1, r2  )
stop = time.clock()
print stop-start
exit()

s  = [((1,1),(6,6)),((2,1),(5,6)),((3,1),(3,6)),((2,4),(4,2.1)),((9.00001,9.00001),(9.00001, 9.00002))]
s2 = [((5,1),(5,6))]

r= segLibrary.calcNonIntersectingSegs( s )
print r
r1, r2 = segLibrary.segIntersection( s, s2 )
print r1
print '--'
print r2
print '----'


s = [((1,1),(6,3)),((5,4),(7,3)),((6,3),(7,3)),((5,4),(7,4)),((7,4),(8,5)),((6,5),(8,5)),((1,6),(6,5)),((1,1),(1,6))]

print segLibrary.snapEndPoints( s )


#103.017658718 41.9061990123 103.017658718 42.6609938303
#103.017658718 42.5891086095 103.017658718 42.6070799147
print segLibrary.isColinearAndOverlapping( ((103.017658718, 41.9061990123),( 103.017658718, 42.6609938303)),((103.017657708, 42.5891086095),( 103.017658718, 42.6070799147)))
print segLibrary.colinearValue((103.017658718,41.9061990123),( 103.017658718, 42.6609938303),(103.017657718, 42.5891086095) )
print segLibrary.colinearValue((103.017658718,41.9061990123),( 103.017658718, 42.6609938303),(103.017658718, 42.6070799147) )

print '--'







segs1=[ ((1,1),(5,1)),((5,1),(3,5)),((3,5),(1,1)) ]
segs2=[ ((1,2),(4,1)),((4,1),(5,1)),((5,1),(1,3)),((1,3),(1,2)) ]


hsegs1 = region.createRegionFromSegs( segs1 )
hsegs2 = region.createRegionFromSegs( segs2 )
result = region.intersection( hsegs1, hsegs2 )

print result
