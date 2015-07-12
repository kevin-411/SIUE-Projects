//Name: Brian Olsen

//CS 140 Lab Section 021

//File: Lab10.cpp

#include <iostream>

#include <cmath>

#include <string>

using namespace std;

double calculateGrade (double num1, double num2);

int enterTotalQuestions (double num, double number );

void main () {

	double gradeAnswers=0.0;

	double gradeTotal=0.0;

	cout.setf(ios::fixed);

	cout.precision(1);

	cout << "Programmed by Brian Olsen" << endl << endl

		 << "Type a negative number for the number of correct questions to exit" << endl << endl;

		cout << "Enter the number of questions answered correctly: ";

		cin >> gradeAnswers;

		if (gradeAnswers < 0){

			return;

		}

		cout << "Enter the total number of questions: ";

		gradeTotal=enterTotalQuestions(gradeAnswers, gradeTotal);

			while(gradeAnswers >= 0 || gradeTotal >=0){	

				cout << "Grade: " << calculateGrade(gradeAnswers, gradeTotal) << endl << endl;

				cout << "Enter the number of questions answered correctly: ";

				cin >> gradeAnswers;

				if (gradeAnswers < 0){

					return;

				}

				cout << "Enter the total number of questions: ";

				gradeTotal=enterTotalQuestions(gradeAnswers, gradeTotal);

			}

}


double calculateGrade (double num1, double num2){

	return(num1/num2*100);

}

int enterTotalQuestions (double num, double number){

	cin >> number;

	while(num > number){

	cout << "Total Number of questions must be at LEAST equal to the number of questions correct! Try Again!" << endl;

	cout << "Enter the total number of questions: ";

	cin >> number;

	}

	return (number);

}