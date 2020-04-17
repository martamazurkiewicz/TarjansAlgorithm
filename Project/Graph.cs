using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Graph
    {
        public List<List<int>> AdjacencyList { get; private set; }

        public Graph(int numberOfVertices)
        {
            AdjacencyList = new List<List<int>>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                AdjacencyList.Add(new List<int>());
            }
        }

        public void AddNeighbors(List<string[]> neighboursLists)
        {
            List<int[]> lists = ConvertNeighborsListsToIntegers(neighboursLists);
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                AdjacencyList[i] = new List<int>();
                foreach (var item in lists[i])
                {
                    AdjacencyList[i].Add(item);
                } 
            }
        }
        private List<int[]> ConvertNeighborsListsToIntegers(List<string[]> neighborsLists)
        {
            List<int[]> lists = new List<int[]>();
            foreach (var item in neighborsLists)
            {
                lists.Add(Array.ConvertAll(item, int.Parse));
            }
            return lists;
        }
    }
}
