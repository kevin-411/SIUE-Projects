//Name: Brian Olsen

//CS 140 Lab Section 021

//File: Lab6.cpp

#include <iostream>

#include <string>

using namespace std;

void main () {

	string str;

	cout << "Programmed by Brian Olsen" << endl

		 << endl

	     <<  "Enter a sentence: ";

	getline(cin,str);

	cout << endl << "Your sentence is: " << endl

		 << str << endl << endl;

	cout << "The capital letters are: " << endl;

	for (int i = 0; i < str.length(); i++) {

		if (int(str.at(i)) >= 65 && int(str.at(i)) <= 90) {

			cout << str.at(i);

		}

		else {

		}

	}

	cout << endl <<endl
		
		 << "Your original sentence was: " << endl

		 << str <<endl <<endl;

}