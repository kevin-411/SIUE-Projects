#include <iostream>
#include <string>
#include <math.h>
#include "p05.h"
#include "Event.h"
#include "EventTracker.h"
#include "EventCountDown.h"

using namespace std;
namespace P05{

		// Returns a TimeInterval structure containing the time elapsed between
		// the event tracked and the current date.
		int EventCountDown::TimeElapsed(const Event& eventTracked,
			                   const Event& currentDate){

								   int days=0;

								   int Month[] = {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};

								   if (eventTracked.ToString() == currentDate.ToString()){ //case where the same day is entered.

									   return days;

								   }


								   int currentDays=(currentDate.GetYear()-Event().GetYear())*365;//calculates how many years in days there are for both events
								   int eventDays=(eventTracked.GetYear()-Event().GetYear())*365;

								   int year=Event().GetYear();//default year to track the leap year for loop

								   for(year; year < currentDate.GetYear() && eventTracked.GetYear();year++){ 

									 if(Event::IsLeap(year)){ //leap year for loop will add 1 day, if applicable to either of the day counters

										 if(currentDate.GetYear() >=year){
										 
										 currentDays++;

										 }

										 if(eventTracked.GetYear() >=year){
										 
										 eventDays++;

										 }
									

									 }
								   


								   }


								   currentDays+=Month[currentDate.GetMonth()-1];//adds the amount of days up to the month before current year
								   eventDays+=Month[eventTracked.GetMonth()-1];

								   currentDays+=currentDate.GetDay();//adds the amount of days in the current month
								   eventDays+=eventTracked.GetDay();
								   
								   days=eventDays-currentDays;//assigns the difference of the total to days int

								   return days;



								   							//	   int days=0;//day count

							//	   if (eventTracked.ToString() == currentDate.ToString()){ //case where the same day is entered.

							//		   return days;

							//	   }

							//	   else if (eventTracked.ToString() < currentDate.ToString()){ //case where time elapsed is needed for a past date.

							//		   return-(TimeElapsed(currentDate,eventTracked));//recursively calls itself but flipped and negated 

							//	   }

							//int daysPerMonth[] = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

							//int year=currentDate.GetYear();
							//int month=currentDate.GetMonth();

							// for(year; year <= eventTracked.GetYear();year++){ //year for loop

							//	 daysPerMonth[2] = (Event::IsLeap(year))? 29 : 28; //leap year test

							//	 //variable needed for the month for loop. It will either use the future event if it is within the same year or
							//	 //it will use 12 if the future date is a year down the road.
							//	 int monthUpTo=(year==eventTracked.GetYear())? eventTracked.GetMonth() : 12; 

							//	 for(month;month<=monthUpTo;month++){ //month for loop

							//	   days += daysPerMonth[month];

							//	 }

							//	 month=0;//resets months to zero for each year
							// 
							// }

							//	   int extraDays=currentDate.GetDay();//sets extraDays equal to the amount of days you're into the current month.

							//	   extraDays+=(daysPerMonth[eventTracked.GetMonth()]-eventTracked.GetDay());//adds the additional days of the last month after the later date .

							//	   days-=extraDays;

							//	   return days;
		}

}//end namespace P05