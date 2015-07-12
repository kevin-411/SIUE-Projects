//Name: Brian Olsen

//CS 140 Lab Section 021

//File: Lab8.cpp

#include <iostream>

#include <cmath>

#include <string>

using namespace std;

void main () {

	double x, y, z, answer;

	char yesOrNo;

	cout.setf(ios::fixed);

	cout.precision(4);

	cout << "Programmed by Brian Olsen" << endl;

	do{

		cout << "\nEnter a value for x: ";

		cin >> x;

		cout << "Enter a value for y: ";

		cin >> y;

		cout << "Enter a value for z: ";

		cin >> z;

		if(z != 0) {

			answer=pow(y,3) - pow(x,4);

			answer=fabs(answer);
	
			answer=answer/fabs(4*z);

			answer=x * sqrt(answer);

			answer=pow(answer,5);

			answer=y/2 + answer;

			cout << "The answer is: " << answer

				 << endl << endl

				 << "Do you wish to do this again? (y/n): ";

			cin >> yesOrNo;

			yesOrNo=toupper(yesOrNo);

		}

		else {

			cout << "\nCannot compute the answer. The denominator can not be zero.\n\n\n"

				 << "Do you wish to do this again? (y/n): ";

			cin >> yesOrNo;

			yesOrNo=toupper(yesOrNo);

		}

	}while(yesOrNo != 'N');



}
