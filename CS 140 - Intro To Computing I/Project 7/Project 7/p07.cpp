//File: P07.cpp

//Date: 04/12/2011

//Name: Brian Olsen

//Course:  CS 140-001 - Introduction to Computing I

//Desc:This program inputs a grade file and reads the scores into an assessment record.  

//Once read in, the average is computed and its histogram displayed to the screen.

//After all assessments have been plotted, it is easy to see how the class performed on that particular assessment.

#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
using namespace std;

//Constants
const int MAX_QUIZ = 8;
const int MAX_PROGRAM = 8;
const int MAX_EXAM = 3;
const int STUDENT_COUNT = 36;
const char PLOT_MARK = char(178);
const string INPUT_FILE = "scores.txt";

//Function prototypes
bool ConnectInputFile(ifstream& fin, const string filename);

string LoadAssessmentArray(ifstream& fin, int scores[], const int numberOfScores);

int ComputeAverage(int scores[], const int numberOfScores);

void DisplayHistogramBar(const string assessment, const int barHeight);


//Beginning of int main()
int main() {

	ifstream fin;
	int quiz[STUDENT_COUNT] = {0};
	int program[STUDENT_COUNT] = {0}; 
	int exam[STUDENT_COUNT] = {0};
	int ave;

	string str, str2;
	
		cout << "Programmed by Brian Olsen.\n\n";

		if (ConnectInputFile(fin, INPUT_FILE) == false) {
		cerr << "Error opening file " << INPUT_FILE << " for input. Aborting!"
			 << endl
			 << endl;
		exit(1);
		}

		for (int i=0; i < MAX_QUIZ; i++){

		str=LoadAssessmentArray(fin, quiz, STUDENT_COUNT);
		ave=ComputeAverage(quiz, STUDENT_COUNT);
		DisplayHistogramBar(str, ave);

		}

		cout << endl;

		for (int i=0; i < MAX_PROGRAM; i++){

		str=LoadAssessmentArray(fin, program, STUDENT_COUNT);
		ave=ComputeAverage(program, STUDENT_COUNT);
		DisplayHistogramBar(str, ave);

		}

		cout << endl;

		for (int i=0; i < MAX_EXAM; i++){

		str=LoadAssessmentArray(fin, exam, STUDENT_COUNT);
		ave=ComputeAverage(exam, STUDENT_COUNT);
		DisplayHistogramBar(str, ave);

		}

		fin.close();

	cout << endl << endl;

	return 0;

} //End of int main()

//Function definitions
bool ConnectInputFile(ifstream& fin, const string filename){

	fin.open(filename.c_str());

	 if (fin.fail()) {

		  return false;

     }

	 else {

		  return true;

	 }

}

string LoadAssessmentArray(ifstream& fin, int scores[], const int numberOfScores){

	string str;

	string temp;

	int num;

	getline(fin,str, ',');
		
for (int i = 0; i < numberOfScores-1; i++){

		getline(fin,temp, ',');

		istringstream iss(temp);

		iss>>num;

		scores[i]= num;

	}

		getline(fin,temp, '\n');

		istringstream iss(temp);

		iss>>num;

		scores[numberOfScores-1]= num;

		return str;
}

int ComputeAverage(int scores[], const int numberOfScores){

	int add=0;

	for(int i=0; i <= numberOfScores-1; i++){

		add+=scores[i];

	}

	return (add/numberOfScores);

}

void DisplayHistogramBar(const string assessment, const int barHeight){

	cout << assessment << ": ";

	for(int i=0; i <= barHeight; i++){

		cout << PLOT_MARK;

	}

	cout << "  " << barHeight << endl << endl;

}