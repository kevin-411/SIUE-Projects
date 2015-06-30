#include "Queue.h"
#include <iostream>

using namespace std;
using namespace QueueNS;

int main() {
	States unitedStates;

	// Load the states from the file (stateInductions.txt).
	unitedStates.LoadStatesFromFile("stateInductions.txt");

	// List the states in order of induction.
	unitedStates.List();

	cout << endl << endl;

	return 0;
}