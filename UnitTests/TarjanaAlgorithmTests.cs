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
        [SetUp]
        public void SetUp()
        {
            graph = new Graph(7);
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
            graph.AddNeighbors(adjacencyList);
        }
        [Test]
        public void GetBridgesTest()
        {
            graph.Tarjan_Bridges();
            List<int[]> bridges = new List<int[]>() { new int[] { 1,0 } };
            Assert.AreEqual(bridges, graph.Bridges);
        }
    }
}
