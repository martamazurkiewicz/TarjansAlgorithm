using NUnit.Framework;
using Project;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class GraphTests
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
                    new int[] {2},
                    new int[] {2},
                    new int[] {0,1},
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
                    new int[] {2},
                    new int[] {2},
                    new int[] {0,1},
                };
            Assert.AreEqual(expectedOutput, graph.AdjacencyList);
        }
        [Test]
        public void AddNeighborsFailTest()
        {
            var graph = new Graph(3);
            Assert.Throws<VortexBiggerThanTopVortexNumberException>(() => graph.AddNeighbors(new List<string[]>(){
                    new string[] {"5","8","4"},
                    new string[] {"3","3"},
                    new string[] {"9","1","2"},
                }));
        }
        [Test]
        public void SortTest()
        {
            var graph = new Graph(3);
            graph.AddNeighbors(new List<string[]>(){
                    new string[] {"3","2"},
                    new string[] {"3","3"},
                    new string[] {"2","2","1"},
                });
            List<int[]> expectedOutput = new List<int[]>(){
                    new int[] {1,2},
                    new int[] {2},
                    new int[] {0,1},
                };
            Assert.AreEqual(expectedOutput, graph.AdjacencyList);
        }
    }
}