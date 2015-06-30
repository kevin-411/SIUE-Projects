#include <iostream>
#include <string>
#include <sstream>
#include "p05.h"
#include "Event.h"
#include "EventTracker.h"
#include "EventCountDown.h"

using namespace std;
namespace P05{

	// Returns the index associated with the pos.
		uint EventTracker::IndexOf(const uint pos) const{

			return pos-1;

		}

	// Initializes the numberOfItemsField to 0.
		EventTracker::EventTracker() : numberOfItemsField(0){}

		// Adds the event to the list in sorted order. Calls the Add() method
		// to perform the addition. If the Add() throws an error, catch it,
		// report the error "Error calling Add() in EventTracker()" and throw
		// the caught exception. This way the errors will be tracked.
		EventTracker::EventTracker(const Event& eventTracked) : numberOfItemsField(0){

			try{
				
				Add(eventTracked);
				
			}
			
			catch (EventTrackerException ete){

				throw EventTrackerException("Error calling Add() in EventTracker()");

				cerr << ete.What() << endl;

			}


		}

		// Creates and event and adds it to the list in
		// sorted order. Adds the event to the list in sorted order. Calls the Add() method
		// to perform the addition. If the Add() throws an error, catch it,
		// report the error "Error calling Add() in EventTracker(...)" and throw
		// the caught exception. This way the errors will be tracked.
		EventTracker::EventTracker(const int month,
			         const int day,
					 const int year,
					 const string& title) : numberOfItemsField(0){

						 Event eventTracked;

						 eventTracked.SetEvent(month,day,year,title);

						 try{

						 Add(eventTracked);

						 }

						 catch(EventTrackerException ete){

							throw EventTrackerException("Error calling Add() in EventTracker()");

							cerr << ete.What() << endl;

						 }



		}

		// Adds the event to the list. Throws an EventTrackerException with
		// the error "List is full in Add()" if list is full.
		void EventTracker::Add(const Event& eventTracked){

		bool success = Count() < MAX_EVENTS_TRACKED;

		if (success) {
			int i = Count();
			while (i >= 1 && eventTracked.ToString() < itemsField[IndexOf(i)].ToString()) {
				itemsField[IndexOf(i+1)] = itemsField[IndexOf(i)];
				i -= 1;
			}
			itemsField[IndexOf(i + 1)] = eventTracked;
			numberOfItemsField += 1;
		}
		/*return success;*/

		}

		// Removes the event from the list. Throws an EventTrackerException with
		// the error "Event not found in Remove()" if event not in the list.
		void EventTracker::Remove(const Event& eventRemoved){

		bool success;
		int i = 1;

			while (i <= Count() && eventRemoved.ToString() != itemsField[IndexOf(i)].ToString()) {
				i += 1;
			}

			success = i <= Count();

			for (int j = i + 1; j <= Count(); j++) {
				itemsField[IndexOf(j - 1)] = itemsField[IndexOf(j)];
			}
		
			if (success) {
			
				numberOfItemsField -= 1;

			}

		}

		// Returns the event at the specified position. Throws an EventTrackerException with
		// the error "Invalid position (pos) in RetrieveAt()" if pos is out or range.
		Event EventTracker::RetrieveAt(const uint pos) const{

			ostringstream oss;

			oss << pos;

			if(pos > MAX_EVENTS_TRACKED || pos > Count()){

				throw EventTrackerException("Invalid position (" + oss.str() + ") in RetrieveAt()");

			}

			return itemsField[IndexOf(pos)];

		}

		// Returns true if event is tracked and updates pos to reflect its position
		// within the list. If the event is not on the list, it returns false and
		// updates pos to reflect its eventual position.
		bool EventTracker::Contains(const Event& eventTracked, uint& pos) const{

			pos = 1;
		while (pos <= Count() && EventTracker::itemsField[IndexOf(pos)].ToString() != eventTracked.ToString()) {
			pos += 1;
		}
		bool success = pos <= Count();
		return success;

			return true;

		}

		// Returns true if empty, false otherwise.
		bool EventTracker::IsEmpty() const{

			 return Count()==0;

		}

		// Returns the length of the list.
		uint EventTracker::Count() const{

			return numberOfItemsField;

		}

		// Returns a list of all the events, one event per line.
		string EventTracker::ToString() const{

			ostringstream oss;

			if(Count()==0){

				return oss.str();

			}
			
			for(int i=0;i <= Count()-1;i++){

				oss << itemsField[i].ToString() << endl;

			}

			return oss.str();



		}// end EventTracker

};//end namespace P05