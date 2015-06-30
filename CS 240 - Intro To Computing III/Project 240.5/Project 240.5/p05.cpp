#include "FlexString.h"
#include <iostream>

using namespace std;
using namespace FlexStringNS;

void TestFlexStringFunctionality();
void TestIntFunctionality();
void TestDoubleFunctionality();
void TestCharFunctionality();
void TestStringFunctionality();


int main() {
	
	TestFlexStringFunctionality();
	TestIntFunctionality();
	TestDoubleFunctionality();
	TestCharFunctionality();
	TestStringFunctionality();

	cout << endl << endl;

	FlexString fs = "One";

	fs = fs + 2;
	fs = fs + string("3");
	fs = fs + string(" easy as tea!") + string("\nDon\'t you think?");

	cout << fs.ToString();

	cout << endl << endl;

	return 0;
} // end main()




void TestFlexStringFunctionality() {
	FlexString fs1("He");
	FlexString fs2;

	cout << endl
		 << "FlextString fs1(\"He\"):"
		 << endl
		 << "FlextString fs2:"
		 << endl
		 << " fs1.ToString(): " << fs1.ToString()
		 << endl
		 << " fs2.ToString(): " << fs2.ToString()
		 << endl;

	fs2 = fs1 + fs1;

	cout << "fs2 = fs1 + fs1: " << fs2.ToString()
		 << endl;
} // end TestFlexStringFunctionality()



void TestIntFunctionality() {
	FlexString fs(45);
	int value = fs;

	cout << endl
		 << "FlextString fs(45):"
		 << endl
		 << "ToString(): " << fs.ToString()
		 << endl
		 << "   ToInt(): " << fs.ToInt()
		 << endl
		 << "     value: " << value
		 << endl
		 << "  (int) fs: " << (int) fs
		 << endl
		 << "   fs + 20: " << (fs + 20).ToString()
		 << endl;

	fs = 60;

	cout << "   fs = 60: " << fs.ToString()
		 << endl;
} // end TestIntFunctionality()


void TestDoubleFunctionality() {
	FlexString fs(45.45);
	double value = fs;

	cout << endl
		 << "FlextString fs(45.45):"
		 << endl
		 << " ToString(): " << fs.ToString()
		 << endl
		 << " ToDouble(): " << fs.ToDouble()
		 << endl
		 << "      value: " << value
		 << endl
		 << "(double) fs: " << (double) fs
		 << endl
		 << "    fs + 20: " << (fs + 20).ToString()
		 << endl;

	fs = 60.0;

	cout << "  fs = 60.0: " << fs.ToString()
		 << endl;
} // end TestDoubleFunctionality()


void TestCharFunctionality() {
	FlexString fs('A');
	char value = fs;

	cout << endl
		 << "FlextString fs('A'):"
		 << endl
		 << "ToString(): " << fs.ToString()
		 << endl
		 << "  ToChar(): " << fs.ToChar()
		 << endl
		 << "     value: " << value
		 << endl
		 << " (char) fs: " << (char) fs
		 << endl
		 << "  fs + 'A': " << (fs + 'A').ToString()
		 << endl;

	fs = 'B';

	cout << "  fs = 'B': " << fs.ToString()
		 << endl;
} // end TestCharFunctionality()


void TestStringFunctionality() {
	string ha("Ha");
	FlexString fs(ha);
	string value = fs;

	cout << endl
		 << "FlextString fs(ha):"
		 << endl
		 << "       ToString(): " << fs.ToString()
		 << endl
		 << "            value: " << value
		 << endl
		 << "      (string) fs: " << (string) fs
		 << endl
		 << "fs + string(\"Ha\"): " << (fs + string("Ha")).ToString()
		 << endl;

	string ah("Ah");
	fs = ah;

	cout << "          fs = ah: " << fs.ToString()
		 << endl;
} // end TestStringFunctionality()