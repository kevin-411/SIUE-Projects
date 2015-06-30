#include "Department.h"
#include <string>
#include <typeinfo>
#include <iostream>
#include <fstream>
#include <cstdlib>
#include <iomanip>
#include <sstream>

using namespace std;
using namespace DepartmentNS;

const string DEPARTMENT_FILE = "departments.txt";
const string EMPLOYEE_FILE = "employees.txt";



// Opens the connection to the filename and returns true if successful,
// false otherwise.
bool ConnectInputFile(ifstream& fin, 
	                  const string filename);

// Opens the department input file and loads the array with
// all the departments.  If connection to the file is unsuccessful,
// gives an error message and exits the program.
void LoadDepartments(Department* dept[]);

// Opens the employee input file and loads the employees array with
// all the employee information.  The depts[] array is used to identify the
// department the employee is a part of and to make the proper reference to it.
// If connection to the file is unsuccessful,gives an error message and exits 
// the program.
// Calls: FindDepartment()
int LoadEmployees(Department* dept[], 
	              BaseEmployee* employee[]);

// Finds the reference to the department in the depts[] array that has a deptID
// as specified.
Department* FindDepartment(const string deptID, 
	                       Department* const dept[], 
	                       const int departmentCount);

// Lists all the departments.
// Calls: ToString() method for each department object.
void ListDepartments(const Department* const dept[], 
	                 const int departmentCount);

// Lists all the employees of the specified type.
// Calls: ToString() method for each employee object.
void ListEmployees(const EmployeeType employeeType, 
	               const BaseEmployee* const employee[], 
				   const int employeeCount);

// Lists all the employees in each department.  The employees array is first sorted by department name
// and the each employee is displayed.
// Calls: operator <() to perform the department comparison.
void ListEmployeesByDepartment(BaseEmployee* employee[], 
	                           const int employeeCount);

// Deletes all the allocated objects.
void CleanUp(BaseEmployee* employee[], 
	         const int employeeCount,
			 Department* dept[],
			 const int deptCount);



void main(void) {
	Department* dept[MAX_DEPTS];
	BaseEmployee* employee[MAX_EMPLOYEES];

	int employeeCount;

	// 1. load the departments
	LoadDepartments(dept);

	// 2. load the employees
	employeeCount = LoadEmployees(dept, employee);

	// 3. list all the departments
	ListDepartments(dept, MAX_DEPTS);

	// 4. list all the managers
	ListEmployees(MANAGER, employee, employeeCount);

	// 5. list all the regular employees
	ListEmployees(REGULAR, employee, employeeCount);

	// 6. list all the hourly workers
	ListEmployees(HOURLY, employee, employeeCount);

	// 7. list all employees by department
	ListEmployeesByDepartment(employee, employeeCount);

	// 8. Clean up the allocated memory.
	CleanUp(employee, employeeCount, dept, MAX_DEPTS);
} // end main()


// Opens the connection to the filename and returns true if successful,
// false otherwise.
bool ConnectInputFile(ifstream& fin, 
	                  const string filename) {
	bool connectedFlag = true;

	fin.open( filename.c_str() );
	if ( fin.fail() ) {
		connectedFlag = false;
	}
	return (connectedFlag);
}


// Opens the department input file and loads the array with
// all the departments.  If connection to the file is unsuccessful,
// gives an error message and exits the program.
void LoadDepartments(Department* dept[]) {
	// <department id>,<department name>,<department manager>
	string deptID;
	string deptName;
	string deptManager;
	int deptIndex = 0;
	ifstream fin;

	if ( ConnectInputFile(fin, DEPARTMENT_FILE) == false) {
		cerr << "Error opening file " << DEPARTMENT_FILE << " for reading. Aborting!"
			 << endl;
		exit(1);
	} // end if

	getline(fin, deptID, ',');
	while ( !fin.eof() ) {
		getline(fin, deptName, ',');
		getline(fin, deptManager);

		// add to the array
		dept[deptIndex++] = new Department(deptID, deptName, deptManager);
		getline(fin, deptID, ',');
	} // end while

	fin.close();
} // end LoadDepartments()


// Opens the employee input file and loads the employees array with
// all the employee information.  The depts[] array is used to identify the
// department the employee is a part of and to make the proper reference to it.
// If connection to the file is unsuccessful,gives an error message and exits 
// the program.
// Calls: FindDepartment()
int LoadEmployees(Department* dept[], 
	              BaseEmployee* employee[]) {
	// <0>,<employee id>,<first last>,<street>,<city>,<state>,<zip>,<dob>,<doh>,<department id>,<hourly wage>,<work load>
	// <1>,<employee id>,<first last>,<street>,<city>,<state>,<zip>,<dob>,<doh>,<department id>,<annual salary>,<date promoted>
	// <2>,<employee id>,<first last>,<street>,<city>,<state>,<zip>,<dob>,<doh>,<department id>,<annual salary>,<title>

	string employeeTypeText;
	string empID;
	string empFirst;
	string empLast;
	string street;
	string city;
	string state;
	string zip;
	string dob;
	string doh;
	string deptID;
	string title;
	string datePromoted;
	string hourlyWageText;
	string workLoadText;
	string annualSalaryText;

	int employeeTypeInt;
	EmployeeType employeeType;
	double hourlyWage;
	double workLoad;
	double annualSalary;
	
	int employeeCount = 0;
	
	ifstream fin;
	istringstream iss;

	if ( ConnectInputFile(fin, EMPLOYEE_FILE) == false) {
		cerr << "Error opening file " << EMPLOYEE_FILE << " for reading. Aborting!"
			 << endl;
		exit(1);
	}

	getline(fin, employeeTypeText, ',');
	while ( !fin.eof() ) {
		iss.str(employeeTypeText);
		iss >> employeeTypeInt;
		iss.clear();

		employeeType = (EmployeeType) employeeTypeInt;

		// Get the common information first.
		getline(fin, empID, ',');
		getline(fin, empFirst, ' ');
		getline(fin, empLast, ',');
		getline(fin, street, ',');
		getline(fin, city, ',');
		getline(fin, state, ',');
		getline(fin, zip, ',');
		getline(fin, dob, ',');
		getline(fin, doh, ',');
		getline(fin, deptID, ',');

		if (employeeType == HOURLY) {
			getline(fin, hourlyWageText, ',');
			iss.str(hourlyWageText);
			iss >> hourlyWage;
			iss.clear();

			getline(fin, workLoadText);
			iss.str(workLoadText);
			iss >> workLoad;
			iss.clear();

			// add to employees array.
			employee[employeeCount] = new HourlyEmployee(empID, 
				                                         empFirst, 
														 empLast, 
														 dob, 
														 doh, 
				                                         FindDepartment(deptID, dept, MAX_DEPTS), 
										                 street, 
														 city, 
														 state, 
														 zip, 
														 hourlyWage, 
														 workLoad);
			employeeCount += 1;
		} else if (employeeType == REGULAR) {
			getline(fin, annualSalaryText, ',');

			iss.str(annualSalaryText);
			iss >> annualSalary;
			iss.clear();

			//fin.ignore(1);
			getline(fin, title);

			// add to employees array.
			employee[employeeCount] = new RegularEmployee(empID, 
				                                          empFirst, 
														  empLast, 
														  dob, 
														  doh, 
				                                          FindDepartment(deptID, dept, MAX_DEPTS),
													      street, 
														  city, 
														  state, 
														  zip, 
														  annualSalary, 
														  title);
			employeeCount += 1;
		} else if (employeeType == MANAGER) {
			getline(fin, annualSalaryText, ',');
			iss.str(annualSalaryText);
			iss >> annualSalary;
			iss.clear();

			getline(fin, datePromoted);

			// add to employees array.
			employee[employeeCount] = new ManagerEmployee(empID, 
				                                          empFirst, 
														  empLast, 
														  dob, 
														  doh,
													      FindDepartment(deptID, dept, MAX_DEPTS),
													      street, 
														  city, 
														  state, 
														  zip, 
														  annualSalary, 
														  datePromoted);
			employeeCount += 1;
		} // end if

		getline(fin, employeeTypeText, ',');
	} // end while
	fin.close();

	return (employeeCount);
} // end LoadEmployees()


// Finds the reference to the department in the depts[] array that has a deptID
// as specified.
Department* FindDepartment(const string deptID, 
	                       Department* const dept[], 
						   const int departmentCount) {
	bool found = false;
	int index = 0;
	Department* foundDept = NULL;

	while (!found && index < departmentCount) {
		if (dept[index]->GetID() == deptID) {
			found = true;
			foundDept = dept[index];
		}
		else {
			index += 1;
		}
	}
	return (foundDept);
} // end FindDepartment()


// Lists all the departments.
// Calls: ToString() method for each department object.
void ListDepartments(const Department* const dept[], 
	                 const int departmentCount) {
	cout << endl
	     << "----------------------------------------------------------------------------------"
		 << endl
	     << "List of departments:"
	     << endl
		 << "----------------------------------------------------------------------------------"
		 << endl
		 << endl;
	for (int index = 0; index < departmentCount; index++) {
		cout << dept[index]->ToString();
	}
	cout << endl
		 << "----------------------------------------------------------------------------------"
		 << endl
		 << endl;
} // end ListDepartments()


// Lists all the employees of the specified type.
// Calls: ToString() method for each employee object.
void ListEmployees(const EmployeeType employeeType, 
	               const BaseEmployee* const employee[], 
				   const int employeeCount) {
	string employeeTypeHeader;
	string className;

	switch (employeeType) {
	case HOURLY:	employeeTypeHeader = "Hourly workers";		
		            className = "class DepartmentNS::HourlyEmployee";	
					break;

	case MANAGER:	employeeTypeHeader = "Managers";			
		            className = "class DepartmentNS::ManagerEmployee";	
					break;

	case REGULAR:	employeeTypeHeader = "Regular employees";	
					className = "class DepartmentNS::RegularEmployee";	
					break;
	} // end switch

	cout << endl
	     << "----------------------------------------------------------------------------------"
		 << endl
		 << "List of " << employeeTypeHeader << ":"
	     << endl
		 << "----------------------------------------------------------------------------------"
		 << endl
		 << endl;
	for (int index = 0; index < employeeCount; index++) {
		if (typeid(*employee[index]).name() == className) {
			cout << employee[index]->ToString() << endl;
		} // end if
	} // end for
	cout << "----------------------------------------------------------------------------------"
		 << endl
		 << endl;
} // end ListEmployees()


// Lists all the employees in each department.  The employees array is first sorted by department name
// and the each employee is displayed.
// Calls: operator <() to perform the department comparison.
void ListEmployeesByDepartment(BaseEmployee* employee[], 
	                           const int employeeCount) {
	cout << endl
	     << "----------------------------------------------------------------------------------"
		 << endl
	     << "List of employees by department:"
	     << endl
		 << "----------------------------------------------------------------------------------"
		 << endl
		 << endl;

	// Sort the array by department, then list all the employees in order.
	for (int top = 0; top <= employeeCount - 2; top += 1) {
		int minIndex = top;
		for (int index = minIndex + 1; index <= employeeCount - 1; index += 1) {
			if (*employee[index] < *employee[minIndex]) {
				minIndex = index;
			} // end if
		} // end for

		BaseEmployee* tmp = employee[top];
		employee[top] = employee[minIndex];
		employee[minIndex] = tmp;
	}

	// Now list them all.
	for (int index = 0; index < employeeCount; index += 1) {
		// Display the first one first in a special way.
		if (index == 0) {
			const Department* dept = employee[0]->GetDept();
			cout << "Department: " << dept->GetName() << endl;

			// Display first employee.
			cout << setiosflags(ios::left)
					 << setw(3) << " "
					 << setw(7) << "EmpID: " 
					 << setw(4) << employee[index]->GetEmpID()
					 << setw(3) << " "
					 << setw(6) << "Name: "
					 << setw(20) << employee[index]->GetFirst() + " " + employee[index]->GetLast()
					 << resetiosflags(ios::left)
					 << endl; 
		} else if ( employee[index]->GetDept() == employee[index - 1]->GetDept() ) {
			// Employee is in the same department as the one before.
			cout << setiosflags(ios::left)
					 << setw(3) << " "
					 << setw(7) << "EmpID: " 
					 << setw(4) << employee[index]->GetEmpID()
					 << setw(3) << " "
					 << setw(6) << "Name: "
					 << setw(20) << employee[index]->GetFirst() + " " + employee[index]->GetLast()
					 << resetiosflags(ios::left)
					 << endl; 
		} else {
			// Employee is in a different department, so display department label.
			const Department* dept = employee[index]->GetDept();
			cout << endl << "Department: " << dept->GetName() << endl;

			// Now display the employee itself.
			cout << setiosflags(ios::left)
					 << setw(3) << " "
					 << setw(7) << "EmpID: " 
					 << setw(4) << employee[index]->GetEmpID()
					 << setw(3) << " "
					 << setw(6) << "Name: "
					 << setw(20) << employee[index]->GetFirst() + " " + employee[index]->GetLast()
					 << resetiosflags(ios::left)
					 << endl; 
		} // end if
	} // end for

	cout << "----------------------------------------------------------------------------------"
		 << endl
		 << endl;
} // end ListEmployeesByDepartment()



// Deletes all the allocated objects.
void CleanUp(BaseEmployee* employee[], 
	         const int employeeCount,
			 Department* dept[],
			 const int deptCount) {
	
				 // Deletes all the allocated objects.
	for (int index = 0; index <= employeeCount - 1; index += 1) {
		delete employee[index];
	} // end for

	for (int index = 0; index <= deptCount - 1; index++) {
		delete dept[index];
	} // end for
} // end CleanUp()