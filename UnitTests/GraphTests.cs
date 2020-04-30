using NUnit.Framework;
using Project;
using System.Collections.Generic;

namespace UnitTests
{
    public class Tests
    {
        [TestFixture]
        class GraphTests
        {
            [Test]
            public void AddNeighborsTest()
            {
                var graph = new Graph(3);
                graph.AddNeighbors(new List<string[]>(){
                    new string[] {"3"},
                    new string[] {"3"},
                    new string[] {"1", "2"},
                });
                List<int[]> expectedOutput = new List<int[]>(){
                    new int[] {3},
                    new int[] {3},
                    new int[] {1,2},
                };
                Assert.AreEqual(expectedOutput, graph.AdjacencyList);
            }
            [Test]
            public void RemoveDuplicatesTest()
            {
                var graph = new Graph(3);
                graph.AddNeighbors(new List<string[]>(){
                    new string[] {"3","3","3"},
                    new string[] {"3","3"},
                    new string[] {"1","1","2"},
                });
                List<int[]> expectedOutput = new List<int[]>(){
                    new int[] {3},
                    new int[] {3},
                    new int[] {1,2},
                };
                Assert.AreEqual(expectedOutput, graph.AdjacencyList);
            }
        }
    }
}