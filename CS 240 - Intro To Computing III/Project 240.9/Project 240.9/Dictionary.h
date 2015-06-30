#ifndef DICTIONARY_LIST_H
#define DICTIONARY_LIST_H

#include <string>
#include <sstream>
#include <iostream>
#include <iomanip>

using namespace std;


namespace DictionaryNS {

	const int MAX_DICTIONARY_ENTRIES = 100;

	//-------------------------------------------------------------------
	// Class: Product
	//
	// Stores product information, consisting of name, department, unitPrice.
	//-------------------------------------------------------------------
	class Product{
	private:
		// Displays a product with the format:
		// <department><spcs><name><spcs>$<unitPrice>
		friend ostream& operator <<(ostream& out, const Product& product);

		string name;
		string department;
		double unitPrice;

	public:
		// Default constructor initializes instance variables with
		// parameter values.
		Product(const string& name = "na", 
			    const string& department = "na",
				const double unitPrice = 0.0);

		// Name accessor methods.
		virtual string Name() const;
		virtual void SetName(const string& value);

		// Department accessor methods.
		virtual string Department() const;
		virtual void SetDepartment(const string& value);

		// UnitPrice accessor methods.
		virtual double UnitPrice() const;
		virtual void SetUnitPrice(const double value);
	}; // end Product


	//-------------------------------------------------------------------
	// Class: DictionaryEntry
	//
	// Stores a dictionary entry, consisting of a key and a value for
	// that key.
	//-------------------------------------------------------------------
	template <typename K, typename V>
	class DictionaryEntry {
	private:
		template <typename K, typename V> 
		friend class Dictionary;
		

		// Displays an entry with format:
		// <key><spcs><value>
		template <typename K, typename V>
		friend ostream& operator <<(ostream& out, 
									const DictionaryEntry<K, V>& dictionaryEntry);

		K key;			// unique key value identifying each entry.
		V value;		// the value associated with the key.

	public:
		// Default constructor initializes instance variables with
		// parameter values.
		DictionaryEntry( const K& key = K(), 
						 const V& value = V() );
	}; // end DictionaryEntry



	//-------------------------------------------------------------------
	// Class: Dictionary
	//
	// Stores a collection of key/value pairs, using an array of
	// DictionaryEntry objects.
	//-------------------------------------------------------------------
	template <typename K, typename V>
	class Dictionary {
	private:
		DictionaryEntry<K, V> entries[MAX_DICTIONARY_ENTRIES];
		size_t numberOfEntries;

	public:
		// Default constructor sets the numberOfEntries to 0.
		Dictionary();

		// Adds an entry. The entry is added in sorted key order.
		virtual void AddValueWithKey(const K& key, const V& value);

		// Returns the removed entry. If entry not found, returns an 
		// empty entry.
		virtual DictionaryEntry<K, V> RemoveValueWithKey(const K& key);

		// Returns the entry with the given key. If the key is not found,
		// it returns an empty entry.
		virtual DictionaryEntry<K, V> RetrieveValueWithKey(const K& key);

		// Displays all the entries in the format:
		// <key><spcs><value>
		// <key><spcs><value>
		// ...
		virtual void List() const;

		// Returns true is Dictionary has not entries, false otherwise.
		virtual bool IsEmpty() const;

		// Returns the number of entries.
		virtual size_t Count() const;
	}; // end Dictionary
	//-----------------------------Product Class-----------------------------

		// Displays a product with the format:
		// <department><spcs><name><spcs>$<unitPrice>
		ostream& operator <<(ostream& out, const Product& product){
			ostringstream price;
			price << setiosflags(ios::fixed) << setprecision(2) << "$" << product.unitPrice;
			out << left << setw(10) << product.department << setw(28) << product.name << right << setw(8) << price.str();
			return out;
		}
		Product::Product(const string& name, 
			    const string& department,
				const double unitPrice){
		SetName(name);
		SetDepartment(department);
		SetUnitPrice(unitPrice);
		}
		string Product::Name() const{
			return name;
		}
		void Product::SetName(const string& value){
			name=value;
		}
		// Department accessor methods.
		string Product::Department() const{
			return department;
		}
		void Product::SetDepartment(const string& value){
			department=value;
		}
		// UnitPrice accessor methods.
		double Product::UnitPrice() const{
			return unitPrice;
		}
		void Product::SetUnitPrice(const double value){
			unitPrice=value;
		}
		//-----------------------------Dictionary Entry Class-----------------------------
		// Displays an entry with format:
		// <key><spcs><value>
		template <typename K, typename V>
		ostream& operator <<(ostream& out, 
									const DictionaryEntry<K, V>& dictionaryEntry){
			out << left << setw(12) << dictionaryEntry.key << dictionaryEntry.value;
			return out;
		}
		template <typename K, typename V>
		DictionaryEntry<K,V>::DictionaryEntry( const K& key, 
						 const V& value){
		}
		//-----------------------------Dictionary Class-----------------------------
		template <typename K, typename V>
		Dictionary<K,V>::Dictionary(){
			numberOfEntries=0;
		}
		// Adds an entry. The entry is added in sorted key order.
		template <typename K, typename V>
		void Dictionary<K,V>::AddValueWithKey(const K& key, const V& value){
			size_t k=0;
			while(k<Count() && key >= entries[k].key){
				k++;
			}
				numberOfEntries++;
			for(size_t i=Count()-1;i>k;i--){
				entries[i]=entries[i-1];	
			}
				entries[k].key=key;
				entries[k].value=value;
		}
		// Returns the removed entry. If entry not found, returns an 
		// empty entry.
		template <typename K, typename V>
		DictionaryEntry<K, V> Dictionary<K,V>::RemoveValueWithKey(const K& key){
			 
			DictionaryEntry<K, V> temp=DictionaryEntry<K, V>();
			for(size_t i=0;i <= Count()-1;i++){
				if(key==entries[i].key){
					temp=entries[i];
					for(size_t j=i;j <= Count()-1;j++){
						entries[j]=entries[j+1];
					}
					numberOfEntries--;
					entries[Count()]=DictionaryEntry<K, V>();
					return temp;
				}
			}
			return temp;
		}
		// Returns the entry with the given key. If the key is not found,
		// it returns an empty entry.
		template <typename K, typename V>
		DictionaryEntry<K, V> Dictionary<K,V>::RetrieveValueWithKey(const K& key){
			for(size_t i=0;i <= Count()-1;i++){
				if(key==entries[i].key){
					return entries[i];
				}
			}
			return DictionaryEntry<K, V>();
		}
		// Displays all the entries in the format:
		// <key><spcs><value>
		// <key><spcs><value>
		// ...
		template <typename K, typename V>
		void Dictionary<K,V>::List() const{
			for(size_t i=0;i <= Count()-1;i++){
				cout << entries[i] << endl;
			}
		}
		// Returns true is Dictionary has not entries, false otherwise.
		template <typename K, typename V>
		bool Dictionary<K,V>::IsEmpty() const{
			return numberOfEntries==0;
		}
		// Returns the number of entries.
		template <typename K, typename V>
		size_t Dictionary<K,V>::Count() const{
			return numberOfEntries;
		}
	}// end DictionaryNS
#endif