#include <iostream>
using namespace std;


void Get_Information(double& x, double& y , double& z);
double Computations (double x, double y, double z, double& product);
void Print_Results(double& x, double& y, double& z, double& product, double& sum);

int main()
{
	double x,
		   y,
		   z,
		   sum=0,
		   product=0;

	cout << "Type a -1 for the first number to exit!\n";
	Get_Information(x, y, z);
	while (x != -1)
	{
		sum=Computations(x, y, z, product);
		Print_Results(x, y, z, product, sum);
		Get_Information (x, y, z);
	}
	return 0;
}

void Get_Information(double& x, double& y , double& z)
{
	cout << "\nEnter 3 numbers: ";
	cin >> x;
	if (x != -1)
		cin >> y >> z;
}

double Computations (double x, double y, double z, double& product)
{
	double sum;
	product = x * y * z;
	sum = x + y + z;
	return (sum);
}
void Print_Results(double& x, double& y, double& z, double& product, double& sum)
{
	cout.setf(ios::fixed);
	cout.precision(1);
	cout << "The numbers were: " << x << " " << y << " " << z << endl;
	cout << "\tThe product is " << product << endl;
	cout << "\tThe sum is " << sum;
}

