#include "lab2-api.h"

main (int argc, char *argv[])
{
  int number, i,j,offset;
  uint32 handle;
  sem_t semaphore;
  sem_t final_sem;
  char num_str[10], semaphore_str[10],final_string[10];

  switch(argc)
  {
    case 2:
      number = dstrtol(argv[1], NULL, 10);
      Printf("Setting number = %d\n", number);
      semaphore = sem_create(1);
      final_sem = sem_create(0);
      ditoa(semaphore, semaphore_str);	//Convert the semaphore to a string
      ditoa(final_sem,final_string);
  
      for(i=0; i<number; i++)
      {
        ditoa(i, num_str);
        process_create(i,1,"userprog5.dlx.obj", num_str,semaphore_str, final_string,
  			NULL);
      }
      break;
    case 4:
      offset = dstrtol(argv[1], NULL, 10);       //Get semaphore
      semaphore = dstrtol(argv[2], NULL, 10);       //Get semaphore
      final_sem = dstrtol(argv[3],NULL,10);
      for(i=0;i<30;i++)
      {
        for(j=0;j<50000;j++);
        Printf("%c%d\n",'A'+offset,i);
      } 
      for(i=0;i<30;i++)
      {
        sem_wait(semaphore);
        for(j=0;j<50000;j++);
        Printf("%c%d\n",'A'+offset,i);
        sem_signal(semaphore);
      } 

      if(offset == 0)
	      sem_wait(final_sem);
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
