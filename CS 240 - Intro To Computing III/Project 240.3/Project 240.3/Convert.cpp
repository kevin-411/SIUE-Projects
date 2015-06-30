#include <string>
#include <stack>
#include "Convert.h"
#include "Character.h"


using namespace std;

namespace PostfixNS {
	/*
	 * Class: Convert
	 *
	 * Class converts an infix expression to postfix.
	 */
		// Returns the postfix conversion of an infix expression.
	string Convert::ToPostfix(const string& infixString){

		stack <char> opStack;//stack that holds the operaters to flip them to post fix
		string tempPost;// temporary post fix string
		bool space=false; // bool that determins if the expression is spaced or not

		for(int i=0; i <= (int)infixString.length()-1;i++){

			char ch=infixString.at(i);
			
			if(Character::IsOperand(ch)){//if character is operand
				tempPost+=ch;
				if(space){
					tempPost+=' ';
				}
			}
			else if(ch=='('){//if character is (
				opStack.push(ch);
			}
			else if(ch==')' && !opStack.empty()){ // if character is )
				while(opStack.top()!='('){
					tempPost+=opStack.top();
					opStack.pop();
					if(space){
					tempPost+=' ';
					}
				}
				opStack.pop();
			}
			else if(!space && ch==' '){// if character is a space and will assume the expression uses spaces if one is used
				tempPost+=' ';
				space=true;
			}
			else if(Character::IsOperator(ch)){// if character is an operator
				while(!opStack.empty() && opStack.top()!='('
				&& Character::PrecedenceOf(ch)<=Character::PrecedenceOf(opStack.top())){
					tempPost+=opStack.top();
					opStack.pop();
					if(space){
					tempPost+=' ';
					}
				}
				opStack.push(ch);
			}

		}//end for

		while(!opStack.empty()){ // empties out the remainder of the operators in the stack
			tempPost+=opStack.top();
			if(space){
					tempPost+=' ';
			}
			opStack.pop();
		}
		return tempPost;
	}
	
} // end PostfixNS