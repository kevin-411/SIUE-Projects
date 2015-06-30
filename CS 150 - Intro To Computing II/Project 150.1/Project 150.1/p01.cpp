//File: P01.cpp

//Date: 08/27/2011

//Name: Brian Olsen

//Course:  CS 150-001 - Introduction to Computing II

//Desc:This program inputs a text file and reads the scrambled words into function to unscramble them.  

//Once read in, the new unscrambled sentences are then displayed to the screen.

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

//constant variables
const int MAX_TOKENS_PER_STRING = 50;
const string INPUT_FILE = "p01.txt";
const char SPLIT_DELIMITER = ' ';

//function headers
bool ConnectInputFile(ifstream& fin, const string& filename);

void SplitStringIntoTokens(const string& stringToSplit, 
						   string tokens[], int& numberOfTokens,
						   const char& delimiter);

string ReverseTheString(const string& str);


int main() {

	//main() Local Variables

	ifstream fin;

	string str="";

	int tokint=0;

	string tok[MAX_TOKENS_PER_STRING]={""};

	//connection code calls on a function within the if statement if conneciton fails error message will occur and program will be terminated

	if (ConnectInputFile(fin, INPUT_FILE) == false) {
		cerr << "Error opening file " << INPUT_FILE << " for input. Aborting!"
			 << endl
			 << endl;
		exit(1);
		}

	//beginning of input will grab a sentence at a time the first function splits the string into tokens and the second unscrambles the token.

	//cout statements are also placed to print out the results before the string is unscrambled and after.

	getline(fin,str);

	while (!fin.eof()){

		SplitStringIntoTokens(str, tok, tokint, SPLIT_DELIMITER);

		cout << str << endl;

		for (int i=0; i <= tokint-1 ;i++){

			tok[i]=ReverseTheString(tok[i]);

			cout << tok[i] << " ";

			tok[i]="";
		
		}

		cout << endl << endl;

		tokint=0;

		getline(fin,str);

	}

	cout << endl;

	fin.close(); //closes the file handle stream.

	return 0;
}// end main()

bool ConnectInputFile(ifstream& fin, const string& filename){

	fin.open(filename.c_str());

	if (fin.fail()){

		return false;

	}

	return true;

}

void SplitStringIntoTokens(const string& stringToSplit, string tokens[], int& numberOfTokens, const char& delimiter){

	string str;

	for (int i=0; i <= stringToSplit.length(); i++){

		if((stringToSplit[i] == delimiter) || (i==stringToSplit.length())){

			tokens[numberOfTokens] = str;

			numberOfTokens++;

			str="";

		}


		else{

			str+=stringToSplit[i];


		}




	}

}

string ReverseTheString(const string& str){

	int l=str.length()-1;
	
	string temp="";

	for(int i=0; i <= l; i++){

		temp+=str[l-i];
	
	}

		return temp;

}