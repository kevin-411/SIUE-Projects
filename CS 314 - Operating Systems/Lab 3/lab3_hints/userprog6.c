#include "lab2-api.h"

main (int argc, char *argv[])
{
  int number, i,j,offset;
  uint32 handle;
  sem_t semaphore,final_sem;
  char num_str[10], semaphore_str[10],final_string[10];

  switch(argc)
  {
    case 2:
      number = dstrtol(argv[1], NULL, 10);
      Printf("Setting number = %d\n", number);
      semaphore = sem_create(1);
      final_sem  = sem_create(0);
      ditoa(semaphore, semaphore_str);	//Convert the semaphore to a string
      ditoa(final_sem,final_string);
  
      for(i=0; i<number; i++)
      {
        ditoa(i, num_str);
        process_create(0,1,"userprog6.dlx.obj", num_str,semaphore_str, final_string,
  			NULL);
	Printf("Starting next process!\n");
      }
      break;
    case 4:
      offset = dstrtol(argv[1], NULL, 10);       //Get semaphore
      semaphore = dstrtol(argv[2], NULL, 10);       //Get semaphore
      final_sem = dstrtol(argv[3],NULL,10);
      Printf("sem is %d\n",final_sem);
      for(i=0;i<30;i++)
      {
        for(j=0;j<12000;j++);
        Printf("%c%d\n",'A'+offset,i);
        if (offset == 0)
          yield();
      } 
      
      for(i=0;i<30;i++)
      {
        sem_wait(semaphore);
        for(j=0;j<12000;j++);
        Printf("%c%d\n",'A'+offset,i);
        sem_signal(semaphore);
        if (offset == 0)
          yield();			      
      } 

      if(offset == 0 || offset == 1){
	      Printf("Waiting on semaphore...!\n");
	      sem_wait(final_sem);
      }
      Printf("offset is %d\n",offset);
      
      printAllQueues();
      
      break;
    default:
      Printf("Usage: ");
      Printf(argv[0]);
      Printf(" number\n");
      Printf("argc = %d\n", argc);
      exit();
  }

 
				
}
