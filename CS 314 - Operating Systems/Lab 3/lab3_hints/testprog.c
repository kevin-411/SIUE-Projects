#include "lab2-api.h"

void testcase1(void);
void testcase2(void);
void testcase3(void);
void testcase4(void);
void testcase5(void);

main(int argc,char *argv[])
{
  int i=0;
  char str[10];
  int testcase;

  switch(argc){
  case 2:
    testcase = dstrtol(argv[1],NULL,10);
    break;
  default:
    Printf("usage: a.out <test-case #>\n");
    exit(-1);
  }

  Printf("\n*****************************************************\n");

  switch(testcase){
  case 1:
    //place code here!
    testcase1();
    break;
  case 2:
    //place code here!
    testcase2();
    break;
  case 3:
    //place code here!
    testcase3();
    break;
  case 4:
    //place code here!
    testcase4();
    break;
  case 5:
    //place code here!
    testcase5();
    break;
  }
  Printf("\n*****************************************************\n");
}

void testcase1(void)
{
  char num_arg[10];
  int i=2;
  int sem_handle;
  char sem_str[10];

  sem_handle = sem_create(0);
  ditoa(sem_handle,sem_str);

  Printf("Inside testcase1!\n");
  ditoa(i,num_arg);
  process_create(0,0,"userprog.dlx.obj",num_arg,sem_str,NULL);
  for(i=0;i<2;i++){
  	sem_wait(sem_handle);
  }
  printAllQueues();
  return;
}

void testcase2(void)
{
  char num_arg[10];
  char sem_string[10];
  sem_t sem_handle;
  int i=3;

  Printf("Inside testcase2!\n");
  sem_handle = sem_create(0);
  ditoa(sem_handle,sem_string);
  ditoa(i,num_arg);
  process_create(0,0,"userprog.dlx.obj",num_arg,sem_string,NULL);
  for(i=0;i<3;i++){
  	sem_wait(sem_handle);
  }
  printAllQueues();
  return;
}

void testcase3(void)
{
  char num_arg[10];
  int i=2;

  Printf("Inside testcase3!\n");
  ditoa(i,num_arg);
  process_create(0,0,"userprog5.dlx.obj",num_arg,NULL);
  return;
}

void testcase4(void)
{
  int i=2;
  char num_arg[10];

  Printf("Inside testcase4!\n");
  ditoa(i,num_arg);
  process_create(0,0,"userprog6.dlx.obj",num_arg,NULL);
  return;
}

void testcase5(void)
{
  Printf("Inside testcase5!\n");
  return;
}
