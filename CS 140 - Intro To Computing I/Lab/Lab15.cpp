//Name: Brian Olsen

//CS 140 Lab Section 021

//File: Lab15.cpp

//Reminder: I am the one with the program that came up with the Link Errors...although this program will not compile you agreed to not take off many points.

//error LNK2019: unresolved external symbol _WinMain@16 referenced in function ___tmainCRTStartup Z:\Documents\Visual Studio 2010\Projects\Lab15b\Lab15b\MSVCRTD.lib(crtexew.obj)	Lab15b

//error LNK1120: 1 unresolved externals	Z:\Documents\Visual Studio 2010\Projects\Lab15b\Debug\Lab15b.exe	1	1	Lab15b

#include <iostream>

#include <fstream>

#include <iomanip>

#include <string>

using namespace std;



void main(){

	ifstream fin;
	int temps[31];
	double ave=0;
	fin.open("Lab15B.txt");

	 if (fin.fail()) {

		 cout << "Error opening file Lab15B.txt for input. Aborting!"

			  << endl << endl;

		 exit(1);

	 }

	 	for(int i=0; i < 31 ;i++){

		fin >> temps[i];

		}

			
	int add=0;



		for (int i=0; i < 31;i++){

		add = add+temps[i];

		

		}
		ave=double(add)/31;

		cout << "Temperatures for October:\n";

	for (int i=0; i <31 ;i++){

		if ((i+1)%7==0){

			cout << setw(3) << temps[i] << endl;

		}


		else{
			
			cout << setw(3) << temps[i];
		
		}

	}
cout << "\nThe average temperature was " << ave << endl << endl;
}

