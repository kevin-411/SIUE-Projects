#ifndef EVENT_COUNTDOWN_H
#define EVENT_COUNTDOWN_H

#include "p05.h"
#include "Event.h"

namespace P05 {
	//-------------------------------------------------------------------------
	// Class: EventCountDown
	//
	// Class offers class-level functionality to compute the time interval
	// from the current date to the tracked event.
	//-------------------------------------------------------------------------
	class EventCountDown {
	public:
		// Returns a TimeInterval structure containing the time elapsed between
		// the event tracked and the current date.
		static int TimeElapsed(const Event& eventTracked,
			                   const Event& currentDate);
	};
}// end namespace P05
#endif