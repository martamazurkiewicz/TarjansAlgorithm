using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Graph
    {
        //temporarily graph will be represented by adjacency list
        List<List<int>> adjacencyList;
        List<int> vertexes;

        public Graph(int numberOfVertexes)
        {
            vertexes = new List<int>();
            for (int i = 0; i < numberOfVertexes; i++)
            {
                vertexes.Add(i);
            }
        }
    }
}
