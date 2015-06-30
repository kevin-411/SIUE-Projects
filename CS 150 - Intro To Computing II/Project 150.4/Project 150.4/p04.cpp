//File: P04.cpp

//Date: 10/20/2011

//Name: Brian Olsen

//Course:  CS 150-001 - Introduction to Computing II

//Desc:This program can take the input of two strings and assign them into a Dictionary of up to 50 items.

//The program can then assign the Dictionary into an Array of Dictionaries and displayed in a like manner to another file or display.

#include "p04.h"
#include "Dictionary.h"
#include "Array.h"
#include <string>
#include <fstream>
#include <iostream>

using namespace std;
using namespace P04;

// Testing functions.
void TestDictionaryClass();
void TestArrayClass();


bool ConnectInputFile(ifstream& fin, const string& filename);
void LoadStates(ifstream& fin, Array& states);
void DisplayStates(Array states);


int main() {
	//TestDictionaryClass();
	//TestArrayClass();

	ifstream fin;
	Array states;

	if ( !ConnectInputFile(fin, "states.txt") ) {
		cerr << "Error opening file states.txt for reading. Aborting!"
			 << endl;
		exit(1);
	}

	LoadStates(fin, states);
	DisplayStates(states);

	cout << endl << endl;
	return 0;
}// end main()

void TestDictionaryClass() {
	Dictionary dictionary;

	cout << "Count = " << dictionary.Count()
		 << endl;
	
	try {
		dictionary.SetValueForKey("Missouri", "Jefferson City");
		dictionary.SetValueForKey("Illinois", "Springfield");

		cout << endl
			 << "After adding two key-value pairs:" << endl
			 << "Count = " << dictionary.Count()
			 << endl
			 << endl
			 << dictionary << endl;

		dictionary.Sort();
		cout << endl
			 << "After sorting dictionary in ascending order:"
			 << endl
			 << dictionary
			 << endl;

		// Add duplicate value.
		dictionary.SetValueForKey("Indiana", "Springfield");
		cout << endl
			 << "Attempting to add key with duplicate value:"
			 << endl
			 << dictionary
			 << endl;
	} catch (DictionaryException de) {
		cerr << de.What()
			 << endl;
	}

	// Update existing key.
		dictionary.SetValueForKey("Illinois", "Vandalia");
		cout << endl
			 << "Changing the value for \"Illinois\""
			 << endl
			 << dictionary
			 << endl;

	try {
		// Get key for non-existing value.
		cout << "Getting the Key for Dover: "
			 << dictionary.GetKeyWithValue("Dover")
			 << endl;

	} catch (DictionaryException de) {
		cerr << de.What()
			 << endl;
	}

}// end TestDictionaryClass()


void TestArrayClass() {
	Array arr;

	cout << "Count = "
		 << arr.Count()
		 << endl
		 << endl;

	Dictionary dictionaryN;

	dictionaryN.SetValueForKey("New Hampshire", "Concord");
	dictionaryN.SetValueForKey("New Mexico", "Santa Fe");
	arr.Add(dictionaryN);

	Dictionary dictionaryI;

	dictionaryI.SetValueForKey("Illinois", "Springfield");
	dictionaryI.SetValueForKey("Indiana", "Indianapolis");
	arr.Add(dictionaryI);
	
	cout << "After adding two dictionaries to the array:"
		 << endl
		 << "Count = " << arr.Count()
		 << endl;
	for (uint i = 0; i <= arr.Count() - 1; i++) {
		cout << arr[i] << endl;
	}

	try {
		cout << arr[3] << endl;
	} catch (ArrayException ae) {
		cerr << ae.What() << endl;
	}// end try
}// end TestArrayClass()


// ADD FUNCTION DEFINITIONS HERE.


bool ConnectInputFile(ifstream& fin, const string& filename){

		fin.open(filename.c_str());

	 if (fin.fail()) {

		  return false;

     }

		  return true;


}
void LoadStates(ifstream& fin, Array& states){

	string k="", v="";//temporary key "k" and value "v" strings

		Dictionary dict;//temporary dictionary "dict"

		getline(fin,k,',');

		getline(fin,v,'\n');

		string test=k;//testing string to check when to assign and move to the next dictionary
	
	while(!fin.eof()){

		dict.SetValueForKey(k,v);//dictionary assignments

		getline(fin,k,',');

		getline(fin,v,'\n');

		if(test.substr(0,1) < k.substr(0,1)){

			states.Add(dict);//array assignments

			dict=Dictionary();//sets dict.numberOfItems to 0

			test=k;

		}


	}

	states.Add(dict);//while loop missed the "W's dictionary" it also missed it on his example so I was unsure on whether to place this or not.
}
void DisplayStates(Array states){

	for (uint i = 0; i <= states.Count() - 1; i++){

		cout << states[i] << endl;

	}

}