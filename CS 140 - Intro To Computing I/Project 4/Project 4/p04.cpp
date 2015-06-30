//File: P04.cpp

//Date: 02/27/2011

//Name: Brian Olsen

//Course:  CS 140-001 - Introduction to Computing I

//Desc: Works as a simple calculator to add, subtract, multiply or divide 2 numbers. This program uses functions to input and apply calculations.

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

const string PROGRAMMER_NAME = "Brian Olsen";

double GetNumber(string prompt);

char GetOperator(string prompt);

double ComputeOperation(double num1, double num2, char op);

void DisplayResult(string label, double result);

int main() {

	cout <<setiosflags(ios::fixed)
		 <<setprecision(1);

	double num1=0.0, num2=0.0, result;

	char oper='a';
	char rep='a';

	cout << "Programmed by " << PROGRAMMER_NAME << "." << endl;

	do{

	num1=GetNumber("\nEnter a number: ");

	oper=GetOperator("Enter operator [+][-][*][/]: ");

	num2=GetNumber("Enter a number: ");

	result=ComputeOperation(num1, num2, oper);

	DisplayResult("\nResult: ", result);

	cout << endl << endl
		 << "[A]nother, [C]lear result, [E]xit? ";

	cin >> rep;

	rep=toupper(rep);

	if (rep=='A'){

		do{
			
		num1=result;

		cout << endl;

		num2=GetNumber("Enter a number: ");

		oper=GetOperator("Enter operator [+][-][*][/]: ");

		result=ComputeOperation(num1, num2, oper);

		DisplayResult("\nResult: ", result);

		cout << endl << endl 

			 << "[A]nother, [C]lear result, [E]xit? ";

		cin >> rep;

		rep=toupper(rep);

		}while (rep == 'A');

	}

	}while (rep != 'E');

	return 0;
}// end main()



double GetNumber(string prompt){

	double input;

	cout << prompt;

	cin >> input;

	return (input);

}

char GetOperator(string prompt){

	char input;

	cout << prompt;

	cin >> input;

	return (input);

}

double ComputeOperation(double num1, double num2, char op) {

	if (op == '+') { 

		return (num1+num2);

	}

	else if (op == '-') {

		return (num1-num2);

	}

	else if (op=='*') {

		return (num1*num2);

	}

	else if (op=='/') {

	return (num1/num2);

	}


}

	void DisplayResult(string label, double result) {

	cout << label 
		 << result;

	}