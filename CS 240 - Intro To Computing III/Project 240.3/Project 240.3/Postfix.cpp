#include <string>
#include <stack>
#include <iostream>
#include "Postfix.h"
#include "Character.h"
using namespace std;

namespace PostfixNS {

	/*
	 * Class: Postfix
	 *
	 * Class evaluates a postfix expression consisting of single character
	 * identifiers.
	 */
	string Postfix::postfixString;
	expressionType Postfix::operandValue[26];


		// Returns the numeric evaluation of a single arithmetic expression.
		expressionType Postfix::EvaluateExpression(const expressionType operand1, 
												 const expressionType operand2, 
												 const char op){
			char temp=op;
			if(temp=='+'){
			return operand1 + operand2;
			}
			else if(temp=='-'){
			return operand1 - operand2;
			}
			else if(temp=='*'){
			return operand1 * operand2;
			}
			else if(temp=='/'){
			return operand1 / operand2;
			}
			else if(temp=='%'){
			return operand1 % operand2;
			}
			return 0;
		}

		// Analyzes the operands used in the postfix expression and
		// asks the user for their numeric values. If an operand is
		// used more than one time in the expression, its value is
		// asked for only once.
		void Postfix::ValueOfOperands(){
	
			for(int i=0; i <= (int)Postfix::postfixString.length()-1; i++){
				char temp=Postfix::postfixString.at(i);
				if(Character::IsOperand(temp) && Postfix::operandValue[temp-'A']==NULL){
					cout << "Enter a value for " << temp << ": ";
					cin >> Postfix::operandValue[temp-'A'];
				}
			}

		}

	
			// Returns the numeric evaluation of a postfix expression.
			// Makes use of the methods offered in the Character class.
			// Stores the parameter value in the instance field.
			// Calls ValueOfOperands() to obtain the numeric value of the operands.
		expressionType Postfix::EvaluatePostfix(const string& postfixString){

			Postfix::postfixString=postfixString;
			stack <expressionType> opStack;

			ValueOfOperands();

			for(int i=0; i <= (int)postfixString.length()-1;i++){
			char ch=postfixString.at(i);

				if(Character::IsOperand(ch)){
					int index=ch-'A';
					opStack.push(Postfix::operandValue[index]);
				}
				else if (ch != ' '){
					char op;
					expressionType operand1, operand2;
					operand2=opStack.top();
					opStack.pop();
					operand1=opStack.top();
					opStack.pop();
					op=ch;
					opStack.push(EvaluateExpression(operand1,operand2,op));
				}
			
			}
			return opStack.top();
		}

	
} // end PostfixNS