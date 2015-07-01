import random
import struct 

oFile = open( 'relation.bin', 'wb')

random.seed(1)

for k in range( 40 ):
    wFile = open( 'wordlist2.txt', 'r')
    for i,w in enumerate( wFile ):
        #if i > 10:
        #    break
        
        newW = ''
        newW2 = ''
        for j in range( len( w) ):
            if w[j].isalpha():
                newW = newW + w[j]
            if len(newW) >= 10:
                break
        for j in range( 10, len( w) ):
            if w[j].isalpha():
                newW2 = newW2 + w[j]
            if len(newW2) >= 10:
                break
    
        # pad the words
        for j in range( len(newW), 10 ):
            newW = newW + ' '

        for j in range( len(newW2), 10 ):
            newW2 = newW2 + ' '
        
        n1 = random.randint( 0, 100000)
        n2 = random.randint( 0, 100000)
    
        newW = [ord(c) for c in newW]
        newW2 = [ord(c) for c in newW2]
        
        a = ''
        a = a+ struct.pack( 'l', n1 )
        a = a+ struct.pack( 'l', n2 )
        for c in newW:
            a = a + struct.pack( 'b', int(c))
    
            
        for c in newW2:
            a = a + struct.pack( 'b', int(c))
    
        oFile.write( a )
    wFile.close()

oFile.close()

exit()

oFile = open( 'relation.bin', 'rb' )

while True:
    rec = oFile.read( 36 )
    if len(rec) < 36 :
        break
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
