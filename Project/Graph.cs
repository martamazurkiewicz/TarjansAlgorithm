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

        public void AddNeighbors(List<string> textList)
        {
            List<List<int>> neighboursLists = ConvertTextListsToIntegersAndChangeTheirRange(textList);
            for (int i = 0; i < AdjacencyList.Count; i++)
            {   
                if (neighboursLists[i].Count > 0)
                {
                    //remove duplicates
                    neighboursLists[i] = neighboursLists[i].Distinct().ToList();

                    //in input vertices starts from 1, in adjacency list vertices must start from 0
                    //function subtract 1 from each of the elements in neighboursList
                    VerticesInNeighboursListStartsFromZero(neighboursLists[i]);

                    //check if vortex is in its own neighboursLists and if so delete it 
                    DeleteVortexFromItsOwnNeighboursList(i, neighboursLists[i]);
                }
                //add neighbours list to adjacency list 
                AdjacencyList[i] = neighboursLists[i];
            }

        }

        private List<List<int>> ConvertTextListsToIntegersAndChangeTheirRange(List<string> textList)
        {
            List<List<int>> neighboursLists = new List<List<int>>();
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                neighboursLists.Add(ConvertTextListToIntegerList(textList[i]));
                if (neighboursLists[i].Count > 0)
                {
                    neighboursLists[i].Sort();
                    //throw exception if top number in neighboursList is bigger than top vortex number
                    CheckIfNeighboursListAreInRange(neighboursLists[i], i);
                }
            }
            return neighboursLists;
        }

        private List<int> ConvertTextListToIntegerList(string text)
        {
                string[] neighboursArray = text.Split(',');
                return neighboursArray[0] != "" ? neighboursArray.Select(Int32.Parse).ToList() : new List<int>();
        }

        private void CheckIfNeighboursListAreInRange(List<int> neighboursList, int vortexNumber)
        {
            if (neighboursList.Count != 0 && neighboursList[^1] > AdjacencyList.Count)
                throw new NeighboursListElementBiggerThanTopVortexException(vortexNumber.ToString());
        }

        private void VerticesInNeighboursListStartsFromZero(List<int> neighboursList)
        {
            for (int i = 0; i < neighboursList.Count; i++)
            {
                neighboursList[i]--;
            }
        }

        private void DeleteVortexFromItsOwnNeighboursList(int vortex, List<int> neighboursList)
        {
            if (neighboursList.Contains(vortex))
                neighboursList.RemoveAll(item => item == vortex);
        }
    }
}
