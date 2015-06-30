#include <iostream>
#include <sstream>
#include <fstream>
#include <string>
using namespace std;


/**************************************************************************
 * **************************************************************************
 *					error  checking stufff
 ***************************************************************************
 ***************************************************************************/ 
// Enable this for error checking
#define CUDA_CHECK_ERROR

#define CudaSafeCall( err )     __cudaSafeCall( err, __FILE__, __LINE__ )
#define CudaCheckError()        __cudaCheckError( __FILE__, __LINE__ )

inline void __cudaSafeCall( cudaError err, const char *file, const int line )
{
	#ifdef CUDA_CHECK_ERROR
	
	#pragma warning( push )
	#pragma warning( disable: 4127 ) // Prevent warning on do-while(0);
	
	do
	{
		if ( cudaSuccess != err )
		{
			fprintf( stderr, "cudaSafeCall() failed at %s:%i : %s\n",
					 file, line, cudaGetErrorString( err ) );
			exit( -1 );
		}
	} while ( 0 );
	
	#pragma warning( pop )
	
	#endif  // CUDA_CHECK_ERROR
	
	return;
}

inline void __cudaCheckError( const char *file, const int line )
{
	#ifdef CUDA_CHECK_ERROR
	
	#pragma warning( push )
	#pragma warning( disable: 4127 ) // Prevent warning on do-while(0);
	
	do
	{
		cudaError_t err = cudaGetLastError();
		if ( cudaSuccess != err )
		{
			fprintf( stderr, "cudaCheckError() failed at %s:%i : %s.\n",
					 file, line, cudaGetErrorString( err ) );
			exit( -1 );
		}
		
		// More careful checking. However, this will affect performance.
		// Comment if not needed.
		err = cudaThreadSynchronize();
		if( cudaSuccess != err )
		{
			fprintf( stderr, "cudaCheckError() with sync failed at %s:%i : %s.\n",
					 file, line, cudaGetErrorString( err ) );
			exit( -1 );
		}
	} while ( 0 );
	
	#pragma warning( pop )
	
	#endif // CUDA_CHECK_ERROR
	
	return;
}

/**************************************************************************
 * *************************************************************************
 *					end of error checking stuff
 ***************************************************************************
 **************************************************************************/ 



// function takes an array pointer, and the number of rows and cols in the array, and 
// allocates and intializes the array to a bunch of random numbers
// Note that this function creates a 1D array that is a flattened 2D array
// to access data item data[i][j], you must can use data[(i*rows) + j]
void makeRandArray( unsigned int *& data, unsigned int rows, unsigned int cols, unsigned int seed )
{
	// allocate the array
	data = new unsigned int[ rows*cols ];
	
	// seed the number generator
	// you should change the seed to get different values
	srand( seed );
	
	// populate the array
	
	for( unsigned int i = 0; i < rows*cols; i++ )
	{
		data[i] = rand() % 10000 + 1; // number between 1 and 10000
		//cerr << data[i] << " ";
	}
	//cerr << endl;
	
}

//*******************************//
// your kernel here!!!!!!!!!!!!!!!!!
//*******************************//
__global__ void matavgKernel(int* mAvg, int rows, int cols, int* dNums)
{
	int rowID=threadidx.y + (blockIDx.y * blockDim.y);
	int colID=threadidx.x + (blockIDx.x * blockDim.x);

	int rowMin=((rowID>0)?rowID-1:0);
	int rowMax=((colID<Rows-1?rowID+1:0);
	int colMin=((colID>0)?colID-1:0);
	int colMax=((rowID<Cols-1?colID+1:0);
	float avg=0;
	int count=0, sum=0;

	for(i=rowMin;i<rowMax;i++){
	 for(j=colMin;j<colMax;j++){
	  count++;
	  sum += dNums[(i*Cols)+j];
	 }
	}
	int Atmp = *((int*)(&avg));
	atomicMax(mAvg,Atmp);
}


int main( int argc, char* argv[] ) 
{
	if(  argc < 3 || argc > 4  )
	{		
		cerr<<"usage: exe [num rows] [num cols] [seed value (optional)]" << endl;
		exit( -1 );
	}
	
	unsigned int rows, cols, seed, rowIDOfMaxCell = 0, colIDOfMaxCell = 0;
	unsigned int *host_data;
	unsigned int dataSize;
	float maxCellAvg = 0;
	int maxCellAvgAsInt = 0;
	{
		stringstream ss1;
		ss1 << argv[1];
		ss1 >> rows;
	}
	{
		stringstream ss1;
		ss1 << argv[2];
		ss1 >> cols;
	}
	{
		if( argc < 3 )
		{
			seed = 1;
		}
		else
		{
			stringstream ss1;
			ss1 << argv[3];
			ss1 >> seed;
		}	
	}
	makeRandArray( host_data, rows, cols, seed );
	dataSize = rows*cols;
	
	/***********************************
	 *	 create a cuda timer to time execution
	 **********************************/
	cudaEvent_t startTotal, stopTotal;
	float timeTotal;
	cudaEventCreate(&startTotal);
	cudaEventCreate(&stopTotal);
	cudaEventRecord( startTotal, 0 );
	/***********************************
	 *	 end of cuda timer creation
	 **********************************/
	
	
	/////////////////////////////////////////////////////////////////////
	///////////////////////  YOUR CODE HERE       ///////////////////////
	/////////////////////////////////////////////////////////////////////
	/*
	 *	 You need to implement your kernel as a function at the top of this file.
	 *	 Here you must 
	 *	 1) allocate device memory
	 *	 2) set up the grid and block sizes
	 *	 3) call your kenrnel
	 *	 4) get the result back from the GPU
	 *	 
	 *	 
	 *	 to use the error checking code, wrap any  cudamalloc functions as follows:
	 *		CudaSafeCall( cudaMalloc( &pointer_to_a_device_pointer, length_of_array * sizeof( int ) ) );
	 *	 Also, place the following function call immediately after you call your kernel
	 *	 ( or after any other cuda call that you think might be causing an error )
	 *		CudaCheckError();
	 */

	 unsigned int rows, cols, seed, rowIDOfMaxCell = 0, colIDOfMaxCell = 0;
	unsigned int *host_data;
	unsigned int dataSize;
	float maxCellAvg = 0;
	int maxCellAvgAsInt = 0;

	dim3 threadsperblock(16,32);
	dim3 numblock((cols + threadsperblock.x-1)/threadsperblock.x, (rows + threadsperblock.y-1)/threadsperblock.y));
	dataSize = rows * cols;
	host_data = new(datasize);
	int* Dmatrix;

	cudasafecall(cudamalloc(Dmatrix,dataSize * sizeof(int));
	cudamemcpy(Dmatrix,host_data,dataSize*,sizeof(int));
	cudamemcpy.hosttodevice;

	MAKernal<<<numblock, treadsperblock>>>(Mavg,rows,cols,Dmatrix);
	
	
	
	/***********************************
	 *	 Stop and destroy the cuda timer 
	 **********************************/
	cudaEventRecord( stopTotal, 0 );
	cudaEventSynchronize( stopTotal );
	cudaEventElapsedTime( &timeTotal, startTotal, stopTotal );
	cudaEventDestroy( startTotal );
	cudaEventDestroy( stopTotal );
	/***********************************
	 *	 end of cuda timer destruction
	 **********************************/
	
	std::cerr << "Total time in seconds: " << timeTotal / 1000.0 << std::endl;
	std::cerr << "Max cell neighborhood avg: " << maxCellAvg  <<std::endl;
	std::cerr << "Max cell neighborhood address: ("
	<< rowIDOfMaxCell << ", " << colIDOfMaxCell << ")" <<std::endl;
	
}


