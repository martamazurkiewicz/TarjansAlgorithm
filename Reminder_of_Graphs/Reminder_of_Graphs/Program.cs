using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder_of_Graphs
{
    class Program
    {
        static int iterator_one = 1;
        static void Main(string[] args)
        {
            List<List<int>> Graph_1 = new List<List<int>>();
            
            Graph_1.Add(new List<int>());
            Graph_1.Add(new List<int>());
            Graph_1.Add(new List<int>());
            Graph_1.Add(new List<int>());
            Graph_1.Add(new List<int>());
            Graph_1[0].Add(1);
            Graph_1[0].Add(3);
            Graph_1[0].Add(4);
            Graph_1[1].Add(0);
            Graph_1[1].Add(2);
            Graph_1[2].Add(1);
            Graph_1[3].Add(0);
            Graph_1[4].Add(0);
            List<int>[] Spanning_Tree_1 = new List<int>[Graph_1.Count];
            Console.WriteLine("dfs tests");
            Console.Write("DFS od 1: ");
            DFS_Order(Graph_1, 1);
            Console.Write("DFS od 0: ");
            DFS_Order(Graph_1, 0);
            Console.Write("DFS od 2: ");
            DFS_Order(Graph_1, 2);
            //Console.WriteLine("recursive tests"); //since this line im testing building up DFS spanning trees
            bool[] visited = new bool[Graph_1.Count];
            //Clearing_Bool_Table(visited);
            //DFS_Order_R(Graph_1, 1,visited);
            //Clearing_Bool_Table(visited);
            //Console.WriteLine();
            //DFS_Order_R(Graph_1, 0,visited);
            //Clearing_Bool_Table(visited);
            //Console.WriteLine();
            //DFS_Order_R(Graph_1, 2,visited);
            //Clearing_Bool_Table(visited);
            //Console.WriteLine();
            Console.WriteLine("dfs spanning tree tests");
            Spanning_Tree_1 = DFS_Spanning_Tree_1(Graph_1, 0);
            Clearing_Bool_Table(visited);
           // Console.WriteLine("recursive tests");
            //testing for DFS_Tree_2, recursive version
            //List<int>[] Spanning_Tree_2 = new List<int>[Graph_1.Count];     
            //for (int i = 0; i < Spanning_Tree_2.Length; i++)
            //{
            //    Spanning_Tree_2[i] = new List<int>();
            //}
            //DFS_Spanning_Tree_R(Graph_1, 0, visited, Spanning_Tree_2);
            //Clearing_Bool_Table(visited);
            Console.WriteLine("dfs counting tests");
            
            int[] DFS_Numbers = new int[Graph_1.Count];
            int[] DFS_Numbers2 = new int[Graph_1.Count];
            DFS_Order_and_Counting(Graph_1,0,DFS_Numbers);
            List<int>[] Spanning_Tree_2 = new List<int>[Graph_1.Count];
            Spanning_Tree_2 = DFS_Spanning_Tree_and_Counting(Graph_1, 0, DFS_Numbers2);
            //DFS_Order_And_Counting_R(Graph_1, 0, visited, DFS_Numbers2);
            //Clearing_Bool_Table(visited);
            //iterator_one = 1;
            Console.ReadKey();
        }
        static void DFS_Order(List<List<int>>Adjacency_List, int First_Vertex) //vertices starting from 0 
        {
            bool[] visited = new bool[Adjacency_List.Count];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            Stack<int> s1 = new Stack<int>();

            s1.Push(First_Vertex);
            visited[First_Vertex] = true;

            while (s1.Count>0)
            {
                int current_Vertex = s1.Pop();
                visited[current_Vertex] = true;
                Console.Write(current_Vertex + " ");
                for (int i = Adjacency_List[current_Vertex].Count-1; i >= 0; i--)
                {
                    if (visited[Adjacency_List[current_Vertex][i]]!=true)
                    {
                        
                        s1.Push(Adjacency_List[current_Vertex][i]);
                    }
                }
            }
            Console.WriteLine();
        }

        static List<int>[] DFS_Spanning_Tree_and_Counting(List<List<int>> Adjacency_List, int First_Vertex, int[] Vertices_DFS_Numbers)
        {
           

            List<int>[] Tree = new List<int>[Adjacency_List.Count];
            for (int i = 0; i < Tree.Length; i++)
            {
                Tree[i] = new List<int>();
            }
            bool[] visited = new bool[Adjacency_List.Count];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            Stack<int> s1 = new Stack<int>();

            s1.Push(First_Vertex);
            visited[First_Vertex] = true;

            while (s1.Count > 0)
            {
                int current_Vertex = s1.Pop();
                
                
                visited[current_Vertex] = true;
                Console.Write(current_Vertex + " ");
                for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
                {
                    if (visited[Adjacency_List[current_Vertex][i]] != true)
                    {

                        s1.Push(Adjacency_List[current_Vertex][i]);
                        Tree[current_Vertex].Add(Adjacency_List[current_Vertex][i]); //adding edge connecting parent and child 
                        Tree[Adjacency_List[current_Vertex][i]].Add(current_Vertex); //adding edge connecting child and parent
                    }                                                                //both lines are necessary if we are considering undirected graph
                }
            }
            Console.WriteLine();
            DFS_Order_and_Counting(Adjacency_List, First_Vertex, Vertices_DFS_Numbers);
            return Tree;
        }
        static List<int>[] DFS_Spanning_Tree_1(List<List<int>> Adjacency_List, int First_Vertex) //returns array of lists building up DFS spanning tree, stack version
        {
            
            List<int>[] Tree = new List<int>[Adjacency_List.Count];
            for (int i = 0; i < Tree.Length; i++)
            {
                Tree[i] = new List<int>();
            }
            bool[] visited = new bool[Adjacency_List.Count];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            Stack<int> s1 = new Stack<int>();

            s1.Push(First_Vertex);
            visited[First_Vertex] = true;

            while (s1.Count > 0)
            {
                int current_Vertex = s1.Pop();
                visited[current_Vertex] = true;
                Console.Write(current_Vertex + " ");
                for (int i = 0; i < Adjacency_List[current_Vertex].Count ; i++)
                {
                    if (visited[Adjacency_List[current_Vertex][i]] != true)
                    {

                        s1.Push(Adjacency_List[current_Vertex][i]);
                        Tree[current_Vertex].Add(Adjacency_List[current_Vertex][i]); //adding edge connecting parent and child 
                        Tree[Adjacency_List[current_Vertex][i]].Add(current_Vertex); //adding edge connecting child and parent
                    }                                                                //both lines are necessary if we are considering undirected graph
                }
            }
            Console.WriteLine();

            return Tree;

        }

        static void DFS_Spanning_Tree_R(List<List<int>> Adjacency_List, int First_Vertex, bool[]visited,List<int>[] Spanning_Tree_2) //altering array of lists building up DFS spanning tree, recursive version
        {

            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            Console.Write(current_Vertex + " ");

            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]] != true) //unvisited neighboor
                {

                    Spanning_Tree_2[current_Vertex].Add(Adjacency_List[current_Vertex][i]); //adding edge connecting parent and child
                    Spanning_Tree_2[Adjacency_List[current_Vertex][i]].Add(current_Vertex);  //adding edge connecting parent and child
                    DFS_Spanning_Tree_R(Adjacency_List, Adjacency_List[current_Vertex][i], visited,Spanning_Tree_2); //both lines are necessary if we are considering undirected graph

                }
            }
        }

        static void DFS_Order_R(List<List<int>> Adjacency_List, int First_Vertex, bool[]visited)
        {
            

            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            Console.Write(current_Vertex+" ");

            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]]!=true) //unvisited neighboor
                {
                    DFS_Order_R(Adjacency_List, Adjacency_List[current_Vertex][i],visited);

                }
            }
            
        }

        static void DFS_Order_and_Counting(List<List<int>> Adjacency_List, int First_Vertex, int[]Vertices_DFS_Numbers) //vertices starting from 0
        {

             
            int i1 = 1;

                bool[] visited = new bool[Adjacency_List.Count];

                for (int i = 0; i < visited.Length; i++)
                {
                    visited[i] = false;
                }
                Stack<int> s1 = new Stack<int>();

                s1.Push(First_Vertex);
                visited[First_Vertex] = true;

                while (s1.Count > 0)
                {
                    int current_Vertex = s1.Pop();
                Vertices_DFS_Numbers[current_Vertex] = i1;
                i1++;
                    visited[current_Vertex] = true;
                    Console.Write(current_Vertex + " ");
                    for (int i = Adjacency_List[current_Vertex].Count - 1; i >= 0; i--)
                    {
                        if (visited[Adjacency_List[current_Vertex][i]] != true)
                        {

                            s1.Push(Adjacency_List[current_Vertex][i]);
                        }
                    }
                }
                Console.WriteLine();
            
        }

        static void DFS_Order_And_Counting_R(List<List<int>> Adjacency_List, int First_Vertex, bool[] visited, int[] Vertices_DFS_Numbers)
        {


            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            Vertices_DFS_Numbers[current_Vertex] = iterator_one;
            iterator_one++;
            Console.Write(current_Vertex + " ");

            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]] != true) //unvisited neighbor
                {

                    DFS_Order_And_Counting_R(Adjacency_List, Adjacency_List[current_Vertex][i], visited, Vertices_DFS_Numbers);

                }
            }
           

        }
        static void Clearing_Bool_Table(bool[] t1)
        {
            for (int i = 0; i < t1.Length; i++)
            {
                t1[i] = false;
            }
        }
    }
}
