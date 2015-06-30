#include <iostream>
#include <string>
#include <sstream>
#include "AccountRecord.h"
#include "AccountsReceivable.h"
#include "p06.h"

using namespace std;

namespace P06 {
// Initializes instance variables with parameter values.
		AccountRecord::AccountRecord(const string& customerName, 
					  const double balance){

						  AccountRecord::SetCustomerName(customerName);
						  AccountRecord::SetAccountBalance(balance);

		}

		// Accessor methods.
		string AccountRecord::GetCustomerName() const{

			return customerNameField;

		}

		void AccountRecord::SetCustomerName(const string customerName){

			customerNameField=customerName;

		}

		double AccountRecord::GetAccountBalance() const{

			return balanceField;

		}

		void AccountRecord::SetAccountBalance(const double balance){

			balanceField=balance;

		}

		// Returns the customer's name and amount formatted as:
		// <customerNameField>::$<balanceField>
		string AccountRecord::ToString() const{

			ostringstream oss;

			oss.setf(ios::fixed);
			oss.precision(2);

			oss << customerNameField << "::$" << balanceField;

			return oss.str();

		}

}//end namespace P06