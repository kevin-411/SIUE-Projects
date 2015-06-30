//File: P06.cpp

//Date: 04/07/2011

//Name: Brian Olsen

//Course:  CS 140-001 - Introduction to Computing I

//Desc:This program computes the weekly payments of a small business and seperates the data of the first and second shift.

#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <sstream>

using namespace std;

// Constants representing the input and two output files to be used with this assignment.
const string INPUT_FILE = "shifts.txt";
const string FIRST_SHIFT_FILE = "firstShift.txt";
const string SECOND_SHIFT_FILE = "secondShift.txt";

// Enumeration representing the possible shifts.
enum Shifts {
	FIRST = 1,
	SECOND
};

//Function Prototypes.
bool ConnectInputFile(ifstream& fin, const string filename);

bool ConnectOutputFile(ofstream& fout, const string filename);

string ReadString(ifstream& fin);

void WriteString(ofstream& fout, const string value, const int width);

int ReadInt(ifstream& fin);

void WriteInt(ofstream& fout, const int value, const int width);

double ReadDouble(ifstream& fin);

void WriteDouble(ofstream& fout, const double value, const int width, const int precision);

double ComputeWeeklyPay(const double hours, const double payRate);


int main() {

	ifstream fin;
	ofstream foutFirst, foutSecond;
	int shift;
	double hours, pay, totalPay=0.0, totalPay2=0.0;
	string first, last, value;

		cout << "Programmed by Brian Olsen.\n\n";

		if (ConnectInputFile(fin, INPUT_FILE) == false) {
		cerr << "Error opening file " << INPUT_FILE << " for input. Aborting!"
			 << endl
			 << endl;
		exit(1);
		}

		if (ConnectOutputFile(foutFirst, FIRST_SHIFT_FILE) == false) {
		cerr << "Error opening file " << FIRST_SHIFT_FILE << " for input. Aborting!"
			 << endl
			 << endl;
		exit(1);
		}

		if (ConnectOutputFile(foutSecond, SECOND_SHIFT_FILE) == false) {
		cerr << "Error opening file " << SECOND_SHIFT_FILE << " for input. Aborting!"
			 << endl
			 << endl;
		exit(1);
		}

		foutFirst << "First Shift Employees\n---------------------\n\n";

		foutSecond << "Second Shift Employees\n----------------------\n\n";

		shift=ReadInt(fin);

		while(!fin.eof()){

		first=ReadString(fin);
		last=ReadString(fin);
		hours=ReadDouble(fin);
		pay=ReadDouble(fin);

			if (shift==FIRST){

				WriteString(foutFirst, first, 17);
				WriteString(foutFirst, last, 17);
				WriteDouble(foutFirst, hours, 7, 1);
				WriteDouble(foutFirst, pay, 7, 2);
				foutFirst << endl;

				pay=ComputeWeeklyPay(hours, pay);

				totalPay += pay;

			}

			else if (shift==SECOND){

				WriteString(foutSecond, first, 17);
				WriteString(foutSecond, last, 17);
				WriteDouble(foutSecond, hours, 7, 1);
				WriteDouble(foutSecond, pay, 7, 2);
				foutSecond << endl;

				pay=ComputeWeeklyPay(hours, pay);

				totalPay2 += pay;

			}

			shift=ReadInt(fin);

		}

		foutFirst << "\nTotal Payroll: $" << totalPay;

		foutSecond << "\nTotal Payroll: $" << totalPay2;

		fin.close();
		foutFirst.close();
		foutSecond.close();

		cout << "Output files have been updated successfully!\n\n";

	return 0;

}// end main

bool ConnectInputFile(ifstream& fin, const string filename){

	fin.open(filename.c_str());

	 if (fin.fail()) {

		  return false;

     }

	 else {

		  return true;

	 }

}

bool ConnectOutputFile(ofstream& fout, const string filename){

	fout.open(filename.c_str());

	 if (fout.fail()) {

		  return false;

     }

	 else {

		  return true;

	 }

}

string ReadString(ifstream& fin){

	string str;

	fin >> str;

	return str;
}

void WriteString(ofstream& fout, const string value, const int width){

	fout << left << setw(width) << value;

}

int ReadInt(ifstream& fin){
	
	string temp;
	
	int num;

	fin >> temp;

	istringstream iss(temp);

	iss >> num;

	return num;
}

void WriteInt(ofstream& fout, const int value, const int width){

	fout << right << setw(width) << value;

}

double ReadDouble(ifstream& fin){

	string temp;

	double num=0.0;

	fin >> temp;

	istringstream iss(temp);

	iss >> num;

	return num;
}
void WriteDouble(ofstream& fout, const double value, const int width, const int precision){

		fout << setiosflags(ios::fixed) << setprecision(precision) << setw(width) << value;

}
double ComputeWeeklyPay(const double hours, const double payRate){

	double otHrs, pay;

	if(hours > 40) {
		otHrs=hours-40;
		pay=payRate*(40);
		otHrs=(payRate*1.5)*otHrs;
		return (otHrs+pay);
	}

	return (hours*payRate);




}