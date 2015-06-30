#ifndef POSTFIX_H
#define POSTFIX_H

using namespace std;

#include <string>
using namespace std;

namespace PostfixNS {
	typedef int expressionType;

	/*
	 * Class: Postfix
	 *
	 * Class evaluates a postfix expression consisting of single character
	 * identifiers.
	 */
	class Postfix {
	private:
		static string postfixString;
		static expressionType operandValue[26];

		// Returns the numeric evaluation of a single arithmetic expression.
		static expressionType EvaluateExpression(const expressionType operand1, 
												 const expressionType operand2, 
												 const char op);

	// Analyzes the operands used in the postfix expression and
	// asks the user for their numeric values. If an operand is
	// used more than one time in the expression, its value is
	// asked for only once.
	static void ValueOfOperands();

	public:
		// Returns the numeric evaluation of a postfix expression.
		// Makes use of the methods offered in the Character class.
		// Stores the parameter value in the instance field.
		// Calls ValueOfOperands() to obtain the numeric value of the operands.
		static expressionType EvaluatePostfix(const string& postfixString);
	};

	//string Postfix::postfixString;
	//expressionType Postfix::operandValue[26];
} // end PostfixNS

#endif