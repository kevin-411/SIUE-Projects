#ifndef	CHARACTER_H
#define CHARACTER_H

using namespace std;

namespace PostfixNS {
	/*
	 * Class: Character
	 *
	 * Class consists of class-level methods that provide functionality
	 * useful in a converting and evaluating expressions.
	 */
	class Character {
	public:
		// Returns true if parameter is an operand (A-Z), false otherwise.
		// Assumes the character is uppercase.
		static bool IsOperand(const char ch);

		// Returns true if parameter is an operator, false otherwise.
		// Supported operators are: +, -, *, /, %.
		static bool IsOperator(const char ch);

		// Assigns a precedence value to each level of precedence. Lowest
		// order starts at 1, increasing by one the higher the level.
		static int PrecedenceOf(const char op);
	};
} // end PostfixNS

#endif