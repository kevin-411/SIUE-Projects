#include "lab2-api.h"

typedef struct DB {
  int some_int;
  char some_char;
} DB;

main (int argc, char *argv[])
{
  int i;
  DB *db;
  uint32 handle;			//Handle of the shared page
  sem_t spage, semaphore;		//Various semaphores

  if(argc!=4)
  {
    Printf("Usage: ");
    Printf(argv[0]);
    Printf(" handle_str spage_str semaphore_str\n");
    exit();
  }
  handle = dstrtol(argv[1], NULL, 10);	//Get the handle from the arguments
  spage = dstrtol(argv[2], NULL, 10);	//Get semaphore spage
  semaphore = dstrtol(argv[2], NULL, 10);	//Get semaphore

  db = (DB *)shmat(handle);		//Map the shared page to address spac
  if(db == NULL)
  {
    Printf("Could not map the virtual address to the memory, exiting...\n");
    exit();
  }

  //Now let us wake up the calling process so that it can quit
  if(sem_signal(spage))
  {
    Printf("Bad semaphore spage.... Exiting!\n");
    exit();
  }

  //Now let us print the message
  Printf("This is one of the %d instances you created\n", db->some_int);
  Printf("The shared character is %c\n", db->some_char);
  Printf("My PID is %d\n", getpid());
}
