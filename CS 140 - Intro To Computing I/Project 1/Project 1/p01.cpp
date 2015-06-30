//File: p01.cpp

//Date: 01/26/2011

//Name: Brian Olsen

//Course:  CS 140-001 - Introduction to Computing I

//Desc:Program asks for first and last name, as well as age. 

//It then decides what age class you are, and displays a welcome message that includes your first name and age class.

#include <string>

#include <iostream>

using namespace std;

void main ()

{	
	int a;

	string fN, lN, cLass;

	cout << "Programmed by Brian Olsen." << endl;

	cout <<endl;

	cout << "Name [First Last]: ";

	cin >> fN >> lN;

	cout << "Age: ";

	cin >> a;

	if (a < 0) {

		cLass = "invalid entry";

	}

	else if ((a >= 0) && (a < 5)) {

	    cLass = "young child";

	}


	else if ((a >= 5) && (a < 13)) {

	    cLass = "child";

	}

	else if ((a >= 13) && (a < 20)) {

		cLass = "teenager";

	}

	else if ((a >= 20) && (a < 40)) {

		cLass = "young adult";

	}

	else if ((a >= 40) && (a < 65)) {

		cLass = "adult";

	}
		
	else if (a >= 65) {

		cLass = "senior citizen";

	}

	cout << "Welcome, " << cLass << " " << fN << "." << endl;

	cout <<endl;

}//end of main()