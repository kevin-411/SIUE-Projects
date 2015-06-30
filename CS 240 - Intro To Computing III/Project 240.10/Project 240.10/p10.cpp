#include "Graph.h"
#include <iostream>
#include <string>

using namespace std;
using namespace P10NS;


int main() {
	Graph graph(9, false, false);
	string vertices[] = {"A", "B", "C", "D", "E", "F", "G", "H", "I"};

	// Add the vertices and edges.
	try {
		graph.add(Edge(0, 8, 0)); // A-I
		graph.add(Edge(0, 5, 0)); // A-F
		graph.add(Edge(0, 1, 0)); // A-B
		graph.add(Edge(1, 2, 0)); // B-C
		graph.add(Edge(1, 4, 0)); // B-E
		graph.add(Edge(2, 3, 0)); // C-D
		graph.add(Edge(3, 6, 0)); // D-G
		graph.add(Edge(3, 7, 0)); // D-H
		graph.add(Edge(4, 6, 0)); // E-G

		// Comment this line when uncommenting the next one.
		graph.add(Edge(6, 5, 0)); // G-F

		// Uncomment this line to see the exception error.
		//graph.add(Edge(6, 5, 1)); // G-F
	
		int* visitedVertices = graph.dfs(0);

		cout << "DFS traversal: ";
		for (int i = 0; i <= 8; i++) {
			cout << vertices[visitedVertices[i]] << " ";
		} // end for

		delete [] visitedVertices;
	} catch (GraphException e) {
		cerr << e.what() << endl;
	}// end try

	//// Try to get an invalid edge.
	//try {
	//	Edge e = graph.getEdge(0, 10);
	//} catch (GraphException e) {
	//	cerr << endl << endl << e.what() << endl;
	//} // end try

	cout << endl << endl;
	return 0;
} // end main()