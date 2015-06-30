#ifndef DEQUE_H
#define DEQUE_H

namespace DequeNS {
	typedef int DequeItemType;

	/* Class: Deque
	 *
	 * Represents a double ended queue, i.e. a doubly linked list. The class
	 * will make use of dummy nodes, one at each end of the list (head, tail).
	 */
	class Deque {
	public:
		class Node;
		typedef Node* nodePtr;

		/* Class: Node
		 *
		 * Nested class represents a node on the list.
		 */
		class Node {
		public:
			DequeItemType item;
			nodePtr previous;
			nodePtr next;

			Node(const DequeItemType& item, const nodePtr previous, const nodePtr next) 
				: item(item), previous(previous), next(next)
			{}
		};// end Node

	private:
		nodePtr head;
		nodePtr tail;
		nodePtr iter;

		// Deletes all the nodes and sets head, tail, iter to NULL.
		void DeleteNodes();
	
		// Duplicates all the nodes on the deque referenced by copyHead.
		void CopyNodes(const nodePtr& copyHead);

		// Creates a new node and populates it. If unable to allocate, it returns NULL.
		nodePtr CreateNode(const DequeItemType& item, const nodePtr previous, const nodePtr next);

	public:	
		// Creates an empty list consisting of the two dummy nodes 
		// (head, tail). iter is set to NULL.
		Deque();
	
		// Creates a duplicate of the copyDeque.
		Deque(const Deque& copyDeque);

		// Destroys the deque.
		~Deque();
	
		// Deletes the existing deque and creates a duplicate of assignDeque.
		Deque operator =(const Deque& assignDeque);

		// Returns a rererence to the first data node or NULL if it does not exist.
		nodePtr GetHead() const;
	
		// Returns a reference to the last data node or NULL if it does not exist.
		nodePtr GetTail() const;

		// Returns a reference to the node after iter if it exists, NULL otherwise.
		nodePtr GetNext(nodePtr iter) const;
	
		// Returns a reference to the node before iter if it exists, NULL otherwise.
		nodePtr GetPrevious(nodePtr iter) const;

		// Inserts a new node before the node referenced by iter, and returns a 
		// reference to the added node.
		nodePtr Insert(const DequeItemType& item, nodePtr iter);
	
		// Inserts a new node at the front of the deque, and returns a 
		// reference to the added node.
		nodePtr InsertFront(const DequeItemType& item);

		// Inserts a new node at the back of the deque, and returns a reference
		// to the added node.
		nodePtr InsertBack(const DequeItemType& item);

		// Removes the node referred by iter and returns the node following if
		// it exists, NULL otherwise.
		nodePtr Remove(nodePtr iter);

		// Removes the first node and sets iter to the next node if it exists,
		// NULL otherwise.
		nodePtr RemoveFront();

		// Removes the last node and sets iter to the previous node if it exists,
		// NULL otherwise.
		nodePtr RemoveLast();
	};// end Deque
}// end namespace DequeNS
#endif