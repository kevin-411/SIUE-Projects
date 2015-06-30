//File: P03.cpp

//Date: 02/22/2012

//Name: Brian Olsen

//Course:  CS 240-001 - Introduction to Computing III

//Desc:This program inputs an In Fix expression using uppercase variables then converts the expression to Post Fix.

// Then it evaluates the expression and outputs the Pre and Post Fix expressions and the result.
#include "Convert.h"
#include "Postfix.h"

#include <iomanip>
#include <iostream>
#include <string>

using namespace std;
using namespace PostfixNS;

int main(void) {
	string infixString;
	string postfixString;
	expressionType postfixResult;

	// Output an instructional message.
	cout << "Program will evaluate an infix expression. Use A-Z for the operands"
		 << endl
		 << "*, /, %, +, -, () for operators. You may add a space around operators."
		 << endl
		 << endl;

	// Get the infix expression from the user.
	cout << "Enter an infix expression: ";
	getline(cin, infixString);

	// Convert to postfix.
	postfixString = Convert::ToPostfix(infixString);

	// Evaluate the expression.
	postfixResult = Postfix::EvaluatePostfix(postfixString);

	cout << endl
		 << right
		 << setw(30) << infixString
		 << setw(3) << " "
		 << "converts to "
		 << setw(3) << " "
		 << left
		 << setw(30) << postfixString
		 << endl;

	// evaluate the postfix expressions
	cout << right
		 << setw(30) << infixString
		 << setw(3) << " "
		 << "evaluates to"
		 << setw(3) <<  " "
		 << left
		 << postfixResult
		 << endl
		 << endl;

	return (0);
}