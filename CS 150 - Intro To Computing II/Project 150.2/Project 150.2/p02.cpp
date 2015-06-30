//File: P02.cpp

//Date: 09/13/2011

//Name: Brian Olsen

//Course:  CS 150-001 - Introduction to Computing II

//Desc:This program inputs an array and calculates the sum with a recursive function.  

//Once the sum is calculated the average is taken displayed along with a binary search locating the position of 50.

//A programmers not is also displayed.

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

const int ARRAY_MAX_ELEMENTS = 100;
const int NUMBER_OF_ELEMENTS = 10;

typedef int ListType;
typedef int List[ARRAY_MAX_ELEMENTS];

// Recursive binary search.
// Finds the key in the array and returns its position in the array or -1 if
// not found.
int BinarySearch(const ListType key, const List items, const int from, const int to);

// Recursive sum.
// Adds all the elements of the list together and returns their sum. The List
// must be of a type whose elements can produce a numeric sum.
ListType SumItems(const List items, const int numberOfItems);

// Computes the average of a list of numeric items. 
double AverageItems(const ListType sumOfItems, const int numberOfItems);

// Displays an array to the screen.
void DisplayArray(ostream& outStream, const List items, const int numberOfItems);


// Displays programmer note.
void DisplayProgrammerNote(const string& note);


int main() {
	List items = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};

	DisplayProgrammerNote("Programmed by Brian Olsen!");

	cout << "Original array:"
		 << endl
		 << setw(5) << " ";
	DisplayArray(cout, items, NUMBER_OF_ELEMENTS);

	ListType sumofitems = SumItems(items, NUMBER_OF_ELEMENTS);

	cout << endl
		 << endl
		 << "Sum of items:" 
		 << endl
		 << setw(5) << " "
		 << "Sum = " << sumofitems
		 << endl;

	cout << endl
		 << "Average of items:" 
		 << endl
		 << setw(5) << " "
		 << setiosflags(ios::fixed)
		 << setprecision(1)
		 << "Ave = " << AverageItems(sumofitems, NUMBER_OF_ELEMENTS)
		 << endl;

	cout << endl
		 << "Locating item 50 with binary search:" 
		 << endl
		 << setw(5) << " "
		 << "pos = " << BinarySearch(50, items, 0, NUMBER_OF_ELEMENTS - 1) + 1
		 << endl;

	cout << endl << endl;
	return 0;
}


//FUNCTION DEFINITIONS.
int BinarySearch(const ListType key, const List items, const int from, const int to){

		int mid = (from + to) / 2;

		if(items[mid]==key){

			return mid;

		}

		else if (items[mid] > key) {

			return BinarySearch(key,items,mid-1,mid-1);

		}

		else{

			return BinarySearch(key,items,mid+1,mid+1);

		}


	}

ListType SumItems(const List items, const int numberOfItems){

	if(numberOfItems==0){

		return 0;

	}

	else{

		return(items[numberOfItems-1] + SumItems(items,numberOfItems-1));

	}
	

}

double AverageItems(const ListType sumOfItems, const int numberOfItems){

	return sumOfItems/numberOfItems;

}

void DisplayArray(ostream& outStream, const List items, const int numberOfItems){

	for(int i=0; i <= numberOfItems-1; i++){

		outStream << items[i] << " ";

	}



}

void DisplayProgrammerNote(const string& note){

	cout << note << endl << endl;

}