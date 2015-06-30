#ifndef FLEX_STRING_H
#define FLEX_STRING_H

#include <string>
#include <sstream>

using namespace std;

namespace FlexStringNS {

	class FlexString {
	private:
		// The string representation of a value. The value can be one
		// of the following:
		// int, double, char, string
		string valueString;

	public:
		// Initializes valueString to "".
		FlexString();

		// Conversion constructors.
		FlexString(const int value);
		FlexString(const double value);
		FlexString(const char value);
		FlexString(const string& value);

		// Overloaded typecast operators.
		operator int() const;
		operator double() const;
		operator char() const;
		operator string() const;

		// Overloaded concatenation operators.
		FlexString operator +(const FlexString& value);
		FlexString operator +(const int value);
		FlexString operator +(const double value);
		FlexString operator +(const char value);
		FlexString operator +(const string& value);

		// Extraction methods.
		int ToInt() const;
		double ToDouble() const;
		char ToChar() const;
		string ToString() const;
	}; // end FlexString

} // end FlexStringNS

#endif