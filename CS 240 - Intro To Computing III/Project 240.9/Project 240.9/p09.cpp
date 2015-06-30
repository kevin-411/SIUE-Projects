#include "Dictionary.h"
#include <iostream>

using namespace std;
using namespace DictionaryNS;

int main() {
	// Create a dictionary of products.
	Dictionary<string, Product> products;

	// Add some entries.
	products.AddValueWithKey( "HOU1234", 
		                      Product("Six-set Wine Glasses", 
							          "Household", 
									  20.00) );
	products.AddValueWithKey( "HOU1209", 
		                      Product("China Set", 
							          "Household", 
									  119.00) );
	products.AddValueWithKey( "MEN3421", 
		                      Product("Silk Necttie", 
							          "Men's", 
									  20.00) );
	products.AddValueWithKey( "MEN3111", 
		                      Product("Levis 505", 
							          "Men's",
									  29.95) );

	cout << "Original list: (4) products listed." << endl << endl;
	products.List();

	cout << endl << endl;

	// Remove an item not in the table.
	cout << "Removing product with key = MEN3112: " 
		 << endl
		 << "   " << products.RemoveValueWithKey("MEN3112")
		 << endl
		 << endl;

	// Remove an item in the table.
	cout << "Removing product with key = HOU1209:"
		 << endl
		 << "   " << products.RemoveValueWithKey("HOU1209")
		 << endl
		 << endl;

	// Retrieve an item in the table.
	cout << "Retrieving product with key MEN3111:"
		 << endl
		 << "   " << products.RetrieveValueWithKey("MEN3111")
		 << endl
		 << endl;

	return (0);
}// end main()