#ifndef EVENT_H
#define EVENT_H

#include <string>
using namespace std;

namespace P05 {
	//-------------------------------------------------------------------------
	// Class: Event
	//
	// Class stores a single event. The event consists of the date and title of
	// the event.
	//-------------------------------------------------------------------------
	class Event {
	private:
		int monthField;
		int dayField;
		int yearField;
		string titleField;

	public:
		// Initializes event to 1/1/1900 and "No title" respectively.
		Event();

		// Initializes event to parameter values.
		Event(const int month,
			  const int day,
			  const int year,
			  const string& title);

		// Designated setter. All other setter methods/constructors will
		// call this one. Performs necessary input validation to assure
		// the date is valid.
		void SetEvent(const int month,
					  const int day,
					  const int year,
					  const string& title);

		// Accessor methods for the month field.
		int GetMonth() const;
		void SetMonth(const int month);

		// Accessor methods for the day field.
		int GetDay() const;
		void SetDay(const int day);

		// Accessor methods for the year field.
		int GetYear() const;
		void SetYear(const int year);

		// Accessor methods for the title field.
		string GetTitle() const;
		void SetTitle(const string& title);

		// Returns true if yearField is leap, false otherwise.
		static bool IsLeap(const int year);

		// Returns a string representation of the event formatted as:
		// <year>/<month>/<day> :: <title>
		// The day and month fields are two characters with a leading 0
		// if need be, while the year is four digits.
		string ToString() const;
	}; // end Event
}// end namespace P05
#endif