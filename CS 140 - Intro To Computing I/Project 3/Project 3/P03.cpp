//File: P03.cpp

//Date: 02/07/2011

//Name: Brian Olsen

//Course:  CS 140-001 - Introduction to Computing I

//Desc:This program will take the order of any number of pizzas along with any number of toppings.

// After The order is placed it is repeated to the customer along with the price based on specification of the company.

#include <iostream>

#include <string>

using namespace std;

void main() {

	char size, sizeTwo, iOne;

	double intCost=0;

	int num, in, pizzaNumber, inNumber;

	string inOrder, endOrder;

	//Statement for decimal places

	cout.setf(ios::fixed);

	cout.precision(2);

	cout << "Programmed by Brian Olsen." << endl;

	cout << endl;

	cout << "Welcome to \"Perfect Pizza\". Please place your order." << endl;

	cout << endl;

	cout << "# of pizzas: ";

	cin >> num;

	//Begining of pizza statement

	for (pizzaNumber=1; pizzaNumber <= num; pizzaNumber++) {

		cout << endl;

		cout << "PIZZA #" << pizzaNumber << ":" << endl;

		cout << "   [S]mall, [M]edium, [L]arge: ";

		cin >> size;

		//insert this section if you want the size output to be in ALL CAPS.

		//if (size >= 'a' && size <= 'z') {

			//size -= ('a' - 'A');

		//}

		if (size == 'S' || size == 's') {

			intCost=intCost + 8.95;

		}
		else if (size == 'M' || size == 'm') {

			intCost=intCost + 9.95;

		}
		else if (size == 'L' || size == 'l') {

			intCost=intCost + 10.95;

		}

		cout << "             # of ingredients: ";

		cin >> in;

		inOrder=' ';

		//Begining of ingredients statement

		for (inNumber=1; inNumber <= in; inNumber++) {

			cout << "     #" << inNumber << " [S, P, M, O, G, B, C]: ";

			cin >> iOne;

			//insert this section if you want the ingredients output to be in ALL CAPS.

					//if (iOne >= 'a' && iOne <= 'z') {

						//iOne -= ('a' - 'A');

					//}

					if(
						iOne == 'S' || iOne == 's' ||

						iOne == 'P' || iOne == 'p' ||

						iOne == 'C' || iOne == 'c' ||

						iOne == 'M' || iOne == 'm' ||

						iOne == 'O' || iOne == 'o' ||

						iOne == 'G' || iOne == 'g' ||

						iOne == 'B' || iOne == 'b') {
		
						intCost=intCost + 1.15;

						inOrder=inOrder + iOne + ' ';

					}
	
					//invalid ingredient entry statement

					else{

						cout << "Invalid ingredient! Try again!" << endl;
	
						return;
	
					 }//end of invalid ingredient entry statement
	
		}//end of ingredients statement

		endOrder=endOrder + "Ordered: 1 " + size + " (" + inOrder + ")" + "\n";

	}//end of pizza statement

	//This section is showing order back for one pizza

		cout << endl << endl;

        cout << endOrder << endl;

		cout << "Total cost: $" << intCost << endl;

		cout << endl;

}//end of main