#include "p04.h"
#include "Array.h"
#include "Dictionary.h"
#include <sstream>

using namespace std;
namespace P04{

	// Sets the number of items to 0.
		Array::Array(){

					numberOfItems=0;

		}

		// Returns the number of dictionaries in the array.
		uint Array::Count() const{

			return numberOfItems;

		}

		// Adds the dictionary to the end of the array. Throws an ArrayException
		// with the error "Array is full in Add()."  if the array is full.
		void Array::Add(const Dictionary& dictionary){

			if(Count() < MAX_ITEMS){

				items[Count()]=dictionary;

				numberOfItems++;

			}

			else{

				throw ArrayException::ArrayException("Array is full in Add().");
			}

		}

		// Returns a reference to the element stored at index.
		// The index is validated and if invalid throws an ArrayException with
		// the error "Index (<index>) out of range in operator []()."  A valid
		// index is in the range 0 to numberOfItems - 1. The return type
		// prevents the operator from appearing on the left hand side of an
		// assignment.
		const Dictionary Array::operator [](const int index){

			ostringstream oss;

			oss << index;

			if(index >= 0 && index <= Count()-1){

				return Array::items[index];

			}

			else{

				string errorMessage="Index (" + oss.str() + ") out of range in operator []().";

				throw ArrayException::ArrayException(errorMessage);
			}

		}
}//end namespace P04