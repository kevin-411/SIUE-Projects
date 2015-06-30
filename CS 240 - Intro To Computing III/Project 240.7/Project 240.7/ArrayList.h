#ifndef ARRAYLIST_H
#define ARRAYLIST_H

#include <iostream>
using namespace std;

template <typename T>
class ArrayList
{
public:
	enum SortOrder  {ASCENDING, DESCENDING};

private:
	typedef T ItemType;
	typedef T* pItemType;
	typedef T** ppItemType;

	ppItemType items;
	size_t count;

	// Finds the index of the next item in order.
	size_t FindNextIndex(const size_t start, const SortOrder order) const;

	// Swaps the two items at the given indices.
	void SwapItems(const size_t index1, const size_t index2);

	// Copies the parameter list.
	void CopyList(const ArrayList<T>& copyArrayList);

	// Deletes all allocated memory.
	void DeleteList();

	// Displays the items in the array, all on one line.
	friend ostream& operator <<(ostream& out, const ArrayList<T> &anArrayList);

public:
	// Sets items to NULL and count to 0.
	ArrayList();

	// Initializes object to the parameter object.
	ArrayList(const ArrayList<T>& copyArrayList);

	// Deletes all allocated memory.
	~ArrayList();

	// Assigns the parameter object to the current object.
	ArrayList operator =(const ArrayList<T>& assignArrayList);

	// Adds anitem to the list and returns the added item. Array is resized by one.
	pItemType Add(pItemType anItem);

	// Removes the item at the given index. Array is resized by one.
	void RemoveItemAtIndex(const size_t index);

	// Returns the item at the given index.
	pItemType ItemAtIndex(const size_t index) const;

	// Returns the size of the array.
	size_t Count() const;

	// Sorts array in either ascending/descending order.
	void Sort(const SortOrder order);
};

template <typename T>
	size_t ArrayList<T>::FindNextIndex(const size_t start, const SortOrder order) const{
		size_t nextIndex=start;
		
		for(size_t i=start;i<count;i++){
			if(order==ASCENDING && *items[nextIndex]>*items[i]){
				nextIndex=i;
			}
			else if(order==DESCENDING && *items[nextIndex]<*items[i]){
				nextIndex=i;
			}
		}
		return nextIndex;	
	}

template <typename T> // Swaps the two items at the given indices.
	void ArrayList<T>::SwapItems(const size_t index1, const size_t index2){
		pItemType temp=items[index1];
		items[index1]=items[index2];
		items[index2]=temp;
		temp=NULL;
	}

template <typename T>// Copies the parameter list.
	void ArrayList<T>::CopyList(const ArrayList<T>& copyArrayList){
		count=copyArrayList.Count();
		items = new pItemType[Count()];

		for(size_t i=0; i<=Count()-1;i++){
			items[i] = new ItemType(*copyArrayList.items[i]);
		}
	}

template <typename T>// Deletes all allocated memory.
	void ArrayList<T>::DeleteList(){
		for(size_t i=0; i<count;i++){
			delete items[i];
		}
		delete [] items;
		items=NULL;
	}

template <typename T>// Displays the items in the array, all on one line.
	ostream& operator <<(ostream& out, ArrayList<T>& anArrayList){
		for(size_t i=0;i<=anArrayList.Count()-1;i++){
			out << *anArrayList.ItemAtIndex(i) << " ";
		}
		return out;
	}

template <typename T>// Sets items to NULL and count to 0.
	ArrayList<T>::ArrayList(){
		count=0;
		items=NULL;
	}

template <typename T>// Initializes object to the parameter object.
	ArrayList<T>::ArrayList(const ArrayList<T>& copyArrayList){
		CopyList(copyArrayList);
	}

template <typename T>// Deletes all allocated memory.
	ArrayList<T>::~ArrayList(){
		DeleteList();
	}

template <typename T>// Assigns the parameter object to the current object.
	ArrayList<T> ArrayList<T>::operator =(const ArrayList<T>& assignArrayList){
		if(this!=&assignArrayList){
			DeleteList();
			CopyList(assignArrayList);
		}
		return *this;
	}

template <typename T> // Adds anitem to the list and returns the added item. Array is resized by one.
		T* ArrayList<T>::Add(pItemType anItem){
		ppItemType tempArrayList= new pItemType[Count()+1];

		if(items==NULL){
		tempArrayList[0]=anItem;
		count=1;
		}
		else{
		for(size_t i=0; i<=Count()-1;i++){
			tempArrayList[i]=items[i];
			items[i]=NULL;
		}
		delete [] items;
		tempArrayList[Count()]=anItem;
		count++;
		}
		items=tempArrayList;
		tempArrayList=NULL;
		
		return items[Count()-1];
	}

template <typename T>// Removes the item at the given index. Array is resized by one.
	void ArrayList<T>::RemoveItemAtIndex(const size_t index){
		ppItemType tempArrayList=new pItemType[Count()-1];

		for(size_t i=0; i<=index-1;i++){//copies from array index 0 to item at array index-1
			tempArrayList[i]=items[i];
			items[i]=NULL;
		}
		for(size_t i=index; i<=Count()-1;i++){//skips copying item at array index and copies at i+1
			tempArrayList[i]=items[i+1];
			items[i]=NULL;
		}
		delete [] items;
		count--;
		
		items=tempArrayList;
		tempArrayList=NULL;
	}

template <typename T>// Returns the item at the given index.
	T* ArrayList<T>::ItemAtIndex(const size_t index) const{
		return items[index];
	}

template <typename T>// Returns the size of the array.
	size_t ArrayList<T>::Count() const{
		return count;
	}
template <typename T>// Sorts array in either ascending/descending order.
	void ArrayList<T>::Sort(const SortOrder order){
			for(size_t i=0; i <= count-1;i++){
				SwapItems(i,FindNextIndex(i,order));
			}
	}
#endif