using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Project
{
    public partial class Graph
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
            ConvertListsToStartWithOne(lists);
            SortLists(lists);
            CheckIfNumberInListsAreInRange(lists);
            AddToAdjacencyList(lists);
            
        }

        private void CheckIfNumberInListsAreInRange(List<List<int>> lists)
        {
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                if (lists[i].Count !=0 && lists[i][^1] > AdjacencyList.Count - 1)
                    throw new VortexBiggerThanTopVortexNumberException(i.ToString());
            }
        }

        private void SortLists(List<List<int>> lists)
        {
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                lists[i].Sort();
            }
        }

        private void AddToAdjacencyList(List<List<int>> lists)
        {
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

        private void ConvertListsToStartWithOne(List<List<int>> lists)
        {
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                for(int j = 0; j < lists[i].Count; j++)
                {
                    lists[i][j]--;
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
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                lists[i] = lists[i].Distinct().ToList(); 
            }
        }
    }
}
