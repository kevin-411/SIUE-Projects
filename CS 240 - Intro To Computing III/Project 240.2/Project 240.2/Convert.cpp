#include "Convert.h"
#include <string>
#include <iostream>
#include <math.h>

using namespace std;
namespace ConvertNS {

	const uint BASE_BIN=2;
	const uint BASE_HEX=16;

		//converts from decimal to binary
		string Convert::convertDecToBin(uint dec,uint base){
			if (dec > 0){
				convertDecToBin(dec/base, base);
				return (binary += (dec%base + '0'));//returns the current string and the next char adding 48 or '0' to convert
			}
			return "";
		}

		//converts from decimal to hexidecimal
		string Convert::convertDecToHex(uint dec,uint base){
			if (dec > 0){
				convertDecToHex(dec/base, base);
				uint temp=dec%base;//temp uint to take the decimals 0-9
				if(temp>=10){
					temp+=7;//adds 7 to the temp if the decimal is 10-15 to get to the correct ascii value
				}
				return (hexadecimal +=char(temp+'0'));//returns the current string and the next char adding 48 or '0' to convert
			}
					return "";
		}

		//converts from hexidecimal to decimal
		uint Convert::convertBinToDec(string bin, uint index){
			
			if(index==0){
				return 0;
			}
			else{
				uint mult=uint(pow(2.0,(int)(index-1)));//takes 2^(power dependant on bit in binary number)
				uint pos=bin.length()-index;//position in binary number to be evaluated
				decimal=convertBinToDec(bin,index-1);//calls function recursively and sets decimal for addition of next return

				return (decimal += (mult * getDecimalEquivalent(bin.at(pos))));
			}
		}

		//converts from hexidecimal to decimal
		uint Convert::convertHexToDec(string hex, uint index){
			
			if(index==0){
				return 0;
			}
			else{
				uint mult=uint(pow(16.0,(int)(index-1)));//takes 16^(power dependant on bit in hexadecimal number)
				uint pos=hex.length()-index;//position in hexadecimal number to be evaluated
				decimal=convertHexToDec(hex,index-1);//calls function recursively and sets decimal for addition of next return

				return (decimal += (mult * getDecimalEquivalent(hex.at(pos))));
			}
		}

		//converts the hex alpha chars to decimal
		uint Convert::getDecimalEquivalent(char hexChar){
					switch(hexChar){
					case '0': return 0; break;
					case '1': return 1; break;
					case '2': return 2; break;
					case '3': return 3; break;
					case '4': return 4; break;
					case '5': return 5; break;
					case '6': return 6; break;
					case '7': return 7; break;
					case '8': return 8; break;
					case '9': return 9; break;
					case 'A': return 10; break;
					case 'B': return 11; break;
					case 'C': return 12; break;
					case 'D': return 13; break;
					case 'E': return 14; break;
					case 'F': return 15; break;
					default: return 0; cout << endl << "Invalid Hex Character adding a zero!" << endl;
					}
				}

		//default constructer initializes hexadecimal and binary strings to empty and decimal to 0
		Convert::Convert() : hexadecimal(""), binary(""), decimal(0){}

		//returns hexadecimal value
		string Convert::GetHex()const{
			return hexadecimal;
		}

		//returns binary value
		string Convert::GetBin()const{
			return binary;
		}

		//returns decimal value
		uint Convert::GetDec()const{
			return decimal;
		}

		//checks if dec equals zero and calls private convert method or sets binary to zero
		void Convert::DecToBin(uint dec){
			if(dec!=0){
			convertDecToBin(dec,BASE_BIN);
			}
			else{
			binary="0";
			}
		}

		//checks if dec equals zero and calls private convert method or sets hexadecimal to zero
		void Convert::DecToHex(uint dec){
			if(dec!=0){
				convertDecToHex(dec,BASE_HEX);
			}
			else{
			hexadecimal="0";
			}
		}

		//calls private convert method
		void Convert::BinToDec(string bin){
			convertBinToDec(bin,bin.length());
		}

		//calls private convert method
		void Convert::HexToDec(string hex){
			convertHexToDec(hex,hex.length());
		}
}//end Convert NS