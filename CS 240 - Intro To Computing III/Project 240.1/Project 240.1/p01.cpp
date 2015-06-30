//File: P01.cpp

//Date: 02/01/2012

//Name: Brian Olsen

//Course:  CS 240-001 - Introduction to Computing III

//Desc:This program inputs integers into a doubly linked list to simulate the usage of a Deque ADT.

#include "Deque.h"
#include <iostream>

using namespace std;
using namespace DequeNS;

void main()
{
	Deque deque;
	Deque::nodePtr iter;

	// Test the class to see if it works correctly.
	iter = deque.InsertFront(10);
	iter = deque.InsertBack(13);
	iter = deque.Insert(12, iter);
	iter = deque.Insert(11, iter);

	// List deque in forward order.
	cout << "Original deque forward:" << endl;
	iter = deque.GetHead();
	while (iter != NULL) {
		cout << iter->item << endl;
		iter = deque.GetNext(iter);
	}

	cout << endl
		 << "Original deque backward:" << endl;
	iter = deque.GetTail();
	while (iter != NULL) {
		cout << iter->item << endl;
		iter = deque.GetPrevious(iter);
	}

	// Test the copy constructor.
	Deque deque2(deque);

	// Add a value to deque2 and verify it is not in deque.
	deque2.InsertBack(14);

	cout << endl
		 << "deque2 forward (includes 14):" << endl;
	iter = deque2.GetHead();
	while (iter != NULL) {
		cout << iter->item << endl;
		iter = deque2.GetNext(iter);
	}
	cout << endl;
	cout << "Original deque forward (should not include 14):" << endl;
	iter = deque.GetHead();
	while (iter != NULL) {
		cout << iter->item << endl;
		iter = deque.GetNext(iter);
	}

	// Testing the assignment operator.
	Deque deque3 = deque2;

	iter = deque3.RemoveFront();
	cout << endl
		 << "deque2 forward (should include 14):" << endl;
	iter = deque2.GetHead();
	while (iter != NULL) {
		cout << iter->item << endl;
		iter = deque2.GetNext(iter);
	}
	cout << endl;
	cout << "deque3 forward (should not include 10):" << endl;
	iter = deque3.GetHead();
	while (iter != NULL) {
		cout << iter->item << endl;
		iter = deque3.GetNext(iter);
	}

}
