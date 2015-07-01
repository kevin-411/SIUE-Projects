
import struct
import sys

if len( sys.argv ) < 2:
    print 'usage: python [scriptname.py] [filename that you want to display] [record to start printing] [number of records to print]'
    exit()

start = 0
end = 0

if len( sys.argv ) >=3 :
    start = int( sys.argv[2] )
if len( sys.argv ) >=4 :
    end = int( sys.argv[3] )

oFile = open( sys.argv[1], 'rb' )

count = 0
while True:
    count += 1
    rec = oFile.read( 28 )
    if len(rec) < 28 :
        break
    if end != 0 and count > end :
        break
    if count < start+1:
        continue
    line = struct.unpack( 'llbbbbbbbbbbbbbbbbbbbb', rec ) 
    
    n1 = int( line[0] );
    n2 = int( line[1] );
    w1 = ''
    for i in range( 2, 12 ):
        w1 = w1 + chr( line[i] )
    w2 = ''
    for i in range( 12, 22 ):
        w2 = w2 + chr( line[i] )
        
    print n1, n2, w1, '1', w2, '2'

oFile.close()
