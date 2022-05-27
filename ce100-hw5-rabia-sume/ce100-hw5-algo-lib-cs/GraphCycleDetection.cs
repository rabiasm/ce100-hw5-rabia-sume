using System;
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
    public class Graph_Cycle_Detection
    {

        private readonly int V;
        private readonly List<List<int>> adj;

        public Graph_Cycle_Detection(int V)
        {
            this.V = V;
            adj = new List<List<int>>(V);

            for (int i = 0; i < V; i++)
                adj.Add(new List<int>());
        }



        /** 
        * @name  IsCyclicUtil 
        * 
        * @brief This function is a variation of DFSUtil() in
        *        https://www.geeksforgeeks.org/archives/18212
        * 
        * @param [in] fiI [\b int]  function index of  in the serie
        * 
        * @param [in] fivisited [\b bool[]]  function index of  in the serie
        * 
        * @param [in] fiRecStack [\b bool[]]  function index of  in the serie
        * 
        * @retval [\b bool] return IsCyclicUtil as true or false.
        * 
        **/

        // This function is a variation of DFSUtil() in
        // https://www.geeksforgeeks.org/archives/18212
        private bool isCyclicUtil(int i, bool[] visited,
                                        bool[] recStack)
        {

            // Mark the current node as visited and
            // part of recursion stack
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = adj[i];

            foreach (int c in children)
                if (isCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }

        public void addEdge(int sou, int dest)
        {
            adj[sou].Add(dest);
        }

        // Returns true if the graph contains a
        // cycle, else false.
        // This function is a variation of DFS() in
        // https://www.geeksforgeeks.org/archives/18212
        public bool isCyclic()
        {

            // Mark all the vertices as not visited and
            // not part of recursion stack
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V];


            // Call the recursive helper function to
            // detect cycle in different DFS trees
            for (int i = 0; i < V; i++)
                if (isCyclicUtil(i, visited, recStack))
                    return true;

            return false;
        }
    }
}
