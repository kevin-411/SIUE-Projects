import hsegLibrary
import math
import collections
import convexHull
import region

def dot( u, v ):
	# returns dot product of vectors u and v
	return u[0]*v[0] + u[1]*v[1] + u[2]*v[2]

def crossProduct( v, u ):
	#returns cross product of u and v
	return( (v[1]*u[2]-u[1]*v[2]), (-v[0]*u[2]+u[0]*v[2]),(v[0]*u[1]-u[0]*v[1]) )


def triangleTriangleIntersection( tri1, tri2 ):
	'''
	triangles always have points [0] and [1] from the same slice.
	So ... always make segs with [0][2] and [1][2] for tri tri intersection
	We are only interested in intersections in the interior of triangles
	'''
	t1s1 = (tri1[0], tri1[2] )
	t1s2 = (tri1[1], tri1[2] )
	t2s1 = (tri2[0], tri2[2] )
	t2s2 = (tri2[1], tri2[2] )
	#for i in range(2):
	if triangleRayIntersection(   t1s1, tri2 ) > 0:
		return True
	elif triangleRayIntersection( t1s2, tri2 ) > 0:
		return True
	elif triangleRayIntersection( t2s1, tri1 ) > 0:
		return True
	elif triangleRayIntersection( t2s2, tri1 ) > 0:
		return True
	#	tri1 = (tri1[1], tri1[0], tri1[2] )
	#	tri2 = (tri2[1], tri2[0], tri2[2] )
	return False


def triangleRayIntersection( ray, tri ):
	'''
	ray is actually a seg in our case.  To conver this algorithm to use rays, change the line:
	    if r <= 0.0 or r >= 1.0:
	  to:
	    if r <= 0.0:
	We will always pass segs, since triangles will end at slice boundaries
	tri is a triangle a tuple of 3 3D points.  Triangle vertices in arbitrary order
	   Returns:
	   -1: triangle is degenerate (seg or a point)
	   0: disjoint
	   1: intersect in unique point
	   2: in the same plane.  
	   This function is modeled from triangle ray intersection algorithm at http://geomalgorithms.com/body_a06-_intersect-2.html#intersect3D_RayTriangle(),
	   although this algorithm is different to handle specific intersection cases differently.  Comments are included that identify
	   portions specific to our intersection needs
	   The code at http://geomalgorithms.com/body_a06-_intersect-2.html#intersect3D_RayTriangle() has the following copyright:
	         //Copyright 2001 softSurfer, 2012 Dan Sunday
		 // This code may be freely used and modified for any purpose
		 // providing that this copyright notice is included with it.
		 // SoftSurfer makes no warranty for this code, and cannot be held
		 // liable for any real or imagined damage resulting from its use.
		 // Users of this code must verify correctness for their application.
	   '''
	# easy test.  if the ray is a tri seg, return not intersecting
	# we don't consider a ray that is identical to a triangle edge to be intersecting
	tsegs = ((tri[0], tri[1] ), (tri[1], tri[0] ), (tri[0], tri[2] ), (tri[2], tri[0] ), (tri[1], tri[2] ), (tri[2], tri[1] ))
	if ray in tsegs:
		return 0

	
	SMALL_NUM = 0.00000001
	#u v n will be triangle vectors
	# dir, w0 and w will be ray vectors
	# r, a, b will be params to calc ray-plane intersect
	
	# get triangle edge vects and normal to plane
	u = (tri[1][0]-tri[0][0], tri[1][1]-tri[0][1], tri[1][2]-tri[0][2])
	v = (tri[2][0]-tri[0][0], tri[2][1]-tri[0][1], tri[2][2]-tri[0][2])
	n = crossProduct( u,v )
	if n == (0,0,0):
		return -1 #degenerate
	dir = (ray[1][0]-ray[0][0], ray[1][1]-ray[0][1], ray[1][2]-ray[0][2]) #ray direction vect
	w0 = (ray[0][0]-tri[0][0], ray[0][1]-tri[0][1], ray[0][2]-tri[0][2])
	a = float( -1*dot( n, w0 ) )
	b = float( dot( n, dir ) )
	if math.fabs( b ) < SMALL_NUM: #ray is parallel to tri
		if a == 0:  # ray lies in tri
			return 2  # ray overlaps the triangle
		else:
			return 0 #ray disjoint from plane
	# get intersect point of ray with triangle plane
	r = a/float(b)
	#check if intersect is beyond end of seg.  For a ray, only test with 0.0
	# we use <= and >= becuase we don't care abount end point intersections
	if r <= 0.0 or r >= 1.0: 
		return 0
	#get the intersection point of the seg and plane
	I = ( ray[0][0]+r*dir[0], ray[0][1]+r*dir[1], ray[0][2]+r*dir[2]  )
	#find if the point is inside the tri
	uu = dot( u, u)
	uv = dot( u, v)
	vv = dot( v, v)
	w = ( I[0]-tri[0][0], I[1]-tri[0][1], I[2]-tri[0][2] )
	wu = dot( w, u)
	wv = dot( w, v)
	D = uv*uv - uu*vv
	# get and test the parametric coords
	s = (uv*wv - vv*wu)/float(D)
	if s < 0.0 or s > 1.0: # I is outside tri
		return 0
	t = (uv*wu - uu*wv)/float(D)
	if t < 0.0 or (s+t) > 1.0: # I is outside tri
		return 0
	return 1  # intersection!  I is in the tri
	

def prepRegionForInterpolation( hsegs ):
	'''
	Assumes a valid region in hseg order returned from region.getRandomIntegerRegion()
	Assumes each cycle in the region has its own unique label, and -1 for exterior labels
	Returns the region with cycles labeled for interoplation
	Returns the convex hull points in CCW sequence
	Returns the cycle mapping.
	Returns list of connected cycles
	Returns a dict that maps a point to a list of cycles connected to that point
	'''
	# find which cycles are connected
	cycleConnectionMapList = hsegLibrary.getConnectedCycleMapping( hsegs )

	# relabel touching cycles to label of the cycle that comes first in hseg order
	hsegs = hsegLibrary.relabelTouchingCyclesToFirstCycleNum( hsegs, cycleConnectionMapList )
	# add halfsegments such that every cycle is connected to some an enclosing cycle, or 
	# adjacent cycle.  After this step, cycles will form a connected graph
	hsegs = hsegLibrary.addVerticalConnectorsPS( hsegs, len( cycleConnectionMapList )-1 )

	# get points in CCW order around outer cycle of region
	poiList = hsegLibrary.getOuterWalkPointSequence( hsegs )
	# compute the convex hull of the region
	hull = convexHull.getHullFromSequence( poiList )
	# assign labels to cycles and connectors to reflect concavities
	hsegs = hsegLibrary.assignCycleLabelsForConcavityMapping( hsegs )
	# get mappings of connected cycles
	mapping, hsegs, connCycleLists, poiToCycLabelDict = hsegLibrary.getConnectedCycleMappingConcav( hsegs )

	return hsegs, hull, mapping, connCycleLists, poiToCycLabelDict



def angleFromVertical( seg ):
	PI = math.pi
	p = seg[0]
	q = seg[1]
	px = p[0]
	py = p[1]
	qx = q[0]
	qy = q[1]

	# check if angle is 0, 360, or 180
	if px == qx:
		if py > qy:
			return 0
	
		else:
			return 180
	#check if angle is 90 or 270
	if py == qy:
		if px < qx:
			return 90
		else:
			return 270
	#translate points to origin
	qx = qx-px
	qy = qy-py
	# get angle from x axis
	angle = math.atan2( qx, qy) *(180/PI)
	
	if qx < 0:
		angle *= -1
		angle += 90
	elif qy < 0:
		angle = 180 - angle + 270
	else:
		angle = 90-angle
	#shift the angle to orient from the vertical
	angle += 90
	if angle > 360:
		angle = angle - 360
	return angle

def writeTrisToFile( triTup, fileName ):
	'''
	expects an iterable containing iterables ( a list of lists).
	Each iterable contained in the first contains triangles.  
	A trianlge is a 3 tuple of points (p0, p1, p2) == ( (x0,y0,z0), (x1,y1,z1), (x2,y2,z2) ) or 3d points
	A point is a 3 tuple.  
	triTup = (listofTris1, listofTris2,...) 
	    where listofTrisX = [t1, t2, t3,...]
	    where tX = (p1,p2,p3) 
	    where pX=(x0, y0, z0,)
	Prints the contents to a file named fileName.  will clobber that file
	'''
	f = open( fileName, 'w')
	for triList in triTup:
		if triList != None:
			for t in triList:
				s1 = str(t[0][0])+' '+ str(t[0][1])+' '+ str(t[0][2])+' '+ str(t[1][0])+' '+ str(t[1][1])+' '+ str(t[1][2]) + '\n'
				s2 = str(t[0][0])+' '+ str(t[0][1])+' '+ str(t[0][2])+' '+ str(t[2][0])+' '+ str(t[2][1])+' '+ str(t[2][2]) + '\n'
				s3 = str(t[2][0])+' '+ str(t[2][1])+' '+ str(t[2][2])+' '+ str(t[1][0])+' '+ str(t[1][1])+' '+ str(t[1][2]) + '\n'
				f.write( s1 )
				f.write( s2 )
				f.write( s3 )
			f.write( '\n')
	f.close()


def appendToAnimationFile( triList, fileObject, numFrames = 100 ):
	'''
	Writes snapshots to a file.  file object should already be open and writeable
	triList is an iterable of triangles
	a triangle is a 3 tuple containind 3 3d points:  ( (x0,y0,z0), (x1,y1,z1), (x2,y2,z2) ) 

	Writes segs to the text file for a snapshot, then appends a newline.
	'''
	if triList == None:
		return
	if not isinstance(triList, collections.Iterable) or numFrames < 1:
		raise Exception( 'triList must be iterable and numFrames > 0')
	numer  = 0.0
	denom = numFrames
	for i in range( numFrames+1 ):
		multiplier = numer/denom
		for t in triList:
			# get the segs representing endpoint movement
			s1 = (t[2], t[0])
			s2 = (t[2], t[1])
			if t[0][2] < t[2][2]:  #make sure lower z value is 1st in the seg
				s1 = (t[0], t[2])
				s2 = (t[1], t[2])
			if i == 0: # check if its a boundary print
				x1,y1,z1 = s1[0]
				x2,y2,z2 = s2[0]
				fileObject.write( str(x1)+' '+str(y1)+' '+str(x2)+' '+str(y2)+'\n') 
			elif i == numFrames:
				x1,y1,z1 = s1[1]
				x2,y2,z2 = s2[1]
				fileObject.write( str(x1)+' '+str(y1)+' '+str(x2)+' '+str(y2)+'\n') 
			elif i > 0  and i < numFrames:
				x1 = ((s1[1][0]-s1[0][0])*multiplier)+s1[0][0]
				y1 = ((s1[1][1]-s1[0][1])*multiplier)+s1[0][1]
				#z1 = ((s1[1][2]-s1[0][2])*multiplier)+s1[0][2]
				x2 = ((s2[1][0]-s2[0][0])*multiplier)+s2[0][0]
				y2 = ((s2[1][1]-s2[0][1])*multiplier)+s2[0][1]
				#z2 = ((s2[1][2]-s2[0][2])*multiplier)+s2[0][2]
				fileObject.write( str(x1)+' '+str(y1)+' '+str(x2)+' '+str(y2)+'\n') 
		numer+=1
		fileObject.write('\n')
	

def isColinearAndOverlapping( Lseg, Rseg, tolerance = .000001 ):
	L = (Lseg[0], Lseg[1])
	R = (Rseg[0], Rseg[1])
	
	if L == None or R == None:
		return False
	if L == R or L == (R[1], R[0]):
		return True
	negt = tolerance * -1
	# will be colinear if l1,l2,r1 and l1,l2,r2 are all within tolerance
	v1 = colinearValue( L[0], L[1], R[0])
	v2 = colinearValue( L[0], L[1], R[1])
	if negt <= v1 and v1 <= tolerance and negt <= v2 and v2 <= tolerance:
		# lines are colinear. values to compare
		ll = L[0][0]
		lu = L[1][0]
		rl = R[0][0]
		ru = R[1][0]
		if ll == lu: #vertical lines
			ll = L[0][1]
			lu = L[1][1]
			rl = R[0][1]
			ru = R[1][1]
		if lu < ll:
			tmp = ll
			ll = lu
			lu = tmp
		if ru < rl:
			tmp = rl
			rl = ru
			ru = tmp
		# if one value from R is between the values from L, they are colinear and overlapping
		# eqivalent segs are checked way at the top
		if ((ll < rl and rl < lu) or ( ll < ru and ru < lu)) or  ((rl < ll and ll < ru) or ( rl < lu and lu < ru)):
			return True
	return False

def colinearValue( p1,p2,p3):
	# will return a 0 if p1, p2,p3 are exactly colinear
	# will return positive value if it forms a left turn
	# will return neg value if it forms a right turn
	p1x = p1[0]
	p1y = p1[1]
	p2x = p2[0]
	p2y = p2[1]
	p3x = p3[0]
	p3y = p3[1]
	return  ((p3y - p1y) * (p2x - p1x)) - ((p2y - p1y) * (p3x - p1x))
	
	
def writeHsegsToTextFile( fileName, hsegs ):
	f = open( fileName, 'w' )
	for h in hsegs:
		if hsegLibrary.isLeft( h ):
			outStr = str(h[0][0][0]) +' ' +str(h[0][0][1]) +' ' +str(h[0][1][0]) +' ' +str(h[0][1][1]) +' ' +str(h[1]) +' ' +str(h[2]) +'\n'
			f.write( outStr )
	f.close()
def writeSegsToTextFile( fileName, segs ):
	f = open( fileName, 'w' )
	for h in segs:
		outStr = str(h[0][0]) +' ' +str(h[0][1]) +' ' +str(h[1][0]) +' ' +str(h[1][1]) +' 1 1\n'
		f.write( outStr )
	f.close()

def interpolate(r1,r2, startTime, endTime, noTriIntersectionChecks = False ):
	'''
	creates motion triangles describing the movement of segs across an interval to interpolate between regions.
	returns 3 list, corresponding to the maximum of 3 time intervals that may be produced.  If a list is empty,
	that time interval was not used.  The middle interval always has something in it.
	If noTriIntersectionChecks is set to True, the first and last intervals wil always be empty.
	'''
	r1, r1Hull, r1LabelMapping, r1ConnCycLists, r1PoiToCycLabelDict  = prepRegionForInterpolation( r1 )
	r2, r2Hull, r2LabelMapping, r2ConnCycLists, r2PoiToCycLabelDict  = prepRegionForInterpolation( r2 )
	
	r1ConnectorSegSet = set( [h[0] for h in r1 if h[1] == -h[2] and( h[1] == 2 or h[2] == 2 or h[1]==1 or h[2]==1)  ] )
	r2ConnectorSegSet = set( [h[0] for h in r2 if h[1] == -h[2] and( h[1] == 2 or h[2] == 2 or h[1]==1 or h[2]==1) ] )
	
	r1HullTris, r2HullTris, r1ConcTris, r1ConcHullSeg, r2ConcTris, r2ConcHullSeg = createMotionPlan( r1, r1Hull, r1ConnCycLists, r1PoiToCycLabelDict, r2, r2Hull, r2ConnCycLists, r2PoiToCycLabelDict, startTime, endTime)
	
	printList = [r1HullTris+r2HullTris]
	printList.append( [t for clist in r1ConcTris for t in clist] )
	printList.append(  [t for clist in r2ConcTris for t in clist] )
	writeTrisToFile( printList, 'debug_tri3d_initial.txt')

	
	if noTriIntersectionChecks:
		# create the return list
		triList = r1HullTris+r2HullTris
		triList.extend( [t for clist in r1ConcTris for t in clist] )
		triList.extend( [t for clist in r2ConcTris for t in clist] )
		return( None, triList, None )
		
	
	# check for tri tri intersections
	# can do this in parallel
	# need to check hull tris against all concavity tris
	# Not a true statement::: a tri from a hull to a hull will never intersect a concavity tri
	intersectingConcs = []
	for t in r1HullTris:
		for i,tList in enumerate( r1ConcTris ):
			for c in tList:
				if triangleTriangleIntersection( t,c ):
					intersectingConcs.append( ((i,1), (i,1) ) )
					break
		
	for t in r2HullTris:
		for i,tList in enumerate( r2ConcTris ):
			for c in tList:
				if triangleTriangleIntersection( t,c ):
					intersectingConcs.append( ((i,2), (i,2) ) )
					break
					
	# need to check concavity tris against each other
       	# make lists of all concavity tris, and their concav ID
	c1AllConcTris = [ (c,i,1) for i,cList in enumerate( r1ConcTris ) for c in cList]
	c2AllConcTris = [ (c,i,2) for i,cList in enumerate( r2ConcTris ) for c in cList]
	c1AllConcTris = c1AllConcTris+ c2AllConcTris 

	for i in range( len(c1AllConcTris)-1):
		for j in range( i+1, len( c1AllConcTris ) ):
			c1 = c1AllConcTris[i]
			c2 = c1AllConcTris[j]
			if triangleTriangleIntersection( c1[0], c2[0] ):
				intersectingConcs.append( ((c1[1],c1[2]), (c2[1],c2[2]) ) )
	
#		evapConcs = set(r1ConcsThatIntersectWithHullTris)
#		condenseConcs = set(r2ConcsThatIntersectWithHullTris)
	evapConcs = set()
	condenseConcs =set()
	# remove duplicate mappings.  a mapping will be ordered first by sliceID 1 or 2, and then by concID
	for i,cmap in enumerate( intersectingConcs ):
		#intersecting conc map s a tuple with ((concID, sliceID), (concID, sliceID))
		if cmap[1][1] < cmap[0][1] or (cmap[1][1] == cmap[0][1] and cmap[1][0] < cmap[0][0]):
			intersectingConcs[i] = (cmap[1], cmap[0])
	intersectingConcsSet = set()
	for cmap in intersectingConcs:
		intersectingConcsSet |= set([cmap])

	# now put concs in the appropriate set.  We only need to get rid of 1 conc if there is an intersection
	# if a conc is already in a evap or condense set, we don't need to do anything else.
	# otherwise, use the first concID in the tuple.  It will favor slice 1 and lower conc IDs
	for cmap in intersectingConcsSet:
		if cmap[0][1] == 1 and cmap[0][0] in evapConcs: continue
		elif cmap[1][1] == 1 and cmap[1][0] in evapConcs: continue
		elif cmap[0][1] == 2 and cmap[0][0] in condenseConcs: continue
		elif cmap[1][1] == 2 and cmap[1][0] in condenseConcs: continue
		elif cmap[0][1] == 1: evapConcs |= set([cmap[0][0]])
		else: condenseConcs |= set([cmap[0][0]])
			
	
	# split times indicate the time boundaries for evapping and condensing steps
	# make changes to them here for more dynamic time interval time splitting mechanisms
	# right now its just a static split.  
	splitTime1 = 1.2 * startTime
	splitTime2 = 0.8 * endTime
	# create triangles for offending concs.  append the hull seg to the tri, make a region out of it, triangulate it
	#evap tris are planar in the original region.  We will need to find a point int he dest region and make 
	# 1 motion tri to it for each edge of a evapTri
	evapTris = []
	evapMotionSegs = []
	for i in evapConcs:
		# get the conc segs
		concSegs = [((ct[0][0], ct[0][1]), (ct[1][0],ct[1][1])) for ct in r1ConcTris[i]]
		# conc segs need to move in place for condense step
		for s in concSegs: # create in place movement for conc boundaries
			if s not in r1ConnectorSegSet:  # do not put it in
				evapMotionSegs.append( (s[0]+(splitTime1,), s[1]+(splitTime1,), s[0]+(startTime,), False) )
				evapMotionSegs.append( (s[0]+(startTime,), s[1]+(startTime,), s[1]+(splitTime1,), True) )
		if r1ConcHullSeg[i] != None:
			concSegs.append( r1ConcHullSeg[i] )
		# triangulate it
		hsegs = region.createRegionFromSegs( concSegs )
		writeHsegsToTextFile( 'debug_tri_hsegs_evap'+str(i)+'.txt', hsegs )
		writeSegsToTextFile( 'debug_tri_segs_evap'+str(i)+'.txt', concSegs )
		theTris =  hsegLibrary.triangulate( hsegs )
		theTris = [ t+(i,) for t in theTris ]
		evapTris.extend( theTris )
	
	# create mappings.  triangles map to points in thier interior Always map from point to seg
	# use midpoint of one tri boundary, then midpoint of that to the other tri point
	# So... point is always in the lower time, seg in the upper time
	for t in evapTris:
		midX = (t[0][0]+t[1][0])/2.0
		midY = (t[0][1]+t[1][1])/2.0
		midX = (midX + t[2][0]) /2.0
		midY = (midY + t[2][1]) /2.0
		p = (midX, midY)
		validAtBoundary =  (r1ConcHullSeg[t[3]]!= None and isColinearAndOverlapping( (t[0], t[1]), r1ConcHullSeg[t[3]] )) or (t[0],t[1]) in r1ConnectorSegSet or (t[1],t[0]) in r1ConnectorSegSet
		evapMotionSegs.append( (t[0]+(splitTime1,), t[1]+(splitTime1,), p+(startTime,), validAtBoundary) )
		validAtBoundary =  (r1ConcHullSeg[t[3]]!= None and isColinearAndOverlapping( (t[0], t[2]), r1ConcHullSeg[t[3]] )) or (t[0],t[2]) in r1ConnectorSegSet or (t[2],t[0]) in r1ConnectorSegSet
		evapMotionSegs.append( (t[0]+(splitTime1,), t[2]+(splitTime1,), p+(startTime,), validAtBoundary) )
		validAtBoundary =  (r1ConcHullSeg[t[3]]!= None and isColinearAndOverlapping( (t[1], t[2]), r1ConcHullSeg[t[3]] )) or (t[1],t[2]) in r1ConnectorSegSet or (t[2],t[1]) in r1ConnectorSegSet
		evapMotionSegs.append( (t[1]+(splitTime1,), t[2]+(splitTime1,), p+(startTime,), validAtBoundary) )
	
	# repeat for condense segs
	condTris = []
	condMotionSegs = []
	for i in condenseConcs:
		# get the conc segs
		concSegs = [((ct[0][0], ct[0][1]), (ct[1][0],ct[1][1])) for ct in r2ConcTris[i]]
		# conc segs need to move in place for condense step
		for s in concSegs: # create in place movement for conc boundaries
			if s not in r2ConnectorSegSet:  # do not put it in
				condMotionSegs.append( (s[0]+(splitTime2,), s[1]+(splitTime2,), s[0]+(endTime,), False) )
				condMotionSegs.append( (s[0]+(endTime,), s[1]+(endTime,), s[1]+(splitTime2,), True) )
		if r2ConcHullSeg[i] != None:
			concSegs.append( r2ConcHullSeg[i] )
		# triangulate it
		hsegs = region.createRegionFromSegs( concSegs )
		writeHsegsToTextFile( 'debug_tri_hsegs_cond'+str(i)+'.txt', hsegs )
		writeSegsToTextFile( 'debug_tri_segs_cond'+str(i)+'.txt', concSegs )
		theTris = hsegLibrary.triangulate( hsegs )
		theTris = [ t+(i,) for t in theTris ]
		condTris.extend( theTris )

	# create mappings from interior points.  
	for t in condTris:
		midX = (t[0][0]+t[1][0])/2.0
		midY = (t[0][1]+t[1][1])/2.0
		midX = (midX + t[2][0]) /2.0
		midY = (midY + t[2][1]) /2.0
		p = (midX, midY)
		validAtBoundary = (r2ConcHullSeg[t[3]]!= None and isColinearAndOverlapping( (t[0], t[1]), r2ConcHullSeg[t[3]] )) or (t[0],t[1]) in r2ConnectorSegSet or (t[1],t[0]) in r2ConnectorSegSet
		condMotionSegs.append( (t[0]+(splitTime2,), t[1]+(splitTime2,), p+(endTime,), validAtBoundary) )
		validAtBoundary =  (r2ConcHullSeg[t[3]]!= None and isColinearAndOverlapping( (t[0], t[2]), r2ConcHullSeg[t[3]] )) or (t[0],t[2]) in r2ConnectorSegSet or (t[2],t[0]) in r2ConnectorSegSet
		condMotionSegs.append( (t[0]+(splitTime2,), t[2]+(splitTime2,), p+(endTime,), validAtBoundary) )
		validAtBoundary =  (r2ConcHullSeg[t[3]]!= None and isColinearAndOverlapping( (t[1], t[2]), r2ConcHullSeg[t[3]] )) or (t[1],t[2]) in r2ConnectorSegSet or (t[2],t[1]) in r2ConnectorSegSet
		condMotionSegs.append( (t[1]+(splitTime2,), t[2]+(splitTime2,), p+(endTime,), validAtBoundary) )
	
	# create intermediate regions.  remove segs from offending concs, add in the hullseg
	# create evap intermediate region.  Map segs to themselves except for segs in evap concs
	allInterval1Tris = None
	if len( evapMotionSegs ) > 0: # we need to add the evap step
		# all segs map to themselves, except for the evap segs, which already have motion tris
		interval1Tris = []
		for t in r1HullTris:
			interval1Tris.append( (t[0], t[1], (t[0][0], t[0][1], splitTime1) ) )
			interval1Tris.append( ( (t[0][0],t[0][1], splitTime1), (t[1][0], t[1][1], splitTime1), t[1] ) )
		for i,cList in enumerate( r1ConcTris ):
			if i not in evapConcs:
				for t in cList:
					if  ( (t[0][0],t[0][1]), (t[1][0], t[1][1])) not in r1ConnectorSegSet: # dont put it in
						interval1Tris.append( (t[0], t[1], (t[0][0], t[0][1], splitTime1)) )
						interval1Tris.append( ( (t[0][0],t[0][1], splitTime1), (t[1][0], t[1][1], splitTime1), t[1] ) )
		allInterval1Tris = interval1Tris + evapMotionSegs
	else:
		splitTime1 = startTime
	# repeat for condense concs
	allInterval3Tris = None
	if len( condMotionSegs ) > 0:
		interval3Tris = []
		for t in r2HullTris:
			interval3Tris.append( (t[0], t[1], (t[0][0], t[0][1], splitTime2)) )
			interval3Tris.append( ( (t[0][0],t[0][1], splitTime2), (t[1][0], t[1][1], splitTime2), t[1] ) )
		for i,cList in enumerate( r2ConcTris ):
			if i not in condenseConcs:
				for t in cList:
					if  ( (t[0][0],t[0][1]), (t[1][0], t[1][1])) not in r2ConnectorSegSet: # dont put it in
						interval3Tris.append( (t[0], t[1], (t[0][0], t[0][1], splitTime2)) )
						interval3Tris.append( ( (t[0][0],t[0][1], splitTime2), (t[1][0], t[1][1], splitTime2), t[1] ) )
		allInterval3Tris = interval3Tris + condMotionSegs
	else:
		splitTime2 = endTime
	# finally creat the mid interval.  add all r1 hull tris and r2 hull tris, with the updated time stamps
	# add all conc tris with updated time stamps that are not in either of the condense or evap sets
	# add hull segs for conc tris that are in the evap and condense sets, and map them to whatever point the concavity had mapped to
	allInterval2Tris = None
	if allInterval1Tris == None and allInterval3Tris == None:
		# just return the original mapping
		allInterval2Tris = r1HullTris + r2HullTris
		for cList in r1ConcTris:
			allInterval2Tris.extend( cList )
		for cList in r2ConcTris:
			allInterval2Tris.extend( cList )
	
	else:
		#add hull tris
		r1HullTris = [( (t[0][0],t[0][1], splitTime1),(t[1][0],t[1][1], splitTime1), (t[2][0],t[2][1], splitTime2))  for t in r1HullTris]
		r2HullTris = [( (t[0][0],t[0][1], splitTime2),(t[1][0],t[1][1], splitTime2), (t[2][0],t[2][1], splitTime1))  for t in r2HullTris]
		allInterval2Tris = r1HullTris + r2HullTris
		# add non evapped or condensed conc tris
		for i,cList in enumerate( r1ConcTris ):
			if i not in evapConcs:
				for t in cList:
					allInterval2Tris.append( ((t[0][0],t[0][1], splitTime1),(t[1][0],t[1][1], splitTime1), (t[2][0],t[2][1], splitTime2)) )
		for i,cList in enumerate( r2ConcTris ):
			if i not in condenseConcs:
				for t in cList:
					allInterval2Tris.append( ((t[0][0],t[0][1], splitTime2),(t[1][0],t[1][1], splitTime2), (t[2][0],t[2][1], splitTime1)) )
		# add hull tris for the evapped/ condensed concs
		for i in evapConcs:
			h = r1ConcHullSeg[i]
			if h != None:   # will be none if it is a hole /nestedhole/cyc configuration that attaches
				mapPoi = r1ConcTris[i][0][2] # conclist, tri, map-to point
				mapPoi = ( mapPoi[0], mapPoi[1], splitTime2 )
				allInterval2Tris.append( ((h[0][0],h[0][1], splitTime1),(h[1][0],h[1][1], splitTime1), mapPoi) )
		for i in condenseConcs:
			h = r2ConcHullSeg[i]
			if h != None:  # will be none if it is a hole /nestedhole/cyc configuration that attaches
				mapPoi = r2ConcTris[i][0][2] # conclist, tri, map-to point
				mapPoi = ( mapPoi[0], mapPoi[1], splitTime1 )
				allInterval2Tris.append( ((h[0][0],h[0][1], splitTime2),(h[1][0],h[1][1], splitTime2), mapPoi) )
	
	# now test for boundary existence.  A segment only shows up on a boundary if it appears exactly once 
	allInterval1Tris = checkBoundaryExistence( allInterval1Tris )
	allInterval2Tris = checkBoundaryExistence( allInterval2Tris )
	allInterval3Tris = checkBoundaryExistence( allInterval3Tris )
	#Finished!
	return (allInterval1Tris, allInterval2Tris, allInterval3Tris )


def checkBoundaryExistence( tris ):
	# only include segs in the boundary if they occur exactly once
	# otherwise its triangles converging on each other.  Tris converging on hull
	# segs have already been removed
	if tris == None:
		return None
	#resTris = []
	#for t in tris:
	#	if len(t) == 3:
	#		resTris.append( (t[0], t[1], t[2], True) )
	#	else:
	#		resTris.append( t )
	#return resTris
	seenSet = set()
	seenTwiceSet = set()		
	for t in tris:
		# get the seg portion, make sure first point is less than second
		if len( t) == 4 and t[3] == False:
			continue
		s = (t[0], t[1])
		if not( s[0][0] < s[1][0] or ( s[0][0] == s[1][0] and s[0][1] < s[1][1] )):
			s = (t[1], t[0])
		if s not in seenSet:
			seenSet |= set([s])
		else:
			seenTwiceSet |= set([s])
	resTris = []
	#triangle whose seg is not in seenTwiceSet exist at boundary, otherwise it does not
	for t in tris:
		# get the seg portion, make sure first point is less than second
		s = (t[0], t[1])
		if not( s[0][0] < s[1][0] or ( s[0][0] == s[1][0] and s[0][1] < s[1][1] )):
			s = (t[1], t[0])
		if s in seenTwiceSet:
			# does not exist at boundary
			resTris.append( (t[0], t[1], t[2], False) )
		else:
			val = True
			if len( t ) == 4:
				val = t[3]
			resTris.append( (t[0], t[1], t[2], val) )
	
	return resTris
		

def createMotionPlan( r1, r1Hull, r1ConCycles, r1PoiToCycLabelDict, r2, r2Hull, r2ConCycles, r2PoiToCycLabelDict, startTime, endTime ):
	'''
	create motion triangles from r1 to r2.  start time must be earlier than end time.
	r1 must be the earlier (source) region, r2 the later (destination) region
	
	walk the outer cycles (cycles with a 2 label from the prep functions above) and convex hulls concurrently
	any concavities map to a single point on the opposing region.  Any cycles are treated as concavities.
	connectors other than connectors with a 2,-2 label will disappear...poof
	'''
	index1 = 0
	index2 = 0
	hullIndex1 = 0
	hullIndex2 = 0
	#last seg will be largest around first dom point
	lastIndex1 = 0
	lastIndex2 = 0
	while r1[lastIndex1+1][0][0] == r1Hull[0]: lastIndex1+=1
	while r2[lastIndex2+1][0][0] == r2Hull[0]: lastIndex2+=1		
	# create a hash table for the seg portions mapped to their index
	r1IndexLookup = dict()
	for i, h in enumerate( r1 ):
		r1IndexLookup[h[0]] = i
	# create a hash table for the seg portions mapped to their index
	r2IndexLookup = dict()
	for i, h in enumerate( r2 ):
		r2IndexLookup[h[0]] = i
	# classes to hold the resulting tris
	r1HullTris = []
	r2HullTris = []
	r1ConcTris = []
	r2ConcTris = []
	r1ConcHullSeg = []
	r2ConcHullSeg = []
	
	# whichever region has advanced a hull seg will have an entire seg in the mapping.  start off assuming that is r1
	mapR1Seg = True
	# put the start hull poi at the end so we don't have to do a bunch of if statements to wrap around
	r1Hull.append( r1Hull[0] )
	r2Hull.append( r2Hull[0] )
	#r1HullSeg = r1Hull[hullIndex1], r1Hull[hullIndex1+1]
	#r2HullSeg = r2Hull[hullIndex2], r2Hull[hullIndex2+1]
	#r1CurrSeg = r1[index1][0]
	#r2CurrSeg = r2[index2][0]
	#walk'em
	while True:
		if mapR1Seg:
			# we will map the seg or concavity chain starting at the current hull poi.  go ahead and update the hull index
			hullIndex1 += 1
			# if the seg is a hull seg, just map it p from the r2 seg
			if  r1[index1][0][1] == r1Hull[ hullIndex1 ]: 
				r1HullTris.append(  (r1[index1][0][0]+(startTime,), r1[index1][0][1]+(startTime,), r2Hull[hullIndex2]+(endTime,) ) )
				if r1[index1][0][0] in r1PoiToCycLabelDict:
					r1ConcTris.append( [] )
					currListIndex = len(r1ConcTris)-1
					r1ConcHullSeg.append( None ) # no closing Hull hseg, all interior cycles 
					cycNumList = r1PoiToCycLabelDict.pop( r1[index1][0][0] )
					for cycID in cycNumList:
						for h in r1ConCycles[cycID]:
							if hsegLibrary.isLeft( h ):
								r1ConcTris[currListIndex].append(  (h[0][0]+(startTime,), h[0][1]+(startTime,), r2Hull[hullIndex2]+(endTime,) ) )
				index1 = hsegLibrary.getNextOuterCycleWalkIndex( r1[index1], r1, r1IndexLookup )
			else:
				#we are on an r1 concavity.  map until we get to the next hull poi
				r1ConcTris.append( [] )
				currListIndex = len(r1ConcTris)-1
				r1ConcHullSeg.append( (r1Hull[hullIndex1-1], r1Hull[hullIndex1]) )
				while r1[index1][0][0] != r1Hull[ hullIndex1 ]:
					r1ConcTris[currListIndex].append( (r1[index1][0][0]+(startTime,), r1[index1][0][1]+(startTime,), r2Hull[hullIndex2]+(endTime,) ) )
					#Insert connected structures that touch here too
					if r1[index1][0][0] in r1PoiToCycLabelDict:
						cycNumList = r1PoiToCycLabelDict.pop( r1[index1][0][0] )
						for cycID in cycNumList:
							for h in r1ConCycles[cycID]:
								if hsegLibrary.isLeft( h ):
									r1ConcTris[currListIndex].append( (h[0][0]+(startTime,), h[0][1]+(startTime,), r2Hull[hullIndex2]+(endTime,) ) )
					index1 = hsegLibrary.getNextOuterCycleWalkIndex( r1[index1], r1, r1IndexLookup )
		else:   #we are mapping an R2 seg.  Do the same as above, but map to r2
			# we will map the seg or concavity chain starting at the current hull poi.  go ahead and update the hull index
			hullIndex2 += 1
			# if the seg is a hull seg, just map it p from the r1 seg
			if  r2[index2][0][1] == r2Hull[ hullIndex2 ]:
				r2HullTris.append(  (r2[index2][0][0]+(endTime,), r2[index2][0][1]+(endTime,), r1Hull[hullIndex1]+(startTime,) ) )
				if r2[index2][0][0] in r2PoiToCycLabelDict:
					r2ConcTris.append( [] )
					currListIndex = len(r2ConcTris)-1
					r2ConcHullSeg.append( None ) # no closing Hull hseg, all interior cycles 
					cycNumList = r2PoiToCycLabelDict.pop( r2[index2][0][0] )
					for cycID in cycNumList:
						for h in r2ConCycles[cycID]:
							if hsegLibrary.isLeft( h ):
								r2ConcTris[currListIndex].append(  (h[0][0]+(endTime,), h[0][1]+(endTime,), r1Hull[hullIndex1]+(startTime,) ) )
				index2 = hsegLibrary.getNextOuterCycleWalkIndex( r2[index2], r2, r2IndexLookup )
			else:
				#we are on an r1 concavity.  map until we get to the next hull poi
				r2ConcTris.append( [] )
				currListIndex = len(r2ConcTris)-1
				r2ConcHullSeg.append( (r2Hull[hullIndex2-1], r2Hull[hullIndex2]) )
				while r2[index2][0][0] != r2Hull[ hullIndex2 ]:
					r2ConcTris[currListIndex].append( (r2[index2][0][0]+(endTime,), r2[index2][0][1]+(endTime,), r1Hull[hullIndex1]+(startTime,) ) )
					#Insert connected structures that touch here too
					if r2[index2][0][0] in r2PoiToCycLabelDict:
						cycNumList = r2PoiToCycLabelDict.pop( r2[index2][0][0] )
						for cycID in cycNumList:
							for h in r2ConCycles[cycID]:
								if hsegLibrary.isLeft( h ):
									r2ConcTris[currListIndex].append( (h[0][0]+(endTime,), h[0][1]+(endTime,), r1Hull[hullIndex1]+(startTime,) ) )
					index2 = hsegLibrary.getNextOuterCycleWalkIndex( r2[index2], r2, r2IndexLookup )
		if hullIndex1 == len( r1Hull)-1 and hullIndex2 == len( r2Hull )-1:
			#done
			break
		
		#now pick if we map the r1 hull set or the r2 hull set in the next round
		if hullIndex1 == len( r1Hull )-1:
			mapR1Seg = False
			continue
		elif hullIndex2 == len( r2Hull )-1:
			mapR1Seg = True
			continue
		else:
			h1angle = angleFromVertical( (r1Hull[hullIndex1], r1Hull[hullIndex1+1]) )
			h2angle = angleFromVertical( (r2Hull[hullIndex2], r2Hull[hullIndex2+1]) )
			if h2angle < h1angle:
				mapR1Seg = False
			else:
				mapR1Seg = True
		
	return r1HullTris, r2HullTris, r1ConcTris, r1ConcHullSeg, r2ConcTris, r2ConcHullSeg
		
