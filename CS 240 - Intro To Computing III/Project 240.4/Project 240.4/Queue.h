#ifndef	QUEUE_H
#define QUEUE_H

#include <string>
#include <Queue>

using namespace std;


namespace QueueNS {

	/* Class: State
	 *
	 * Stores statehood information for a state.
	 */
	class State {
	private:
		string name;
		string dateInducted;

	public:
		// Output the state formatted as:
		// <dateInducted>::<name>
		friend ostream& operator <<(ostream& out, const State& object);

		// Initializes object with parameters.
		State(const string& name, const string& dateInducted);

		// Accessor methods.
		string GetName() const;
		void SetName(const string& name);
		string GetDateInducted() const;
		void SetDateInducted(const string& dateInducted);
	};



	/* Class: States
	 *
	 * Uses the STL queue to store all the states in order of induction date.
	 * Each element of the queue is associated with a year of state inductions, and
	 * stores a queue of all the states inducted that year. Therefore, you will wind
	 * up with a queue of queues.
	 */
	class States {
	private:
		queue< queue<State> > elements;

	public:
		// Does nothing.
		States();

		// Loads all the states from the textfile.
		void LoadStatesFromFile(const string& filename);

		// Lists all the states to the screen by popping each state.
		void List();
	};
}

#endif