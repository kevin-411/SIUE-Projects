//File: P06.cpp

//Date: 11/17/2011

//Name: Brian Olsen

//Course:  CS 150-001 - Introduction to Computing II

//Desc:This program can take the input of an Account which consists of a string for company name and a double for account balance.

//The program can then put the accounts into a list that can be accessed and displayed by transaction date.

#include "main.h"

int main() {
	//TestAccountRecordClass();
	TestAccountsReceivableClass();

	cout << endl << endl;
	return 0;
}// end main()


void TestAccountRecordClass() {
	cout << "Testing AccountRecord Class:"
		 << endl;

	AccountRecord empty;
	AccountRecord ar("ABC Metals", 25000.0);

	cout << TAB(5)
		 << empty.ToString()
		 << endl
		 << TAB(5)
		 << ar.ToString()
		 << endl;

	empty.SetCustomerName("Empty Inc.");
	empty.SetAccountBalance(12000.0);

	cout << "After updating account empty:"
		 << endl
		 << TAB(5)
		 << empty.GetCustomerName()
		 << "::"
		 << setiosflags(ios::fixed)
		 << setprecision(2) 
		 << "$" << empty.GetAccountBalance()
		 << endl;

}// end TestAccountRecordClass()


void TestAccountsReceivableClass() {
	cout << "Testing SalesRecord Structure:"
		 << endl;

	SalesRecord sr("11/02/2011", 
		            1, 
					new AccountRecord("Gold & Silver Co.", 50000.0));
	
	cout << TAB(5)
		 << sr.salesDateField
		 << "::"
		 << sr.accountCountField
		 << "::"
		 << sr.accountsField[0].ToString()
		 << endl
		 << endl;

	cout << "Testing AccountsReceivable Class:"
		 << endl;

	AccountsReceivable ar;

	ar.AddAccountRecord("11/01/2011", AccountRecord("Company 1", 25000.0));
	ar.AddAccountRecord("11/01/2011", AccountRecord("Company 2", 45000.0));
	ar.AddAccountRecord("11/02/2011", AccountRecord("Company 3", 10000.0));
	ar.AddAccountRecord("11/03/2011", AccountRecord("Company 1", 15000.0));

	cout << ar.ToString();

	cout << endl
		 << "Retrieving all accounts for 11/01/2011:"
		 << endl;
	
	SalesRecord sales11012011 = ar.GetAllSalesForDate("11/01/2011");
	for (uint acct = 0; acct < sales11012011.accountCountField; acct++) {
		 cout << TAB(5) << sales11012011.accountsField[acct].ToString()
			  << endl;
	}// end for

	cout << endl
		 << "Deleting all accounts for 11/01/2011:"
		 << endl;

	ar.DeleteAllSalesForDate("11/01/2011");
	cout << ar.ToString();

	cout << endl
		 << "Testing the copy constructor:"
		 << endl;
	
	AccountsReceivable copy(ar);
	copy.AddAccountRecord("12/25/2010", AccountRecord("Santa's Elfs Ltd", 60000.0));

	cout << "copy:"
		 << endl
		 << copy.ToString()
		 << endl
		 << "ar:"
		 << endl
		 << ar.ToString()
		 << endl;

	cout << endl
		 << "Testing the =() operator:"
		 << endl;

	AccountsReceivable assign(ar);
	assign.AddAccountRecord("12/31/2011", AccountRecord("Dust Fairy Inc", 45000.0));

	cout << "assign:"
		 << endl
		 << assign.ToString()
		 << endl
		 << "ar:"
		 << endl
		 << ar.ToString()
		 << endl;



}// end TestAccountsReceivableClass()