using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Graph
    {
        //temporarily graph will be represented by adjacency list
        List<List<int>> adjacencyList;
        public List<int> vertexes { get; private set; }

        public Graph(int numberOfVertexes)
        {
            vertexes = new List<int>();
            for (int i = 0; i < numberOfVertexes; i++)
            {
                vertexes.Add(i);
            }
        }

        internal void AddNeighbors(List<int[]> lists)
        {
            adjacencyList = new List<List<int>>();
            for (int i = 0; i < vertexes.Count; i++)
            {
                adjacencyList[i] = new List<int>();
                foreach (var item in lists[i])
                {
                    adjacencyList[i].Add(item);
                } 
            }
        }
    }
}
