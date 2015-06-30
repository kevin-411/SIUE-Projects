#include "ArrayList.h"
#include <iostream>

using namespace std;


int main()
{
	ArrayList<int> arrayList;

	// Add five numbers to the list.
	arrayList.Add( new int(10) );
	arrayList.Add( new int(1) );
	arrayList.Add( new int(4) );
	arrayList.Add( new int(8) );
	arrayList.Add( new int(3) );

	// List the arrayList.
	cout << "Original arrayList:" << endl;
	cout << arrayList << endl << endl;

	// Sort the arrayList.
	arrayList.Sort(ArrayList<int>::ASCENDING);

	cout << "Sorted arrayList in ascending order:" << endl;
	cout << arrayList << endl << endl;

	// Test the copy constructor and =() method.
	ArrayList<int> copyList(arrayList);
	ArrayList<int> assignList;


	// Remove one value from the copy list.
	copyList.RemoveItemAtIndex(4);

	// List the arrayList.
	cout << "Original arrayList (should be the same as above):" << endl;
	cout << arrayList << endl << endl;

	// List the copyList.
	cout << "CopyList (last item removed):" << endl;
	cout << copyList << endl << endl;

	assignList = arrayList;
	assignList.Sort(ArrayList<int>::DESCENDING);

	// List the arrayList.
	cout << "Original arrayList (should be the same as above):" << endl;
	cout << arrayList << endl << endl;

	// List the assignList.
	cout << "Sorted assignList in descending order:" << endl;
	cout << assignList;
	cout << endl << endl;

	return (0);
}// end main()