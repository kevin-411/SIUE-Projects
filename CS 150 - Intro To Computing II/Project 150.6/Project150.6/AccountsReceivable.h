#ifndef ACCOUNTS_RECEIVABLE_H
#define ACCOUNTS_RECEIVABLE_H

#include <string>
#include "p06.h"
#include "AccountRecord.h"

using namespace std;

namespace P06 {
	//-------------------------------------------------------------------------
	// Struct: SalesRecord
	//
	// Structure that represents a sales information record. It consists of the
	// date the sale was made, a count of customer orders on that day and a 
	// dynamic array to all the customer account records.
	//-------------------------------------------------------------------------
	struct  SalesRecord {
		string salesDateField;
		uint accountCountField;
		AccountRecord* accountsField;

		// Initializes fields with parameter values.
		SalesRecord(const string date = "00/00/0000", 
				    const uint count = 0, 
				    AccountRecord* sales = NULL)
		: salesDateField(date), accountCountField(count), accountsField(sales)
		{}// end SalesRecord()
	};// end SalesRecord
	//-------------------------------------------------------------------------



	//-------------------------------------------------------------------------
	// Class: AccountsReceivable
	//
	// Class thats represents all the account receivable records. It is
	// implemented with a dynamic array of SalesRecord records, each one storing
	// all the sales on a given date.
	//-------------------------------------------------------------------------
	class AccountsReceivable {
	private:
		SalesRecord* salesField;
		uint salesCountField;

		// Makes a deep copy of the object.
		void CopyObject(const AccountsReceivable& copyObject);

		// Returns all the memory to the heap. Sets fields to NULL
		// and 0 respectively.
		void ReleaseObject();

	public:
		// Initializes instance variables to NULL and 0 respectively.
		AccountsReceivable();

		// Makes a deep copy of the parameter object. Calls the CopyObject()
		// method.
		AccountsReceivable(const AccountsReceivable& copyObject);

		// Deallocates all the allocated memory. Calls the ReleaseObject() method.
		~AccountsReceivable();

		// Makes a deep copy of the source object. First it tests for self
		// assignment, and then it Releases the current object and copies the
		// parameter object. Calls the ReleaseObject() and CopyObject() methods.
		AccountsReceivable operator =(const AccountsReceivable& sourceObject);

		// Returns all the sales record for a given date, NULL if no sales
		// were made on that date.
		SalesRecord GetAllSalesForDate(const string& date);

		// Adds an account record to the accounts receivable. If the account was
		// for an existing sale date, then the accountsField array is resized and the record
		// added to the end of the accountsField array. If the account is for a
		// new sale date, first the salesField array is resized, then the accountsField
		// array is created and the account added to it.
		void AddAccountRecord(const string& salesDate,
			                  AccountRecord account);

		// Deletes all the account records on a given date. If the date does not
		// exist, nothing gets deleted. The function returns the number of accounts
		// that were deleted or 0 if no records were deleted. Once the date is 
		// located, swap with the last record and resize the array.
		uint DeleteAllSalesForDate(const string& date);

		// Returns the salesCountField.
		uint Count() const;

		// Returns a string that holds all the records, formatted as:
		// <salesDate>::<salesCount>::<customerSalesRecord>
		//                            <customerSalesRecord>
		//                            ...
		// <salesDate>::<salesCount>::<customerSalesRecord>
		//                            <customerSalesRecord>
		//                            ...
		// ...
		string ToString() const;

	}; // end AccountsReceivable
}// end namespace P06

#endif