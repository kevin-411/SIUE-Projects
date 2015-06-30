#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <iomanip>
using namespace std;

int main()
{
        char buffer[4];
        int i;
        char * iPtr;
        iPtr = (char*)(void*) &i;

        FILE* FD = fopen("test2.bin", "rb");
		if(FD==NULL){
			cerr << "OH NO" << endl;
			exit(1);
		}
        int amt = 4;
        while( amt != 0 )
        {
                amt = fread(buffer,1,4,FD);
                if( amt == 4)
                {
                        iPtr[0] = buffer[3];
                        iPtr[1] = buffer[2];
                        iPtr[2] = buffer[1];
                        iPtr[3] = buffer[0];
                        cout << "i = " << hex << i << endl;
                }
        }







}
