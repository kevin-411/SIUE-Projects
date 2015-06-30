//File: P05.cpp

//Date: 11/03/2011

//Name: Brian Olsen

//Course:  CS 150-001 - Introduction to Computing II

//Desc:This program can take the input of two Events and assign them into an array.

//The program can then display the events or manipulate them as needed and calculate days between two events.

#include <iostream>
#include <string>
#include "p05.h"
#include "Event.h"
#include "EventTracker.h"
#include "EventCountDown.h"

using namespace std;
using namespace P05;

void TestingEventClass();
void TestingEventTrackerClass();
void TestingEventCountDownClass();


int main() {
	/*TestingEventClass();*/
	//TestingEventTrackerClass();
	//TestingEventCountDownClass();
	
	Event today;
	Event eventTracked;
	int month;
	int day;
	int year;
	char slash;
	string eventTitle;
	int daysElapsed;
	char another;
	char space;

	do {
		// Get today's date.
		cout << "Enter today's date [m/d/yyyy]: ";
		cin >> month >> slash >> day >> slash >> year;

		// Set the today object.
		today.SetEvent(month, day, year, "today");

		// Get the tracked event.
		cout << "Enter event to track [m/d/yyyy title]: ";
		cin >> month >> slash >> day >> slash >> year;
		cin.ignore(1);								// ignore the space
		getline(cin, eventTitle);

		// Set the tracked event object.
		eventTracked.SetEvent(month, day, year, eventTitle);

		// Compute the days elapsed.
		daysElapsed = EventCountDown::TimeElapsed(eventTracked, today);
		
		// Show days elapsed.
		cout << "    " 
			 << eventTracked.GetTitle();
		if (daysElapsed < 0) {
		cout << " was "
			 << -daysElapsed
			 << " days ago."
			 << endl;
		} else {
			cout  << " is "
				 << daysElapsed
				 << " days away."
				 << endl;
		}// end else

		cout << endl
			 << "Enter another (y|n)? ";
		cin >> another;
	} while (another == 'y' || another == 'Y');

	cout << endl << endl;
	return 0;
}// end main()


void TestingEventClass() {
	Event empty;
	Event programDue(11, 4, 2011, "P05 due date");

	cout << "Testing the Event class:"
         << endl
		 << endl 
		 << "empty: " << empty.ToString()
		 << endl
		 << "programDue: " << programDue.ToString()
		 << endl;
	
	empty.SetEvent(20, 38, 2012, "Invalid empty event");
	
	cout << "empty: " << empty.ToString()
		 << endl;
	
	empty.SetMonth(10);
	empty.SetDay(18);
	empty.SetYear(2011);
	empty.SetTitle("Corrected empty event");

	cout << "empty: " << empty.ToString()
		 << endl;

}// end TestingEventClass()

void TestingEventTrackerClass() {
	EventTracker events;
	EventTracker eventTracker1(Event(10, 18, 2011, "Event 1"));
	EventTracker eventTracker2(11, 4, 2011, "Event 2");
	Event event1(10, 18, 2012, "Event 1");

	try {
		eventTracker2.Add(event1);
		cout << "Testing the EventTracker Class: "
			 << endl
			 << "Events: " << events.Count()
			 << endl
			 << events.ToString()
			 << endl
			 << "EventTracker1: " << eventTracker1.Count()
			 << endl
			 << eventTracker1.ToString()
			 << endl
			 << "EventTracker2: " << eventTracker2.Count()
			 << endl
			 << eventTracker2.ToString()
			 << endl;

		eventTracker2.Remove(event1);

		cout << "After removing Event 1:"
			 << endl
			 << "EventTracker2: " << eventTracker2.Count()
			 << endl
			 << eventTracker2.ToString()
			 << endl
			 << "EventTracker1: " 
			 << endl
			 << eventTracker1.RetrieveAt(1).ToString()
			 << endl
			 << "empty: " << eventTracker1.IsEmpty()
			 << endl;
	}
	catch (EventTrackerException ete) {
		cerr << ete.What() << endl;
	}// end catch
}// end TestingEventTrackerClass()

void TestingEventCountDownClass() {
	Event today(10, 18, 2011, "today");
	Event xmas(12, 25, 2011, "xmas");

	int daysElapsed = EventCountDown::TimeElapsed(xmas, today);
	
	cout << "From " 
		 << today.GetYear() 
		 << "/"
		 << today.GetMonth()
		 << "/"
		 << today.GetDay()
		 << " ";

	if (daysElapsed < 0) {
		cout << xmas.GetTitle()
			 << " was "
			 << -daysElapsed
			 << " days ago."
			 << endl;
	} else {
		cout << xmas.GetTitle()
			 << " is "
			 << daysElapsed
			 << " days away."
			 << endl;
	}// end else
}// end TestingEventCountDownClass()