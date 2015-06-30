#include "Graph.h"
#include <iostream>
#include <string>
#include <stack>

using namespace std;
namespace P10NS{


	//------------------------Edge Definitions-----------------------

		/* Initializes fields with parameter values. */
		Edge::Edge(int v1, int v2, int weight){
			Edge::v1=v1;
			Edge::v2=v2;
			Edge::weight=weight;
		}

	//------------------------Graph Definitions-----------------------
		/* Determines whether there is an unvisited vertex that is adjacent
		 * to v. The array mark[] keeps track of the visited vertices.
		 */
		bool Graph::hasUnvisited(int v, bool mark[]) const{
			int edge;
			isWeighted()?edge=-1:edge=0;

			for(int i = 0; i <= getNumberOfVertices()-1; i++){
				if(matrix[v][i]!=edge && !mark[i]){
					return true;
				}
			}
			return false;
		}
		
		/* Returns the next unvisited vertex that is adjacent to vertex v. 
		 * The array mark[] keeps track of the visited vertices.
		 */
		int Graph::getUnvisited(int v, bool mark[]) const{
			int edge;
			isWeighted()?edge=-1:edge=0;

			for(int i = 0; i <= getNumberOfVertices()-1; i++){
				if(!mark[i] && matrix[v][i]!=edge){
					return i;
				}
			}	
			return -1;
		}
		/* Creates the matrix to hold nNodes nodes and sets weighted and
		 * directed and sets numEdges to 0. If the graph is weighted, 
		 * each cell in the matrix is initialized to -1, if unweighted to 0.
		 */
		Graph::Graph(const int nNodes, bool weighted, bool directed){
			int edge;
			weighted?edge=-1:edge=0;

			matrix = new int*[nNodes];
			for(int i=0;i <= nNodes-1; i++){
				matrix[i]= new int[nNodes];
				for(int j=0;j <= nNodes-1; j++){
					matrix[i][j]= edge;
				}
			}
			numVertices=nNodes;
			numEdges=0;
			Graph::weighted=weighted;
			Graph::directed=directed;
		}

		// Releases all the memory held by the matrix.
		Graph::~Graph(){
			for(int i=0;i <= numVertices-1; i++){
				delete [] matrix[i];
			}
			delete matrix;
		}

		// Accessor methods.
		int Graph::getNumberOfVertices() const{
			return numVertices;
		}
		int Graph::getNumberOfEdges() const{
			return numEdges;
		}
		bool Graph::isWeighted() const{
			return weighted;
		}
		bool Graph::isDirected() const{
			return directed;
		}
		int Graph::getEdgeWeight(const Edge& e) const{
			return e.weight;
		}

		/* Adds the edge to the graph. The matrix is updated according
		 * to whether the graph is weighted/unweighted and/or directed/undirected.
		 * If the graph is unweighted and the edge has a non-zero weight, throw 
		 * GraphException("Cannot add a weighted edge to an unweighted graph.").
		 */
		void Graph::add(const Edge& e){
			try{
				
				if(!isWeighted() && e.weight==0){
					numEdges++;
				 matrix[e.v1][e.v2]=1;
				 !isDirected()?matrix[e.v2][e.v1]=1:(NULL);
				}
				else if(isWeighted()){
					numEdges++;
				 matrix[e.v1][e.v2]=e.weight;
				 !isDirected()?matrix[e.v2][e.v1]=e.weight:(NULL);
				}
				else{
					throw GraphException("Cannot add a weighted edge to an unweigted graph.");
				}
			}
			catch(GraphException ge){
			cerr << ge.what() << endl;
			}
		}

		/* Returns the edge connecting the two vertices.
		 * If v1 or v2 are invalid, throws GraphException("v1 not a valid vertex.")
		 * or GraphException("v2 not a valid vertex.").
		 */
		Edge Graph::getEdge(int v1, int v2) const{

			try{
				int w=0;
				if(v1<0 || v1>numVertices-1){
					throw(GraphException("v1 not a valid vertex."));
				}
				else if(v2<0 || v2>numVertices-1){
					throw(GraphException("v2 not a valid vertex."));
				}
				else{
				isWeighted()?w=matrix[v1][v2]:0;

				return Edge(v1,v2,w);
				}
			}
			catch(GraphException ge){
			cerr << ge.what() << endl;
			}
			return Edge(v1,v2,0);
		}

		/* Performs a dfs traversal of the graph, and returns an array
		 * representing the traversed vertices. The starting vertex
		 * is provided as the parameter.
		 */
		int* Graph::dfs(int v) const{
			int* traversed=new int [numVertices];
			bool* mark=new bool [numVertices];
			int count=1;
			for(int i=0;i<=numVertices-1;i++){
					mark[i]=false;
			}
			stack<int> traverse;

			traversed[0]=v;
			traverse.push(v);
			mark[v]=true;
			while(!traverse.empty()){

				if(!hasUnvisited(traverse.top(),mark)){
					traverse.pop();
				}
				else{
					int next=getUnvisited(traverse.top(),mark);
					traversed[count]=next;
					count++;
					mark[next]=true;
					traverse.push(next);
				}
			}
			return traversed;
		}
	}// end P10NS