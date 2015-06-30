#include "lab2-api.h"

typedef struct DB {
  int some_int;
  char some_char;
} DB;

main (int argc, char *argv[])
{
  int number, i;
  DB *db;
  uint32 handle;
  sem_t spage;
  sem_t semaphore;
  char handle_str[10], spage_str[10], semaphore_str[10];

  switch(argc)
  {
    case 2:
      number = dstrtol(argv[1], NULL, 10);
      Printf("Setting number = %d\n", number);
      break;
    default:
      Printf("Usage: ");
      Printf(argv[0]);
      Printf(" number\n");
      exit();
  }

  handle = shmget();	//Get a shared memory page
  db = (DB *)shmat(handle);
  if(db==NULL)
  {
    Printf("Could not map the shared page to virtual address, exiting..\n");
    exit();
  }
  db->some_int = number;
  db->some_char = 'A';
  spage = sem_create(0);	//Get a semaphore to wait till this memory
 	 			//page is mapped to some other process's
				//virtual address space
  semaphore = sem_create(5);

  ditoa(handle, handle_str);	//Convert the shared page handle to a string
  ditoa(spage, spage_str);	//Convert the semaphore spage to a string
  ditoa(semaphore, semaphore_str);
  				//Convert the semaphore to a string

  for(i=0; i<number; i++)
    process_create("userprog2.dlx.obj", handle_str, spage_str, semaphore_str, NULL);

  sem_wait(spage);		//Wait till at least one process grabs the
  				//shared memory page. Otherwise the page could
				//be released before anyone grabs it!
}
