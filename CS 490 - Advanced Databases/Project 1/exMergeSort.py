from __future__ import division # this changes / to floating division and // to integer division
import struct, os, math, time
try:
    from cStringIO import StringIO
except:
    from StringIO import StringIO
#######################CONST########################################

BpMB=1048576 #bytes/MB
sizeOfFiles=100 * BpMB
rowSize=28 #bytes
filename = "./relation.bin"
size=os.path.getsize(filename)
numOfFiles=int(math.ceil(size/sizeOfFiles))
#######################SORT#########################################
startAll = time.time()
try:
    oFile = open( filename, 'rb' )
 
    for i in range(numOfFiles): 
        startSort = time.time()
        f = open('./' + str(i + 1),'wb')
        output = StringIO()
        count = rowSize
        arr = []
        while(count < sizeOfFiles): #continue while byte count is less than 100MB
            if (count % (rowSize * 100000)==0):
                print str(count // BpMB) + " MB read into the array"
             
            rec=oFile.read( rowSize ) #grab the next record
            if (rec == ''): # an empty string indicates EOF
                break
            line = struct.unpack( 'bbbbbbbbbb', rec[8:18] ) #only retrieving the index for sorting
 
            w1 = ''
            for c in line:
                w1 += chr( c )
 
            arr.append((w1,rec))
            count +=rowSize
             
        print "ARRAY ESTABLISHED!!\n"
        arr.sort()
        finishSort = time.time() - startSort
        print "FINISHED SORTING!! Elapsed Time: %.3f min." % (finishSort / 60)
        print "\n"
        startBuffTime = time.time()
        for line in arr:
            output.write(line[1])
        finishBuffTime = time.time() - startBuffTime
        print "FINISHED BUFFERING!! Elapsed Time: %.3f min." % (finishBuffTime / 60)
        startFileTime = time.time()
        f.write(output.getvalue()) #write index value for sorting
        finishFileTime = time.time() - startBuffTime
        print "FINISHED Writing to file!! Elapsed Time: %.3f min." % (finishFileTime / 60)
        print "FILE {0} FINISHED!!\n".format(i + 1)
         
        f.close()
         
except IOError :
    print "Der wuz un IO errur!! Dey took er jERBs!!!\n"
except os.error:
    print "Der wuz un OS errur!! Dey took er jERBs!!!\n"
 
oFile.close()
finishAll = time.time() - startAll
print "Finished entire sorting section in %.3f min." % (finishAll / 60)

#######################MERGE#######################################
#######################FUNCITONS###################################
def readFiles(f,buff):
    numFiles = 50 # number of files to push to buffer
    lines = f.read(rowSize * numFiles)
    
    for i in range(len(lines)//rowSize):
        
        index = lines[8 + (i * rowSize):18 + (i * rowSize)]
        rec=lines[0 + (i * rowSize):rowSize+ (i * rowSize)] # get the record
        buff.append((index,rec))
    if((len(lines)//rowSize)!=50):
        buff.append('<<<EOF>>>')

def thisShouldKeepGoing(buffs):
    for i,buff in enumerate(buffs):
        if i > 0 and buff[0] != '<<<EOF>>>':
            return True
    return False

####################################################################
startAll = time.time()
try:
    files = []
    buffs = []
    files.append(open('./output','wb'))  #files[0] is output
    buffs.append(StringIO())# buff[0] is output buff<--can't use we run out memory :(
    for i in range(numOfFiles):
        files.append(open('./' + str(i + 1),'rb'))
        buffs.append([])
        readFiles(files[i + 1],buffs[i + 1]) # load dat buff
    while (thisShouldKeepGoing(buffs)):
        mIndex=0
        minChar='~' #<--I use the tilda because it has higher precedence than all letters
        for i,buff in enumerate(buffs):
            if i > 0 and buff[0] != '<<<EOF>>>' and buff[0][0] < minChar:
                mIndex = i
                minChar = buff[0][0]
        files[0].write(buffs[mIndex][0][1])
        del buffs[mIndex][0]
        if (len(buffs[mIndex]) == 0): # if buffer is empty get mo' shit
            readFiles(files[mIndex],buffs[mIndex])
    #files[0].write(buffs[0].getvalue())
    buffs[0].close()
    for f in files:
        f.close()
    
except IOError :
    print "Der wuz un IO errur!! Dey took er jERBs!!!\n"
    
finishAll = time.time() - startAll
print "Finished entire merging section in %.3f min." % (finishAll / 60)