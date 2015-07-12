import segLibrary
import hsegLibrary
import struct

def getRandomIntegerRegion( numRandomSegsToGenerate = 50, percentOfSegsToRemove = .05 ):
	'''
	generates a region from random segments.
	input:
	   numRandomSegsToGenerate: the number of random segs to generate.  The actual region
	       will have many fewer segs than this.  Higher numbers will typically generate more complex regions.
	       The region will be constructed by intersecting the reandom segs, and finding a region
	       among the resulting segs.
	   percentOfSegsToRemove: Once random segments are generated and intersected such that all
	       segments only intersect at endpoints, some segments will be removed at random.
	       This parameter indicates the percentage of overall segs that will be removed. A 
	       higher number typically causes regions to have less regular shapes.  Note that a high percentage
	       may require a larger number of random segs to be generated.
	returns:
	     hsegs:  an ordered list of half segments with valid labels.  
	         A half segment is a tuple with the following:
	              ((x,y)(x,y), labelAbove, labelBelow)
		      labels are integral values
		      an interior label will be positive.  An exterior label will be -1
		 hsegs will be ordered in half segment order
		 Each cycle in hsegs will have its own unique label number
	'''
	if numRandomSegsToGenerate == None:
		numRandomSegsToGenerate = 50
	if percentOfSegsToRemove == None:
		percentOfSegsToRemove = .05
	#random.seed()
	# got a bunch of random segs with integer endpoints	
	segs = segLibrary.createRandomSegs( numRandomSegsToGenerate )
	# find their intersections, but make sure endpoints are integers
	segs = segLibrary.calcNonIntersectingSegsIntEndPoints(segs)
	#randomly remove some of the segs
	segs = segLibrary.removeRandSegs( segs, percentOfSegsToRemove )
	# create a region, favoring large (as in... containing lots of segments) cycles
	hsegs = hsegLibrary.extractAllLargeValidCycles( segs )
	return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )

def getRandomRegion( numRandomSegsToGenerate = 50, percentOfSegsToRemove = .05 ):
	'''
	generates a region from random segments.
	input:
	   numRandomSegsToGenerate: the number of random segs to generate.  The actual region
	       will have many fewer segs than this.  Higher numbers will typically generate more complex regions.
	       The region will be constructed by intersecting the reandom segs, and finding a region
	       among the resulting segs.
	   percentOfSegsToRemove: Once random segments are generated and intersected such that all
	       segments only intersect at endpoints, some segments will be removed at random.
	       This parameter indicates the percentage of overall segs that will be removed. A 
	       higher number typically causes regions to have less regular shapes.  Note that a high percentage
	       may require a larger number of random segs to be generated.
	returns:
	     hsegs:  an ordered list of half segments with valid labels.  
	         A half segment is a tuple with the following:
	              ((x,y)(x,y), labelAbove, labelBelow)
		      labels are integral values
		      an interior label will be positive.  An exterior label will be -1
		 hsegs will be ordered in half segment order
		 Each cycle in hsegs will have its own unique label number
	'''
	if numRandomSegsToGenerate == None:
		numRandomSegsToGenerate = 50
	if percentOfSegsToRemove == None:
		percentOfSegsToRemove = .05
	#random.seed()
	# got a bunch of random segs with integer endpoints	
	segs = segLibrary.createRandomSegs( numRandomSegsToGenerate )
	# convert to floats
	segs = [((float(s[0][0]),float(s[0][1])), (float(s[1][0]), float(s[1][1])) ) for s in segs]
	newSegs = []
	for s in segs:
		if s[0] < s[1]:
			newSegs.append( s )
		else:
			newSegs.append( (s[1],s[0]) )
	segs = newSegs
	# find their intersections
	segs = segLibrary.calcNonIntersectingSegs(segs)
	#randomly remove some of the segs
	segs = segLibrary.removeRandSegs( segs, percentOfSegsToRemove )
	# create a region, favoring large (as in... containing lots of segments) cycles
	hsegs = hsegLibrary.extractAllLargeValidCycles( segs )
	return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )

def createRegionFromSegs( segs ):
	if segs == None or len(segs) == 0:
		return []
	segs = [((float(s[0][0]),float(s[0][1])), (float(s[1][0]), float(s[1][1])) ) for s in segs]
	newSegs = []
	for s in segs:
		if s[0] < s[1]:
			newSegs.append( s )
		else:
			newSegs.append( (s[1],s[0]) )
	segs = newSegs
	segs = segLibrary.calcNonIntersectingSegs( segs )
	hsegs = hsegLibrary.labelUniqueCycles( segs )
	return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )

def createRegionFavorLargeCyclesFromSegs( segs ):
	if segs == None or len(segs) == 0:
		return []
	newSegs = [];
	for s in segs:
		if segLibrary.poiComp( s[0], s[1] ) == 1:
			s = (s[1], s[0] )
		if( s[0] != s[1] ):
			newSegs.append( s )
	segs = newSegs
	segs = segLibrary.calcNonIntersectingSegs( segs )
	return hsegLibrary.extractAllLargeValidCycles( segs )

def getOuterCycle( hsegs ):
	if hsegs == None or len(hsegs) == 0:
		return []
	return giveUniqueLabelToEachCycle( hsegs, True )

def giveUniqueLabelToEachCycle( hsegs, getOnlyOuterCycle = False ):
	if hsegs == None or len(hsegs) == 0:
		return []
	segs = [h[0] for h in hsegs if hsegLibrary.isLeft( h ) ]
	hsegs = hsegLibrary.labelUniqueCycles( segs, getOnlyOuterCycle )
	return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )

def createCountPartition( segList, laList, lbList ):
	if segList == None or laList == None or lbList == None or len( segList )== 0 or len( laList ) == 0 or len( lbList ) == 0 or len(segList) != len( laList ) or len( segList ) != len( lbList ) or len( laList) != len( lbList ):
		return [],[],[]
	sr,la,lb = segLibrary.calcNonIntersectingSegs( segList,  laList, lbList )
	

	# write the results to a file
	outfile = open( 'zcountIntermediateNon_Rob_Check.txt','w' )
	for i in range( len( sr ) ):
		seg = sr[i]
		s=struct.pack('>d', seg[0][0] )
		hexx1 = ''.join('%.2x' % ord(c) for c in s) # get hex vals from bin string s
		s=struct.pack('>d', seg[0][1])
		hexy1 = ''.join('%.2x' % ord(c) for c in s) # get hex vals from bin string s
		s=struct.pack('>d', seg[1][0])
		hexx2 = ''.join('%.2x' % ord(c) for c in s) # get hex vals from bin string s
		s=struct.pack('>d', seg[1][1])
		hexy2 = ''.join('%.2x' % ord(c) for c in s) # get hex vals from bin string s
    #output the line to the new file
		outfile.write( hexx1 + ' ' + hexy1 + ' '+  hexx2 + ' ' + hexy2+' ' + str(la[i]) +' '+str(lb[i])+ '\n')
	outfile.close()
	print zip( sr, la, lb)
	print 'done intersections'
	
	s,la,lb = segLibrary.countInteriors( sr, la, lb) 
	return s,la,lb

def union( hsegs1, hsegs2 ):
	''' Assumes that hsegs1 and hsegs2 are valid regions, created with def createRegionFromSegs.
	    regions are assumed to have valid labelling.  This function will relabel them to compute the union
	'''
	if hsegs1 == None:
		hsegs1 = list()
	if hsegs2 == None:
		hsegs2 == list()
	if len( hsegs1 ) == 0:
		return hsegs2
	if len( hsegs2 ) == 0:
		return hsegs1
	if len(hsegs1) == 0 and len( hsegs2) == 0:
		return []
	# get the segs
	segs1 = [ h[0] for h in hsegs1 if hsegLibrary.isLeft( h ) ]
	segs2 = [ h[0] for h in hsegs2 if hsegLibrary.isLeft( h ) ]
	
	# get the bboxs
	s1maxx = max( [x[0] for y in segs1 for x in y] )
	s1minx = min( [x[0] for y in segs1 for x in y] )
	s1maxy = max( [x[1] for y in segs1 for x in y] )
	s1miny = min( [x[1] for y in segs1 for x in y] )
	s2maxx = max( [x[0] for y in segs2 for x in y] )
	s2minx = min( [x[0] for y in segs2 for x in y] )
	s2maxy = max( [x[1] for y in segs2 for x in y] )
	s2miny = min( [x[1] for y in segs2 for x in y] )
	# check for overlap in x AND y direction
	if not( (s1maxx >= s2maxx and s1minx >= s2maxx) or ( s1maxx <= s2minx and s1minx <= s2minx) or (s1maxy >= s2maxy and s1miny >= s2maxy) or ( s1maxy <= s2miny and s1miny <= s2miny)):
		# get the broken segs
		resultSegs1, resultSegs2 = segLibrary.segIntersection( segs1, segs2 )
	
		# get the regions
		hsegs1 = hsegLibrary.labelUniqueCycles( resultSegs1 )
		hsegs1 = hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs1 )
		hsegs2 = hsegLibrary.labelUniqueCycles( resultSegs2 )
		hsegs2 = hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs2 )
		# keep just the left hsegs
		hsegs1 = [h for h in hsegs1 if hsegLibrary.isLeft( h ) ]
		hsegs2 = [h for h in hsegs2 if hsegLibrary.isLeft( h ) ]
		# union will keep all hsegs out of the other or on with matching interabove
		s1, la1, lb1 = [ list(z) for z in zip(* hsegs1 )] 
		s2, la2, lb2 = [ list(z) for z in zip(* hsegs2 )] 

		# keep the ones out of the opposing region
		resultSet = set();
		resultSet |= segLibrary.keepOuterBoundary( s1, la1, lb1, s2, la2, lb2 )
		resultSet |= segLibrary.keepOuterBoundary(  s2, la2, lb2, s1, la1, lb1 )
		
		# make a region out of it
		resultList = list( resultSet )

		hsegs = hsegLibrary.labelUniqueCycles( resultList )
		return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )

	else:
		resultList = list()
		for s in segs1:
			resultList.append( s );
		for s in segs2:
			resultList.append( s )
		resultSet = set( resultList )
		resultList = list( resultSet ) 
		# create the region this code copied from createRegionFromsegs, minus the seg intersection function call
		
		hsegs = hsegLibrary.labelUniqueCycles( resultList )
		return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )


def difference( hsegs1, hsegs2 ):
	''' NON-symmetric difference.  for R1 and R2, 
	    defined as R1 - (R1 \cap R2).
	    Regions are asssumed to have valid labelling.
	    this fucntion will return a properly labeled region
	'''
	if hsegs1 == None or len(hsegs1) == 0:
		return []
	if hsegs2 == None or len(hsegs2) == 0:
		return hsegs1
	# get the segs
	segs1 = [ h[0] for h in hsegs1 if hsegLibrary.isLeft( h ) ]
	segs2 = [ h[0] for h in hsegs2 if hsegLibrary.isLeft( h ) ]
	
	# get the bboxs
	s1maxx = max( [x[0] for y in segs1 for x in y] )
	s1minx = min( [x[0] for y in segs1 for x in y] )
	s1maxy = max( [x[1] for y in segs1 for x in y] )
	s1miny = min( [x[1] for y in segs1 for x in y] )
	s2maxx = max( [x[0] for y in segs2 for x in y] )
	s2minx = min( [x[0] for y in segs2 for x in y] )
	s2maxy = max( [x[1] for y in segs2 for x in y] )
	s2miny = min( [x[1] for y in segs2 for x in y] )
	# check for overlap in x AND y direction
	if not( (s1maxx >= s2maxx and s1minx >= s2maxx) or ( s1maxx <= s2minx and s1minx <= s2minx) or (s1maxy >= s2maxy and s1miny >= s2maxy) or ( s1maxy <= s2miny and s1miny <= s2miny)):
		# get the intersection
		hsegsInter = intersection( hsegs1, hsegs2 )
		if len( hsegsInter ) == 0:
			return hsegs1
		
		# now do the difference
		# get the segs
		segs1 = [ h[0] for h in hsegs1 if hsegLibrary.isLeft( h ) ]
		segs2 = [ h[0] for h in hsegsInter if hsegLibrary.isLeft( h ) ]
		
		# get the broken segs
		resultSegs1, resultSegs2 = segLibrary.segIntersection( segs1, segs2 )
			# get the regions
		hsegs1 = hsegLibrary.labelUniqueCycles( resultSegs1 )
		hsegs1 = hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs1 )
		hsegs2 = hsegLibrary.labelUniqueCycles( resultSegs2 )
		hsegs2 = hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs2 )
		# keep just the left hsegs
		hsegs1 = [h for h in hsegs1 if hsegLibrary.isLeft( h ) ]
		hsegs2 = [h for h in hsegs2 if hsegLibrary.isLeft( h ) ]

		# union will keep all hsegs out of the other or on with matching interabove
		s1, la1, lb1 = [ list(z) for z in zip(* hsegs1 )] 
		s2, la2, lb2 = [ list(z) for z in zip(* hsegs2 )] 

		# keep the ones out of the opposing region
		resultSet = set();
		resultSet |= segLibrary.keepOuterBoundary( s1, la1, lb1, s2, la2, lb2, False )
		resultSet |= segLibrary.keepInnerBoundary(  s2, la2, lb2, s1, la1, lb1, False )
		# make a region out of it
		resultList = list( resultSet )

		hsegs = hsegLibrary.labelUniqueCycles( resultList )
		return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )
	else:
		return hsegs1


def intersection( hsegs1, hsegs2 ):
	''' Assumes that hsegs1 and hsegs2 are valid regions, created with def createRegionFromSegs.
	    regions are assumed to have valid labelling.  This function will relabel them to compute the intersction
	'''
	# check for empty input
	if hsegs2 == None or len(hsegs2) == 0:
		return list()
	if hsegs1 == None or len( hsegs1) == 0:
		return list()
	# get the segs
	segs1 = [ h[0] for h in hsegs1 if hsegLibrary.isLeft( h ) ]
	segs2 = [ h[0] for h in hsegs2 if hsegLibrary.isLeft( h ) ]
	# get the bboxs
	s1maxx = max( [x[0] for y in segs1 for x in y] )
	s1minx = min( [x[0] for y in segs1 for x in y] )
	s1maxy = max( [x[1] for y in segs1 for x in y] )
	s1miny = min( [x[1] for y in segs1 for x in y] )
	s2maxx = max( [x[0] for y in segs2 for x in y] )
	s2minx = min( [x[0] for y in segs2 for x in y] )
	s2maxy = max( [x[1] for y in segs2 for x in y] )
	s2miny = min( [x[1] for y in segs2 for x in y] )
	# check for overlap in x AND y direction
	if (s1maxx >= s2maxx and s1minx >= s2maxx) or ( s1maxx <= s2minx and s1minx <= s2minx) or (s1maxy >= s2maxy and s1miny >= s2maxy) or ( s1maxy <= s2miny and s1miny <= s2miny):
		return list()

	# get the broken segs
	resultSegs1, resultSegs2 = segLibrary.segIntersection( segs1, segs2 )

	# get the regions
	hsegs1 = hsegLibrary.labelUniqueCycles( resultSegs1 )
	hsegs1 = hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs1 )
	hsegs2 = hsegLibrary.labelUniqueCycles( resultSegs2 )
	hsegs2 = hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs2 )
	# keep just the left hsegs
	hsegs1 = [h for h in hsegs1 if hsegLibrary.isLeft( h ) ]
	hsegs2 = [h for h in hsegs2 if hsegLibrary.isLeft( h ) ]

	# union will keep all hsegs out of the other or on with matching interabove
	s1, la1, lb1 = [ list(z) for z in zip(* hsegs1 )]
	s2, la2, lb2 = [ list(z) for z in zip(* hsegs2 )] 

	# keep the ones out of the opposing region
	resultSet = set();
	resultSet |= segLibrary.keepInnerBoundary( s1, la1, lb1, s2, la2, lb2 )
	resultSet |= segLibrary.keepInnerBoundary(  s2, la2, lb2, s1, la1, lb1 )

	# make a region out of it
	resultList = list( resultSet )

	hsegs = hsegLibrary.labelUniqueCycles( resultList )
	return hsegLibrary.switchLabelsForCorrectCycleLabelling( hsegs )




def writeRegionToFile( theRegion, theFileName ):
	theFileObject = open( theFileName, 'w')
	for h in theRegion:
		if hsegLibrary.isLeft( h )  or h[0][0] == h[0][1]:
			s1 = str( h[0][0][0])+' '+str(h[0][0][1])+' '+str( h[0][1][0])+' '+str(h[0][1][1])+' '+ str(h[1])+' '+ str(h[2])  +' ' + '\n'
			theFileObject.write( s1 )
	theFileObject.close()

def writeRegionToHexFile( theRegion, theFileName ):
	theFileObject = open( theFileName, 'w')
	for h in theRegion:
		if hsegLibrary.isLeft( h )  or h[0][0] == h[0][1]:
			x1 = struct.pack('>d', h[0][0][0])
			hexx1 = ''.join('%.2x' % ord(c) for c in x1)
			y1 = struct.pack('>d', h[0][0][1])
			hexy1 = ''.join('%.2x' % ord(c) for c in y1)
			x2 = struct.pack('>d', h[0][1][0])
			hexx2 = ''.join('%.2x' % ord(c) for c in x2)
			y2 = struct.pack('>d', h[0][1][1])
			hexy2 = ''.join('%.2x' % ord(c) for c in y2)
			s1 = hexx1 + ' ' + hexy1 + ' ' + hexx2 + ' ' + hexy2 + ' ' + str(h[1]) + ' ' + str(h[2]) + ' ' + '\n'
			theFileObject.write( s1 )
	theFileObject.close()
