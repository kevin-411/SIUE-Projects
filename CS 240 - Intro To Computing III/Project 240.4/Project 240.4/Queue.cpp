#include "Queue.h"
#include <string>
#include <Queue>
#include <fstream>
#include <iostream>
#include <iomanip>

using namespace std;


namespace QueueNS {
		// Output the state formatted as:
		// <dateInducted>::<name>
		 ostream& operator <<(ostream& out, const State& object){
			out << right << setw(18) << object.dateInducted << "   " << left << object.name;
			return out;
		}

		// Initializes object with parameters.
		State::State(const string& name, const string& dateInducted){
			SetName(name);
			SetDateInducted(dateInducted);
		}

		// Accessor methods.
		string State::GetName() const{
			return State::name;
		}
		void State::SetName(const string& name){
			State::name=name;
		}
		string State::GetDateInducted() const{
			return State::dateInducted;
		}
		void State::SetDateInducted(const string& dateInducted){
			State::dateInducted=dateInducted;
		}



	/* Class: States
	 *
	 * Uses the STL queue to store all the states in order of induction date.
	 * Each element of the queue is associated with a year of state inductions, and
	 * stores a queue of all the states inducted that year. Therefore, you will wind
	 * up with a queue of queues.
	 */



		// Does nothing.
		States::States(){}

		// Loads all the states from the textfile.
		void States::LoadStatesFromFile(const string& filename){

			ifstream fin;
			string num, stateName, stateDate;
			int length;
			queue <State> dates;

			fin.open(filename.c_str());

			if (fin.fail()) {
				cerr << "Error opening file " << filename.c_str() << " for input. Aborting!" << endl << endl;
				exit(1);
			}
			while (!fin.eof()){
			
				getline(fin,num);

				if(num!=""){
				length=int(num.at(0)-'0');
				}
				for(int i=1;i<=length;i++){
					getline(fin,stateName,':');
					getline(fin,stateDate);

					dates.push(State::State(stateName,stateDate));
				}

				if(!dates.empty()){
				elements.push(dates);
				length=0;
				}
				while(!dates.empty()){
				dates.pop();
				}
			}
			fin.close();
		}

		// Lists all the states to the screen by popping each state.
		void States::List(){

			queue <State> display;

			while(!elements.empty()){
				display=elements.front();

				while(!display.empty()){
					cout << display.front() << endl;
					display.pop();
				}
				cout << endl;
				elements.pop();
			}
				cout << endl;
		}
}
