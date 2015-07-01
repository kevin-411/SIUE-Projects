
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
    rec = oFile.read( 16 )
    if len(rec) < 16 :
        break
    if end != 0 and count > end :
        break
    if count < start+1:
        continue
    line = struct.unpack( 'qq', rec ) 
    
    n1 = int( line[0] );
    n2 = int( line[1] );
    print n1, n2

oFile.close()
