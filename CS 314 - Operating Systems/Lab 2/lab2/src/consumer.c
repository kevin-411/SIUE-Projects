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
  cond_t full, empty;
  buffer *Ptr_buff;
  int I = 0;
  int cons_num = 0;
  char Temp;
  int handle = 0;

  handle = dstrtol(argv[1], NULL, 10);
  mainlock = dstrtol(argv[2], NULL,10);  
  full = dstrtol(argv[3], NULL, 10);
  empty = dstrtol(argv[4], NULL, 10);
  cons_num = dstrtol(argv[5],NULL,10);
  spage = dstrtol(argv[6],NULL,10);

  if(argc!=7)
  {
    Printf("Usage: ");
    Printf(argv[0]);
    Printf(" handle_str mainlock_str,full_str,empty_str,cons_num_str,spage_str\n");
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

  while (Ptr_buff->fullentries == 0)
  {
    cond_wait(full);

  }

  Temp = Ptr_buff->array[Ptr_buff->tail];
  Printf ("Consumer %d character removed = %c\n", cons_num, Temp);
  Ptr_buff->tail = (Ptr_buff->tail + 1) % 5;
  Ptr_buff->fullentries--;

  cond_signal(empty);
  lock_release(mainlock);

 }while (1);

}

