#include "lab2-api.h"

main (int argc, char *argv[])
{
	int i=0,j=3;
	int total = -1;
	int present = -1;
	char sem_string[10],total_string[10],present_string[10];
	int sem_handle;

	switch(argc){
		case 1:
			sem_handle = sem_create(1);
			ditoa(sem_handle,sem_string);
			total = 2;
			ditoa(total,total_string);
			for(present=0;present<total;present++){
				ditoa(present,present_string);
				process_create(0,0,"userprog.dlx.obj",total_string,present_string,sem_string);
			}
			return;
		case 2:
			total = dstrtol(argv[1],NULL,10);
			ditoa(total,total_string);
			sem_handle = sem_create(total-1);
			ditoa(sem_handle,sem_string);
			for(present=0;present<total;present++){
				ditoa(present,present_string);
				process_create(0,0,"userprog.dlx.obj",total_string,present_string,sem_string);
			}
			return;
		case 3:
			sem_handle = dstrtol(argv[2],NULL,10);
			ditoa(sem_handle,sem_string);
			total = dstrtol(argv[1],NULL,10);
			ditoa(total,total_string);
			for(present=0;present<total;present++){
				ditoa(present,present_string);
				process_create(0,0,"userprog.dlx.obj",total_string,present_string,sem_string);
			}
			return;
		case 4:
			total = dstrtol(argv[1],NULL,10);
			present = dstrtol(argv[2],NULL,10);
			sem_handle = dstrtol(argv[3],NULL,10);

			if(present >= total){
				Printf("usage: a.out <total> <present> <sem_handle>\n");
				return;
			}
			break;
		default:
			Printf("usage: a.out\n");
			return;
	}

	for(i=0;i<30;i++){
		for(j=0;j<30000;j++);
	}
	sem_signal(sem_handle);
	sleep();
	/*
	if(total == present + 1){
		printAllQueues();
	}
	else
		sem_wait(sem_handle);
	*/
}
