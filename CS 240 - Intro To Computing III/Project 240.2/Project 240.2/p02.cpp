//File: P02.cpp

//Date: 02/03/2012

//Name: Brian Olsen

//Course:  CS 240-001 - Introduction to Computing III

//Desc:This program inputs integers and produces the conversion either into it's binary or hexidecimal equivilent.
#include <iostream>
#include "Convert.h"
#include <string>
#include <iomanip>


using namespace std;
using namespace ConvertNS;

void main(){

	 Convert binNum1,binNum2,binNum3, hexNum1, hexNum2, hexNum3;
	 
	cout << "Decimal to binary conversions:" << endl;

			binNum1.DecToBin(45);
			binNum2.DecToBin(1024);
			binNum3.DecToBin(10456);

	cout << setw(7) << 45 << " : " << binNum1.GetBin() << endl
			
		 << setw(7) << 1024 << " : " << binNum2.GetBin() << endl
			
		 << setw(7) << 10456 << " : " << binNum3.GetBin() << endl

		 << endl << "Decimal to hexadecimal conversions:" << endl;

			hexNum1.DecToHex(45);
			hexNum2.DecToHex(1024);
			hexNum3.DecToHex(10456);

	cout << setw(7) << 45 << " : " << hexNum1.GetHex() << endl
			
		 << setw(7) << 1024 << " : " << hexNum2.GetHex() << endl
			
		 << setw(7) << 10456 << " : " << hexNum3.GetHex() << endl

		 << endl << "Binary to decimal conversions:" << endl;

			binNum1.BinToDec(binNum1.GetBin());
			binNum2.BinToDec(binNum2.GetBin());
			binNum3.BinToDec(binNum3.GetBin());

	cout << setw(17) << binNum1.GetBin() << " : " << binNum1.GetDec() << endl
			
		 << setw(17) << binNum2.GetBin() << " : " << binNum2.GetDec() << endl
			
		 << setw(17) << binNum3.GetBin() << " : " << binNum3.GetDec() << endl

		 << endl << "Hexadecimal to decimal conversions:" << endl;

			hexNum1.HexToDec(hexNum1.GetHex());
			hexNum2.HexToDec(hexNum2.GetHex());
			hexNum3.HexToDec(hexNum3.GetHex());

	cout << setw(7) << hexNum1.GetHex() << " : " << hexNum1.GetDec() << endl
			
		 << setw(7) << hexNum2.GetHex() << " : " << hexNum2.GetDec() << endl
			
		 << setw(7) << hexNum3.GetHex() << " : " << hexNum3.GetDec() << endl << endl;
}