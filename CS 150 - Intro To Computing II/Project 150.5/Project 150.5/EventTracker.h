#ifndef EVENT_TRACKER_H
#define EVENT_TRACKER_H

#include "p05.h"
#include "Event.h"

namespace P05 {
	//-------------------------------------------------------------------------
	// Class: EventTrackerException
	//
	//-------------------------------------------------------------------------
	class EventTrackerException {
	private:
		string errorMessageField;

	public:
		EventTrackerException(const string& errorMessage = 
			                  "EventTrackerException thrown")
			: errorMessageField(errorMessage)
		{}// end EventTrackerException()

		string What() const {
			return "EventTrackerException :: " + errorMessageField;
		}// end What()
	};// end EventTrackerException

	//-------------------------------------------------------------------------
	// Class: EventTracker
	//
	// Class stores a sorted list of Events by date.
	//-------------------------------------------------------------------------
	class EventTracker {
	private:
		Event itemsField[MAX_EVENTS_TRACKED];
		uint numberOfItemsField;

		// Returns the index associated with the pos.
		uint IndexOf(const uint pos) const;

	public:
		// Initializes the numberOfItemsField to 0.
		EventTracker();

		// Adds the event to the list in sorted order. Calls the Add() method
		// to perform the addition. If the Add() throws an error, catch it,
		// report the error "Error calling Add() in EventTracker()" and throw
		// the caught exception. This way the errors will be tracked.
		EventTracker(const Event& eventTracked);

		// Creates and event and adds it to the list in
		// sorted order. Adds the event to the list in sorted order. Calls the Add() method
		// to perform the addition. If the Add() throws an error, catch it,
		// report the error "Error calling Add() in EventTracker(...)" and throw
		// the caught exception. This way the errors will be tracked.
		EventTracker(const int month,
			         const int day,
					 const int year,
					 const string& title);

		// Adds the event to the list. Throws an EventTrackerException with
		// the error "List is full in Add()" if list is full.
		void Add(const Event& eventTracked);

		// Removes the event from the list. Throws an EventTrackerException with
		// the error "Event not found in Remove()" if event not in the list.
		void Remove(const Event& eventRemoved);

		// Returns the event at the specified position. Throws an EventTrackerException with
		// the error "Invalid position (pos) in RetrieveAt()" if pos is out or range.
		Event RetrieveAt(const uint pos) const;

		// Returns true if event is tracked and updates pos to reflect its position
		// within the list. If the event is not on the list, it returns false and
		// updates pos to reflect its eventual position.
		bool Contains(const Event& eventTracked, uint& pos) const;

		// Returns true if empty, false otherwise.
		bool IsEmpty() const;

		// Returns the length of the list.
		uint Count() const;

		// Returns a list of all the events, one event per line.
		string ToString() const;
	};// end EventTracker
}// end namespace P05
#endif