//Brian Olsen, Drew Mahan, Brendan Lehman
//CS312 02/02/2012

#include <sys/time.h>
#include <fstream>
#include <iostream>
#include <omp.h>
#include <cstdlib>
#include <sstream>
#include <list>
#include <string>

using namespace std;

// a class to get more accurate time

class stopwatch{
	
private:
	double elapsedTime;
	double startedTime;
	bool timing;
	//returns current time in seconds
	double current_time( ) 
	{
		timeval tv;
		gettimeofday(&tv, NULL);
		double rtn_value = (double) tv.tv_usec;
		rtn_value /= 1e6;
		rtn_value += (double) tv.tv_sec;
		return rtn_value;
	}
	
public:
	stopwatch( ): elapsedTime( 0 ), startedTime( 0 ), timing( false )
	{
		
	}
	
	void start( )
	{
		if( !timing )
		{
			timing = true;
			startedTime = current_time( );
		}
	}
	
	void stop( )
	{
		if( timing )
		{
			elapsedTime +=  current_time( )-startedTime;
			timing = false;
		}
	}
	
	void resume( )
	{
		start( );
	}
	
	void reset( )
	{
		elapsedTime = 0;
		startedTime = 0;
		timing = false;
	}
	
	double getTime( )
	{
		return elapsedTime;
	}
};



// function takes an array pointer, and the number of rows and cols in the array, and 
// allocates and intializes the two dimensional array to a bunch of random numbers

void makeRandArray( unsigned int **& data, unsigned int rows, unsigned int cols, unsigned int seed )
{
	// allocate the array
	data = new unsigned int*[ rows ];
	for( unsigned int i = 0; i < rows; i++ )
	{
		data[i] = new unsigned int[ cols ];
	}
	
	// seed the number generator
	// you should change the seed to get different values
	srand( seed );
	
	// populate the array
	
	for( unsigned int i = 0; i < rows; i++ )
		for( unsigned int j = 0; j < cols; j++ )
		{
			data[i][j] = rand() % 10000 + 1; // number between 1 and 10000
		}
	
}

void getDataFromFile( unsigned int **& data, char fileName[], unsigned int &rows, unsigned int &cols )
{
	ifstream in;
	in.open( fileName );
	if( !in )
	{
		cerr << "error opening file: " << fileName << endl;
		exit( -1 );
	}
	
	in >> rows >> cols;
	data = new unsigned int*[ rows ];
	for( unsigned int i = 0; i < rows; i++ )
	{
		data[i] = new unsigned int[ cols ];
	}
	
	// now read in the data
	
	for( unsigned int i = 0; i < rows; i++ )
		for( unsigned int j = 0; j < cols; j++ )
		{
			in >> data[i][j];
		}
	
}


int main( int argc, char* argv[] ) 
{
	if( argc < 3 )
	{
		cerr<<" usage: exe [input data file] [num of threads to use] " << endl;
		
		cerr<<"or usage: exe rand [num of threads to use] [num rows] [num cols] [seed value]" << endl;
	}
	
	// read in the file
	unsigned int rows, cols, seed;
	unsigned int numThreads;
	unsigned int ** data;
	// convert numThreads to int
	{
		stringstream ss1;
		ss1 << argv[2];
		ss1 >> numThreads;
	}
	
	string fName( argv[1] );
	if( fName == "rand" )
	{
		{
			stringstream ss1;
			ss1 << argv[3];
			ss1 >> rows;
		}
		{
			stringstream ss1;
			ss1 << argv[4];
			ss1 >> cols;
		}
		{
			stringstream ss1;
			ss1 << argv[5];
			ss1 >> seed;
		}
		makeRandArray( data, rows, cols, seed );
	}
	else
	{
		getDataFromFile( data,  argv[1], rows, cols );
	}
	
		/*cerr << "data: " << endl;
	 for( unsigned int i = 0; i < rows; i++ )
	 {
	 for( unsigned int j = 0; j < cols; j++ )
	 {
	 cerr << "i,j,data " << i << ", " << j << ", ";
	 cerr << data[i][j] << " ";
	 }
	 cerr << endl;
	 }
	 cerr<< endl;*/
	
	// tell omp how many threads to use
	omp_set_num_threads( numThreads );
	
	stopwatch S1;
	S1.start();

	//my code here
	
	float maxTotal=0;
	unsigned int maxRows=0, maxCols=0;
	
	#pragma omp parallel for
	for(unsigned int k = 0; k < numThreads; k++){
	
	unsigned int i=0, endi=0, pos=k+1, xtra=rows%numThreads, tempRows=0, tempCols=0;
	float max=0, total=0, avg=1;
	
		switch (k){
	
			case 0: i=0; endi=((rows-xtra)/numThreads)+xtra; cout << endi << "endi" << endl; break;
	
			
			
			default: i=(k*(rows-xtra)/numThreads)+xtra; endi=(pos*(rows-xtra)/numThreads)+xtra; cout << endi << "endi" << k << endl;
	
		}

		for(i; i < endi; i++ ){

			for(unsigned int j=0; j < cols; j++ ){

			total=data[i][j];//add middle

				if(i!=0){
				total+=data[i-1][j];//add left middle
				avg++;
				}

				if(i!=rows-1){
				total+=data[i+1][j];//add right middle
				avg++;
				}

				if(j!=0){ 
				total+=data[i][j-1];//add top middle
				avg++;
				}

				if(j!=cols-1){
				total+=data[i][j+1];//add bottom middle
				avg++;
				}

				if(j!=0 && i!=0){
				total+=data[i-1][j-1];//add top left
				avg++;
				}

				if(j!=0 && i!=rows-1){
				total+=data[i+1][j-1];//add top right
				avg++;
				}

				if(j!=cols-1 && i!=0){
				total+=data[i-1][j+1];//add bottom left
				avg++;
				}

				if(j!=cols-1 && i!=rows-1){
				total+=data[i+1][j+1];//add bottom right
				avg++;
				}

				total=total/avg;
				
				
				if (total > max){
				max=total;
				tempRows=i;
				tempCols=j;
				}
				

				avg=1;
	
		}//end cols
			
			}//end rows
			
	#pragma omp critical
	if(max > maxTotal){
			maxTotal+=total;
			maxRows=tempRows;
			maxCols=tempCols;
			}

	}//end speed for
	
	cout << "largest average: " << maxTotal << endl;

	cout << "found at cells: (" << maxRows << "," << maxCols << ")" << endl;

	S1.stop();
	
	// print out the max value here
	
	cerr << "elapsed time: " << S1.getTime( ) << endl;
}


