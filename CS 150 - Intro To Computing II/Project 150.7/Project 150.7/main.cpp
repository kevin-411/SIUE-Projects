//File: P07.cpp

//Date: 12/01/2011

//Name: Brian Olsen

//Course:  CS 150-001 - Introduction to Computing II

//Desc:This program can take the input of various words and store them into sepereate linked lists and printed out from those lists.

#include "main.h"

int main() {
	// Testing the WordTracker class.
	/* TestWordTrackerClass();*/

	WordTracker wt;
	LoadWordTrackerFromFile(wt, "words.txt");

	cout << "Listing contents of words.txt:"
		 << endl
		 << "------------------------------"
		 << endl;
	wt.ListAllWords();
	cout << endl << endl;

	return 0;
}// end main()


void TestWordTrackerClass() {
	WordTracker wt;

	try {
		cout << "Original empty WordTracker:"
			 << endl 
			 << "-------------------------------------------"
			 << endl;
		wt.ListAllWords();

		/* Add a few words to the tracker.*/
		wt.AddWord("Hello");
		wt.AddWord("Hi");
		wt.AddWord("The");
		wt.AddWord("A");
		wt.AddWord("Zoo");

		cout << endl
			 << "After adding 5 words to the tracker:"
			 << endl
			 << "-------------------------------------------"
			 << endl;
		wt.ListAllWords();

		// Get the count of the H list.
		cout << endl
			 << "List of H list ("
			 << wt.GetCountOfWordsStartingWith('H') 
			 << "):"
			 << endl
			 << "-------------------------------------------"
			 << endl;
		wt.ListWordsStartingWith('h');
	
		// Remove the Z list.
		cout << endl
			 << "After removing Z list:"
			 << endl 
			 << "-------------------------------------------"
			 << endl;
		wt.RemoveWordsStartingWith('Z');
		wt.ListAllWords();

		// Make a duplicate copy.
		WordTracker duplicate(wt);
		
		duplicate.AddWord("Duplicate");
		cout << endl
			 << "Duplicate list:"
			 << endl 
			 << "-------------------------------------------"
			 << endl;
		duplicate.ListAllWords();
		cout << endl
			 << "Original list:"
			 << endl;
		wt.ListAllWords();

		// Assign original to duplicate.
		duplicate = wt;

		duplicate.AddWord("Duplicate");
		cout << endl
			 << "Duplicate list after assignment:"
			 << endl 
			 << "-------------------------------------------"
			 << endl;
		duplicate.ListAllWords();
		cout << endl
			 << "Original list:"
			 << endl;
		wt.ListAllWords();
	} catch (bad_alloc ba) {
		cerr << ba.what()
			 << endl;
		exit(1);
	}// end try
	cout << endl << endl;	 
}// end TestWordTrackerClass()

// Connects the file stream to the filename and returns true is
// stream is opened successfully, false otherwise.
bool ConnectInputFile(ifstream& fin, const string& filename){

			fin.open(filename.c_str());

	 if (fin.fail()) {

		  return false;

     }

		  return true;

}

// Reads the file and loads the WordTracker object will all the words.
// It first calls ConnectInputFile() to establish the connection. Catches
// a bad_alloc Exception if any attempt to add a word fails, displays the
// error message in the exception object and exits the application.
void LoadWordTrackerFromFile(WordTracker& wt, const string& filename){

	ifstream fin;
	string temp;

	try{
	if(ConnectInputFile(fin,filename)==true){

		while(!fin.eof()){
			getline(fin,temp);
			if(temp!=""){
			wt.AddWord(temp);
			}
		}

	}
	}catch(bad_alloc ba){
		cerr << ba.what();
	}

}