#ifndef ARRAY_H
#define ARRAY_H

#include "Dictionary.h"
#include "p04.h"
#include <string>

using namespace std;

namespace P04 {
	
	class ArrayException {
	private:
		string errorMessage;

	public:
		ArrayException(const string& msg = "An Array error has occurred.")
			: errorMessage(msg)
		{} // and ArrayException()

		string What() const {
			return "ArrayException: " + errorMessage;
		}// end What()
	};// end ArrayException


	// Stores up to MAX_ITEMS Dictionary objects.
	class Array {
	private:
		static const uint MAX_ITEMS = 50;

		Dictionary items[MAX_ITEMS];
		uint numberOfItems;

	public:
		// Sets the number of items to 0.
		Array();

		// Returns the number of dictionaries in the array.
		uint Count() const;

		// Adds the dictionary to the end of the array. Throws an ArrayException
		// with the error "Array is full in Add()."  if the array is full.
		void Add(const Dictionary& dictionary);

		// Returns a reference to the element stored at index.
		// The index is validated and if invalid throws an ArrayException with
		// the error "Index (<index>) out of range in operator []()."  A valid
		// index is in the range 0 to numberOfItems - 1. The return type
		// prevents the operator from appearing on the left hand side of an
		// assignment.
		const Dictionary operator [](const int index);
	}; // end Array

}// end namespace
#endif