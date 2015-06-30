#include <iostream>
#include <string>
#include <sstream>
#include <iomanip>
#include "p06.h"
#include "AccountRecord.h"
#include "AccountsReceivable.h"

using namespace std;

namespace P06 {

		// Makes a deep copy of the object.
		void AccountsReceivable::CopyObject(const AccountsReceivable& copyObject){

				salesCountField=copyObject.Count();
				salesField=new SalesRecord[salesCountField];

			for (uint i = 0; i < salesCountField; i++) {

				uint size=salesField[i].accountCountField=copyObject.salesField[i].accountCountField;
				salesField[i].salesDateField=copyObject.salesField[i].salesDateField;
				salesField[i].accountsField=new AccountRecord[size];

				for(uint j = 0; j < size; j++) {
                salesField[i].accountsField[j]=copyObject.salesField[i].accountsField[j];//for loop to assign all current Account Records
				}
			}

		}

		// Returns all the memory to the heap. Sets fields to NULL
		// and 0 respectively.
		void AccountsReceivable::ReleaseObject(){

				for (uint i = 0; i < Count(); i++) {
					delete [] salesField[i].accountsField;
					salesField[i].accountsField=NULL;
				}
					delete [] salesField;
					salesField = NULL;

		}

		// Initializes instance variables to NULL and 0 respectively.
		AccountsReceivable::AccountsReceivable(): salesField(NULL), salesCountField(0){}

		// Makes a deep copy of the parameter object. Calls the CopyObject()
		// method.
		AccountsReceivable::AccountsReceivable(const AccountsReceivable& copyObject){

			CopyObject(copyObject);

		}

		// Deallocates all the allocated memory. Calls the ReleaseObject() method.
		AccountsReceivable::~AccountsReceivable(){

			ReleaseObject();

		}

		// Makes a deep copy of the source object. First it tests for self
		// assignment, and then it Releases the current object and copies the
		// parameter object. Calls the ReleaseObject() and CopyObject() methods.
		AccountsReceivable AccountsReceivable::operator =(const AccountsReceivable& sourceObject){
				if (this != &sourceObject) {
					ReleaseObject();
					CopyObject(sourceObject);
				}
				return *this;

		}

		// Returns all the sales record for a given date, NULL if no sales
		// were made on that date.
		SalesRecord AccountsReceivable::GetAllSalesForDate(const string& date){

			uint i=0;

			while(i != Count() && date != salesField[i].salesDateField){
				i++;
			}

			if(i==Count()){
				return SalesRecord();
			}

				return salesField[i];

		}

		// Adds an account record to the accounts receivable. If the account was
		// for an existing sale date, then the accountsField array is resized and the record
		// added to the end of the accountsField array. If the account is for a
		// new sale date, first the salesField array is resized, then the accountsField
		// array is created and the account added to it.
		void AccountsReceivable::AddAccountRecord(const string& salesDate,
			                  AccountRecord account){



			if(salesCountField==NULL){ //INITIALIZING AND ADDING FIRST SALES STRUCTURE & DATE AND ACCOUNT RECORD

					salesField=new SalesRecord[1];
					salesCountField=1;
					salesField[0].salesDateField=salesDate;
				    salesField[0].accountsField=new AccountRecord[1];
					salesField[0].accountsField[0]=account;
					salesField[0].accountCountField=1;

				}else{

				int posIndex=0;

				while(posIndex != Count() && salesDate != salesField[posIndex].salesDateField){
					posIndex++;//finds the index of the current structure being used
				}

				 if(posIndex==Count()){ //ADD NEW SALES STRUCTURE & DATE

							uint size=Count();//salesCountField

							SalesRecord* tempSalesRecord=new SalesRecord[size+1];//sets new temp variable to the proper variable size

							for (uint i = 0; i < size; i++) {

								tempSalesRecord[i]=salesField[i];//for loop to assign all current Sales Records

							}

							tempSalesRecord[size]=GetAllSalesForDate(salesDate);//adds new Sales Record
							tempSalesRecord[size].salesDateField=salesDate;//adds new date of Sales Record
							salesCountField++;

							delete [] salesField;
							AccountsReceivable::salesField=tempSalesRecord;//set the tempSales.accountsField to point to the new Sales structure array
							tempSalesRecord=NULL;
		
					}

					//ADD ACCOUNT RECORD OR INITIALIZING ACCOUNT RECORD FOR NEW STRUCTURE

					uint size=salesField[posIndex].accountCountField;//added account index

					AccountRecord* tempAccountRecord=new AccountRecord[size+1];//sets new temp variable to the proper variable size

					for (uint i = 0; i < size; i++) {

						tempAccountRecord[i]= salesField[posIndex].accountsField[i];//for loop to assign all current Account Records

					}

					tempAccountRecord[size]=account;//adds new AccountRecord
					salesField[posIndex].accountCountField++;

					delete [] salesField[posIndex].accountsField;
					AccountsReceivable::salesField[posIndex].accountsField=tempAccountRecord;//set the tempSales.accountsField to point to the new Sales structure array
					tempAccountRecord=NULL;

			}

		}

		// Deletes all the account records on a given date. If the date does not
		// exist, nothing gets deleted. The function returns the number of accounts
		// that were deleted or 0 if no records were deleted. Once the date is 
		// located, swap with the last record and resize the array.
		uint AccountsReceivable::DeleteAllSalesForDate(const string& date){

			uint posIndex=0;
			uint delCount;

			while(posIndex != Count() && date != salesField[posIndex].salesDateField){
				posIndex++;//finds the index of the current structure being used
			}

			if(posIndex==Count()){
				return 0;
			}else{

							uint size=Count();//salesCountField
							SalesRecord* tempSalesRecord=new SalesRecord[size-1];//sets new temp variable to the proper variable size

							if(posIndex!=size-1){
							SalesRecord temp=salesField[posIndex];
							salesField[posIndex]=salesField[size-1];//flips the SalesRecord to be deleted with the last SalesRecord in the array
							salesField[size-1]=temp;
							temp.accountsField=NULL;
							}

							for (uint i = 0; i < size-1; i++) {
							tempSalesRecord[i]=salesField[i];//assigns remaining sales records not being deleted
							}

							delCount=salesField[size-1].accountCountField;//records the amount of accounts that were deleted

							delete [] salesField[size-1].accountsField;
							salesField[size-1].accountsField=NULL;

							delete [] salesField;
							AccountsReceivable::salesField=tempSalesRecord;//set the tempSales.accountsField to point to the new Sales structure array
							tempSalesRecord=NULL;
							salesCountField--;
		
				}

			return delCount;

		}

		// Returns the salesCountField.
		uint AccountsReceivable::Count() const{

			return salesCountField;

		}

		// Returns a string that holds all the records, formatted as:
		// <salesDate>::<salesCount>::<customerSalesRecord>
		//                            <customerSalesRecord>
		//                            ...
		// <salesDate>::<salesCount>::<customerSalesRecord>
		//                            <customerSalesRecord>
		//                            ...
		// ...
		string AccountsReceivable::ToString() const{

			ostringstream oss;

			

			for(uint i=0; i < Count();i++){

				oss << salesField[i].salesDateField << "::" << setfill('0') << setw(3) << salesField[i].accountCountField << "::" 
					<< salesField[i].accountsField[0].ToString() << endl;

					for(uint j=1; j < salesField[i].accountCountField ;j++){

						oss << setfill(' ') << TAB(17) << salesField[i].accountsField[j].ToString() << endl;

				}
					oss << endl;

			}


			return oss.str();
		}

}//end namespace P06