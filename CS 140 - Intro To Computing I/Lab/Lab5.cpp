//Name: Brian Olsen

//CS 140 Lab Section 021

//File: Lab5.cpp

#include <iostream>

using namespace std;

const double pi=3.14159;

const double l=11.95;

const double m=12.35;

const double s=13.28;

void main () {

	char selection;

	double a, b, c, cost;

	cout.setf(ios::fixed);

	cout.precision(2);

	cout << "Programmed by Brian Olsen." << endl << endl;

	cout << "What type of area are you carpeting:" << endl;

	cout << "Choose from the following:" << endl;

	cout << "        A. Circle" << endl;

	cout << "        B. Rectangle" << endl;

	cout << "        C. Right Triangle" << endl;

	cout << "Enter your selection: ";

	cin >> selection;

		switch (selection) {

		case 'A':

		case 'a':

			cout << "Enter the radius: ";

			cin >> a;

			c= pi * (a * a);

		break;

		case 'B':

		case 'b':

			cout << "Enter the length and width: ";

			cin >> a >> b;

			c=a * b;

		break;

		case 'C':

		case 'c':

			cout << "Enter the base and height: ";

			cin >> a >> b;

			c=.5 * (a * b);

		break;

		default: 

			cout << "Invalid!! Area will be zero!" << endl;

			cost=0.00;

			cout << endl << endl << "The cost is $" << cost << endl;

			return;

		}

		if (c >= 150.00) {

			cost=c * l;

		}

		else if (c < 150.00 && c >= 75.00) {

			cost=c * m;

		}

		else if (c < 75.00 && c >= 1) {

			cost=c *s;

		}

		cout << endl << "The cost is $" << cost << endl;

	return;

}