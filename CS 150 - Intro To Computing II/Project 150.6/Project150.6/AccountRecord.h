#ifndef ACCOUNT_RECORD_H
#define ACCOUNT_RECORD_H

#include <string>
using namespace std;

namespace P06 {
	//-------------------------------------------------------------------------
	// Class: AccountRecord
	//
	// Class stores a customer sales record, which includes the name and
	// balance amount.
	//-------------------------------------------------------------------------
	class AccountRecord {
	private:
		string customerNameField;
		double balanceField;

	public:
		// Initializes instance variables with parameter values.
		AccountRecord(const string& customerName = "na", 
					  const double balance = 0.0);

		// Accessor methods.
		string GetCustomerName() const;
		void SetCustomerName(const string customerName);

		double GetAccountBalance() const;
		void SetAccountBalance(const double balance);

		// Returns the customer's name and amount formatted as:
		// <customerNameField>::$<balanceField>
		string ToString() const;

	};// end AccountRecord
}// end namespace P06

#endif