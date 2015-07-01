/* ************************************************************************* *
 *                                                                           *
 *  Multi.cpp:                                                               *
 *    This is a sample program for multi-threaded applications.              *
 *                                                                           *
 *    As soon as this program starts, the main thread generates two child    *
 *    threads.  The two child threads wait for 10 seconds and terminate.     *
 *                                                                           *
 *    While the two child threads are running, the main thread waits.  The   *
 *    main thread waits until both threads finish.                           *
 *                                                                           *
 *  Compile:                                                                 *
 *    In Project->Setting->C/C++->CodeGenartion(in Category)                 *
 *            ->Select Multi-threaded for runtime library                    *
 *                                                                           *
 *  Coded by: H. Fujinoki                                                    *
 *    September 12, 11:00 AM at Edwardsville, IL                             *
 *                                                                           *
 * ************************************************************************* */
#include <process.h>  // for thread system calls (_beginthread, etc.)
#include <windows.h>  // for TRUE, FALSE labels
#include <stdio.h>    // for printf
#include <time.h>     // for clock() and CLK_TCK    

/* Global label defenition ------------------------------------------------ */
#define INTERVAL    1             // Transmission interval in seconds
#define REPEATS     50            // Number of child thread's repeats

/* Global Variables ------------------------------------------------------- */
int nChild1_status;               // Child thread #1 status
int nChild2_status;               // Child thread #2 status    

/* Prototypes ------------------------------------------------------------- */
void ChildThread1(void *dummy);   // The child thread #1
void ChildThread2(void *dummy);   // The child thread #2

/* The MAIN --------------------------------------------------------------- */
void main (void)
{
   /* Set the child thread status (TRUE = RUNNING) --- */
   nChild1_status = TRUE;
   nChild2_status = TRUE;

   /* Create and start the two threads --- */
   _beginthread (ChildThread1, 0, NULL );  // Start child process #1
   _beginthread (ChildThread2, 0, NULL );  // Start child process #2

   /* Spin-loop until both threads finish --- */
   while ((nChild1_status == TRUE)||(nChild2_status == TRUE))
   {  ;  }

   /* Two threads are now finished --- */
   printf("Both child threads are finished ... \n");
   printf("The main thread is finishing ... \n"); 
}

// The Child-Thread #1 ///////////////////////////////////////////////////////
void ChildThread1(void *dummy)
{
   /* Child #1 local variable(s) --- */
   int    i;    // Loop counter

   /* This thread is started --- */
   printf("Child Thread #1 has started ... \n");

   /* wait for 10 seconds w/ count down --- */
   for (i = 0; i < REPEATS ; i++)
   {
       /* Wait for 10 seconds --- */
       Sleep((clock_t)INTERVAL * CLOCKS_PER_SEC);

       /* Display count down --- */
       printf("Child #1: %d more second(s) to finish ...\n", REPEATS -i);
   }

   /* Reset the status flag --- */
   nChild1_status = FALSE;

   /* Terminate this thread --- */
   _endthread();
}

// The Child-Thread #2 ///////////////////////////////////////////////////////
void ChildThread2(void *dummy)
{
   /* Child #2 local variable(s) --- */
   int    i;    // Loop counter

   /* This thread is started --- */
   printf("Child Thread #2 has started ... \n");

   /* wait for 10 seconds w/ count down --- */
   for (i = 0; i < REPEATS ; i++)
   {
       /* Wait for 10 seconds --- */
       Sleep((clock_t)INTERVAL * CLOCKS_PER_SEC);

       /* Display count down --- */
       printf("Child #2: %d more second(s) to finish ...\n", REPEATS -i);
   }

   /* Reset the status flag --- */
   nChild2_status = FALSE;

   /* Terminate this thread --- */
   _endthread();
}

// THE END OF LINES //////////////////////////////////////////////////////////