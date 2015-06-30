#ifndef BST_TEMPLATE_H
#define BST_TEMPLATE_H

#include <string>
using namespace std;


namespace p08NS {
	// Pointer to a function that can be used to display the data.
	typedef void (*FunctionType)(const int index);


	/************************************************************************
	 * Class: bstTemplate
	 *
	 * The class implements a binary search tree. The tree stores the search
	 * key that can be used to locate the data in a data collection.
	 ***********************************************************************/
	template <typename T>
	class bstTemplate {
	private:
		struct TreeNode;
		typedef TreeNode* TreeNodePtr;

		/*******************************************************************
		 * struct: TreeNode
		 *
		 * The structure that represents a tree node. Each node consists of
		 * the key value, its index into the data collection, and two
		 * pointers, for each of the two subtrees.
		 *******************************************************************/
		struct TreeNode {
			T key;
			int dataIndex;		// index into the array of data
			TreeNodePtr left;
			TreeNodePtr right;

			// 4-arg constructor.
			TreeNode(const T& key, const int index, TreeNodePtr left, TreeNodePtr right)
				: key(key), dataIndex(index), left(left), right(right)
			{}// end TreeNode()
		}; // end TreeNode
		TreeNodePtr root;

	protected:
		// Recursively destroys each tree node in the tree.
		void DestroyTree(TreeNodePtr& iter){
			if(iter!=NULL){
			DestroyTree(iter->left);
			DestroyTree(iter->right);
			DeleteNodeItem(iter);
			}
		}// end DestroyTree()


		// Recursively copies the tree pointed to by iterFrom, onto the tree
		// pointed to by iterTo.
		void CopyTree(TreeNodePtr iterFrom, TreeNodePtr& iterTo) const {
			if(iterFrom!=NULL){
				iterTo = new TreeNode(iterFrom->key,iterFrom->dataIndex,NULL,NULL);
				CopyTree(iterFrom->left,iterTo->left);
				CopyTree(iterFrom->right,iterTo->right);
			}
		} // end CopyTree()


		// Recursively inserts the item into the tree.
		void InsertNode(TreeNodePtr& iter, const T& key, const int index) {
		if(iter==NULL){
			iter = new TreeNode(key,index,NULL,NULL);
		}
		else if(key < iter->key){
			InsertNode(iter->left,key,index);
		}
		else{
			InsertNode(iter->right,key,index);
		}
		} // end InsertNode


		// Recursively removes the node from the tree. Assume that the key
		// is on the tree.
		void DeleteItem(TreeNodePtr& iter,const T& key) {
		if(key==iter->key){
			DeleteNodeItem(iter);
		}
		else if(key < iter->key){
			DeleteItem(iter->left,key);
		}
		else{
			DeleteItem(iter->right,key);
		}
		} // end DeleteItem()


		// Removes the actual node from the tree.
		void DeleteNodeItem(TreeNodePtr& iter) {
		if(iter->left==NULL && iter->right == NULL){
			delete iter;
			iter=NULL;
		}
		else if((iter->left!=NULL && iter->right == NULL)||
				(iter->left==NULL && iter->right != NULL)){
					TreeNodePtr delPtr=iter;
				if(iter->left!=NULL){
					iter=iter->left;
				}
				else{
					iter=iter->right;
				}
				delete delPtr;
		}
		else{
			T replace;
			ProcessLeftMost(iter,replace,iter->dataIndex);
			iter->key=replace;
		}
		} // end DeleteNodeItem()
		

		// Finds the node that contains the immediate successor key value.
		// This key will be on the left most node of the right subtree.
		void ProcessLeftMost(TreeNodePtr& iter, T& key,int& index) {
		if(iter->left == NULL){
			key=iter->key;
			index=iter->dataIndex;
			TreeNodePtr delPtr = iter;
			iter=iter->right;
			delete delPtr;
		}
		else{
			ProcessLeftMost(iter->right,key,iter->dataIndex);
		}

		} // end ProcessLeftMost()


		// Retrieves the index of the specified key. Assume that the key is
		// on the tree.
		int RetrieveItem(TreeNodePtr& iter, const T& key) const {
		if(key==iter->key){
			return(iter->dataIndex);
		}
		else if(key < iter->key){
			return RetrieveItem(iter->left,key);
		}
		else{
			return RetrieveItem(iter->right,key);
		}
		} // end RetrieveItem()

		// Performs a preorder visitation of each node.
		void PreorderTraversal(TreeNodePtr iter, FunctionType visit) const {
			if(iter!=NULL){
				visit(iter->dataIndex);
				PreorderTraversal(iter->left,visit);
				PreorderTraversal(iter->right,visit);
			}
		} // end PreorderTraversal()


		// Performs an inorder visitation of each node.
		void InorderTraversal(TreeNodePtr iter, FunctionType visit) const {
			if(iter!=NULL){
			InorderTraversal(iter->left,visit);
			visit(iter->dataIndex);
			InorderTraversal(iter->right,visit);
			}
		} // end InorderTraversal()


		// Performs a postorder visitation of each node.
		void PostorderTraversal(TreeNodePtr iter, FunctionType visit) const {
			if(iter!=NULL){
			PostorderTraversal(iter->left,visit);
			PostorderTraversal(iter->right,visit);
			visit(iter->dataIndex);
			}
		} // end PostorderTraversal()

	public:
		// No-arg constructor. Sets the root to NULL.
		bstTemplate() : root(NULL) {} // end bstTemplate()
		

		// Copy constructor. Calls the CopyTree() method to perform the
		// actual copying.
		bstTemplate(const bstTemplate& copyThisTree) {
			CopyTree(copyThisTree.root,root);
		} // end bstTemplate()

		
		// Destructor. Calls the DestroyTree() method to perform the
		// actual destruction of the tree.
		virtual ~bstTemplate() {
			DestroyTree(root);
			cout << "Tree released..." << endl;
		} // end ~bstTemplate()


		// Makes a duplicate of the tree.
		virtual bstTemplate operator =(const bstTemplate& assignThisTree) {
			if(this!=&assignThisTree){
				DestroyTree(root);
				CopyTree(assignThisTree.root,root);
			}
			return *this;
		} // end operator =()


		// Inserts the key with its index into the tree.
		virtual void Insert(const T& key, const int index) {
			InsertNode(root,key,index);
		} // end Insert()
		

		// Deletes the node containing the key.
		virtual void Delete(const T& key) {
			bstTemplate::DeleteItem(root,key);
		} // end Delete()


		// Retrieves the index for the specified key.
		int Retrieve(const T& key) {
			return RetrieveItem(root,key);
		} // end Retrieve
		// Calls the PreorderTraversal() method to perform the actual
		// traversal.
		virtual void Preorder(FunctionType visit) const {
			PreorderTraversal(root,visit);
		} // end Preorder()


		// Calls the InorderTraversal() method to perform the actual
		// traversal.
		virtual void Inorder(FunctionType visit) const {
			InorderTraversal(root,visit);
		} // end Inorder()

		// Calls the PostorderTraversal() method to perform the actual
		// traversal.
		virtual void Postorder(FunctionType visit) const {
			PostorderTraversal(root,visit);
		} // end Postorder()
	}; // end bstTemplate

} // end namespace p08NS
#endif