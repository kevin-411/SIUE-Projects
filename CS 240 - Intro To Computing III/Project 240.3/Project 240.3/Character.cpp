#include "Character.h"
#include <string>

namespace PostfixNS {
		// Returns true if parameter is an operand (A-Z), false otherwise.
		// Assumes the character is uppercase.
		bool Character::IsOperand(const char ch){

			char temp=toupper(ch);

			if(temp >= 'A' && temp <= 'Z'){
				return true;
			}

			return false;
		}

		// Returns true if parameter is an operator, false otherwise.
		// Supported operators are: +, -, *, /, %.
		bool Character::IsOperator(const char ch){
			if(ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '%'){
				return true;
			}
			return false;
		}

		// Assigns a precedence value to each level of precedence. Lowest
		// order starts at 1, increasing by one the higher the level.
		int Character::PrecedenceOf(const char op){

			if(op == '('||op == ')'){
				return 3;
			}
			else if (op == '%' ||op == '/'||op == '*'){
				return 2;
			}
			else if(op == '+'||op == '-'){
				return 1;
			}

			return 0;
		}
}//Postfix