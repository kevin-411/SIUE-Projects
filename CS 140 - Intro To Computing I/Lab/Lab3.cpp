//Brian Olsen

//CS140 Lab Section 021

//File Lab3.cpp

#include <iostream>

using namespace std;

void main()
{
 
    int lImit, sPeed, eXcess, fIne;

	cout << "Programmed by Brian Olsen" << endl;

	cout << endl;

	cout << "Enter the speed limit: ";

	cin >> lImit;

	cout << "Enter driving speed: ";

	cin >> sPeed;

	eXcess = sPeed-lImit;

	cout << endl;

	cout << "Excess speed: " << eXcess << " mph" << endl;

	if (eXcess <= 0) {

		fIne=0;

	}

	else if ((eXcess >= 1 && eXcess <= 10)) {

		fIne=55;

	}

	else if ((eXcess > 10) && (eXcess <= 25)) {

		fIne=75;

	}

	else if ((eXcess > 25) && (eXcess <= 35)) {

		fIne=110;

	}

	else if (eXcess > 35) {

		fIne=175;

	}

	cout << "Fine: $" << fIne << endl;

	cout << endl;

}