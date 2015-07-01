#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <winsock2.h>
#include <string>
#include <time.h>

#define SERVER_PORT "8050" //client port connection
#define MAX_CLIENT_BUFFER 3 //Maximum clients
#define MAX_BUFFER 100 //Maximum buffer size

int main(int argc,char *argv[])
{
  struct sockaddr_in server_addr;
  struct sockaddr_in client_addr;
  unsigned int my_sock, new_sock;
  char in_buf[MAX_BUFFER];
  char out_buf[MAX_BUFFER];
  char *ipaddress;
  time_t current_time;
  struct tm * time_info;
  int clientSize;

  WORD wVersionRequested = MAKEWORD(2,1);
  WSADATA wsaData;

  WSAStartup(wVersionRequested, &wsaData);

  server_addr.sin_family = AF_INET; //use IPv4
  server_addr.sin_port = htons(atoi(SERVER_PORT)); // set port
  server_addr.sin_addr.s_addr = htonl(INADDR_ANY); //add my IP Address to client

  my_sock = socket(server_addr.sin_family, SOCK_STREAM, 0);
  int status = bind(my_sock,(struct sockaddr *)&server_addr,sizeof(server_addr));
  if(status < 0){
    perror("Server failed to call bind.\n");
    exit(1);
  }
  status = listen(my_sock, MAX_CLIENT_BUFFER);
  if(status < 0){
    perror("Server failed to call status.\n");
    exit(1);
  }
  while(1){
	clientSize = sizeof(client_addr);
    new_sock = accept(my_sock,(struct sockaddr *)&client_addr, &clientSize);

    time(&current_time);//initialize current_time var
    time_info = localtime(&current_time);//set time_info to local time
    strftime(out_buf, MAX_BUFFER, "%H:%M:%S", time_info);//load formatted time text into out_buf

    if(new_sock==-1){
      perror("Server failed to call accept.\n");
      continue;
    }else{ 
      if(recv(new_sock, in_buf, MAX_BUFFER, 0) < 0 ){
	perror("Server failed to call recv.\n");
	continue;
      }
	  ipaddress = inet_ntoa(client_addr.sin_addr);
      printf("Connection from %s arrived (Port No = %d)\nClient ID = %s at %s\n", ipaddress, client_addr.sin_port,strtok(in_buf,"\n"), out_buf); 

      if(send(new_sock, out_buf, MAX_BUFFER, 0) < 0){
	perror("Server failed to call send.\n");
	continue;
      }
      closesocket(new_sock);
    }
  }
  WSACleanup( );
  return 0;
}
