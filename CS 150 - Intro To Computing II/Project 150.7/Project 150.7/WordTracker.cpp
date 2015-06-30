#include "p07.h"
#include "WordTracker.h"
#include <string>
#include <iostream>
#include <fstream>

using namespace std;

namespace P07 {

	// Initializes receiving object with a duplicate of the 
		// parameter object.
		void WordTracker::CopyObject(const WordTracker& copyObject){
			Node* iter;

			for(uint i=0; i < 26 ;i++){
			words[i]=copyObject.words[i];
			uint size=words[i].count;
			iter=copyObject.words[i].head;
				for(uint j=0; j < size;j++){
					iter=CreateNode(iter->item,iter);
					iter=iter->next;
				}
			}
		}


		// Releases all the memory allocated to the object and sets
		// each WordList element to 0, 0, NULL.
		// Calls ReleaseNodes() for each list in the array.
		void WordTracker::ReleaseObject(){

			for(uint i=0; i < 26 ;i++){
				words[i].count=0;
				words[i].head=NULL;
				words[i].startsWith=0;
				ReleaseNodes(words[i].head);
			}
			

		}

		// Releases all the memory allocated for the nodes on the list.
		// Sets head to NULL.
		void WordTracker::ReleaseNodes(Node*& head){
			
			Node* del=head;

			while(head!=NULL){
				head=head->next;
				del->next=NULL;
				delete del;
				del=head;
			}
		}

		// Allocates and populates a Node. Throws a bad_alloc
		// exception if memory allocation fails.
		WordTracker::Node* WordTracker::CreateNode(const ItemType& item, 
			             Node* const next){
				
						Node* newPtr = new Node(item,next);
						
						if(newPtr==NULL){
							throw bad_alloc();
						}
							 return newPtr;
		}

		// Hash function to map a character to an array index.
		// The hash is as follows:
		// uint arrayIndex = ch - 'A'.
		// Returns the arrayIndex that ch maps to. Converts the character
		// to uppercase first.
		uint WordTracker::Hash(const char ch) const{

			uint arrayIndex = toupper(ch) - 'A';

			return arrayIndex;

		}

// Initializes each array element to 0, 0, NULL.
		WordTracker::WordTracker(){}

		// Makes a duplicate of the parameter object. 
		// Calls CopyObject().
		WordTracker::WordTracker(const WordTracker& copyObject){

			CopyObject(copyObject);

		}

		// Releases all allocated memory.
		// Calls ReleaseObject();
		WordTracker::~WordTracker(){

			ReleaseObject();

		}

		// Assigns a duplicate of the parameter object. Checks against 
		// self-assignment first.
		// Calls CopyObject() and ReleaseObject().
		WordTracker WordTracker::operator =(const WordTracker& assignObject){

			if(this != &assignObject){
				ReleaseObject();
				CopyObject(assignObject);
			}
			
			return *this;
		}

		// Returns the count of words(nodes) that start with the specified
		// character.
		// Calls Hash() to get the array index of the proper list.
		uint WordTracker::GetCountOfWordsStartingWith(const char startsWith) const{

			return words[Hash(startsWith)].count;

		}

		// Lists all the words that start with the specified character.
		// Calls Hash() to get the array index of the list to output.
		// Format of output:
		// <newline>
		// <initial character>:
		// <TAB5><word1>::<word2>...::<word10>
		// <TAB5><word11>...::<wordn>
		// <newline>
		void WordTracker::ListWordsStartingWith(const char startsWith) const{

			char ch=startsWith;
			uint size=words[Hash(ch)].count;
			Node* iter = words[Hash(ch)].head;

				cout << endl << words[Hash(ch)].startsWith << ":" << endl << TAB(5) << iter->item;
				for(uint i=1; i < size ; i++){
					iter=iter->next;
					cout << "::" << iter->item;
					if(((i+1)%10)==0){
						iter=iter->next;
						i++;
						cout << endl << TAB(5) << iter->item;
					}
				}

				cout << endl;
		}

		// Lists all the words from A to Z.
		// Calls ListWordsStartingWith().
		void WordTracker::ListAllWords() const{

			for(uint i=0; i < 26 ;i++){
				uint count=this->words[i].count;

				if(count != 0){
				char ch=this->words[i].startsWith;
				ListWordsStartingWith(ch);
				}
			}
		}

		// Removes all the list of words that start with the specified 
		// character and sets the list's head to NULL.
		// Calls Hash() to get the array index of the list to remove and
		// ReleaseNodes() to release the actual list. Resets the WordList
		// members to 0,0,NULL to indicate that list has been removed.
		// Returns the number of words removed.
		uint WordTracker::RemoveWordsStartingWith(const char startWith){

			uint count=words[Hash(startWith)].count;

			if(count > 0){
				ReleaseNodes(words[Hash(startWith)].head);
				words[Hash(startWith)].count=0;
				words[Hash(startWith)].startsWith=0;
				words[Hash(startWith)].head=NULL;
			}
			return count;
		}

		// Adds a word to the proper list. The word is added to the front
		// of the list.
		// Calls Hash() to get the array index of the list to add to.
		void WordTracker::AddWord(const string& word){
			uint index=Hash(word.at(0));
			words[index].head=CreateNode(word,words[index].head);
			words[index].startsWith=word.at(0);
			words[index].count++;
		}

}