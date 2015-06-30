#include "bstTemplate.h"
#include <iostream>
#include <iomanip>
#include <string>

using namespace std;
using namespace p08NS;

struct Employee {
	int eid;
	string last;
	string first;

	Employee(const int Eid, const string Last, const string First)
		: eid(Eid), last(Last), first(First)
	{}// end Employee()
};


// First create an array of employee structures.
// Global for ease of use.
Employee staff[] = {Employee(10, "Last1", "First1"),
                    Employee(20, "Last2", "First2"),
					Employee(52, "Last3", "First3"),
					Employee(11, "Last4", "First4"),
					Employee(12, "Last5", "First5")};


// Function to display the employee at the specified index.
void Display(const int index);


// Function to test the bst.
void TestBST();


int main() {
	bstTemplate<int> bstid;
	bstTemplate<string> bstlname;

	TestBST();
	for (int i = 0; i < 5; i++) {
		bstid.Insert(staff[i].eid, i);
	} // end for
	for (int i = 0; i < 5; i++) {
		bstlname.Insert(staff[i].last, i);
	} // end for

	cout << "Employees by ascending eid:"
		 << endl
		 << "---------------------------------------------------"
		 << endl;
	bstid.Inorder(Display);

	cout << endl
		 << endl
		 << "Employees by ascending last name:"
		 << endl
		 << "---------------------------------------------------"
		 << endl;
	bstlname.Inorder(Display);
		cout <<endl << endl;

	return (0);
} // end main()

// Function to display the employee at the specified index.
void Display(const int index){
	cout << "{" << staff[index].eid << " " << staff[index].last << " " << staff[index].first << "} ";
}


// Function to test the bst.
void TestBST() {
	bstTemplate<int> bst1;

	for (int i = 0; i < 5; i++) {
		bst1.Insert(staff[i].eid, i);
	} // end for


	cout << "(Traversing tree by eid)"
		 << endl
         << "bst1: Preorder"
		 << endl
		 << "--------------------"
		 << endl;
	bst1.Preorder(Display);

	cout << endl
		 << endl
		 << "bst1: Inorder"
		 << endl
		 << "--------------------"
		 << endl;
	bst1.Inorder(Display);

	cout << endl
		 << endl
		 << "bst1: Postorder"
		 << endl
		 << "--------------------"
		 << endl;
	bst1.Postorder(Display);


	bstTemplate<int> bst2(bst1);

	// Remove a value from bst2.
	bst2.Delete(52);

	cout << endl
		 << endl
		 << "After copying bst1 into bst2 and removing 52 from bst2"
		 << endl
		 << "bst1: Inorder"
		 << endl
		 << "--------------------"
		 << endl;
	bst1.Inorder(Display);

	cout << endl
		 << endl
		 << "bst2: Inorder"
		 << endl
		 << "--------------------"
		 << endl;
	bst2.Inorder(Display);

	cout << endl
		 << endl
		 << "Retrieving employee with eid = 10"
		 << endl
		 << "------------------------------------------"
		 << endl
		 << "eid: 10, Name: ";

	int index = bst1.Retrieve(10);

	cout << staff[index].first
		 << " "
		 << staff[index].last
		 << endl
		 << endl;

	bst2 = bst1;
	bst2.Delete(20);

	cout << endl
		 << endl
		 << "After assigning bst1 into bst2 and removing 10 from bst2"
		 << endl
		 << "bst1: Inorder"
		 << endl
		 << "--------------------"
		 << endl;
	bst1.Inorder(Display);

	cout << endl
		 << endl
		 << "bst2: Inorder"
		 << endl
		 << "--------------------"
		 << endl
		 << endl;
	bst2.Inorder(Display);
} // end TestBST()
