#include <iostream>
#include <string>
#include <sstream>
#include <iomanip>
#include "p05.h"
#include "Event.h"
#include "EventTracker.h"
#include "EventCountDown.h"

using namespace std;
namespace P05{

	// Initializes event to 1/1/1900 and "No title" respectively.
		Event::Event(){

		SetEvent(1,1,1900,"No title");

		}

		// Initializes event to parameter values.
		Event::Event(const int month,
			  const int day,
			  const int year,
			  const string& title){

				  SetEvent(month,day,year,title);

		}

		// Designated setter. All other setter methods/constructors will
		// call this one. Performs necessary input validation to assure
		// the date is valid.
		void Event::SetEvent(const int month,
					  const int day,
					  const int year,
					  const string& title){

			yearField = (year >= 1753)? year : 1900;
			monthField = (month >= 1 && month <= 12)? month : 1;

			int daysPerMonth[] = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
			daysPerMonth[2] = (IsLeap(year))? 29 : 28;

			dayField = (day >= 1 && day <= daysPerMonth[monthField])? day : 1;

			titleField=title;

		}

		// Accessor methods for the month field.
		int Event::GetMonth() const{

			return monthField;

		}
		void Event::SetMonth(const int month){

			SetEvent(month,dayField,yearField,titleField);

		}

		// Accessor methods for the day field.
		int Event::GetDay() const{

			return dayField;

		}
		void Event::SetDay(const int day){

			SetEvent(monthField,day,yearField,titleField);

		};

		// Accessor methods for the year field.
		int Event::GetYear() const{

			return yearField;

		}
		void Event::SetYear(const int year){

			SetEvent(monthField,dayField,year,titleField);

		}

		// Accessor methods for the title field.
		string Event::GetTitle() const{

			return titleField;

		}
		void Event::SetTitle(const string& title){

			SetEvent(monthField,dayField,yearField,title);

		}

		// Returns true if yearField is leap, false otherwise.
		bool Event::IsLeap(const int year){

				bool div_4 = (year % 4 == 0);
				bool div_100 = (year % 100 == 0);
				bool div_400 = (year % 400 == 0);

			return !div_100 && div_4 || div_400;

		}

		// Returns a string representation of the event formatted as:
		// <year>/<month>/<day> :: <title>
		// The day and month fields are two characters with a leading 0
		// if need be, while the year is four digits.
		string Event::ToString() const{
			ostringstream oss;

	oss << setfill('0')
		<< setw(4) << yearField << "/"
		<< setw(2) << monthField << "/"
		<< setw(2) << dayField
		<< " :: " << titleField;

	return oss.str();

		} // end Event

};//end namespace P05