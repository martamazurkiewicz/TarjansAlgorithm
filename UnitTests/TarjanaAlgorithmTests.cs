using System;
using System.Collections.Generic;
using NUnit.Framework;
using Project;

namespace UnitTests
{
    [TestFixture]
    class TarjanaAlgorithmTests
    {
        Graph graph;
        Graph graph2;
        [SetUp]
        public void SetUp()
        {
            graph = new Graph(7);
            graph2 = new Graph(6);
            List<string> adjacencyList = new List<string>()
            {
                "2,3,4",
                "1,5,6",
                "1,4,7",
                "1,3,7",
                "2,6",
                "2,5",
                "3,4"
            };
            List<string> adjacencyList2 = new List<string>()
            {
                "2,3",
                "1,3,5",
                "1,2",
                "5,6",
                "2,4,6",
                "4,5"
            };
            graph.AddNeighbors(adjacencyList);
            graph2.AddNeighbors(adjacencyList2);
        }
        [Test]
        public void GetBridgesTest()
        {
            graph.Tarjan_Bridges();
            List<int[]> bridges = new List<int[]>() { new int[] { 1,0 } };
            Assert.AreEqual(bridges, graph.Bridges);
        }
        [Test]
        public void GetBridgesTest2()
        {
            graph2.Tarjan_Bridges();
            List<int[]> bridges = new List<int[]>() { new int[] { 4, 1 } };
            Assert.AreEqual(bridges, graph2.Bridges);
        }
    }
}
