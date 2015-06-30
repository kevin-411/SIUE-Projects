#include "p04.h"
#include "Dictionary.h"
#include <iostream>


using namespace std;
namespace P04{

ostream& operator <<(ostream& out, const Dictionary& dictionary){

		for(uint i=0; i < dictionary.Count(); i++){

				out << "{key = " << dictionary.key[i] << ", value = " << dictionary.value[i] << "}\n";

		}

		return (out);

}

		// Sorts the dictionary by key in specified order.
void Dictionary::SelectionSort(SortOrder order){

	for(uint i=0;i < Count(); i++){

		uint min=IndexOfNextSmallestKey(i);
		uint max=IndexOfNextLargestKey(i);

		if (order==ASCENDING){

			SwapKeys(i, min);

		}

		else if (order==DESCENDING){

			SwapKeys(i, max);

		}

	}



}

		// Returns the index of the next smallest key.
uint Dictionary::IndexOfNextSmallestKey(const uint startIndex){

	string min=key[startIndex];

	uint pos=startIndex;

	for(uint i=startIndex + 1; i < Count() ;i++){

		 if(min>key[i]){

			  pos=i;

			  min=key[i];
		  }

	}

	return (pos);

}

		// Returns the index of the next largest key.
uint Dictionary::IndexOfNextLargestKey(const uint startIndex){

		string max=key[startIndex];

		uint pos=startIndex;

	for(uint i=startIndex + 1; i < Count() ;i++){

		if(max<key[i]){

			  pos=i;

			  max=key[i];
		  }

	}

	return (pos);

}

		// Swaps the key and value at the specified indices.
void Dictionary::SwapKeys(const uint index1, const uint index2){

	string temp=key[index1];
	key[index1]=key[index2];
	key[index2]=temp;

	temp=value[index1];
	value[index1]=value[index2];
	value[index2]=temp;

}

		// Sets the numberOfkeys to 0.
Dictionary::Dictionary(){

	Dictionary::numberOfKeys=0;

}

		// Returns the value of the specified key. If the key is not found, it
		// throws a DictionaryException with the error "Invalid key (<key>) in
		// GetValueForKey()."
string Dictionary::GetValueForKey(const string& key) const{

		uint i=0;

	while(i<Count() && Dictionary::key[i] != key){

		i++;

	}

		if(key==Dictionary::key[i]){

		   return Dictionary::key[i];

		}

		else if(i==Count()){

		string errorMessage="Invalid value (" + key + ") in GetKeyWithValue().";

		throw DictionaryException::DictionaryException(errorMessage);

		return "";//added these just to make the compiler happy

	}

		return "";//added these just to make the compiler happy

}

		// Sets the value for the specified key.
		// If the key exists, it overwrites its value, otherwise the
		// key-value pair is added to the end of the dictionary. If
		// value is already used, a DictionaryException is thrown with the
		// error message: "Duplicate values (<value>) not allowed in
		// SetValueForKey()." and key is not set. If the dictionary is full, it
		// throws the exception "SetValueForKey() reports the dictionary is full."
void Dictionary::SetValueForKey(const string& key, const string& value){

		if(Count() >= Dictionary::MAX_KEYS){

					throw DictionaryException::DictionaryException("SetValueForKey() reports the dictionary is full.");
				
		}

		for(uint i=0; i <= Count();i++){


			if(key==Dictionary::key[i]){

				Dictionary::value[i]=value;

				i=Count()+1;

			}

			else if(value==Dictionary::value[i]){

					throw DictionaryException::DictionaryException("Duplicate values (" + value + ") not allowed in SetValueForKey().");

			}



			else if(i==Count()){

				Dictionary::key[i]=key;

				Dictionary::value[i]=value;

				numberOfKeys++;

				i++;

			}


		 }

		
			

}

		// Returns the key with the specified value. If the value is not
		// found it throws a DictionaryException with the message
		// "Invalid value(<value>) in GetKeyWithValue()."
string Dictionary::GetKeyWithValue(const string& value) const{

	uint i=0;

	while(i<Count() && Dictionary::value[i] != value){

		i++;

	}

		if(value==Dictionary::value[i]){

		   return Dictionary::key[i];

		}

		else if(i==Count()){

		string errorMessage="Invalid value (" + value + ") in GetKeyWithValue().";

		throw DictionaryException::DictionaryException(errorMessage);

		return "";//added these just to make the compiler happy

	}
 return "";//added these just to make the compiler happy
		
}

		// Sorts the dictionary in specified order by key.
		void Dictionary::Sort(SortOrder order){

			Dictionary::SelectionSort(order);

		}

		// Returns the number of keys in the dictionary.
		uint Dictionary::Count() const{

			return numberOfKeys;

	};// end Dictionary
}//end namespace P04