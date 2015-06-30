#ifndef DICTIONARY_H
#define DICTIONARY_H

#include <string>
#include "p04.h"

using namespace std;

namespace P04 {

	class DictionaryException {
	private:
		string errorMessage;

	public:
		DictionaryException(const string& msg = "A Dictionary error has occurred.")
			: errorMessage(msg)
		{}// end DictionaryException()

		string What() const {
			return "DictionaryException: " + errorMessage;
		}// end What()
	};// end DictionaryException

	// Stores up to 50 key-value pairs. Only one value per key is allowed, and
	// keys and values are unique.
	class Dictionary {
	private:
		static const uint MAX_KEYS = 50;

		string key[MAX_KEYS];
		string value[MAX_KEYS];
		uint numberOfKeys;

		// Lists all the key-value pairs using the output format:
		// {key = <key>, value = <value>}
		friend ostream& operator <<(ostream& out, const Dictionary& dictionary);

		// Sorts the dictionary by key in specified order.
		void SelectionSort(SortOrder order);

		// Returns the index of the next smallest key.
		uint IndexOfNextSmallestKey(const uint startIndex);

		// Returns the index of the next largest key.
		uint IndexOfNextLargestKey(const uint startIndex);

		// Swaps the two keys at the specified indices.
		void SwapKeys(const uint index1, const uint index2);

	public:
		// Sets the numberOfkeys to 0.
		Dictionary();

		// Returns the value of the specified key. If the key is not found, it
		// throws a DictionaryException with the error "Invalid key (<key>) in
		// GetValueForKey()."
		string GetValueForKey(const string& key) const;

		// Sets the value for the specified key.
		// If the key exists, it overwrites its value, otherwise the
		// key-value pair is added to the end of the dictionary. If
		// value is already used, a DictionaryException is thrown with the
		// error message: "Duplicate values (<value>) not allowed in
		// SetValueForKey()." and key is not set. If the dictionary is full, it
		// throws the exception "SetValueForKey() reports the dictionary is full."
		void SetValueForKey(const string& key, const string& value);

		// Returns the key with the specified value. If the value is not
		// found it throws a DictionaryException with the message
		// "Invalid value(<value>) in GetKeyWithValue()."
		string GetKeyWithValue(const string& value) const;

		// Sorts the dictionary in specified order by key.
		void Sort(SortOrder order = ASCENDING);

		// Returns the number of keys in the dictionary.
		uint Count() const;
	};// end Dictionary

}// end namespace
#endif