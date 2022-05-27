using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce100_hw5_algo_lib_cs;
using System.Collections.Generic;
using System.Linq;


/**
 * @file Algo_lib.cs
 * @author Rabia SÜME 
 * @date 27 MAY 2022
 *
 * @brief <b> HW-5 Functions </b>
 *
 * HW-5 Algo Test Header
 *
 * @see http://bilgisayar.mmf.erdogan.edu.tr/en/
 *
 */

namespace ce100_hw5_algo_test_cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Graph_Cycle_Detection_TestMethod1()
        {
            Graph_Cycle_Detection graph = new Graph_Cycle_Detection(4);
            graph.addEdge(1, 0);
            graph.addEdge(0, 2);
            graph.addEdge(2, 1);
            graph.addEdge(0, 3);
            graph.addEdge(3, 4);


            Assert.IsTrue(graph.isCyclic());
        }



        [TestMethod]
        public void Graph_Cycle_Detection_TestMethod2()
        {
            Graph_Cycle_Detection graph = new Graph_Cycle_Detection(9);
            graph.addEdge(1, 2);
            graph.addEdge(1, 3);
            graph.addEdge(1, 4);
            graph.addEdge(1, 5);
            graph.addEdge(2, 6);
            graph.addEdge(2, 7);
            graph.addEdge(3, 8);

            Assert.IsFalse(graph.isCyclic());
        }



        [TestMethod]
        public void Graph_Cycle_Detection_TestMethod3()
        {
            Graph_Cycle_Detection graph = new Graph_Cycle_Detection(6);
            graph.addEdge(0, 1);
            graph.addEdge(1, 2);
            graph.addEdge(1, 5);
            graph.addEdge(2, 3);
            graph.addEdge(3, 4);
            graph.addEdge(4, 0);
            graph.addEdge(4, 1);

            Assert.IsTrue(graph.isCyclic());
        }


        [TestMethod]
        public void Minimum_Spanning_Tree_TestMethod_1()
        {

            /* Let us create following weighted graph */
            int V = 4; // Number of vertices in graph
            int E = 5; // Number of edges in graph
            Minimum_Spanning_Tree graph = new Minimum_Spanning_Tree(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 2;

            // add edge 0-2
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 6;

            // add edge 0-3
            graph.edge[2].src = 1;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 7;

            // add edge 1-3
            graph.edge[3].src = 2;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 4;

            // add edge 2-3
            graph.edge[4].src = 3;
            graph.edge[4].dest = 2;
            graph.edge[4].weight = 5;

            // Function call
            string fiact = graph.KruskalMST();
            string fores = "( 0(source) --> 1(dest) == 2(weight) )" +
                         "( 2(source) --> 3(dest) == 4(weight) )" +
                         "( 0(source) --> 2(dest) == 6(weight) )";



            Assert.AreEqual(fiact, fores);
        }



        [TestMethod]
        public void Minimum_Spanning_Tree_TestMethod_2()
        {

            /* Let us create following weighted graph */
            int V = 4; // Number of vertices in graph
            int E = 5; // Number of edges in graph
            Minimum_Spanning_Tree graph = new Minimum_Spanning_Tree(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 10;

            // add edge 0-2
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 6;

            // add edge 0-3
            graph.edge[2].src = 0;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 5;

            // add edge 1-3
            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 15;

            // add edge 2-3
            graph.edge[4].src = 2;
            graph.edge[4].dest = 3;
            graph.edge[4].weight = 4;

            // Function call
            string fiact = graph.KruskalMST();
            string fores = "( 2(source) --> 3(dest) == 4(weight) )" +
                         "( 0(source) --> 3(dest) == 5(weight) )" +
                         "( 0(source) --> 1(dest) == 10(weight) )";



            Assert.AreEqual(fiact, fores);
        }




        [TestMethod]
        public void Minimum_Spanning_Tree_TestMethod_3()
        {

            /* Let us create following weighted graph */
            int V = 4; // Number of vertices in graph
            int E = 5; // Number of edges in graph
            Minimum_Spanning_Tree graph = new Minimum_Spanning_Tree(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 10;

            // add edge 0-2
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 6;

            // add edge 0-3
            graph.edge[2].src = 0;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 5;

            // add edge 1-3
            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 15;

            // add edge 2-3
            graph.edge[4].src = 2;
            graph.edge[4].dest = 3;
            graph.edge[4].weight = 4;

            // Function call
            string fiact = graph.KruskalMST();
            string fores = "( 2(source) --> 3(dest) == 4(weight) )" +
                         "( 0(source) --> 3(dest) == 5(weight) )" +
                         "( 0(source) --> 1(dest) == 10(weight) )";

            Assert.AreEqual(fiact, fores);
        }





        [TestMethod]
        public void Max_Flow_TestMethod_1()
        {

            // Let us create a graph shown in the above example
            int[,] graph = new int[,] {
            { 0, 16, 13, 0, 0, 0 }, { 0, 0, 10, 12, 0, 0 },
            { 0, 4, 0, 0, 14, 0 },  { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },   { 0, 0, 0, 0, 0, 0 }};
            Max_Flow m = new Max_Flow();
            int fiact = m.fordFulkerson(graph, 0, 5);
            int fores = 23;
            Assert.AreEqual(fiact, fores);
        }






        [TestMethod]
        public void Max_Flow_TestMethod_2()
        {

            // Let us create a graph shown in the above example
            int[,] graph = new int[,] {
            { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 3, 0 },  { 0, 5, 0, 0, 0, 0 },
            { 0, 0, 0, 6, 0, 0 },   { 0, 7, 0, 0, 0, 0 }};
            Max_Flow m = new Max_Flow();
            int fiact = m.fordFulkerson(graph, 0, 5);
            int fores = 0;
            Assert.AreEqual(fiact, fores);
        }







        [TestMethod]
        public void Max_Flow_TestMethod_3()
        {

            // Let us create a graph shown in the above example
            int[,] graph = new int[,] {
            { 0, 16, 13, 0, 4, 0 }, { 1, 1, 1, 1, 1, 1 },
            { 0, 4, 11, 0, 14, 0 },  { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },   { 0, 0, 0, 0, 0, 0 }};
            Max_Flow m = new Max_Flow();
            int fiact = m.fordFulkerson(graph, 0, 5);
            int fores = 13;
            Assert.AreEqual(fiact, fores);
        }







        [TestMethod]
        public void Single_Source_Shortest_Path_TestMethod_1()
        {
            int V = 5; // Number of vertices in graph
            int E = 5; // Number of edges in graph

            Single_Source_Shortest_Path graph = new Single_Source_Shortest_Path(V, E);

            // add edge 0-1 
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 1;

            // add edge 0-2 
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 11;

            // add edge 1-2 
            graph.edge[2].src = 1;
            graph.edge[2].dest = 2;
            graph.edge[2].weight = 4;

            // add edge 1-4 
            graph.edge[3].src = 1;
            graph.edge[3].dest = 4;
            graph.edge[3].weight = 7;

            // add edge 1-3 
            graph.edge[4].src = 1;
            graph.edge[4].dest = 3;
            graph.edge[4].weight = 2;


            string fiAct = Single_Source_Shortest_Path.BellmanFord(graph, 0);
            string foRes = "0(Vertex) --> 0(Distance from source)," +
                "	1(Vertex) --> 1(Distance from source)," +
                "	2(Vertex) --> 5(Distance from source)," +
                "	3(Vertex) --> 3(Distance from source)," +
                "	4(Vertex) --> 8(Distance from source)";

            Assert.AreEqual(fiAct, foRes);
        }





        [TestMethod]
        public void Single_Source_Shortest_Path_TestMethod_2()
        {

            int V = 6; // Number of vertices in graph
            int E = 10; // Number of edges in graph

            Single_Source_Shortest_Path graph = new Single_Source_Shortest_Path(V, E);

            // add edge 0-1 
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 1;

            // add edge 0-2 
            graph.edge[1].src = 1;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = -1;

            // add edge 1-2 
            graph.edge[2].src = 2;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = -1;

            // add edge 1-3 
            graph.edge[3].src = 3;
            graph.edge[3].dest = 0;
            graph.edge[3].weight = -1;

            // add edge 2-3
            graph.edge[5].src = 2;
            graph.edge[5].dest = 3;
            graph.edge[5].weight = 3;

            // add edge 3-4 
            graph.edge[6].src = 3;
            graph.edge[6].dest = 4;
            graph.edge[6].weight = 4;

            // add edge 4-5 
            graph.edge[7].src = 4;
            graph.edge[7].dest = 5;
            graph.edge[7].weight = 7;

            // add edge 5-3 
            graph.edge[7].src = 5;
            graph.edge[7].dest = 4;
            graph.edge[7].weight = -3;

            // add edge 5-3 
            graph.edge[7].src = 5;
            graph.edge[7].dest = 3;
            graph.edge[7].weight = 5;

            // add edge 5-3 
            graph.edge[7].src = 3;
            graph.edge[7].dest = 5;
            graph.edge[7].weight = 4;

            
            string result = Single_Source_Shortest_Path.BellmanFord(graph, 0);
            string expected = "0(Vertex) --> -10(Distance from source)," +
                "	1(Vertex) --> -7(Distance from source)," +
                "	2(Vertex) --> -8(Distance from source)," +
                "	3(Vertex) --> -9(Distance from source)," +
                "	4(Vertex) --> -5(Distance from source)," +
                "	5(Vertex) --> -5(Distance from source)";
            Assert.AreEqual(result, expected);

        }



        [TestMethod]
        public void Single_Source_Shortest_Path_TestMethod_3()
        {

            int V = 4; // Number of vertices in graph
            int E = 4; // Number of edges in graph

            Single_Source_Shortest_Path graph = new Single_Source_Shortest_Path(V, E);

            // add edge 0-1 
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = -1;

            // add edge 0-2 
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 4;

            // add edge 1-2 
            graph.edge[2].src = 1;
            graph.edge[2].dest = 2;
            graph.edge[2].weight = 3;

            // add edge 1-3 
            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 2;



            string fiact = Single_Source_Shortest_Path.BellmanFord(graph, 0);
            string fores = "0(Vertex) --> 0(Distance from source)," +
                "	1(Vertex) --> -1(Distance from source)," +
                "	2(Vertex) --> 2(Distance from source)," +
                "	3(Vertex) --> 1(Distance from source)";
            Assert.AreEqual(fiact, fores);
        }
    }
}
