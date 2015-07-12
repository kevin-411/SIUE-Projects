//Name: Brian Olsen
//CS 140 Lab Section 021
//File: Lab Exam II.cpp

#include <iostream>

using namespace std;

void Get_Information(int& miles, double& gallons, double& hours);
double Calculate(int miles, double gallons, double hours, double& mph);
void Print_Results(double mph, double mpg);

int main() {
	int miles;
	double gallons, hours, mph, mpg=0;

	cout.setf(ios::fixed);
	cout.precision(2);
	
	cout << "Programmed by Brian Olsen.\n\n"
		 << "Type a negative number for miles to exit\n";

	Get_Information(miles, gallons, hours);

	while(miles > 0){

	mpg=Calculate(miles, gallons, hours, mph);

	Print_Results(mph,mpg);

	Get_Information(miles, gallons, hours);

	}

	return 0;

}

void Get_Information(int& miles, double& gallons, double& hours){

	cout << "\nEnter the number of miles traveled: ";

	cin >> miles;

	if (miles <= 0) {

		return;

	}

	cout << "Enter the number of gallons that were used: ";

	cin >> gallons;

	while (gallons <= 0){

		cout << "Gallons can't be negative or zero!!!\nTry Again\n"
				<< "Enter the number of gallons that were used: ";

		cin >> gallons;

	}

		cout << "Enter the number of hours you traveled: ";

		cin >> hours;

	while (hours <= 0){

		cout << "Hours can't be negative or zero!!!\nTry Again\n"
			 << "Enter the number of hours you traveled: ";

		cin >> hours;

	}

}

double Calculate(int miles, double gallons, double hours, double& mph){

	mph=miles/hours;

	return (miles/gallons);

}

void Print_Results(double mph, double mpg){

	cout << "\nAverage Speed: " << mph << " mph."
		 << "\nDistance Per Gallon: " << mpg << " mpg.\n";

}