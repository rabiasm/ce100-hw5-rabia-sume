﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
    public class Max_Flow
    {
        static readonly int V = 6; // Number of vertices in
                                   // graph


        /** 
       * @name  bfs
       * 
       * @brief Returns true if there is a path
       *        from source 'fiS' to sink 'fiT' in residual
       *        graph. Also fills fşParent[] to store the path
       *      
       * 
       * @param [in] firGraph [\b int[,]]  function index of  in the serie
       * 
       * @param [in] fiS [\b int]  function index of  in the serie
       * 
       * @param [in] fiT [\b int]  function index of  in the serie
       * 
       * @param [in] fiParent [\b int[]]  function index of  in the serie
       * 
       * @retval [\b bool] return bfs as a bool.
       * 
       **/

        /* Returns true if there is a path
        from source 's' to sink 't' in residual
        graph. Also fills parent[] to store the
        path */
        bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            // Create a visited array and mark
            // all vertices as not visited
            bool[] visited = new bool[V];
            for (int i = 0; i < V; ++i)
                visited[i] = false;

            // Create a queue, enqueue source vertex and mark
            // source vertex as visited
            List<int> queue = new List<int>();
            queue.Add(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop
            while (queue.Count != 0)
            {
                int u = queue[0];
                queue.RemoveAt(0);

                for (int v = 0; v < V; v++)
                {
                    if (visited[v] == false
                        && rGraph[u, v] > 0)
                    {
                        // If we find a connection to the sink
                        // node, then there is no point in BFS
                        // anymore We just have to set its parent
                        // and can return true
                        if (v == t)
                        {
                            parent[v] = u;
                            return true;
                        }
                        queue.Add(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            // We didn't reach sink in BFS starting from source,
            // so return false
            return false;
        }

        // Returns the maximum flow
        // from s to t in the given graph
        public int fordFulkerson(int[,] graph, int s, int t)
        {
            int u, v;

            // Create a residual graph and fill
            // the residual graph with given
            // capacities in the original graph as
            // residual capacities in residual graph

            // Residual graph where rGraph[i,j]
            // indicates residual capacity of
            // edge from i to j (if there is an
            // edge. If rGraph[i,j] is 0, then
            // there is not)
            int[,] rGraph = new int[V, V];

            for (u = 0; u < V; u++)
                for (v = 0; v < V; v++)
                    rGraph[u, v] = graph[u, v];

            // This array is filled by BFS and to store path
            int[] parent = new int[V];

            int max_flow = 0; // There is no flow initially

            // Augment the flow while there is path from source
            // to sink
            while (bfs(rGraph, s, t, parent))
            {
                // Find minimum residual capacity of the edhes
                // along the path filled by BFS. Or we can say
                // find the maximum flow through the path found.
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow
                        = Math.Min(path_flow, rGraph[u, v]);
                }

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                // Add path flow to overall flow
                max_flow += path_flow;
            }

            // Return the overall flow
            return max_flow;
        }
    }
}
