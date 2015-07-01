/*---------------------------------------------------------------------------*/
/*                                                                           */
/*   Program Name = Client.cpp                                               */
/*                                                                           */
/*   A message "client" program to demonstrate sockets programming           */
/*    - TCP/IP client/server model is implemented                            */
/*---------------------------------------------------------------------------*/
/*   Notes:                                                                  */
/*     1) This program conditionally compiles for Winsock sockets.           */
/*                                                                           */
/*     2) This program needs server to be running on another host.  Program  */
/*        server should be started first.                                    */
/*     3) This program assumes the following command format to start:        */
/*        "CLIENT <CLIENT ID#> <SERVER IP ADDREES> <SERVER PORT #>"          */
/*                                                                           */
/*---------------------------------------------------------------------------*/
/*   For MS Visual C++ Environment: add "wsock32.lib" in the link option     */
/*          in "Project" Menu.                                               */
/*---------------------------------------------------------------------------*/

/*----- Include files -------------------------------------------------------*/
#include <stdio.h>          /* Needed for printf()                           */
#include <string.h>         /* Needed for memcpy() and strcpy()              */
#include <time.h>           /* Needed for clock() and CLK_TCK                */
#include <fcntl.h>          /* for O_WRONLY, O_CREAT                         */

#include <windows.h>        /* Needed for all Winsock stuff                  */
#include <sys\timeb.h>      /* Needed for ftime() and timeb structure        */

/*----- Defines -------------------------------------------------------------*/
#define  MY_PORT_NUM    0      /* My (client) Port number                    */
#define  MAX_BUFFER     100    /* Maximum Buffer Size                        */
#define  NUM_LOOPS      15     /* Number of client repeats                   */

/*------ Prototypes ---------------------------------------------------------*/
void sleep(clock_t wait);      /* wait for specific time (in milisecond)     */

/*===== The Main ============================================================*/
void main(int argc, char *argv[])
{
  /* The following two lines needed for Window's socket */
  WORD wVersionRequested = MAKEWORD(1,1);       /* Stuff for WSA functions   */
  WSADATA wsaData;                              /* Stuff for WSA functions   */

  unsigned int         my_s;            /* My (client) socket descriptor     */
  struct sockaddr_in   server_addr;     /* Server Internet address           */
  struct sockaddr_in   my_addr;         /* My (client) Internet address      */

  char   in_buf[MAX_BUFFER];            /* The in-coming buffer              */
  char   out_buf[MAX_BUFFER];           /* The out-going buffer              */

  int    buffer_size = MAX_BUFFER;

  int                  i, j;            /* Loop counters                     */
  int                  NumBytes;        /* Recieved Bytes                    */
  int                  status;          /* System Call Result Status         */
  int                  addrlen;         /* Internet Address Lnegth           */

  char   *stopstring;                   /* For "strtod" function             */
  double dTempPort;                     /* For "strtod" function             */

  /* Check the # of arguments */
  if (argc < 4)
  {
      printf("Number of arguments is not correct.\n");
      printf("Format: client <client-ID> <IP address of the server> <port #>\n");
      dTempPort = 1050;
  }

  /* If the format of the command line looks OK */
  else
  {
     printf("\nClient ID: %s\n", argv[1]);
     printf("IP Address: %s\n", argv[2]);
     dTempPort = strtod(argv[3], &stopstring);
     printf("Port#: %d\n\n", int(dTempPort));
  }

  /* THE MAIN LOOP --------------------------------------------------------- */
  for (i= 0; i < NUM_LOOPS; i++)
  { 
     /* This stuff initializes winsock                                       */
     WSAStartup(wVersionRequested, &wsaData);

     /* Create a socket                                                      */
     /*   - AF_INET is Address Family Internet and SOCK_STREAM is streams    */
     my_s = socket (AF_INET, SOCK_STREAM, 0);

     /* Lingerring Socket - Important for multiple requests                  */
     LINGER ling;       // Create the LINGER object
     ling.l_onoff = 1;  // Linger = ON
     ling.l_linger = 0; // Hard disconnect
     if (setsockopt(my_s, SOL_SOCKET, SO_LINGER, (LPSTR)&ling, sizeof(ling))<0)
     {   printf("Unsuccessfull linger setting .....\n");  }  

     /* Set My(client's) IP Address ---------------------------------------- */
     my_addr.sin_family      = AF_INET;         /* Address Family To Be Used */
     my_addr.sin_port        = htons(int(MY_PORT_NUM));/* Port number to use */
     my_addr.sin_addr.s_addr = htonl(INADDR_ANY);           /* My IP address */

     /* Bind to the local site --------------------------------------------- */
     status = bind(my_s, (struct sockaddr *)&my_addr, sizeof(my_addr));  
     if (status < 0)  
     {  printf("BIND Error ... \n");  }
 
     /* Set Server's IP Address -------------------------------------------- */
     server_addr.sin_family      = AF_INET;     /* Address Family to be Used */
     server_addr.sin_addr.s_addr = inet_addr(argv[2]);         /* IP address */
     server_addr.sin_port        = htons(int(dTempPort)); /* Port num to use */
     addrlen = sizeof(server_addr);  /* Get the length of the server address */

     /* Connect to the server process -------------------------------------- */
     status = connect(my_s, (LPSOCKADDR)&server_addr, sizeof(server_addr));
     if (status < 0)   
     {   
        printf("Connect Error ... \n");
        i = 999;
     }  

     /* If TCP connection successful --------------------------------------- */
     else
     {
        /* Send the initial request to the server */

        /* Clean up the buffers */
        for (j = 0; j < MAX_BUFFER; j++)
        {  
            out_buf[j] = '\0';
            in_buf[j]  = '\0';
        }

        /* Construct the first payload message (client ID) */
        out_buf[0] = argv[1][0];  // One character code from command arguments
        out_buf[1] = '\n';        // Null-terminate it
        status = send(my_s, out_buf, strlen(out_buf), 0);   // Send to server
        if (status < 0)   
        {   printf("Initial Request Error ... \n");  }  

        /* Receiving a message from the server */
        NumBytes = recv(my_s, in_buf, MAX_BUFFER, 0);
        if (NumBytes < 0)   
        {   printf("Receiving Error ... \n");  }  
        else
        {   printf("Reply Received: %d bytes received.\n", NumBytes); }
  
        /* Display the returned timestamp */
        printf("Reply Message: %s.\n", in_buf);

        /* Close all open sockets (my socket) */
        status = closesocket(my_s);
        if (status < 0)
        {  printf("CLOSE Error ... \n");  }

        /* This stuff cleans-up winsock */
        WSACleanup();

        /* Insert 1 second delay */
        sleep( (clock_t)1 * CLOCKS_PER_SEC );
      }
   } // Loop X15 (as defined by "NUM_LOOPS")
}

/* Wait for specific time (in milisecond) ---------------------------------- */
void sleep(clock_t wait)
{
   clock_t goal;
   goal = wait + clock();
   while( goal > clock() )
      ;
}

// === THE END OF LINES ==================================================== */
