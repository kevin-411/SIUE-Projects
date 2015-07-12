// Name: Brian Olsen

// CS140 Lab Section 021

// File: Lab Exam I.cpp

#include <iostream>

using namespace std;

const double pi=3.14159;

void main(){

	double r=0.0;

	double a=0.0;
		
	int s=0;

	cout.setf(ios::fixed);

	cout.precision(2);

	cout << "Programmed by Brian Olsen." << endl << endl;

	cout << "Type a negative number for the radius to exit." << endl << endl

		 << "Enter the radius: ";

	cin >> r;

	while (r >= 0.0) {

	cout << "Choose from the following:" << endl;

	cout << "        1. Circumfrence" << endl;

	cout << "        2. Area" << endl;

	cout << "        3. Volume" << endl;

	cout << "Enter your selection: ";

	cin >> s;

		if (s==1){
			
			a=2*pi*r;

		}

		else if (s==2){
			
			a=(r*r)*pi;

		}

		else if (s==3){
			
			a=4.0/3.0*pi*(r*r*r);

		}

		else {

			a=0.0;

		}

		cout << endl << "The answer is: " << a << endl << endl;

		cout << endl << "Enter the radius: ";

		cin >> r;

	}

}