#ifndef CONVERT_H
#define CONVERT_H
#include <iostream>
#include <string>

using namespace std;

namespace ConvertNS {
	typedef unsigned int uint;

	class Convert {

	private:

		string hexadecimal;
		string binary;
		uint decimal;

		//converts from decimal to binary
		string convertDecToBin(uint dec,uint base);

		//converts from decimal to hexidecimal
		string convertDecToHex(uint dec,uint base);

		//converts from binary to decimal
		uint convertBinToDec(string bin, uint index);

		//converts from hexidecimal to decimal
		uint convertHexToDec(string hex, uint index);

		//converts the hex alpha chars to decimal
		uint getDecimalEquivalent(char hexChar);

	public: 

		//default constructer initializes hexadecimal and binary strings to empty and decimal to 0
		Convert();

		//returns hexadecimal value
		string GetHex()const;

		//returns binary value
		string GetBin()const;

		//returns decimal value
		uint GetDec()const;

		//checks if dec equals zero and calls private convert method or sets binary to zero
		void DecToBin(uint dec);

		//checks if dec equals zero and calls private convert method or sets hexadecimal to zero
		void DecToHex(uint dec);

		//calls private convert method
		void BinToDec(string bin);	

		//calls private convert method
		void HexToDec(string hex);

	};//end Convert class
}//end namespace Convert NS
#endif