//File: P03.cpp

//Date: 09/27/2011

//Name: Brian Olsen

//Course:  CS 150-001 - Introduction to Computing II

//Desc:This program can take the input of a phone number and output to a text file all the possible words that could be used for that specific phone number. 

#include <iostream>
#include <string>
#include <sstream>
#include <iomanip>
#include <fstream>
using namespace std;


class PhoneNumber {
private:
	int digits[8];		// [0] is skipped, [1]-[7] correspond to phone#

public:
	// Initializes all 7 digits to 5.
	PhoneNumber();

	// Initializes the object with supplied parameters. Calls 
	// SetPhoneNumber() to actually perform the initialization.
	PhoneNumber(const int exchange, const int line);

	// Initializes the object with supplied parameter. Parses the
	// exchange and line from the string and calls SetPhoneNumber()
	// to actually perform the initialization.
	PhoneNumber(const string& phoneNumber);

	// Sets the object to supplied parameters. Calls SetDigit to set
	// each digit in the phone number.
	void SetPhoneNumber(const int exchange, const int line);

	// Sets the digit at the specified index. If the digit is 0 or 1 it
	// sets the object's corresponding digit to 5 and gives the error message
	// "SetDigit: Invalid digit (<digit>), setting it to 5".
	// Validates the index and gives the error message "SetDigit: Invalid 
	// index (<index>)", if index is out of range. Does not set the digit if 
	// index is invalid.
	void SetDigit(const int digit, const int index);

	// Gets the digit at the specified index. Validates the index to make 
	// sure it is within range, and gives the error message
	// "GetIndex: Invalid index (<index>), if index is invalid.
	int GetDigit(const int index) const;

	// Returns a string containing the number formatted as:
	// 555-5555
	string ToString() const;
}; // end PhoneNumber

PhoneNumber::PhoneNumber(){	

		SetPhoneNumber(555,5555);

}
PhoneNumber::PhoneNumber(const int exchange, const int line){

	SetPhoneNumber(exchange, line);

}
PhoneNumber::PhoneNumber(const string& phoneNumber){

	
	int exchange=0;
	int line=0;

			istringstream iss(phoneNumber.substr(0,3));
			iss >> exchange;

			istringstream iss2(phoneNumber.substr(4,7));
			iss2 >> line;



		SetPhoneNumber(exchange,line);



}
//void PhoneNumber::SetPhoneNumber(const int exchange, const int line){ //this is an alternate method for the SetPhoneNumber that parses from left to right but I thought you may deduce points for implementing it differently.
//
//		int dig=exchange;			//assigns the first section "exchange" of the phone number into digit or "dig"
//
//		int sub=0;					//integer that will be subtracted from the temporary number
//
//		int temp=0;					//integer that is used temporarily 
//
//		int mod=100;				//number to use when moding the original digit
//
//	for (int i=1; i <= 7;i++){
//
//			sub=dig%mod;			//assignment to find out the amount to subtract from temp
//
//			temp=dig-sub;			//temporary digit gets the the value divisable by mod
//
//			dig=dig-temp;			//digit is subtracted from temp to get rid of the digit being currently parsed 
//
//			temp=temp/mod;          //temporary digit is getting divided by mod in order to equal the desired digit being parsed
//
//			mod=mod/10;             //mod is getting divided by ten for the next circulation of the for statement
//
//			if (mod==1/10){			//after we're done with the exchange the line needs to be evaluated
//
//				dig=line;			//assign digit to the second half of the phone number
//
//				mod=1000;           //mod needs to be set to 1000 for 4 digits versus 3 and our original for loop continues
//
//			}
//
//			SetDigit(temp, i);
//
//	}

void PhoneNumber::SetPhoneNumber(const int exchange, const int line){

		int dig=exchange; //sets an exchange to digit to be parsed

		int j=3; //couts in reverse to achieve the correct location in temp array

		int temp=0; //temp integer to hold parsed integers

	for (int i=0; i <= 6; i++){

		temp=dig%10; //mods the digit and assigns to temp

		dig=(dig-temp)/10; //subtracts digit from current digit being parsed and divides it by 10 for the mod to work on the next loop

		SetDigit(temp, j);//inputs the temp parsed digit with the index of j

		j--;

		if(i==2){ //if statement to trigger when exchange is finished parsing and line needs to be assigned

		dig=line;

		j=7;

		}

	}//end for

}
void PhoneNumber::SetDigit(const int digit, const int index){

	if(index >= 1 && index <= 7){

	switch(digit) {

		case 0: cout << "SetDigit: Invalid digit (0), setting it to 5\n"; digits[index]=5; break;

		case 1: cout << "SetDigit: Invalid digit (1), setting it to 5\n"; digits[index]=5; break;

		default: digits[index]=digit; break;

	}

	}

	else{

		cout << "SetDigit: Invalid index " << index << endl;

	}


}
int PhoneNumber::GetDigit(const int index) const{

	if(index >= 1 && index <=7){

		return digits[index];

	}

	else{

		cout << "SetDigit: Invalid index " << index;

		return 5;

	}

}
string PhoneNumber::ToString() const{

	ostringstream oss;

	oss  << PhoneNumber::GetDigit(1)
		 << PhoneNumber::GetDigit(2)
		 << PhoneNumber::GetDigit(3)
		 << "-"
		 << PhoneNumber::GetDigit(4)
		 << PhoneNumber::GetDigit(5)
		 << PhoneNumber::GetDigit(6)
		 << PhoneNumber::GetDigit(7);

	return oss.str();

}




class WordGenerator {
private:
	PhoneNumber phoneNumber;

public:
	// Simply accepts the default value assigned by the
	// PhoneNumber class. Does nothing more.
	WordGenerator();

	// Initializes the object with parameter object.
	// Calls the SetPhoneNumber() method.
	WordGenerator(const PhoneNumber& aPhoneNumber);

	// Sets the object to the parameter object.
	void SetPhoneNumber(const PhoneNumber& aPhoneNumber);

	// Returns the phoneNumber.
	PhoneNumber GetPhoneNumber() const;

	// Generates all 2,187 possible words from the phone number and
	// writes them to the specified stream.
	void Generate(ostream& outStream);//this is where you actually output to the text file...think towards the data structure table in word doc.
};

WordGenerator::WordGenerator(){

	PhoneNumber phoneNumber();

}
WordGenerator::WordGenerator(const PhoneNumber& aPhoneNumber){

	SetPhoneNumber(aPhoneNumber);

}
void WordGenerator::SetPhoneNumber(const PhoneNumber& aPhoneNumber){

     phoneNumber=aPhoneNumber;

}
PhoneNumber WordGenerator::GetPhoneNumber() const{

	return (phoneNumber);

}
void WordGenerator:: Generate(ostream& outStream){

	char chars[3][7]={'0','0'};

	for(int i=0; i <= 2; i++){//for statement for character 1

			switch(phoneNumber.GetDigit(1)){

				case 2: switch(i){case 0:chars[0][0]='A'; case 1: chars[1][0]='B'; case 2: chars[2][0]='C';} break;

				case 3: switch(i){case 0:chars[0][0]='D'; case 1: chars[1][0]='E'; case 2: chars[2][0]='F';} break;

				case 4: switch(i){case 0:chars[0][0]='G'; case 1: chars[1][0]='H'; case 2: chars[2][0]='I';} break;

				case 5: switch(i){case 0:chars[0][0]='J'; case 1: chars[1][0]='K'; case 2: chars[2][0]='L';} break;

				case 6: switch(i){case 0:chars[0][0]='M'; case 1: chars[1][0]='N'; case 2: chars[2][0]='O';} break;

				case 7: switch(i){case 0:chars[0][0]='P'; case 1: chars[1][0]='R'; case 2: chars[2][0]='S';} break;

				case 8: switch(i){case 0:chars[0][0]='T'; case 1: chars[1][0]='U'; case 2: chars[2][0]='V';} break;

				case 9:	switch(i){case 0:chars[0][0]='W'; case 1: chars[1][0]='X'; case 2: chars[2][0]='Y';} break;

				default: cout << "Error with the Word Generator. Error Type: Invalid Input for Phone Number";

			}




		for(int j=0; j <= 2; j++){//for statement for character 2

			switch(phoneNumber.GetDigit(2)){

				case 2: switch(j){case 0:chars[0][1]='A'; case 1: chars[1][1]='B'; case 2: chars[2][1]='C';} break;

				case 3: switch(j){case 0:chars[0][1]='D'; case 1: chars[1][1]='E'; case 2: chars[2][1]='F';} break;

				case 4: switch(j){case 0:chars[0][1]='G'; case 1: chars[1][1]='H'; case 2: chars[2][1]='j';} break;

				case 5: switch(j){case 0:chars[0][1]='J'; case 1: chars[1][1]='K'; case 2: chars[2][1]='L';} break;

				case 6: switch(j){case 0:chars[0][1]='M'; case 1: chars[1][1]='N'; case 2: chars[2][1]='O';} break;

				case 7: switch(j){case 0:chars[0][1]='P'; case 1: chars[1][1]='R'; case 2: chars[2][1]='S';} break;

				case 8: switch(j){case 0:chars[0][1]='T'; case 1: chars[1][1]='U'; case 2: chars[2][1]='V';} break;

				case 9:	switch(j){case 0:chars[0][1]='W'; case 1: chars[1][1]='X'; case 2: chars[2][1]='Y';} break;

				default: cout << "Error with the Word Generator. Error Type: Invalid input for Phone Number";

			}

			for(int k=0; k <= 2; k++){//for statement for character 3

				switch(phoneNumber.GetDigit(3)){

					case 2: switch(k){case 0:chars[0][2]='A'; case 1: chars[1][2]='B'; case 2: chars[2][2]='C';} break;
								
					case 3: switch(k){case 0:chars[0][2]='D'; case 1: chars[1][2]='E'; case 2: chars[2][2]='F';} break;

					case 4: switch(k){case 0:chars[0][2]='G'; case 1: chars[1][2]='H'; case 2: chars[2][2]='k';} break;

					case 5: switch(k){case 0:chars[0][2]='J'; case 1: chars[1][2]='K'; case 2: chars[2][2]='L';} break;

					case 6: switch(k){case 0:chars[0][2]='M'; case 1: chars[1][2]='N'; case 2: chars[2][2]='O';} break;

					case 7: switch(k){case 0:chars[0][2]='P'; case 1: chars[1][2]='R'; case 2: chars[2][2]='S';} break;

					case 8: switch(k){case 0:chars[0][2]='T'; case 1: chars[1][2]='U'; case 2: chars[2][2]='V';} break;

					case 9:	switch(k){case 0:chars[0][2]='W'; case 1: chars[1][2]='X'; case 2: chars[2][2]='Y';} break;

					default: cout << "Error with the Word Generator. Error Type: Invalid input for Phone Number";

				}

				for(int l=0; l <= 2; l++){//for statement for character 4

					switch(phoneNumber.GetDigit(4)){

						case 2: switch(l){case 0:chars[0][3]='A'; case 1: chars[1][3]='B'; case 2: chars[2][3]='C';} break;
								
						case 3: switch(l){case 0:chars[0][3]='D'; case 1: chars[1][3]='E'; case 2: chars[2][3]='F';} break;

						case 4: switch(l){case 0:chars[0][3]='G'; case 1: chars[1][3]='H'; case 2: chars[2][3]='l';} break;

						case 5: switch(l){case 0:chars[0][3]='J'; case 1: chars[1][3]='K'; case 2: chars[2][3]='L';} break;

						case 6: switch(l){case 0:chars[0][3]='M'; case 1: chars[1][3]='N'; case 2: chars[2][3]='O';} break;

						case 7: switch(l){case 0:chars[0][3]='P'; case 1: chars[1][3]='R'; case 2: chars[2][3]='S';} break;

						case 8: switch(l){case 0:chars[0][3]='T'; case 1: chars[1][3]='U'; case 2: chars[2][3]='V';} break;
	
						case 9:	switch(l){case 0:chars[0][3]='W'; case 1: chars[1][3]='X'; case 2: chars[2][3]='Y';} break;

						default: cout << "Error with the Word Generator. Error Type: Invalid Input for Phone Number";

					}

				

					for(int m=0; m <= 2; m++){//for statement for character 5

						switch(phoneNumber.GetDigit(5)){

							case 2: switch(m){case 0:chars[0][4]='A'; case 1: chars[1][4]='B'; case 2: chars[2][4]='C';} break;
								
							case 3: switch(m){case 0:chars[0][4]='D'; case 1: chars[1][4]='E'; case 2: chars[2][4]='F';} break;

							case 4: switch(m){case 0:chars[0][4]='G'; case 1: chars[1][4]='H'; case 2: chars[2][4]='m';} break;

							case 5: switch(m){case 0:chars[0][4]='J'; case 1: chars[1][4]='K'; case 2: chars[2][4]='L';} break;

							case 6: switch(m){case 0:chars[0][4]='M'; case 1: chars[1][4]='N'; case 2: chars[2][4]='O';} break;

							case 7: switch(m){case 0:chars[0][4]='P'; case 1: chars[1][4]='R'; case 2: chars[2][4]='S';} break;

							case 8: switch(m){case 0:chars[0][4]='T'; case 1: chars[1][4]='U'; case 2: chars[2][4]='V';} break;

							case 9:	switch(m){case 0:chars[0][4]='W'; case 1: chars[1][4]='X'; case 2: chars[2][4]='Y';} break;

							default: cout << "Error with the Word Generator. Error Type: Invalid Input for Phone Number";

						}

						for(int n=0; n <= 2; n++){//for statement for character 6

							switch(phoneNumber.GetDigit(6)){

								case 2: switch(n){case 0:chars[0][5]='A'; case 1: chars[1][5]='B'; case 2: chars[2][5]='C';} break;
								
								case 3: switch(n){case 0:chars[0][5]='D'; case 1: chars[1][5]='E'; case 2: chars[2][5]='F';} break;

								case 4: switch(n){case 0:chars[0][5]='G'; case 1: chars[1][5]='H'; case 2: chars[2][5]='n';} break;

								case 5: switch(n){case 0:chars[0][5]='J'; case 1: chars[1][5]='K'; case 2: chars[2][5]='L';} break;

								case 6: switch(n){case 0:chars[0][5]='M'; case 1: chars[1][5]='N'; case 2: chars[2][5]='O';} break;

								case 7: switch(n){case 0:chars[0][5]='P'; case 1: chars[1][5]='R'; case 2: chars[2][5]='S';} break;

								case 8: switch(n){case 0:chars[0][5]='T'; case 1: chars[1][5]='U'; case 2: chars[2][5]='V';} break;

								case 9:	switch(n){case 0:chars[0][5]='W'; case 1: chars[1][5]='X'; case 2: chars[2][5]='Y';} break;

								default: cout << "Error with the Word Generator. Error Type: Invalid Input for Phone Number";

							}

							for(int o=0; o <= 2; o++){//for statement for character 7

								switch(phoneNumber.GetDigit(7)){

									case 2: switch(o){case 0:chars[0][6]='A'; case 1: chars[1][6]='B'; case 2: chars[2][6]='C';} break;
								
									case 3: switch(o){case 0:chars[0][6]='D'; case 1: chars[1][6]='E'; case 2: chars[2][6]='F';} break;

									case 4: switch(o){case 0:chars[0][6]='G'; case 1: chars[1][6]='H'; case 2: chars[2][6]='I';} break;

									case 5: switch(o){case 0:chars[0][6]='J'; case 1: chars[1][6]='K'; case 2: chars[2][6]='L';} break;

									case 6: switch(o){case 0:chars[0][6]='M'; case 1: chars[1][6]='N'; case 2: chars[2][6]='O';} break;

									case 7: switch(o){case 0:chars[0][6]='P'; case 1: chars[1][6]='R'; case 2: chars[2][6]='S';} break;

									case 8: switch(o){case 0:chars[0][6]='T'; case 1: chars[1][6]='U'; case 2: chars[2][6]='V';} break;

									case 9:	switch(o){case 0:chars[0][6]='W'; case 1: chars[1][6]='X'; case 2: chars[2][6]='Y';} break;

									default: cout << "Error with the Word Generator. Error Type: Invalid Input for Phone Number";

								}

										if(o==2){

									     outStream << chars[i][0] << chars[j][1] << chars[k][2] << chars[l][3] << chars[m][4] << chars[n][5] << chars[0][6] << "," 
									   			   << chars[i][0] << chars[j][1] << chars[k][2] << chars[l][3] << chars[m][4] << chars[n][5] << chars[1][6] << ","
												   << chars[i][0] << chars[j][1] << chars[k][2] << chars[l][3] << chars[m][4] << chars[n][5] << chars[2][6] << endl;	
										}



	}//end for statement for character 7

	}//end for statement for character 6

	}//end for statement for character 5

	}//end for statement for character 4

	}//end for statement for character 3

	}//end for statement for character 2

	}//end for statement for character 1

}




void TestingPhoneNumberClass();
void TestingWordGeneratorClass();

int main() {
	
	//TestingPhoneNumberClass();
	TestingWordGeneratorClass();

	cout << endl << endl;
	return 0;
}


//void TestingPhoneNumberClass() {
//	PhoneNumber homePhone(738,2273);
//	
//	cout << "homePhone: " 
//		 << homePhone.ToString()
//		 << endl
//		 << endl;
//
//	cout << "wrongNumber: 210-4500"
//		 << endl;
//
//	PhoneNumber wrongNumber(210,4500);
//	cout << wrongNumber.ToString()
//		 << endl
//		 << endl;
//	wrongNumber.SetDigit(6, 2);
//	wrongNumber.SetDigit(7, 3);
//	wrongNumber.SetDigit(9, 6);
//	wrongNumber.SetDigit(9, 7);
//
//	cout << "Correcting the number to: "
//		 << wrongNumber.GetDigit(1)
//		 << wrongNumber.GetDigit(2)
//		 << wrongNumber.GetDigit(3)
//		 << "-"
//		 << wrongNumber.GetDigit(4)
//		 << wrongNumber.GetDigit(5)
//		 << wrongNumber.GetDigit(6)
//		 << wrongNumber.GetDigit(7)
//		 << endl
//		 << endl;
//}// end TestingPhoneNumberClass()


void TestingWordGeneratorClass() {
	WordGenerator wordGen1;

	int line, exchange;

	//cout << "wordGen1: " << wordGen1.GetPhoneNumber().ToString()
	//	 << endl;

	//WordGenerator wordGen2(PhoneNumber(245,3498));

	//cout << "wordGen2: " << wordGen2.GetPhoneNumber().ToString()
	//	 << endl;

	//wordGen1.SetPhoneNumber(PhoneNumber(738,2273));
	//cout << "wordGen1: " << wordGen1.GetPhoneNumber().ToString()
	//	 << endl;

	cout << "Enter the first three digits of the phone number: " << endl << endl;

	cin >> line;

	cout << "Enter the last four digits of the phone number: " << endl << endl;

	cin >> exchange;

	wordGen1.SetPhoneNumber(PhoneNumber(line,exchange));

	ofstream fout;

	fout.open( (wordGen1.GetPhoneNumber().ToString() + ".csv").c_str() );
	
	if ( !fout.is_open() ) {
		cerr << "Error writing to output file. Aborting!"
			 << endl;
		exit(1);
	}

	wordGen1.Generate(fout);
	fout.close();

}// end TestingWordGeneratorClass()