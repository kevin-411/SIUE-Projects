#ifndef CONVERT_H
#define CONVERT_H

using namespace std;

#include <string>

using namespace std;

namespace PostfixNS {
	/*
	 * Class: Convert
	 *
	 * Class converts an infix expression to postfix.
	 */
	class Convert {
	public:
		// Returns the postfix conversion of an infix expression.
		static string ToPostfix(const string& infixString);
	};
} // end PostfixNS
#endif