#ifndef MAIN_H
#define MAIN_H

#include "p07.h"
#include "WordTracker.h"
#include <string>
#include <iostream>
#include <fstream>

using namespace std;
using namespace P07;

// Tests the WordTracker class. This function is implemented and should
// be used as is.
void TestWordTrackerClass();

// Connects the file stream to the filename and returns true is
// stream is opened successfully, false otherwise.
bool ConnectInputFile(ifstream& fin, const string& filename);

// Reads the file and loads the WordTracker object will all the words.
// It first calls ConnectInputFile() to establish the connection. Catches
// a bad_alloc Exception if any attempt to add a word fails, displays the
// error message in the exception object and exits the application.
void LoadWordTrackerFromFile(WordTracker& wt, const string& filename);

#endif