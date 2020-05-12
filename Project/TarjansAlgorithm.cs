using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public partial class Graph
    {
        //Tarjan's algorithm output - list of bridges
        //integer arrays in list always have 2 elements - 2 vertices of an edge
        //used in main window
        public List<int[]> Bridges { get; private set; }

        public int iterator_one = 1;
       
         int[] dfs_numbers;
         int?[] parents_array;
         List<int>[] spanning_tree_2;
         int[] low_array; //array for low parameter for every vertex
         bool[] visited;

        public void Tarjan_Bridges()
        {
            Bridges = new List<int[]>();
            visited = new bool[AdjacencyList.Count];
            low_array = new int[AdjacencyList.Count];
            spanning_tree_2 = new List<int>[AdjacencyList.Count];
            dfs_numbers = new int[AdjacencyList.Count];
            Set_Spanning_Tree();
            Set_DFS_Array();
            Set_Parents_Array();
            Tarjan_Bridges(0);
            Clearing_Bool_Table(visited);
            iterator_one = 1;
        }
     void Tarjan_Bridges(int First_Vertex)
        {

            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            //   Console.Write(current_Vertex + " ");

            for (int i = 0; i < AdjacencyList[current_Vertex].Count; i++)
            {
                if (visited[AdjacencyList[current_Vertex][i]] != true) //unvisited neighboor
                {
                    Tarjan_Bridges(AdjacencyList[current_Vertex][i]);

                }
            } //end of branch
            
            int low_tmp = dfs_numbers[current_Vertex]; //first initialization of low parameter
            //checking for sons' low parameters
            for (int i = 0; i < spanning_tree_2[current_Vertex].Count; i++)
            {
                if (low_array[spanning_tree_2[current_Vertex][i]] != 0 && low_array[spanning_tree_2[current_Vertex][i]] < low_tmp)
                {
                    low_tmp = low_array[spanning_tree_2[current_Vertex][i]];
                }
            }
            //checking for other 'current vertex' neighbors

            for (int i = 0; i < AdjacencyList[current_Vertex].Count; i++)
            {
                bool returning_edge = true;
                if (AdjacencyList[current_Vertex][i] == parents_array[current_Vertex]) //father
                {
                    returning_edge = false;
                }
                if (AdjacencyList[current_Vertex][i] != parents_array[current_Vertex]) //not father
                {

                    for (int j = 0; j < spanning_tree_2[current_Vertex].Count; j++) //but son
                    {
                        if (AdjacencyList[current_Vertex][i] == spanning_tree_2[current_Vertex][j])
                        {
                            returning_edge = false;
                        }
                    }
                    

                }//not father nor son
                if (returning_edge == true)
                {
                    if (dfs_numbers[AdjacencyList[current_Vertex][i]] < low_tmp)
                    {
                        low_tmp = dfs_numbers[AdjacencyList[current_Vertex][i]];
                    }
                }

            }
            low_array[current_Vertex] = low_tmp;
            if (low_array[current_Vertex] == dfs_numbers[current_Vertex] && parents_array[current_Vertex] != null)
            {
               // Console.WriteLine("Most: " + current_Vertex + " " + parents_array[current_Vertex]);
                Bridges.Add(new int[] { current_Vertex, (int)parents_array[current_Vertex] });
            }


        }
         void Set_Spanning_Tree() //dfs spanning tree
        {
            for (int i = 0; i < spanning_tree_2.Length; i++)
            {
                spanning_tree_2[i] = new List<int>();
            }
            DFS_Spanning_Tree_R(0);
            Clearing_Bool_Table(visited);
        }
         void Set_DFS_Array() //array for dfs numbers of vertices
        {
            DFS_Array_R(0);
            Clearing_Bool_Table(visited);
        }
         void Set_Parents_Array() //array of parents for every vertex
        {
            parents_array = DFS_Parents_Array();
            Clearing_Bool_Table(visited);
        }

        void Clearing_Bool_Table(bool[] t1)
        {
            for (int i = 0; i < t1.Length; i++)
            {
                t1[i] = false;
            }
        }
         void DFS_Spanning_Tree_R(int First_Vertex) //altering array of lists building up DFS spanning tree, recursive version
        {
            //version where spanning tree doesnt have child-parent edges, only edges from parent to child
            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            //Console.Write(current_Vertex + " ");

            for (int i = 0; i < AdjacencyList[current_Vertex].Count; i++)
            {
                if (visited[AdjacencyList[current_Vertex][i]] != true) //unvisited neighboor
                {

                    spanning_tree_2[current_Vertex].Add(AdjacencyList[current_Vertex][i]); //adding edge connecting parent and child
                    DFS_Spanning_Tree_R(AdjacencyList[current_Vertex][i]);

                }
            }
        }
          void DFS_Array_R(int First_Vertex)//array for vertices dfs numbers
        {
            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            dfs_numbers[current_Vertex] = iterator_one;
            iterator_one++;


            for (int i = 0; i < AdjacencyList[current_Vertex].Count; i++)
            {
                if (visited[AdjacencyList[current_Vertex][i]] != true) //unvisited neighbor
                {

                    DFS_Array_R(AdjacencyList[current_Vertex][i]);

                }
            }
        }

          int?[] DFS_Parents_Array() //array for vertices' parents
        {
            int?[] parents_array = new int?[spanning_tree_2.Length];
            for (int i = 0; i < spanning_tree_2.Length; i++) //parents
            {
                for (int j = 0; j < spanning_tree_2[i].Count; j++) //kids
                {
                    parents_array[spanning_tree_2[i][j]] = i;
                }
            }
            return parents_array;
        }

    }
}
