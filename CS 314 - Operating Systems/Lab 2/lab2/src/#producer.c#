#include "lab2-api.h"

typedef struct buffer{
     char array[5];
     int head;
     int tail;
     int fullentries;
} buffer;

main (int argc, char *argv[])
{
  sem_t spage;
  lock_t mainlock;
  cond_t full,empty ;
  buffer *Ptr_buff;
  char A[11] = "HelLo World";
  int I = 0;
  int prod_num=0;
  int handle = 0;

 handle = dstrtol(argv[1], NULL, 10);
 mainlock = dstrtol(argv[2], NULL,10);  //if (argc!=5)
 full = dstrtol(argv[3], NULL, 10);
 empty = dstrtol(argv[4], NULL, 10);
 prod_num = dstrtol(argv[5],NULL,10);
 spage = dstrtol(argv[6],NULL,10);//Get semaphore spage

if(argc!=7)
  {
    Printf("Usage: ");
    Printf(argv[0]);
    Printf(" handle_str mainlock_str,full_str,empty_str,prod_num_str,spage_str\n");
    exit();
  }


 Ptr_buff = (buffer *) shmat(handle);

 if(sem_signal(spage))
 {
  Printf("Bad semaphore spage.... Exiting!\n");
  exit();
 }

 do
 {

   lock_acquire(mainlock);

   while (Ptr_buff->fullentries == 5)
   {
      cond_wait(empty);
   }

   Ptr_buff->array[Ptr_buff->head] = A[I];
   Printf ("Producer %d inserted = %c\n", prod_num, A[I]);
   I = I + 1;
   Ptr_buff->head = (Ptr_buff->head + 1) % 5;
   Ptr_buff->fullentries++;
   cond_signal(full);
   lock_release(mainlock);

  if ( I == 11 )
  {
    exit();

  }
 
 }while(1);

}
