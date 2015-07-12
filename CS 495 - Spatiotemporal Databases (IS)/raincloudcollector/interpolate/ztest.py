import region

#make a couple of regions

s1 = [((1,1),(5,1)),((1,1),(1,5)),((1,5),(5,5)),((5,1),(5,5))]
s2 = [((1,2),(2,2)),((1,2),(1,3)),((1,3),(2,3)),((2,1),(2,3))]
s3 = [((5,2),(5,3)),((5,2),(6,2)),((5,3),(6,3)),((6,2),(6,3))]
s4 = [((3,4),(6,4)),((3,4),(3,6)),((3,6),(6,6)),((6,4),(6,6))]


r1 = region.createRegionFromSegs( s1 )
r2 = region.createRegionFromSegs( s2 )
r3 = region.createRegionFromSegs( s3 )
r4 = region.createRegionFromSegs( s4 )

print region.difference( r1, r2 )
print 'RESULT'
print '---'
print region.difference( r1, r3 )
print 'RESULT'
print '---'
print region.difference( r1, r4 )
print 'RESULT'
print '---'
