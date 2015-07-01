/*
*	SIMPLIFY - The goal of this code is to reduce the amount of points in a given line while maintaining topological integrity.
*	Author: Brian Olsen
*	Email: olsenb@purdue.edu || bolsen@siue.edu || brianolsen87@gmail.com
*/
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>//sort ceil
//#include <ctime> //used in STAT INFO
//#include <omp.h> //ran slower with directives
/*
*	POINT CLASS - Holds cartesian points consisting of an x and a y
*/

class Point {
private:
public:
	double x;
	double y;

	Point(){
	}

	Point(double x, double y){
		Point::x=x;
		Point::y=y;
	}

	bool operator < (const Point& rhs) const{
		if(x==rhs.x){
			return y < rhs.y;
		}
		return x < rhs.x;
	}

	//Assignment Overloader
	bool operator ==(const Point  &rhs) const{
			if(this == &rhs || (rhs.x == x && rhs.y == y)){
				return true;
			}
			return false;
	}
};
/*
*	POINTS CLASS - Holds multiple points from the point class and provides LIST API functionality
*/
class Points {
	private:
		const int DEFAULT_NUM_POINTS;

		void CopyPoints(const Points  &copyPoints){
			points = new Point[DEFAULT_NUM_POINTS];

			for(int i = 0; i <= copyPoints.length - 1; i++){
				Append(copyPoints.points[i]);
			}

			length = copyPoints.length;
			id = copyPoints.id;
		}

		void ShallowCopyPoints(const Points  &copyPoints){
			points = copyPoints.points;
			length = copyPoints.length;
			id = copyPoints.id;
		}

		void DeletePoints(){
			delete [] points;
			points = NULL;
			length = 0;
		}

	public:
		Point* points;
		int length;
		int id;

		Points():DEFAULT_NUM_POINTS(5), length(0), id(-1){
			points = new Point[DEFAULT_NUM_POINTS];
		}

		Points(int id):DEFAULT_NUM_POINTS(5), length(0){
			Points::id = id;
			points = new Point[DEFAULT_NUM_POINTS];
		}

		Points(const Points  &rhs):DEFAULT_NUM_POINTS(5), length(0){
			ShallowCopyPoints(rhs);
		}

		Points& Points::operator =(const Points  &rhs){
			if(this != &rhs){
				DeletePoints();
				CopyPoints(rhs);
			}
			return *this;
		}

		void Destroy(){
			DeletePoints();
		}


		//Appends new point and extends array in chunks 
		void Append(Point point){
			if(!(length % DEFAULT_NUM_POINTS) && length !=0){
				int newLength = length + DEFAULT_NUM_POINTS;
				Point* newPoints = new Point[newLength];
				for(int i = 0; i <= length - 1; i++){
					newPoints[i] = points[i];
				}
				delete [] points;
				points = newPoints;
				newPoints = NULL;
			}
			length++;
			points[length-1] = point;
		}

		void AppendPoints(Points pts){
			for(int i = 0; i <= pts.length - 1; i++){
				Append(pts.points[i]);
			}
		}

		//Inserts point at index
		void Insert(Point point, int index){
			Append(point);
			int i = length - 1;
			while(i > index){
				Point temp = points[i];
				points[i] = points[i-1];
				points[i-1] = temp;
				i -= 1;
			}
		}

		void Sort(){
			if(length >= 2){
				//sorts on x then on y O(nlgn)
				std::sort(points, points +  length);
			}
		}
		bool Contains(Point point){
			//binarySearchLow
			int from = 0, high = length - 1, mid;
			while (from <= high){
				mid = (from + high) / 2;
				if(points[mid].x >= point.x){
					high = mid - 1;
				}else{
					from = mid + 1;
				}
			}
			//binarySearchHigh
			int to = 0; 
			high = length - 1;
			while (to <= high){
				mid = (to + high) /2;
				if(points[mid].x > point.x){
					high = mid - 1;
				}else{
					to = mid + 1;
				}
			}

			for(; from < to; from++){
				if(point == points[from]){
					return true;
				}
			}
			return false;
		}

};
/*
*	LINES CLASS - Holds multiple lines from the line class and provides LIST API functionality
*/
class Lines {
	private:
		const int DEFAULT_NUM_LINES;

		void CopyLines(const Lines  &copyLines){
			lines = new Points[DEFAULT_NUM_LINES];

			for(int i = 0; i <= copyLines.length - 1; i++){
				Append(copyLines.lines[i]);
			}

			length = copyLines.length;
		}
		void ShallowCopyLines(const Lines  &copyLines){
			lines = copyLines.lines;
			length = copyLines.length;
		}

		void DeleteLines(){
			delete [] lines;
			lines = NULL;
			length = 0;
		}

	public:
		Points* lines;
		int length;

		Lines():DEFAULT_NUM_LINES(50), length(0){
			lines = new Points[DEFAULT_NUM_LINES];
		}

		Lines (const Lines  &rhs):DEFAULT_NUM_LINES(50), length(0){
			ShallowCopyLines(rhs);
		}

		Lines& Lines::operator =(const Lines  &rhs){
			if(this != &rhs){
				DeleteLines();
				CopyLines(rhs);
			}
			return *this;
		}

		void Destroy(){
			for(int i = 0; i <= length - 1; i++){
				lines[i].Destroy();
			}
			DeleteLines();
		}

		//Appends new line and extends array in chunks
		void Append(Points line){
			if(!(length % DEFAULT_NUM_LINES) && length !=0){
				int newLength = length + DEFAULT_NUM_LINES;
				Points* newLines = new Points[newLength];
				for(int i = 0; i <= length - 1; i++){
					newLines[i] = lines[i];
				}
				delete [] lines;
				lines = newLines;
				newLines = NULL;
			}
			length++;
			lines[length-1] = line;
		}

		void Insert(Points line, int index){
			Append(line);
			int i = length - 1;
			while(i > index){
				Points temp = lines[i];
				lines[i] = lines[i-1];
				lines[i-1] = temp;
				i -= 1;
			}
		}
};
/*
*	BUFFER CLASS - Holds buffer from the line class and provides LIST API functionality
*/
class Buffer {
	private:
		const int DEFAULT_BUFFER_SIZE;

		void CopyBuffer(const Buffer  &copyBuffer){
			buffer = copyBuffer.buffer;
			length = copyBuffer.length;
		}

		void DeleteBuffer(){
			delete [] buffer;
			buffer = NULL;
			length = 0;
		}

	public:
		char* buffer;
		int length;

		Buffer():DEFAULT_BUFFER_SIZE(10000), length(0){
			buffer = new char[DEFAULT_BUFFER_SIZE];
		}
		Buffer(char * chars):DEFAULT_BUFFER_SIZE(10000), length(0){
			SetBuffer(chars);
		}
		Buffer(char * chars, int newLength):DEFAULT_BUFFER_SIZE(100), length(0){
			SetBuffer(chars, newLength);
		}

		Buffer (const Buffer  &rhs):DEFAULT_BUFFER_SIZE(10000){
			CopyBuffer(rhs);
		}
		//Assignment Overloader
		Buffer& Buffer::operator =(const Buffer  &rhs){
			if(this != &rhs){
				DeleteBuffer();
				CopyBuffer(rhs);
			}
			return *this;
		}

		void Destroy(){
			DeleteBuffer();
		}

		//Appends new line and extends array in chunks
		void Append(char ch){
			if(!(length % DEFAULT_BUFFER_SIZE) && length !=0){
				int newLength = length + DEFAULT_BUFFER_SIZE;
				char* newBuffer;
				newBuffer= new char[newLength];
				for(int i = 0; i <= length - 1; i++){
					newBuffer[i] = buffer[i];
				}
				delete [] buffer;
				buffer = newBuffer;
				newBuffer = NULL;
			}
			length++;
			buffer[length-1] = ch;
		}
		void AppendBuffers(Buffer buffer){
			for(int i = 0; i <= buffer.GetLength() - 1; i++){
				Append(buffer.buffer[i]);
			}
		}
		//Inserts ch at index
		void Insert(char ch, int index){
			Append(ch);
			int i = length - 1;
			while(i > index){
				char temp = buffer[i];
				buffer[i] = buffer[i-1];
				buffer[i-1] = temp;
				i -= 1;
			}
		}
		//Gets length or number of buffer
		int GetLength(){
			return length;
		}


		void SetBuffer(char* chars){
			length = 0;
			for(; chars[length] != 0; length++);
			int size = DEFAULT_BUFFER_SIZE * (length / DEFAULT_BUFFER_SIZE + 1);
			buffer = new char[size];
			for(int i = 0; i <= length - 1; i++){
				buffer[i] = chars[i];
			}
		}
		void SetBuffer(char* chars, int newLength){
			length = newLength;
			int size = DEFAULT_BUFFER_SIZE * (length / DEFAULT_BUFFER_SIZE + 1);
			buffer = new char[size];
			for(int i = 0; i <= length - 1; i++){
				buffer[i] = chars[i];
			}
		}

};
/*
*	FUNCTION DECLARATIONS
*/
Points GetPoints(char* filepath);
Lines GetLines(char* filepath);
bool PointInPolygon(Point point, Points polygon);
int binarySearchLow(Points points, double value);
int binarySearchHigh(Points points, double value);
void makeXMLDoc(char* filepath, Lines lines);
double min(double a, double b, double c);
double max(double a, double b, double c);

int main(int argc, char* argv[]){
	if(argc != 5){
		printf("Usage: %s <MinNumberOfPointsToRemove> <LineInputFilePath> <PointInputFilePath> <OutputFilePath>\n",argv[0]);
		return 0;
	}

	/* STAT INFO
	std::clock_t start;
    double duration;
	start = std::clock();
	*/

	int numPointsToRemove = atoi(argv[1]);
	char* lineInputFilepath = argv[2];
	char* pointInputFilepath = argv[3];
	char* outputFilepath = argv[4];

	Points points = GetPoints(pointInputFilepath);
	Lines lines;
	Points totalKeepPoints = Points();
	Lines linesTemplate = GetLines(lineInputFilepath);

	//zero is a place holder to enter the while loop
	totalKeepPoints.Append(Point(0,0));
	points.Sort();

	while(totalKeepPoints.length > 0){
		totalKeepPoints = Points();
		lines = linesTemplate;
		//int i;
		//#pragma omp parallel for// private(i)
		for(int i = 0; i <= lines.length - 1; i++){
			Points keepPoints = Points(lines.lines[i].id);
			keepPoints.Append(lines.lines[i].points[0]);
			int beforeIndex = 0;
			//avoid the first and last points
			for(int j = 1; j <= lines.lines[i].length - 2; j++){
				Point p = lines.lines[i].points[j];
				Point before = lines.lines[i].points[beforeIndex];
				Point after = lines.lines[i].points[j + 1];
				Points polygon = Points();

				polygon.Append(before);
				polygon.Append(p);
				polygon.Append(after);

				double minx = min(before.x, after.x, p.x);
				double miny = min(before.y, after.y, p.y);
				double maxx = max(before.x, after.x, p.x);
				double maxy = max(before.y, after.y, p.y);
				int from = binarySearchLow(points,minx);
				int to = binarySearchHigh(points,maxx);
				for(; from < to; from++){
					Point testP = points.points[from];
					if(testP.y > miny && testP.y < maxy && PointInPolygon(testP,polygon)){
						keepPoints.Append(p);
						beforeIndex = j;
					}// end if
				}// end for k
			}//end for j

			keepPoints.Append(lines.lines[i].points[lines.lines[i].length - 1]);
			
			if(keepPoints.length == 2){
				keepPoints.Insert(lines.lines[i].points[lines.lines[i].length - 2],1);
			}

			for(int j = 0;j <= keepPoints.length - 1; j++){
				Point pnt = keepPoints.points[j];
				if(!points.Contains(pnt)){
					//#pragma omp critical
					totalKeepPoints.Append(pnt);
				}
			}// end 2nd for j
			lines.lines[i] = keepPoints;
			keepPoints.Destroy();
		}//end for i
		points.AppendPoints(totalKeepPoints);
		points.Sort();
	}//end while 
	lines.lines[1];
	makeXMLDoc(outputFilepath, lines);
	/* STAT INFO
	duration = ( std::clock() - start ) / (double) CLOCKS_PER_SEC;

	int numLinePoints = 0;
	int numLinePointsKept = 0;
	for(int i = 0; i <= linesTemplate.length - 1; i++){
		numLinePoints += linesTemplate.lines[i].length;
	}
	for(int i = 0; i <= lines.length - 1; i++){
		numLinePointsKept += lines.lines[i].length;
	}
	lines.Destroy();
	points.Destroy();

	printf("Total number of line points: %d\n",numLinePoints);
	printf("Points removed: %d\n",numLinePoints - numLinePointsKept);
	printf("Ran in: %.8f\n", duration);
	printf("Score(numPoints/time(sec)): %.8f", (numLinePoints - numLinePointsKept)/duration);
	*/
	return 0;
}//end main
/*
*	FUNCTIONS
*/
Points GetPoints(char* filepath){
		Points points = Points();
		const double MB_IN_BYTES = 1048576;
		char *buf, *line, *temp = NULL;
		int bufSize, lineSize, tempSize, h_i, t_i, numberOfIterations = 1;
		double x, y;
		long fileSize = 0;

		FILE* file = fopen(filepath, "r");
		if(file==NULL){
			printf("There was an error opening the file!!");
			return Points();
		}

		//obtain file size:
		fseek (file , 0 , SEEK_END);
		fileSize = ftell (file);
		rewind (file);

		//break file up into 1 MB segments...each segment will require an iteration.
		if(fileSize > MB_IN_BYTES){
			numberOfIterations = ceil(fileSize / MB_IN_BYTES);
		}

		//The first 1 to (n-1) iterations will have a buffer equal to the segment size
		//The nth iteration will have a  buffer equal of the remaining value.
		//If the file is < .5 GB then it will run through the standard iteration

		for(int i = 0 ; i <= numberOfIterations - 1 ; i++){
			bufSize=(i == numberOfIterations - 1)?(fileSize - (numberOfIterations - 1) * MB_IN_BYTES):MB_IN_BYTES;
			buf = new char[bufSize];
			fread(buf,bufSize,1,file);

			h_i = t_i = 0;
			
			while(buf[t_i] != '\n' && t_i < bufSize - 1){
				t_i++;
			}

			while(t_i < bufSize){
				lineSize = t_i - h_i;

				//linking the previous segment
				if(temp != NULL){
					lineSize += tempSize;
					line = new char[lineSize];
					for(int j = 0; j <= tempSize - 1; j++){
						line[j] = temp[j];
					}
					for(int j = tempSize; j <= lineSize - 1; j++){
						line[j] = buf[j - tempSize];
					}
					delete [] temp;
					temp = NULL;
					tempSize = 0;
				//this is the standard path where we copy the contents of the
				//buffer up to the newline into line
				}else{
					line = new char[lineSize];
					for(int j = 0; j <= lineSize - 1; j++){
						line[j] = buf[h_i + j];
					}
				}
				
				//the syntax to scan up to a specific character is %*[^(char)](char)
				//where (char) is any non whitspace and non number character.
				//% indicates to scan
				//* indicates to ignore
				//[^(char)](char) indicates the special character to scan to and ignore
				//%lf is a "long float" in other words a double and the 8 value
				//precision called for a double and not a float.
				if(sscanf(line,"%*[^>]>%*[^>]>%lf,%lf", &x, &y)==2){
					points.Append(Point(x,y));
				}else{
					printf("Error scanning file!!\n");
				}

				delete [] line;
				line = NULL;

				//advance head and tail indeces past the new line
				t_i++;
				h_i = t_i;
				
				//advance the tail index to the next new line
				while(t_i < bufSize && buf[t_i] != '\n' && t_i < bufSize - 1){
					t_i++;
				}

				if(i<=numberOfIterations -2 && t_i != bufSize){
					tempSize = t_i - h_i;
					temp = new char[tempSize];
					for(int j = 0; j <= tempSize - 1; j++){
						temp[j] = buf[h_i + j];
					}
					delete [] buf;
				}
			}
		}

		//clean up file pointer and buffer
		fflush(file);
		fclose(file);
		delete [] buf;
		buf = NULL;
		filepath = NULL;
		return points;
}

Lines GetLines(char* filepath){
		Lines lines = Lines();
		const double MB_IN_BYTES = 1048576;
		char *buf, *line, *temp = NULL;
		int bufSize, lineSize, tempSize, h_i, t_i, numberOfIterations = 1,lineID;
		double x, y;
		long fileSize = 0;

		FILE* file = fopen(filepath, "r");
		if(file==NULL){
			printf("There was an error opening the file!!");
			return Lines();
		}

		//obtain file size:
		fseek (file , 0 , SEEK_END);
		fileSize = ftell (file);
		rewind (file);

		//break file up into 1 MB segments...each segment will require an iteration.
		if(fileSize > MB_IN_BYTES){
			numberOfIterations = ceil(fileSize / MB_IN_BYTES);
		}

		//The first 1 to (n-1) iterations will have a buffer equal to the segment size
		//The nth iteration will have a  buffer equal of the remaining value.
		//If the file is < .5 GB then it will run through the standard iteration
		for(int i = 0 ; i <= numberOfIterations - 1 ; i++){
			bufSize=(i == numberOfIterations - 1)?(fileSize - (numberOfIterations - 1) * MB_IN_BYTES):MB_IN_BYTES;
			buf = new char[bufSize];
			fread(buf,bufSize,1,file);

			h_i = t_i = 0;
			while(buf[t_i] != '\n' && t_i < bufSize - 1){
				t_i++;
			}
			while(t_i < bufSize){
				lineSize = t_i - h_i;

				//linking the previous segment
				if(temp != NULL){
					lineSize += tempSize;
					line = new char[lineSize];
					for(int j = 0; j <= tempSize - 1; j++){
						line[j] = temp[j];
					}
					for(int j = tempSize; j <= lineSize - 1; j++){
						line[j] = buf[j - tempSize];
					}
					delete [] temp;
					temp = NULL;
					tempSize = 0;
				//this is the standard path where we copy the contents of the
				//buffer up to the newline into line
				}else{
					line = new char[lineSize];
					for(int j = 0; j <= lineSize - 1; j++){
						line[j] = buf[h_i + j];
					}
				}

				if(sscanf(line,"%d:", &lineID)==1){
				}else{
					lineID = -1;
				}

				Points points = Points(lineID);
				int bytesConsumed = 0, currentBytes;
				
				if(sscanf(line,"%*[^>]>%*[^>]>%lf,%lf%n", &x, &y, &bytesConsumed)==2){
					points.Append(Point(x,y));
					while(line[bytesConsumed + 1] != '<'){
						if(sscanf(line + bytesConsumed,"%lf,%lf%n", &x, &y, &currentBytes)==2){
						bytesConsumed += currentBytes;
						points.Append(Point(x,y));
						}else{
							printf("Error scanning line file!!\n");
						}
					}
					lines.Append(points);
				}
				else{
					printf("Error scanning line file!!\n");
				}

				delete [] line;
				line = NULL;

				//advance head and tail indeces past the new line
				t_i++;
				h_i = t_i;
				
				//advance the tail index to the next new line
				while(t_i < bufSize && buf[t_i] != '\n' && t_i < bufSize - 1){
					t_i++;
				}

				if(i<=numberOfIterations -2 && t_i == bufSize){
					tempSize = t_i - h_i;
					temp = new char[tempSize];
					for(int j = 0; j <= tempSize - 1; j++){
						temp[j] = buf[h_i + j];
					}
					delete [] buf;
				}
			}
		}

		//clean up file pointer and buffer
		fflush(file);
		fclose(file);
		delete [] buf;
		buf = NULL;
		filepath = NULL;
		return lines;
}

bool PointInPolygon(Point point, Points polygon){
	int i, j, n = polygon.length;
	bool c = false;
	double x = point.x;
	double y = point.y;
	for (i = 0, j = n-1; i < n; j = i++) {
		Point p1 = polygon.points[i], p2 = polygon.points[j];
		if ( ((p1.y>y) != (p2.y>y)) && (x < (p2.x-p1.x) * (y-p1.y) / (p2.y-p1.y) + p1.x) )
			c = !c;
	}
	return c;
}

int binarySearchLow(Points pts, double value){
	int low = 0, high = pts.length - 1, mid;
	while (low <= high){
		mid = (low + high) / 2;
		if(pts.points[mid].x >= value){
			high = mid - 1;
		}else{
			low = mid + 1;
		}
	}
	return low;
}

int binarySearchHigh(Points pts, double value){
	int low = 0, high = pts.length - 1, mid;
	while (low <= high){
		mid = (low + high) /2;
		if(pts.points[mid].x > value){
			high = mid - 1;
		}else{
			low = mid + 1;
		}
	}
	return low;
}

double min(double a, double b, double c){
	return ((a<b)?((a<c)?a:c):((b<c)?b:c));
}

double max(double a, double b, double c){
	return ((a>b)?((a>c)?a:c):((b>c)?b:c));
}

void makeXMLDoc(char* filepath, Lines lines){
	Buffer prefix = Buffer(":<gml:LineString srsName=\"EPSG:54004\" xmlns:gml=\"http://www.opengis.net/gml\"><gml:coordinates decimal=\".\" cs=\",\" ts=\" \">");
	Buffer postfix = Buffer("</gml:coordinates></gml:LineString>\n");
	Buffer buffer = Buffer();
	int len = 0;
	char* nums = new char[100];
	char* integer = new char[15];

	for(int i = 0; i <= lines.length - 1; i++){
		Points points = lines.lines[i];
		len = sprintf(integer,"%d", points.id);
		buffer.AppendBuffers(Buffer(integer,len));
		buffer.AppendBuffers(prefix);
		delete [] integer;
		integer = new char[15];
		for(int j = 0; j <= points.length - 1; j++){
			Point p = points.points[j];
			len = sprintf(nums, "%.9f,%.9f ",p.x,p.y);
			Buffer values = Buffer(nums,len);
			buffer.AppendBuffers(values);
			values.Destroy();
			delete [] nums;
			nums = new char[100];
		}

		buffer.AppendBuffers(postfix);
	}
	FILE* file = fopen(filepath,"w");
	fwrite (buffer.buffer , sizeof(char), buffer.GetLength(), file);
	buffer.Destroy();
	prefix.Destroy();
	postfix.Destroy();
	fclose(file);

}