from __future__ import division # this changes / to floating division and // to integer division
import struct, os, math, time
try:
    from cStringIO import StringIO
except:
    from StringIO import StringIO
    
    
BpMB=1048576 #bytes/MB
sizeOfFiles=100 * BpMB
rowSize=28 #bytes
filename = "./output"
size=os.path.getsize(filename)
numOfFiles=int(math.ceil(size/sizeOfFiles))
word = '1'

####################### Ask User for Word ##########################
anything = 1
while(word != '0'):
    if(anything != 1):
        print "No Results"
    anything = 0
    word = raw_input("Please enter the word you want to search for or a '0' to exit:")
    if (word == '0'):
        break
    word.replace(" ", "")
    word = word+"          "
    word = word[:10]
    print "Your results are: "
#######################FIND#########################################
    startAll = time.time()
    try:
        oFile = open( filename, 'rb' )
     
        for i in range(numOfFiles): 
            count = rowSize
            arr = []
            while(count < sizeOfFiles): #continue while byte count is less than 100MB
                                
                rec=oFile.read( rowSize ) #grab the next record
                if (rec == ''): # an empty string indicates EOF
                    break
                line = struct.unpack( 'bbbbbbbbbb', rec[8:18] ) #only retrieving the index for sorting
                w1 = ''
                for c in line:
                    w1 += chr( c )
                #print w1
                arr.append((w1,rec))
                count +=rowSize            
            if (arr[len(arr)-1][0] < word):
                break
            if (arr[0][0] > word):
                break
            for line in arr:
                if (line[0] == word):
                    anything = 1
                    print line[0]
        
                       
    except IOError :
        print "IO ERROR!!!  :(\n"
    except os.error:
        print "OS ERROR!!!  :'(\n"
     
    oFile.close()
    finishAll = time.time() - startAll
    print "Bye Yall"
