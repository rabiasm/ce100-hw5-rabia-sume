﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ce100_hw5_algo_lib_cs.Minimum_Spanning_Tree;

/**
 * @file Algo_lib.cs
 * @author Rabia SÜME
 * @date 27 MAY 2022
 *
 * @brief <b> HW-5 Functions </b>
 *
 * HW-5 Algo Lib Functions Header
 *
 * @see http://bilgisayar.mmf.erdogan.edu.tr/en/
 *
 */


namespace ce100_hw5_algo_lib_cs
{
    public class Minimum_Spanning_Tree


    /** 
    * @name  KRUSKAL
    * 
    * @brief The main function that finds shortest
    *        distances from src to all other vertices
    *        using Bellman-Ford algorithm. The function
    *        also detects negative weight cycle
    *        The row graph[i] represents i-th edge with
    *        three values u, v and w.
    * 
    * @param [in] fiGraph [\b int[,]]  function index of  in the serie
    * 
    * @param [in] fiV [\b int]  function index of  in the serie
    * 
    * @param [in] fiE [\b int]  function index of  in the serie
    * 
    * @retval [\b int[]] return BellmanFord as an array.
    * 
    **/


    {
        // A class to represent a graph edge
        public class Edge : IComparable<Edge>
        {
            public int src, dest, weight;

            // Comparator function used for sorting edges
            // based on their weight
            public int CompareTo(Edge compareEdge)
            {
                return this.weight
                       - compareEdge.weight;
            }
        }

        // A class to represent
        // a subset for union-find
        public class subset
        {
            public int parent, rank;
        };

        public int V, E; // V-> no. of vertices & E->no.of edges
        public Edge[] edge; // collection of all edges

        // Creates a graph with V vertices and E edges
        public Minimum_Spanning_Tree(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        // A utility function to find set of an element i
        // (uses path compression technique)
        int find(subset[] subsets, int i)
        {
            // find root and make root as
            // parent of i (path compression)
            if (subsets[i].parent != i)
                subsets[i].parent
                    = find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        // A function that does union of
        // two sets of x and y (uses union by rank)
        void Union(subset[] subsets, int x, int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);

            // Attach smaller rank tree under root of
            // high rank tree (Union by Rank)
            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            // If ranks are same, then make one as root
            // and increment its rank by one
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        // The main function to construct MST
        // using Kruskal's algorithm
        public string KruskalMST()
        {
            string print = "";
            // This will store the
            // resultant MST
            Edge[] result = new Edge[V];
            int e = 0; // An index variable, used for result[]
            int i = 0; // An index variable, used for sorted edges
            for (i = 0; i < V; ++i)
                result[i] = new Edge();

            // Step 1: Sort all the edges in non-decreasing
            // order of their weight. If we are not allowed
            // to change the given graph, we can create
            // a copy of array of edges
            Array.Sort(edge);

            // Allocate memory for creating V subsets
            subset[] subsets = new subset[V];
            for (i = 0; i < V; ++i)
                subsets[i] = new subset();

            // Create V subsets with single elements
            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0; // Index used to pick next edge

            // Number of edges to be taken is equal to V-1
            while (e < V - 1)
            {
                // Step 2: Pick the smallest edge. And increment
                // the index for next iteration
                Edge next_edge = new Edge();
                next_edge = edge[i++];

                int x = find(subsets, next_edge.src);
                int y = find(subsets, next_edge.dest);

                // If including this edge doesn't cause cycle,
                // include it in result and increment the index
                // of result for next edge
                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
                // Else discard the next_edge
            }

            // print the contents of result[] to display
            // the built MST
            Console.WriteLine("Following are the edges in "
                              + "the constructed MST");

            int minimumCost = 0;
            for (i = 0; i < e; ++i)
            {
                print += "( " + result[i].src + "(source) --> " + result[i].dest + "(dest) == " + result[i].weight + "(weight) )";
                minimumCost += result[i].weight;
            }
            return print;
        }
    }
}
