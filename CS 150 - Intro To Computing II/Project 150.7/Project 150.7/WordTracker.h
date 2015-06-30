#ifndef WORDTRACKER_H
#define WORDTRACKER_H

#include <string>
#include "p07.h"
using namespace std;


namespace P07 {

	class WordTracker {
	private:
		// The linked list's item type. Private since it is part of
		// the implementation.
		typedef string ItemType;

		// Struct: Node
		struct Node {
			ItemType item;
			Node* next;

			Node(const ItemType& item = ItemType(), Node* const next = NULL)
				: item(item), next(next)
			{}// end Node()
		};// end Node

		// Struct: WordList
		// Structure holds the word's initial character, a count of the nodes
		// on the list and the actual list of words.
		struct WordList {
			char startsWith;
			uint count;
			Node* head;

			WordList(const char startsWith = 0,
				     const uint count = 0,
					 Node* const head = NULL)
				: startsWith(startsWith), count(count), head(head)
			{}
		};// end WordList

		// Initializes receiving object with a duplicate of the 
		// parameter object.
		void CopyObject(const WordTracker& copyObject);

		// Releases all the memory allocated to the object and sets
		// each WordList element to 0, 0, NULL.
		// Calls ReleaseNodes() for each list in the array.
		void ReleaseObject();

		// Releases all the memory allocated for the nodes on the list.
		// Sets head to NULL.
		void ReleaseNodes(Node*& head);

		// Allocates and populates a Node. Throws a bad_alloc
		// exception if memory allocation fails.
		Node* CreateNode(const ItemType& item = ItemType(), 
			             Node* const next = NULL);

		// Hash function to map a character to an array index.
		// The hash is as follows:
		// uint arrayIndex = ch - 'A'.
		// Returns the arrayIndex that ch maps to. Converts the character
		// to uppercase first.
		uint Hash(const char ch) const;

		// Array of linked lists. Each element holds a linked list with all the
		// words that begin with the same letter. First element corresponds to
		// "A", and last element to "Z". A hashing algorithm will be used to
		// access each linked list.
		WordList words[26];

	public:
		// Initializes each array element to 0, 0, NULL.
		WordTracker();

		// Makes a duplicate of the parameter object. 
		// Calls CopyObject().
		WordTracker(const WordTracker& copyObject);

		// Releases all allocated memory.
		// Calls ReleaseObject();
		~WordTracker();

		// Assigns a duplicate of the parameter object. Checks against 
		// self-assignment first.
		// Calls CopyObject() and ReleaseObject().
		WordTracker operator =(const WordTracker& assignObject);

		// Returns the count of words(nodes) that start with the specified
		// character.
		// Calls Hash() to get the array index of the proper list.
		uint GetCountOfWordsStartingWith(const char startsWith) const;

		// Lists all the words that start with the specified character.
		// Calls Hash() to get the array index of the list to output.
		// Format of output:
		// <newline>
		// <initial character>:
		// <TAB5><word1>::<word2>...::<word10>
		// <TAB5><word11>...::<wordn>
		// <newline>
		void ListWordsStartingWith(const char startsWith) const;

		// Lists all the words from A to Z.
		// Calls ListWordsStartingWith().
		void ListAllWords() const;

		// Removes all the list of words that start with the specified 
		// character and sets the list's head to NULL.
		// Calls Hash() to get the array index of the list to remove and
		// ReleaseNodes() to release the actual list. Resets the WordList
		// members to 0,0,NULL to indicate that list has been removed.
		// Returns the number of words removed.
		uint RemoveWordsStartingWith(const char startWith);

		// Adds a word to the proper list. The word is added to the front
		// of the list.
		// Calls Hash() to get the array index of the list to add to.
		void AddWord(const string& word);

	}; // end WordTracker

}// end namespace P07

#endif