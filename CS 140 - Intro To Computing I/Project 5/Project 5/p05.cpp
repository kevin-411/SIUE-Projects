//File: P05.cpp

//Date: 03/18/2011

//Name: Brian Olsen

//Course:  CS 140-001 - Introduction to Computing I

//Desc:This program has many different menus of choices that give the user the ability to choose quantities of certain items.
// The majority of the programs tasks are written in seperate functions.

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

// Main menu constants.
enum MainMenu {
	TICKET = 1,
	CONCESSION,
	QUIT
};

// Ticket menu constants.
enum TicketMenu {
	EARLYBIRD = 1, 
	WEEKDAY, 
	WEEKEND, 
	BACK_TICKET
};

// Concession menu constants.
enum ConcessionMenu {
	POPCORN_SMALL = 1, 
	POPCORN_MEDIUM, 
	POPCORN_LARGE, 
	SODA_SMALL, 
	SODA_MEDIUM, 
	SODA_LARGE,
	CANDY,
	BACK_CONCESSION
};

// Ticket cost constants.
const double EARLYBIRD_COST = 5.00;
const double WEEKDAY_COST = 7.50;
const double WEEKEND_COST = 10.00;


// Concession cost constants.
const double POPCORN_SMALL_COST = 3.50;
const double POPCORN_MEDIUM_COST = 4.50;
const double POPCORN_LARGE_COST = 5.50;
const double SODA_SMALL_COST = 1.50;
const double SODA_MEDIUM_COST = 2.00;
const double SODA_LARGE_COST = 2.50;
const double CANDY_COST = 2.50;

const string MENU_HEADER = "Main Menu";
const string TICKET_HEADER = "Ticket Menu";
const string CONCESSION_HEADER = "Concession Menu";

//FUNCTION HEADERS
int MainMenu(string header);

int TicketMenu(string header);

int ConcessionMenu(string header);

double ProcessTicket(int type, double cost);

double ProcessConcession(int type, double cost);

double TicketCost(int choice, int qty);

double ConcessionCost(int choice, int qty);

void DisplayTotalCost(string label, double cost);

// IMPLEMENT MAIN.
int main() {

	cout.setf(ios::fixed);
	cout.precision(2);

	double cost=0;

	int choice=0;
		
		choice=MainMenu(MENU_HEADER);

	while (choice != QUIT){

		switch (choice) {
			
		case TICKET: cost += ProcessTicket(0,0); break;

		case CONCESSION: cost += ProcessConcession(0,0); break;

		}

		choice=MainMenu(MENU_HEADER);
	
	}


	DisplayTotalCost("Total Cost = $ ", cost);

			return 0;
}// END MAIN
//Function Defenitions
int MainMenu(string header){

    int a;

	cout << setw(5) << " " << header << endl << endl
		 << setw(5) << " " << "[1] Ticket" << endl
		 << setw(5) << " " << "[2] Concession" << endl
		 << setw(5) << " " << "[3] Quit" << endl << endl;

	do{
	cout << "Enter your choice [1-3]: ";
	cin >> a;
	cout << endl;
	}while (a < 1 || a > 3);
	
	return a;

}

int TicketMenu(string header){

	int a;

	cout << setw(5) << " " << header << endl << endl
		 << setw(5) << " " << "[1] Early Bird ($5.00)" << endl
		 << setw(5) << " " << "[2] Weekday ($7.50)" << endl
		 << setw(5) << " " << "[3] Weekend ($10.00)" << endl
		 << setw(5) << " " << "[4] Back" << endl << endl;

	do{
	cout << "Enter your choice [1-4]: ";
	cin >> a;
	cout << endl;
	}while (a < 1 || a > 4);
	
	return a;

}

int ConcessionMenu(string header){

		int a;

	cout << setw(5) << " " << header << endl << endl
		 << setw(5) << " " << "[1] Small Popcorn ($3.50)" << endl
		 << setw(5) << " " << "[2] Medium Popcorn ($4.50)" << endl
		 << setw(5) << " " << "[3] Large Popcorn ($5.50)" << endl
		 << setw(5) << " " << "[4] Small Soda ($1.50)" << endl
		 << setw(5) << " " << "[5] Medium Soda ($2.00)" << endl
		 << setw(5) << " " << "[6] Large Soda ($2.50)" << endl
		 << setw(5) << " " << "[7] Candy ($2.50)" << endl
		 << setw(5) << " " << "[8] Back" << endl << endl;

	do{
	cout << "Enter your choice [1-8]: ";
	cin >> a;
	cout << endl;
	}while (a < 1 || a > 8);
	
	return a;

}

double ProcessTicket(int type, double cost){

	type=TicketMenu(TICKET_HEADER);
	
	while (type != BACK_TICKET){

	cost += TicketCost(type,0);

	type=TicketMenu(TICKET_HEADER);

	};

	 return cost;

}

double ProcessConcession(int type, double cost){

	type=ConcessionMenu(CONCESSION_HEADER);
	
	while (type != BACK_CONCESSION){

	cost += ConcessionCost(type,0);

	type=ConcessionMenu(CONCESSION_HEADER);

	};

	 return cost;

}

double TicketCost(int choice, int qty){

	double a;

		cout << "\nEnter qty: ";

		cin >> qty;

		cout << endl;

	switch (choice){
	case EARLYBIRD: a=EARLYBIRD_COST * qty; return a; break;
	case WEEKDAY: a=WEEKDAY_COST * qty; return a; break;
	case WEEKEND: a=WEEKEND_COST * qty; return a; break;
	case BACK_TICKET: return 0; break;

	}

}

double ConcessionCost(int choice, int qty){

		double a;

		cout << "\nEnter qty: ";

		cin >> qty;

		cout << endl;

	switch (choice){
	case POPCORN_SMALL: a=POPCORN_SMALL_COST * qty; return a; break;
	case POPCORN_MEDIUM: a=POPCORN_MEDIUM_COST * qty; return a; break;
	case POPCORN_LARGE: a=POPCORN_LARGE_COST * qty; return a; break;
	case SODA_SMALL: a=SODA_SMALL_COST * qty; return a; break;
	case SODA_MEDIUM: a=SODA_MEDIUM_COST * qty; return a; break;
	case SODA_LARGE: a=SODA_LARGE_COST * qty; return a; break;
	case CANDY: a=CANDY_COST * qty; return a; break;
	case BACK_CONCESSION: return 0; break;

}

}

void DisplayTotalCost(string label, double cost){

		cout << endl << label << cost << endl<< endl;

}