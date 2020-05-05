using NUnit.Framework;
using Project;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void AddNeighborsTest1()
        {
            var graph = new Graph(9);
            graph.AddNeighbors(new List<string>(){
                "2,6",
                "1,3",
                "2,4,8",
                "3,5,6,7",
                "3,4,7",
                "1,4",
                "4,5",
                "3",
                ""
                });
            var expectedOutput = new List<List<int>>(){
                    new List<int>(){1,5},
                    new List<int>(){0,2},
                    new List<int>(){1,3,7},
                    new List<int>(){2,4,5,6},
                    new List<int>(){2,3,6},
                    new List<int>(){0,3},
                    new List<int>(){3,4},
                    new List<int>(){2},
                    new List<int>()
                };
            Assert.AreEqual(expectedOutput, graph.AdjacencyList);
        }

        [Test]
        public void AddNeighborsTest2()
        {
            var graph = new Graph(9);
            graph.AddNeighbors(new List<string>(){
                "6,2",
                "1,3,3",
                "8,4,3,2",
                "3,5,6,7",
                "3,7,4,5,7,7",
                "1,4",
                "5,4",
                "3",
                ""
                });
            var expectedOutput = new List<List<int>>(){
                    new List<int>(){1,5},
                    new List<int>(){0,2},
                    new List<int>(){1,3,7},
                    new List<int>(){2,4,5,6},
                    new List<int>(){2,3,6},
                    new List<int>(){0,3},
                    new List<int>(){3,4},
                    new List<int>(){2},
                    new List<int>()
                };
            Assert.AreEqual(expectedOutput, graph.AdjacencyList);
        }

        [Test]
        public void AddNeighborsFailTest()
        {
            var graph = new Graph(4);
            Assert.Throws<NeighboursListElementBiggerThanTopVortexException>(() => graph.AddNeighbors(new List<string>(){
                    "5,8,4",
                    "",
                    "3,3",
                    "9,1,2"
                }));
        }

        //tests of private functions used for debugging while solving issues
        /*
        [Test]
        public void ConvertTextListToIntegerListTest()
        {
            var graph = new Graph(4);
            Assert.AreEqual(new List<int>() { 5, 8, 4 }, graph.ConvertTextListToIntegerList("5,8,4"));
        }
        [Test]
        public void CheckIfNeighboursListAreInRangeFailTest()
        {
            var graph = new Graph(4);
            Assert.Throws<NeighboursListElementBiggerThanTopVortexException>(() =>
                graph.CheckIfNeighboursListAreInRange(new List<int>() { 2, 2, 4, 7, 8 }, 0));
        }
        [Test]
        public void CheckIfNeighboursListAreInRangeTest()
        {
            var graph = new Graph(4);
            Assert.DoesNotThrow(() =>
                graph.CheckIfNeighboursListAreInRange(new List<int>() { 2, 2, 4 }, 0));
        }
        [Test]
        public void ConvertTextListsToIntegersAndChangeTheirRangeTest()
        {
            var graph = new Graph(9);
            var textList = new List<string>(){
                "5,8,4",
                "",
                "",
                "2,3",
                "8,9",
                "3,3",
                "9,1,2",
                "",
                "1,2"
            };
            var expectedOutput = new List<List<int>>(){
                new List<int>(){4,5,8},
                new List<int>(),
                new List<int>(),
                new List<int>(){2,3},
                new List<int>(){8,9},
                new List<int>(){3,3},
                new List<int>(){1,2,9},
                new List<int>(),
                new List<int>(){1,2}
            };
            Assert.AreEqual(expectedOutput, graph.ConvertTextListsToIntegersAndChangeTheirRange(textList));
        }
        */
    }
}