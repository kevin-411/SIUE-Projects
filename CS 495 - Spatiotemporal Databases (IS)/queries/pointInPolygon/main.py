import sys
import raincloudregion
 
filename="20131116144301398.bin"
directory = "./"
sys.stdin = open(directory +  filename, 'rb')
writer = open("./tmp", 'w')

#for line in sys.stdin:
#   line = line.strip()
#   keys = line.split()
mcrc = raincloudregion.translateMovingRegion(sys.stdin)

key = mcrc.color
value = 1
writer.write("%s\t%d" % (key, value) )

writer.close()
fakestdin = open("./tmp",'r')


last_key = None
running_total = 0
for input_line in fakestdin:
   input_line = input_line.strip()
   this_key, value = input_line.split("\t", 1)
   value = int(value)
  
   if last_key == this_key:
       running_total += value
   else:
       if last_key:
           print( "%s\t%d" % (last_key, running_total) )
       running_total = value
       last_key = this_key
  
if last_key == this_key:
   print( "%s\t%d" % (last_key, running_total) )
   
fakestdin.close()

ins.close()