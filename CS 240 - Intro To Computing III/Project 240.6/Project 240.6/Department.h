#ifndef DEPARTMENT_H
#define DEPARTMENT_H

#include <string>
#include <sstream>
#include <iomanip>

using namespace std;

namespace DepartmentNS {


		enum EmployeeType {
		HOURLY, 
		MANAGER,
		REGULAR
	};
	const int MAX_DEPTS = 3;
	const int MAX_EMPLOYEES = 100;
	
	//-------------------------------------------------------------------------------------
	// Class: Department
	//
	// Stores information for a department.
	//-------------------------------------------------------------------------------------
	class Department {
	private:
		string id;
		string name;
		string manager;		// name of manager heading the department

	public:
		// Initializes the department.
		Department(const string id = "", 
			       const string name = "", 
				   const string manager = "");
	
		// Does nothing here.
		virtual ~Department() {}
	
		// Accessor methods.
		string GetID() const;
		void SetID(const string& id);
		string GetName() const;
		void SetName(const string& name);
		string GetManager()const;
		void SetManager(const string& manager);
		
		// Returns a string with the department info formatted as:
		// ID: deptID	Dept: name	Manager: manager
		virtual string ToString() const;
	};


	//-------------------------------------------------------------------------------------
	// Class: BaseEmployee
	//
	// Abstract base class that stores all common employee information.
	//-------------------------------------------------------------------------------------
	class BaseEmployee {
	private:
		// Address declaration.
		struct Address {
			string street;
			string city;
			string state;
			string zipcode;
		};

		string empID;
		string first;
		string last;
		string dob;						// date of birth
		string doh;						// date of hire
		Address homeAddress;
		Department* dept;				// reference to employee's department

	public:
		// Initializes the base employee.
		BaseEmployee(const string empID = "", 
			         const string first = "", 
					 const string last = "", 
					 const string dob = "", 
					 const string doh = "", 
					 Department* const dept = NULL,
					 const string street = "", 
					 const string city = "", 
					 const string state = "",
					 const string zipcode = "");

		// Does nothing here.
		virtual ~BaseEmployee() {}

		// Accessor methods.
		string GetEmpID() const;
		void SetEmpID(const string& empID);
		string GetFirst() const;
		void SetFirst(const string& first);
		string GetLast() const;
		void SetLast(const string& last);
		string GetDOB() const;
		void SetDOB(const string& dob);
		string GetDOH() const;
		void SetDOH(const string& doh);
		const Department* GetDept() const;
		void SetDepartment(Department* const dept);
		string GetStreet() const;
		void SetStreet(const string& street);
		string GetCity() const;
		void SetCity(const string& city);
		string GetState() const;
		void SetState(const string& state);
		string GetZipcode() const;
		void SetZipcode(const string& zipcode);


		// Returns a string of an employee record formatted as:
		//   EmpID: empID					
		//    Name: first last
		//    Dept: dept
		// Address: street, city, state zip
		//     DOH: doh
		//     DOB: dob
		virtual string ToString() const;


		// Returns true if department name of current object is alphabetically before
		// the department name of the parameter object.
		bool operator <(const BaseEmployee& rhs) const;

		// Pure virtual function that all subclasses must implement.
		virtual double GetPay() const =0;
	};



	//-------------------------------------------------------------------------------------
	// Class: HourlyEmployee
	//
	// Stores an hourly employee.
	//-------------------------------------------------------------------------------------
	class HourlyEmployee : public BaseEmployee {
	private:
		double hourlyRate;	
		double workLoad;		// hours per week

	public:
		// Initializes the hourly employee.
		HourlyEmployee(const string empID = "", 
			           const string first = "", 
					   const string last = "", 
					   const string dob = "", 
					   const string doh = "", 
					   Department* const dept = NULL,
					   const string street = "", 
					   const string city = "", 
					   const string state = "",
					   const string zip = "", 
					   const double hourlyRate = 0.0, 
					   const double workLoad = 0.0);
		
	
		//  Does nothing here.
		virtual ~HourlyEmployee() {}

		// Accessor methods.
		double GetHourlyRate() const;
		void SetHourlyRate(const double hourlyRate);
		double GetWorkLoad() const;
		void SetWorkLoad(const double workLoad);
	
		// computes and returns the annual pay
		virtual double GetPay() const;
	
		// Returns a string of the hourly employee record formatted as:
		// HourlyRate: $hourlyRate
		//   WorkLoad: workLoad
		// Annual Pay: $annual pay
		virtual string ToString() const;
	};



	//-------------------------------------------------------------------------------------
	// Class: BaseSalariedEmployee
	// Abstract base class for salaried employees.
	//-------------------------------------------------------------------------------------
	class BaseSalariedEmployee : public BaseEmployee {
	private:
		double annualSalary;

	public:

		// Initializes the base salaried employee.
		BaseSalariedEmployee(const string empID = "", 
			                 const string first = "", 
							 const string last = "", 
							 const string dob = "", 
							 const string doh = "", 
							 Department* const dept = NULL,
							 const string street = "", 
							 const string city = "", 
							 const string state = "",
							 const string zipcode = "", 
							 const double annualSalary = 0.0);

		// Does nothing here.
		virtual ~BaseSalariedEmployee() {}

		// Accessor methods.
		double GetAnnualSalary() const;
		void SetAnnualSalary(const double annualSalary);

		// Returns the annualSalary.
		// must be implemented by each child class.
		virtual double GetPay() const = 0;
	};



	//-------------------------------------------------------------------------------------
	// Class: ManagerEmployee
	// Stores a manager employee.
	//-------------------------------------------------------------------------------------
	class ManagerEmployee : public BaseSalariedEmployee {
	private:
		string datePromoted;

	public:
		// Initializes the manager employee.
		ManagerEmployee(const string empID = "", 
			            const string first = "", 
						const string last = "", 
						const string dob = "", 
						const string doh = "", 
						Department* const dept = NULL,
						const string street = "", 
						const string city = "", 
						const string state = "",
						const string zipcode = "", 
						const double annualSalary = 0.0, 
						const string datePromoted = "");
		

		// Does nothing here.
		virtual ~ManagerEmployee() {}

		// Accessor methods.
		string GetDatePromoted() const;
		void SetDatePromoted(const string& datePromoted);

		// Returns a string of the manager employee record, formatted as:
		// first show the base employee
		// Date Promoted: datePromoted
		// Annual Salary: annualSalary
		virtual string ToString() const;

		// Returns the annual salary.
		virtual double GetPay() const;
	};



	//-------------------------------------------------------------------------------------
	// Class: RegularEmployee
	// Stores a regular employee.
	//-------------------------------------------------------------------------------------
	class RegularEmployee : public BaseSalariedEmployee {
	private:
		string title;

	public:
		// Initializes the manager employee.
		RegularEmployee(const string empID = "", 
			            const string first = "", 
						const string last = "", 
						const string dob = "", 
						const string doh = "", 
						Department* const dept = NULL,
						const string street = "", 
						const string city = "", 
						const string state = "",
						const string zipcode = "", 
						const double annualSalary = 0.0, 
						const string title = "");
		

		// Does nothing here.
		virtual ~RegularEmployee() {}

		// Accessor methods.
		string GetTitle() const;
		void SetTitle(const string& title);

		// Returns a string of a regular employee record, formatted as:
		// <base employee>
		//		   Title: title
		// Annual Salary: annualSalary
		virtual string ToString() const;

		// Returns the annual salary
		virtual double GetPay() const;
	};
} // end DepartmentNS

#endif