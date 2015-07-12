//Name: Brian Olsen
//CS 140 Lab Section 021
//File: Lab11.cpp

#include <iostream>
#include <cmath>
#include <string>

using namespace std;

void Get_Input(int& num_correct, int& num_questions);
double Calculate_Grade(char& let_grade, double num_correct, double num_questions, bool& passing);
void Print_Results(double grade, bool passing, char let_grade);

int main() {

	int num_questions,
		num_correct;
	double grade;
	bool passing;
	char let_grade;

	cout.setf(ios::fixed);
	cout.precision(1);

	cout << "Programmed By Brian Olsen\n\n";
	cout << "Type a negative number for the number of correct questions to exit\n\n";
	
	Get_Input(num_correct, num_questions);
	while (num_correct >= 0)
	{
		grade = Calculate_Grade(let_grade, num_correct, num_questions,  passing);

		Print_Results(grade, passing, let_grade);
		Get_Input(num_correct, num_questions);
	}

	return 0;

}

void Get_Input(int& num_correct, int& num_questions){

	cout << "Enter the number of questions answered correctly: ";
	cin >> num_correct;

		if(num_correct<0){
			return;
		}

	cout << "Enter the total number of questions: ";
	cin >> num_questions;

	while(num_questions < num_correct || num_questions==0){

	cout << "Invalid! Try Again!\n";
	cout << "Enter the total number of questions: ";
	cin >> num_questions;

	}

}

double Calculate_Grade(char& let_grade, double num_correct, double num_questions, bool& passing){

	double perc;

	perc=num_correct/num_questions*100;

	if(perc >= 90){
		let_grade='A';
	}

	else if(perc < 90 && perc >= 80){
		let_grade='B';
	}

	else if(perc < 80 && perc >= 70){
		let_grade='C';
	}

	else if(perc < 70 && perc >= 60){
		let_grade='D';
	}

	else{
		let_grade='F';
	}

	if(perc >= 59.5){
		passing=true;
	}

	else{
		passing=false;
	}

	return num_correct/num_questions*100;

}

void Print_Results(double grade, bool passing, char let_grade){

	if(passing==true){
		cout << "Your grade of " << grade << " is a " << let_grade << " and is passing\n\n";
	}

	else{
		cout << "Your grade of " << grade << " is a " << let_grade << " and is failing\n\n";
	}

}




