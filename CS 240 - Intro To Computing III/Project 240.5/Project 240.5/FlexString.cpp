#include <string>
#include <sstream>
#include "FlexString.h"

using namespace std;

namespace FlexStringNS {

		// The string representation of a value. The value can be one
		// of the following:
		// int, double, char, string
		

		// Initializes valueString to "".
		FlexString::FlexString(){
			valueString="";
		}
		// Conversion constructors.
		FlexString::FlexString(const int value){
			stringstream conversion;
			conversion<<value;

			valueString=conversion.str();
		}
		FlexString::FlexString(const double value){
			stringstream conversion;
			conversion<<value;

			valueString=conversion.str();
		}
		FlexString::FlexString(const char value){
			valueString=value;
		}
		FlexString::FlexString(const string& value){
			valueString=value;
		}

		// Overloaded typecast operators.
		FlexString::operator int() const{
			int num;
			istringstream iss(valueString);
			iss>>num;
			return num;
		}
		FlexString::operator double() const{
			double num;
			istringstream iss(valueString);
			iss>>num;
			return num;
		}
		FlexString::operator char() const{
			return valueString.at(0);
		}
		FlexString::operator string() const{
			return valueString;
		}

		// Overloaded concatenation operators.
		FlexString FlexString::operator +(const FlexString& value){
			valueString+=value.valueString;
			return *this;
		}
		FlexString FlexString::operator +(const int value){
			FlexString val(value);
			return valueString + val.valueString;
		}
		FlexString FlexString::operator +(const double value){
			FlexString val(value);
			return valueString + val.valueString;
		}
		FlexString FlexString::operator +(const char value){
			FlexString val(value);
			return valueString + val.valueString;
		}
		FlexString FlexString::operator +(const string& value){
			FlexString val(value);
			return valueString + val.valueString;
		}

		// Extraction methods.
		int FlexString::ToInt() const{
			int num;
			istringstream iss(valueString);
			iss>>num;
			return num;
		}
		double FlexString::ToDouble() const{
			double num;
			istringstream iss(valueString);
			iss>>num;
			return num;
		}
		char FlexString::ToChar() const{
			return valueString.at(0);
		}
		string FlexString::ToString() const{
			return valueString;
		}
} // end FlexStringNS
