using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

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
            List<List<int>> lists = ConvertNeighborsListsToInteger(neighboursLists);
            RemoveDulicates(lists);
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                if (lists[i].Count != 0)
                {
                    AdjacencyList[i] = new List<int>();
                    foreach (var item in lists[i])
                    {
                        AdjacencyList[i].Add(item);
                    }
                }
            }
        }

        private List<List<int>> ConvertNeighborsListsToInteger(List<string[]> neighborsLists)
        {
            List<List<int>> lists = new List<List<int>>();
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                if (neighborsLists[i][0] == "")
                    lists.Add(new List<int>());
                else
                    lists.Add(neighborsLists[i].Select(Int32.Parse).ToList());
            } 
            return lists;
        }
        private void RemoveDulicates(List<List<int>> lists)
        {
            foreach (var item in lists)
            {
                item.Distinct().ToList();
            }
        }
    }
}
