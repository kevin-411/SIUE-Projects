#include "lab2-api.h"

typedef struct buffer{
   char array[5];
   int head;
   int tail;
   int fullentries;

} buffer;

main (int argc, char *argv[])
{
  int i,j;
  sem_t spage;
  lock_t mainlock;
  cond_t empty,full;
  int prod_number;
  int cons_number;
  uint32 handle;
  buffer *Ptr_buff;
  char handle_str[10];
  char spage_str[10], mainlock_str[10],empty_str[10];
  char cons_num_str[10], prod_num_str[10],full_str[10];

  prod_number = dstrtol(argv[1]);
  cons_number = dstrtol(argv[2]);

  handle = shmget();
  mainlock = lock_create();
  empty = cond_create(mainlock);
  full = cond_create(mainlock);
  spage = sem_create(0);	

  ditoa(handle, handle_str);
  ditoa(mainlock,  mainlock_str);
  ditoa(full, full_str);
  ditoa(empty, empty_str);
  ditoa(spage, spage_str);

  Ptr_buff = (buffer *) shmat(handle);
  Ptr_buff->head = 0;
  Ptr_buff->tail = 0;
  Ptr_buff->fullentries = 0;


   for (i=0;i<prod_number;i++)
    {
      ditoa(i,prod_num_str);
      process_create("producer.dlx.obj", handle_str, mainlock_str, full_str,empty_str,prod_num_str, spage_str,  NULL);
    }

  for( j=0; j<cons_number;j++)
   {
     ditoa(j,cons_num_str);
     process_create("consumer.dlx.obj", handle_str, mainlock_str, full_str,empty_str,cons_num_str, spage_str, NULL);
   }

 
   sem_wait(spage);
 }




