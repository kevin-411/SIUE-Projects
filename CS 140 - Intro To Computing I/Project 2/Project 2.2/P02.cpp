//File: P02.cpp

//Date: 01/26/2011

//Name: Brian Olsen

//Course:  CS 140-001 - Introduction to Computing I

//Desc:This program will take the order of up to two pizzas with up to two ingredients per pizza.

// After The order is placed it repeated to the customer along with the price based on specefication of the company.

#include <iostream>

using namespace std;

void main() {

	char size, sizeTwo, iOne, iTwo, iiOne, iiTwo, type;

	double intCost;

	int num, in;

	cout.setf(ios::fixed);

	cout.precision(2);

	cout << "Programmed by Brian Olsen." << endl;

	cout << endl;

	cout << "Welcome to \"Perfect Pizza\". Please place your order." << endl;

	cout << endl;

	cout << "# of pizzas [1-2]: ";

	cin >> num;

	//ONLY 1 PIZZA

	if (num == 1) {

		cout << endl;

		cout << "PIZZA #1:" << endl;

		cout << "[S]mall, [M]edium, [L]arge: ";

	cin >> size;

	if (size == 'S' || size == 's') {

		intCost=8.95;

	}
	else if (size == 'M' || size == 'm') {

		intCost=9.95;

	}
	else if (size == 'L' || size == 'l') {

		intCost=10.95;

	}

	cout << "    # of ingredients [1-2]: ";

	cin >> in;

		if (in == 1) {

			cout << "  #1 [S, P, M, O, G, B, C]: ";

			cin >> iOne;
	
			if (iOne == 'S' || iOne == 's' ||

				iOne == 'P' || iOne == 'p' ||

				iOne == 'C' || iOne == 'c') {
	
				intCost=intCost + 1.15;
			 }

			else if (iOne == 'M' || iOne == 'm' ||

				iOne == 'O' || iOne == 'o' ||

				iOne == 'G' || iOne == 'g' ||

				iOne == 'B' || iOne == 'b') {
	
				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

					iTwo = ' ';


		}//end of statement for 1 pizza 1 ingredient

		else if (in == 2) {

			cout << "  #1 [S, P, M, O, G, B, C]: ";

			cin >> iOne;

			if (iOne == 'S' || iOne == 's' ||

				iOne == 'P' || iOne == 'p' ||

				iOne == 'C' || iOne == 'c') {

				intCost=intCost + 1.15;
			} 

			else if (iOne == 'M' || iOne == 'm' ||
	
				iOne == 'O' || iOne == 'o' ||

				iOne == 'G' || iOne == 'g' ||

				iOne == 'B' || iOne == 'b') {

				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

		cout << "  #2 [S, P, M, O, G, B, C]: ";

		cin >> iTwo;

			if (iTwo == 'S' || iTwo == 's' ||

				iTwo == 'P' || iTwo == 'p' ||

				iTwo == 'C' || iTwo == 'c') {

				intCost=intCost + 1.15;
			}
			else if (iTwo == 'M' || iTwo == 'm' ||

				iTwo == 'O' || iTwo == 'o' ||

				iTwo == 'G' || iTwo == 'g' ||

				iTwo == 'B' || iTwo == 'b') {

				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

		}//end of statement for 1 pizza 2 ingredients

	}//end of only 1 pizza statements


	//ONLY 2 PIZZAS

	else if (num == 2) {

			cout << endl;

			cout << "PIZZA #1:" << endl;

			cout << "[S]mall, [M]edium, [L]arge: ";

	cin >> size;

	if (size == 'S' || size == 's') {

		intCost=8.95;

	}
	else if (size == 'M' || size == 'm') {

		intCost=9.95;

	}
	else if (size == 'L' || size == 'l') {

		intCost=10.95;

	}

	cout << "    # of ingredients [1-2]: ";

	cin >> in;

		if (in == 1) {

			cout << "  #1 [S, P, M, O, G, B, C]: ";

			cin >> iOne;
	
			if (iOne == 'S' || iOne == 's' ||

				iOne == 'P' || iOne == 'p' ||

				iOne == 'C' || iOne == 'c') {
	
				intCost=intCost + 1.15;
			 }

			else if (iOne == 'M' || iOne == 'm' ||

				iOne == 'O' || iOne == 'o' ||

				iOne == 'G' || iOne == 'g' ||

				iOne == 'B' || iOne == 'b') {
	
				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

					iTwo = ' ';


		}//end of statement for first pizza 2 pizzas 1 ingredient

		else if (in == 2) {

			cout << "  #1 [S, P, M, O, G, B, C]: ";

			cin >> iOne;

			if (iOne == 'S' || iOne == 's' ||

				iOne == 'P' || iOne == 'p' ||

				iOne == 'C' || iOne == 'c') {

				intCost=intCost + 1.15;
			} 

			else if (iOne == 'M' || iOne == 'm' ||
	
				iOne == 'O' || iOne == 'o' ||

				iOne == 'G' || iOne == 'g' ||

				iOne == 'B' || iOne == 'b') {

				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

		cout << "  #2 [S, P, M, O, G, B, C]: ";

		cin >> iTwo;

			if (iTwo == 'S' || iTwo == 's' ||

				iTwo == 'P' || iTwo == 'p' ||

				iTwo == 'C' || iTwo == 'c') {

				intCost=intCost + 1.15;
			}
			else if (iTwo == 'M' || iTwo == 'm' ||

				iTwo == 'O' || iTwo == 'o' ||

				iTwo == 'G' || iTwo == 'g' ||

				iTwo == 'B' || iTwo == 'b') {

				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

		}//end of statement for first pizza 2 pizzas 2 ingredients

		cout << endl;

		cout << endl;

		cout << "PIZZA #2:" << endl;

		cout << "[S]mall, [M]edium, [L]arge: ";

		cin >> sizeTwo;

	if (sizeTwo == 'S' || sizeTwo == 's') {

		intCost=intCost + 8.95;

	}
	else if (sizeTwo == 'M' || sizeTwo == 'm') {

		intCost=intCost + 9.95;

	}
	else if (sizeTwo == 'L' || sizeTwo == 'l') {

		intCost=intCost + 10.95;

	}

	cout << "    # of ingredients [1-2]: ";

	cin >> in;

		if (in == 1) {

			cout << "  #1 [S, P, M, O, G, B, C]: ";

			cin >> iiOne;
	
			if (iiOne == 'S' || iiOne == 's' ||

				iiOne == 'P' || iiOne == 'p' ||

				iiOne == 'C' || iiOne == 'c') {
	
				intCost=intCost + 1.15;

			}

			else if (iiOne == 'M' || iiOne == 'm' ||

				iiOne == 'O' || iiOne == 'o' ||

				iiOne == 'G' || iiOne == 'g' ||

				iiOne == 'B' || iiOne == 'b') {
	
				intCost=intCost + 1.15;

			}

			else {

				cout << "No more than two ingredients per order! Try again!" << endl;

				return;

			}

					iiTwo = ' ';

		}//end of statement for second pizza 2 pizzas 1 ingredient

		else if (in == 2) {

			cout << "  #1 [S, P, M, O, G, B, C]: ";

			cin >> iiOne;

			if (iiOne == 'S' || iiOne == 's' ||

				iiOne == 'P' || iiOne == 'p' ||

				iiOne == 'C' || iiOne == 'c') {

				intCost=intCost + 1.15;

			} 

			else if (iiOne == 'M' || iiOne == 'm' ||
	
				iiOne == 'O' || iiOne == 'o' ||

				iiOne == 'G' || iiOne == 'g' ||

				iiOne == 'B' || iiOne == 'b') {

				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

		cout << "  #2 [S, P, M, O, G, B, C]: ";

		cin >> iiTwo;

			if (iiTwo == 'S' || iiTwo == 's' ||

				iiTwo == 'P' || iiTwo == 'p' ||

				iiTwo == 'C' || iiTwo == 'c') {

				intCost=intCost + 1.15;

			}

			else if (iiTwo == 'M' || iiTwo == 'm' ||

				iiTwo == 'O' || iiTwo == 'o' ||

				iiTwo == 'G' || iiTwo == 'g' ||

				iiTwo == 'B' || iiTwo == 'b') {

				intCost=intCost + 1.15;

			}

			else {

			cout << "No more than two ingredients per order! Try again!" << endl;

			return;

			}

		}//end of statement for second pizza 2 pizzas 2 ingredients

	}//end of Pizza #2

	//ELSE STATEMENT IN CASE AN INCORRECT NUMBER IS ENTERED

	else {

		cout << "No more than two pizzas per order! Try again!" << endl;

		return;

	}

	cout << endl;

	cout << endl;

	//This section is showing order back for one pizza

	if (num == 1) {

		if (iTwo == ' ') {

			cout << "Ordered: 1 " << size << " (" 
			 << iOne << ")" <<endl;

		}

		else if (iTwo != ' ') {

			cout << "Ordered: 1 " << size << " (" 
			 << iOne << ", " << iTwo << ")" <<endl;

		}

	}//end of 1 pizza order display

	//this section show back the order for two pizzas

	else if (num == 2) {

		if (iTwo == ' ' && iiTwo != ' ') {

			cout << "Ordered: 1 " << size << " (" 
			 << iOne << ")" <<endl;

			cout << "         1 " << sizeTwo << " (" 
			 << iiOne << ", " << iiTwo << ")" <<endl;

		}

		else if (iTwo == ' ' && iiTwo == ' ') {

			cout << "Ordered: 1 " << size << " (" 
			 << iOne << ")" <<endl;

			cout << "         1 " << sizeTwo << " (" 
			 << iiOne << ")" <<endl;

		}
	
		else if (iTwo != ' ' && iiTwo == ' ') {

		cout << "Ordered: 1 " << size << " (" 
			 << iOne << ", " << iTwo << ")" <<endl;
	
		cout << "         1 " << sizeTwo << " (" 
			 << iiOne << ")" <<endl;

		}

		else if (iTwo != ' ' && iiTwo != ' ') {

		cout << "Ordered: 1 " << size << " (" 
			 << iOne << ", " << iTwo << ")" <<endl;

		cout << "         1 " << sizeTwo << " (" 
			 << iiOne << ", " << iiTwo << ")" <<endl;

		}

	}//end of 2 pizza order display

		cout << "Total cost: $" << intCost << endl;

		cout << endl;

}//end of main

