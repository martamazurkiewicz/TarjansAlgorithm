using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Graph
    {
        public List<List<int>> adjacencyList { get; private set; }

        public Graph(int numberOfVertices)
        {
            adjacencyList = new List<List<int>>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                adjacencyList.Add(new List<int>());
            }
        }

        public void AddNeighbors(List<int[]> lists)
        {
            adjacencyList = new List<List<int>>();
            for (int i = 0; i < adjacencyList.Count; i++)
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
