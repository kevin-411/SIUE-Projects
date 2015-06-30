#ifndef GRAPH_H
#define GRAPH_H

#include <string>
using namespace std;

namespace P10NS {
	
	/***********************************************************************
	 * Class: GraphException
	 * 
	 * Represents the exception for the graph class.
	 **********************************************************************/
	class GraphException {
	private:
		string message;

	public:
		GraphException(const string& message = "Graph exception")
			: message(message)
		{} // end GraphException()

		string what() const { return message; }
	}; // end GraphException


	/***********************************************************************
	 * Class: Edge
	 * 
	 * Represents an edge in a graph. The nodes connected by the edge
	 * are represented by integer values, which can be mapped to letters
	 * if need be by the client. If the graph is directed, the direction
	 * is from v1 to v2.
	 **********************************************************************/
	class Edge {
	private:
		int v1;
		int v2;
		int weight;

		friend class Graph;

	public:
		/* Initializes fields with parameter values. */
		Edge(int v1, int v2, int weight);
	}; // end Edge


	/***********************************************************************
	 * Class: Graph
	 * 
	 * Represents a weighted/unweighted, directed/undirected graph, 
	 * implemented using an adjacency matrix. The following assumptions are
	 * made regarding the cells in the matrix.
	 *
	 * Weighted graph: -1: infinite cost, >0: actual cost.
	 * Unweighted graph: 0: no edge, 1: edge.
	 **********************************************************************/
	class Graph {
	private:
		// The adjacency matrix.
		int** matrix;
		int numVertices;
		int numEdges;
		bool weighted;
		bool directed;

		/* Determines whether there is an unvisited vertex that is adjacent
		 * to v. The array mark[] keeps track of the visited vertices.
		 */
		bool hasUnvisited(int v, bool mark[]) const;
		
		/* Returns the next unvisited vertex that is adjacent to vertex v. 
		 * The array mark[] keeps track of the visited vertices.
		 */
		int getUnvisited(int v, bool mark[]) const;

	public:
		/* Creates the matrix to hold nNodes nodes and sets weighted and
		 * directed and sets numEdges to 0. If the graph is weighted, 
		 * each cell in the matrix is initialized to -1, if unweighted to 0.
		 */
		Graph(const int nNodes, bool weighted, bool directed);

		// Releases all the memory held by the matrix.
		~Graph();

		// Accessor methods.
		int getNumberOfVertices() const;
		int getNumberOfEdges() const;
		bool isWeighted() const;
		bool isDirected() const;
		int getEdgeWeight(const Edge& e) const;

		/* Adds the edge to the graph. The matrix is updated according
		 * to whether the graph is weighted/unweighted and/or directed/undirected.
		 * If the graph is unweighted and the edge has a non-zero weight, throw 
		 * GraphException("Cannot add a weighted edge to an unweighted graph.").
		 */
		void add(const Edge& e);

		/* Returns the edge connecting the two vertices.
		 * If v1 or v2 are invalid, throws GraphException("v1 not a valid vertex.")
		 * or GraphException("v2 not a valid vertex.").
		 */
		Edge getEdge(int v1, int v2) const;

		/* Performs a dfs traversal of the graph, and returns an array
		 * representing the traversed vertices. The starting vertex
		 * is provided as the parameter.
		 */
		int* dfs(int v) const;
	}; // end Graph
}// end P10NS

#endif