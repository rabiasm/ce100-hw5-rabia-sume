using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw5_algo_lib_cs
{
    public class Single_Source_Shortest_Path
    {
        // A class to represent a weighted edge in graph
        public class Edge
        {
            public int src, dest, weight;
            public Edge()
            {
                src = dest = weight = 0;
            }
        };

        public int V, E;

        public Edge[] edge;

        // Creates a graph with V vertices and E edges
        public Single_Source_Shortest_Path(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[e];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        //
        /** 
        * @name  Bellman Ford
        * 
        * @brief  The main function that finds shortest distances from src
        *         to all other vertices using Bellman-Ford algorithm. The
        *         function also detects negative weight cycle
        * 
        * @param [in] fiGraph [\b Single_Source_Shortest_Path]  function index of  in the serie
        * 
        * @param [in] fisrc [\b int]  function index of  in the serie
        * 
        * @retval [\b string] return BellmanFord as a string.
        * 
        **/
        public static string BellmanFord(Single_Source_Shortest_Path figraph, int fisrc)
        {
            string print = "";
            int V = figraph.V, E = figraph.E;
            int[] dist = new int[V];

            // Step 1: Initialize distances from src to all other
            // vertices as INFINITE
            for (int i = 0; i < V; ++i)
                dist[i] = int.MaxValue;
            dist[fisrc] = 0;

            // Step 2: Relax all edges |V| - 1 times. A simple
            // shortest path from src to any other vertex can
            // have at-most |V| - 1 edges
            for (int i = 1; i < V; ++i)
            {
                for (int j = 0; j < E; ++j)
                {
                    int u = figraph.edge[j].src;
                    int v = figraph.edge[j].dest;
                    int weight = figraph.edge[j].weight;
                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;
                    }
                }
            }

            // Step 3: check for negative-weight cycles. The above
            // step guarantees shortest distances if graph doesn't
            // contain negative weight cycle. If we get a shorter
            // path, then there is a cycle.
            for (int j = 0; j < E; ++j)
            {
                int u = figraph.edge[j].src;
                int v = figraph.edge[j].dest;
                int weight = figraph.edge[j].weight;
                if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                {
                    Console.WriteLine("Graph contains negative weight cycle");
                }
            }

            Console.WriteLine("Vertex Distance from Source");
            for (int i = 0; i < V; ++i)
            {
                print += i + "(Vertex)" + " --> " + dist[i] + "(Distance from source)" + ",\t";
            }
            return print.Remove(print.Length - 2);
        }
    }
}
