#include "Deque.h"
#include <iostream>

using namespace std;
namespace DequeNS {


// Deletes all the nodes and sets head, tail, iter to NULL.
		void Deque::DeleteNodes(){

			iter=head;

			while (head != NULL){
			head=head->next;

			iter->next = NULL;
			iter->previous = NULL;
			delete iter;

			iter = head;
		}

			tail=NULL;

		}
	
		// Duplicates all the nodes on the deque referenced by copyHead.
		void Deque::CopyNodes(const nodePtr& copyHead){

		Node* copyIter = copyHead;

		head=CreateNode(copyIter->item,NULL,NULL);
		tail=head->next=CreateNode(copyIter->item,head,NULL);

		iter=head;
		copyIter = copyIter->next;

		while (copyIter->next != NULL) {
			iter->next=tail->previous=CreateNode(copyIter->item,iter,tail);

			copyIter=copyIter->next;
			iter=iter->next;
			}
		}

		// Creates a new node and populates it. If unable to allocate, it returns NULL.
		Deque::nodePtr Deque::CreateNode(const DequeItemType& item, const nodePtr previous, const nodePtr next){
			nodePtr newNode;
			
			try{
			newNode = new Node(item, previous, next);
			
			if(newNode!=NULL)
			return newNode;

			} catch (bad_alloc ba) {
			cerr << "Unable to allocate sufficient memory. Exiting!" << endl;
			exit(1);
		}

		return newNode;
				
		}

		// Creates an empty list consisting of the two dummy nodes 
		// (head, tail). iter is set to NULL.
		Deque::Deque(){
			
			head = CreateNode(DequeItemType(), NULL, NULL);
			tail = head->next = CreateNode(DequeItemType(),head,NULL);
			iter=NULL;

		}
	
		// Creates a duplicate of the copyDeque.
		Deque::Deque(const Deque& copyDeque){
			CopyNodes(copyDeque.head);
		}

		// Destroys the deque.
		Deque::~Deque(){
			DeleteNodes();
		}
	
		// Deletes the existing deque and creates a duplicate of assignDeque.
		Deque Deque::operator =(const Deque& assignDeque){

			if(this != &assignDeque){
				DeleteNodes();
				Deque(assignDeque);
			}
			
			return *this;

		}

		// Returns a reference to the first data node or NULL if it does not exist.
		Deque::nodePtr Deque::GetHead() const{

			nodePtr temp=head->next;

			
				if(temp->item!=DequeItemType()){
				return temp;
			
				}

			return NULL;
		}
	
		// Returns a reference to the last data node or NULL if it does not exist.
		Deque::nodePtr Deque::GetTail() const{

			nodePtr temp=tail->previous;

			
				if(temp->item!=DequeItemType()){
				return temp;
				}
				

			return NULL;
		}

		// Returns a reference to the node after iter if it exists, NULL otherwise.
		Deque::nodePtr Deque::GetNext(nodePtr iter) const{

			nodePtr temp=iter->next;

			if(temp->item != DequeItemType()){
				return temp;
			}

			return NULL;
		}
	
		// Returns a reference to the node before iter if it exists, NULL otherwise.
		Deque::nodePtr Deque::GetPrevious(nodePtr iter) const{

			nodePtr temp=iter->previous;

			if(temp->item != DequeItemType()){
				return temp;
			}

			return NULL;
		}

		// Inserts a new node before the node referenced by iter, and returns a 
		// reference to the added node.
		Deque::nodePtr Deque::Insert(const DequeItemType& item, nodePtr iter){

			nodePtr before=iter->previous;

			before->next = iter->previous = CreateNode(item,before,iter);

			return before->next;

		}
	
		// Inserts a new node at the front of the deque, and returns a 
		// reference to the added node.
		Deque::nodePtr Deque::InsertFront(const DequeItemType& item){

			nodePtr after=head->next;

			head->next = after->previous = CreateNode(item,head,after);

			return head->next;

		}

		// Inserts a new node at the back of the deque, and returns a reference
		// to the added node.
		Deque::nodePtr Deque::InsertBack(const DequeItemType& item){

			nodePtr before=tail->previous;

			before->next = tail->previous = CreateNode(item,before,tail);

			return before->next;

		}

		// Removes the node referred by iter and returns the node following if
		// it exists, NULL otherwise.
		Deque::nodePtr Deque::Remove(nodePtr iter){

			nodePtr before = iter->previous;
			nodePtr after = iter->next;

			after->previous=before;
			before->next=after;

			iter->next=NULL;
			iter->previous=NULL;
			delete iter;
			iter=NULL;

			if(after->item != NULL){

				return after;

			}

			return NULL;

		}

		// Removes the first node and sets iter to the next node if it exists,
		// NULL otherwise.
		Deque::nodePtr Deque::RemoveFront(){

			nodePtr del = head->next;
			nodePtr after = del->next;

			after->previous=head;
			head->next=after;

			del->next=NULL;
			del->previous=NULL;
			delete del;
			del=NULL;

			if(after->item != NULL){

				return after;

			}

			return NULL;

		}

		

		// Removes the last node and sets iter to the previous node if it exists,
		// NULL otherwise.
		Deque::nodePtr Deque:: RemoveLast(){

			nodePtr del = tail->previous;
			nodePtr before = del->previous;
			
			before->next=tail;
			tail->previous=before;

			del->next=NULL;
			del->previous=NULL;
			delete del;
			del=NULL;

			if(before->item != NULL){

				return before;

			}

			return NULL;

		}

}//end DequeNS