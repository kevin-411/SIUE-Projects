#include "Department.h"
#include <sstream>
#include <iomanip>
#include <string>

using namespace std;

namespace DepartmentNS{
	
		// Initializes the department.
		Department::Department(const string id, 
							   const string name, 
							   const string manager){
					Department::SetID(id);
					Department::SetName(name);
					Department::SetManager(manager);
					}
	
		//// Does nothing here.
		// Department::~Department() {}
	
		// Accessor methods.
		string Department::GetID() const{
			return id;
		}
		void Department::SetID(const string& id){
			Department::id=id;
		}
		string Department::GetName() const{
			return name;
		}
		void Department::SetName(const string& name){
			Department::name=name;
		}
		string Department::GetManager()const{
			return manager;
		}
		void Department::SetManager(const string& manager){
			Department::manager=manager;
		}
		
		// Returns a string with the department info formatted as:
		// ID: deptID	Dept: name	Manager: manager
		string Department::ToString() const{
			stringstream output;
			output << "ID: " << id << setw(12) << "Dept:   " << setw(28) << left << name << "Manager: " << manager << endl;
			return output.str();
		}


	//-------------------------------------------------------------------------------------
	// Class: BaseEmployee
	//
	// Abstract base class that stores all common employee information.
	//-------------------------------------------------------------------------------------
	
		// Initializes the base employee.
		BaseEmployee::BaseEmployee(const string empID, 
			         const string first, 
					 const string last, 
					 const string dob, 
					 const string doh, 
					 Department* const dept,
					 const string street, 
					 const string city, 
					 const string state,
					 const string zipcode){
		BaseEmployee::SetEmpID(empID);
		BaseEmployee::SetFirst(first);
		BaseEmployee::SetLast(last);
		BaseEmployee::SetDOB(dob);
		BaseEmployee::SetDOH(doh);
		BaseEmployee::SetDepartment(dept);
		BaseEmployee::SetStreet(street);
		BaseEmployee::SetCity(city);
		BaseEmployee::SetState(state);
		BaseEmployee::SetZipcode(zipcode);
		}

		//// Does nothing here.
		//BaseEmployee::~BaseEmployee() {}

		// Accessor methods.
		string BaseEmployee::GetEmpID() const{
			return empID;
		}
		void BaseEmployee::SetEmpID(const string& empID){
			BaseEmployee::empID=empID;
		}
		string BaseEmployee::GetFirst() const{
			return first;
		}
		void BaseEmployee::SetFirst(const string& first){
			BaseEmployee::first=first;
		}
		string BaseEmployee::GetLast() const{
			return last;
		}
		void BaseEmployee::SetLast(const string& last){
			BaseEmployee::last=last;
		}
		string BaseEmployee::GetDOB() const{
			return dob;
		}
		void BaseEmployee::SetDOB(const string& dob){
			BaseEmployee::dob=dob;
		}
		string BaseEmployee::GetDOH() const{
			return doh;
		}
		void BaseEmployee::SetDOH(const string& doh){
			BaseEmployee::doh=doh;
		}
		const Department* BaseEmployee::GetDept() const{
			return dept;
		}
		void BaseEmployee::SetDepartment(Department* const dept){
			BaseEmployee::dept=dept;
		}
		string BaseEmployee::GetStreet() const{
			return BaseEmployee::homeAddress.street;
		}
		void BaseEmployee::SetStreet(const string& street){
			BaseEmployee::homeAddress.street=street;
		}
		string BaseEmployee::GetCity() const{
			return BaseEmployee::homeAddress.city;
		}
		void BaseEmployee::SetCity(const string& city){
			BaseEmployee::homeAddress.city=city;
		}
		string BaseEmployee::GetState() const{
			return BaseEmployee::homeAddress.state;
		}
		void BaseEmployee::SetState(const string& state){
			BaseEmployee::homeAddress.state=state;
		}
		string BaseEmployee::GetZipcode() const{
			return BaseEmployee::homeAddress.zipcode;
		}
		void BaseEmployee::SetZipcode(const string& zipcode){
			BaseEmployee::homeAddress.zipcode=zipcode;
		}


		// Returns a string of an employee record formatted as:
		//   EmpID: empID					
		//    Name: first last
		//    Dept: dept
		// Address: street, city, state zip
		//     DOH: doh
		//     DOB: dob
	string BaseEmployee::ToString() const{

			stringstream output;
			 output << setw(15) << right << "EmpID: " << left << empID << endl 
					<< setw(15) << right << "Name: " << left << first << " " << last << endl 
					<< setw(15) << right << "Dept: " << left << (*dept).GetName() << endl 
					<< setw(15) << right << "Address: " << left << GetStreet() << ", " << GetCity() << ", " << GetState() << ", " << GetZipcode() << endl
					<< setw(15) << right << "DOH: " << left << GetDOH() << endl
					<< setw(15) << right << "DOB: " << left << GetDOB() << endl;
					
					
			return output.str();
		}


		// Returns true if department name of current object is alphabetically before
		// the department name of the parameter object.
		bool BaseEmployee::operator <(const BaseEmployee& rhs) const{

			if((*this).GetDept()->GetName().at(0) < rhs.GetDept()->GetName().at(0)){
				return true;
			}
			return false;
		}

		//// Pure virtual function that all subclasses must implement.
		//virtual double BaseEmployee::GetPay() const =0 {}
	



	//-------------------------------------------------------------------------------------
	// Class: HourlyEmployee
	//
	// Stores an hourly employee.
	//-------------------------------------------------------------------------------------
	
		// Initializes the hourly employee.
		HourlyEmployee::HourlyEmployee(const string empID, 
					   const string first, 
					   const string last, 
					   const string dob, 
					   const string doh, 
					   Department* const dept,
					   const string street, 
					   const string city, 
					   const string state,
					   const string zipcode,  
					   const double HourlyRate, 
					   const double WorkLoad){
		HourlyEmployee::SetEmpID(empID);
		HourlyEmployee::SetFirst(first);
		HourlyEmployee::SetLast(last);
		HourlyEmployee::SetDOB(dob);
		HourlyEmployee::SetDOH(doh);
		HourlyEmployee::SetDepartment(dept);
		HourlyEmployee::SetStreet(street);
		HourlyEmployee::SetCity(city);
		HourlyEmployee::SetState(state);
		HourlyEmployee::SetZipcode(zipcode);
		HourlyEmployee::SetHourlyRate(HourlyRate);
		HourlyEmployee::SetWorkLoad(WorkLoad);
		}
		
	
		////  Does nothing here.
		//HourlyEmployee::~HourlyEmployee() {}

		// Accessor methods.
		double HourlyEmployee::GetHourlyRate() const{
			return hourlyRate;
		}
		void HourlyEmployee::SetHourlyRate(const double hourlyRate){
			HourlyEmployee::hourlyRate=hourlyRate;
		}
		double HourlyEmployee::GetWorkLoad() const{
			return workLoad;
		}
		void HourlyEmployee::SetWorkLoad(const double workLoad){
			HourlyEmployee::workLoad=workLoad;
		}
	
		// computes and returns the annual pay
		 double HourlyEmployee::GetPay() const{
			return (hourlyRate*workLoad*52);
		}
	
		// Returns a string of the hourly employee record formatted as:
		// HourlyRate: $hourlyRate
		//   WorkLoad: workLoad
		// Annual Pay: $annual pay
		 string HourlyEmployee::ToString() const{
			stringstream output;
			output << BaseEmployee::ToString()
					<< setiosflags(ios::fixed) << setprecision(2)
					<< setw(15) << right << "Hourly Rate: $" << left << hourlyRate << endl
					<< setw(15) << right << "Work Load: " << left << workLoad << endl
					<< setw(15) << right << "Annual Pay: $" << left << GetPay() << endl;
			return output.str();
		}
	



	//-------------------------------------------------------------------------------------
	// Class: BaseSalariedEmployee
	// Abstract base class for salaried employees.
	//-------------------------------------------------------------------------------------
	

		// Initializes the base salaried employee.
		BaseSalariedEmployee::BaseSalariedEmployee(const string empID, 
			                 const string first, 
							 const string last, 
							 const string dob, 
							 const string doh, 
							 Department* const dept,
							 const string street, 
							 const string city, 
							 const string state,
							 const string zipcode, 
							 const double annualSalary){
		BaseSalariedEmployee::SetEmpID(empID);
		BaseSalariedEmployee::SetFirst(first);
		BaseSalariedEmployee::SetLast(last);
		BaseSalariedEmployee::SetDOB(dob);
		BaseSalariedEmployee::SetDOH(doh);
		BaseSalariedEmployee::SetDepartment(dept);
		BaseSalariedEmployee::SetStreet(street);
		BaseSalariedEmployee::SetCity(city);
		BaseSalariedEmployee::SetState(state);
		BaseSalariedEmployee::SetZipcode(zipcode);
		BaseSalariedEmployee::SetAnnualSalary(annualSalary);
		}

		//// Does nothing here.
		//BaseSalariedEmployee::~BaseSalariedEmployee() {}

		// Accessor methods.
		double BaseSalariedEmployee::GetAnnualSalary() const{
			return annualSalary;
		}
		void BaseSalariedEmployee::SetAnnualSalary(const double annualSalary){
			BaseSalariedEmployee::annualSalary=annualSalary;
		}

		//// Returns the annualSalary.
		//// must be implemented by each child class.
		//virtual double BaseSalariedEmployee::GetPay() = 0 const{}




	//-------------------------------------------------------------------------------------
	// Class: ManagerEmployee
	// Stores a manager employee.
	//-------------------------------------------------------------------------------------
	
		// Initializes the manager employee.
		ManagerEmployee::ManagerEmployee(const string empID, 
			            const string first, 
						const string last, 
						const string dob, 
						const string doh, 
						Department* const dept,
						const string street, 
						const string city, 
						const string state,
						const string zipcode, 
						const double annualSalary, 
						const string datePromoted){
		ManagerEmployee::SetEmpID(empID);
		ManagerEmployee::SetFirst(first);
		ManagerEmployee::SetLast(last);
		ManagerEmployee::SetDOB(dob);
		ManagerEmployee::SetDOH(doh);
		ManagerEmployee::SetDepartment(dept);
		ManagerEmployee::SetStreet(street);
		ManagerEmployee::SetCity(city);
		ManagerEmployee::SetState(state);
		ManagerEmployee::SetZipcode(zipcode);
		ManagerEmployee::SetAnnualSalary(annualSalary);
		ManagerEmployee::SetDatePromoted(datePromoted);
		}
		

		//// Does nothing here.
		//ManagerEmployee::~ManagerEmployee() {}

		// Accessor methods.
		string ManagerEmployee::GetDatePromoted() const{
			return datePromoted;
		}
		void ManagerEmployee::SetDatePromoted(const string& datePromoted){
			ManagerEmployee::datePromoted=datePromoted;
		}

		// Returns a string of the manager employee record, formatted as:
		// first show the base employee
		// Date Promoted: datePromoted
		// Annual Salary: annualSalary
		 string ManagerEmployee::ToString() const{
			stringstream output;
			output << BaseEmployee::ToString()
					<< setw(15) << right << "Date Promoted: " << left << datePromoted << endl
					<< setiosflags(ios::fixed) << setprecision(2)
					<< setw(15) << right << "Annual Salary: $" << left << GetPay() << endl;
			return output.str();
		}

		// Returns the annual salary.
		 double ManagerEmployee::GetPay() const{
			return GetAnnualSalary();
		}
	



	//-------------------------------------------------------------------------------------
	// Class: RegularEmployee
	// Stores a regular employee.
	//-------------------------------------------------------------------------------------
	
		// Initializes the manager employee.
		RegularEmployee::RegularEmployee(const string empID, 
			            const string first, 
						const string last, 
						const string dob, 
						const string doh, 
						Department* const dept,
						const string street, 
						const string city, 
						const string state,
						const string zipcode, 
						const double annualSalary, 
						const string title){
		RegularEmployee::SetEmpID(empID);
		RegularEmployee::SetFirst(first);
		RegularEmployee::SetLast(last);
		RegularEmployee::SetDOB(dob);
		RegularEmployee::SetDOH(doh);
		RegularEmployee::SetDepartment(dept);
		RegularEmployee::SetStreet(street);
		RegularEmployee::SetCity(city);
		RegularEmployee::SetState(state);
		RegularEmployee::SetZipcode(zipcode);
		RegularEmployee::SetAnnualSalary(annualSalary);
		RegularEmployee::SetTitle(title);
		}
		

		//// Does nothing here.
		// RegularEmployee::~RegularEmployee() {}

		// Accessor methods.
		string RegularEmployee::GetTitle() const{
			return title;
		}
		void RegularEmployee::SetTitle(const string& title){
			RegularEmployee::title=title;
		}

		// Returns a string of a regular employee record, formatted as:
		// <base employee>
		//		   Title: title
		// Annual Salary: annualSalary
		 string RegularEmployee::ToString() const{
			stringstream output;
			output << BaseEmployee::ToString()
					<< setw(15) << right << "Title: " << left << title << endl
					<< setiosflags(ios::fixed) << setprecision(2)
					<< setw(15) << right << "Annual Salary: $" << left << GetPay() << endl;
			return output.str();
		}

		// Returns the annual salary
		 double RegularEmployee::GetPay() const{
			return GetAnnualSalary();
		}

} // end DepartmentNS