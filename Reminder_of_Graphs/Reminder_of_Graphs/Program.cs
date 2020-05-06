using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Reminder_of_Graphs
{
    public class Tarjan_Graph {
        public List<List<int>> graph;
        public int[] dfs_numbers;
        public int?[] parents_array;
        public List<int>[] spanning_tree_2;
        public int[]low_array; //array for low parameter for every vertex
        public bool[] visited;
        public List<int[]> Bridges { get; private set; }

        public Tarjan_Graph(List<List<int>> graph)
        {
            this.graph = graph;
            Bridges = new List<int[]>();
            visited = new bool[graph.Count];
            low_array = new int[graph.Count];
            spanning_tree_2 = new List<int>[graph.Count];
            dfs_numbers = new int[graph.Count];  
            set_Spanning_Tree();
            set_DFS_Array();
            set_Parents_Array();
        }
        public void set_Spanning_Tree() //dfs spanning tree
        {
            for (int i = 0; i < spanning_tree_2.Length; i++)
            {
                spanning_tree_2[i] = new List<int>();
            }
            Program.DFS_Spanning_Tree_R(graph, 0, visited, spanning_tree_2);
           Clearing_Bool_Table(visited);
        }
        public void set_DFS_Array() //array for dfs numbers of vertices
        {
            Program.DFS_Array_R(graph, 0, visited, dfs_numbers);
          Clearing_Bool_Table(visited);
        }
        public void set_Parents_Array() //array of parents for every vertex
        {
         parents_array =   Program.DFS_Parents_Array(spanning_tree_2);
           Clearing_Bool_Table(visited);
        }
        public void Clearing_Bool_Table(bool[] t1)
        {
            for (int i = 0; i < t1.Length; i++)
            {
                t1[i] = false;
            }
        }
        public void Tarjan_Bridges(List<List<int>> Adjacency_List, int First_Vertex, bool[] visited)
        {




            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
         //   Console.Write(current_Vertex + " ");

            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]] != true) //unvisited neighboor
                {
                    Tarjan_Bridges(Adjacency_List, Adjacency_List[current_Vertex][i], visited);

                }
            } //end of branch
            //low_array[current_Vertex] = dfs_numbers[current_Vertex]; //first initialization of low parameter
            int low_tmp = dfs_numbers[current_Vertex]; //first initialization of low parameter
            //checking for sons' low parameters
            for (int i = 0; i < spanning_tree_2[current_Vertex].Count; i++)
            {
                if (low_array[ spanning_tree_2[current_Vertex][i] ]!=0 && low_array[spanning_tree_2[current_Vertex][i]]<low_tmp)
                {
                    low_tmp = low_array[spanning_tree_2[current_Vertex][i]];
                }
            }
            //checking for other 'current vertex' neighbors

            for (int i = 0; i < graph[current_Vertex].Count; i++)
            {
                bool returning_edge = true;
                if (graph[current_Vertex][i] == parents_array[current_Vertex]) //father
                {
                    returning_edge = false;
                }
                if (graph[current_Vertex][i] != parents_array[current_Vertex]) //not father
                {

                    for (int j  = 0; j < spanning_tree_2[current_Vertex].Count; j++) //but son
                    {
                        if (graph[current_Vertex][i] == spanning_tree_2[current_Vertex][j])
                        {
                            returning_edge = false;
                        }
                    }
                   // returning_edge = true;

                }//not father nor son
                if (returning_edge==true)
                {
                    if (dfs_numbers[graph[current_Vertex][i]] < low_tmp)
                    {
                        low_tmp = dfs_numbers[graph[current_Vertex][i]];
                    }
                }

            }
            low_array[current_Vertex] = low_tmp;
            if (low_array[current_Vertex]==dfs_numbers[current_Vertex] && parents_array[current_Vertex]!=null)
            {
                Console.WriteLine("Most: "+current_Vertex + " "+parents_array[current_Vertex]);
                Bridges.Add(new int[] {current_Vertex,(int)parents_array[current_Vertex] });
            }
            

        }

    }

    public class Program
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
            List<List<int>> Graph_2_waw = new List<List<int>>();
            Graph_2_waw.Add(new List<int>());
            Graph_2_waw.Add(new List<int>());
            Graph_2_waw.Add(new List<int>());
            Graph_2_waw.Add(new List<int>());
            Graph_2_waw.Add(new List<int>());
            Graph_2_waw.Add(new List<int>());
            Graph_2_waw[0].Add(1);
            Graph_2_waw[0].Add(2);
            Graph_2_waw[1].Add(0);
            Graph_2_waw[1].Add(2);
            Graph_2_waw[1].Add(4);
            Graph_2_waw[2].Add(0);
            Graph_2_waw[2].Add(1);
            Graph_2_waw[3].Add(4);
            Graph_2_waw[3].Add(5);
            Graph_2_waw[4].Add(1);
            Graph_2_waw[4].Add(3);
            Graph_2_waw[4].Add(5);
            Graph_2_waw[5].Add(3);
            Graph_2_waw[5].Add(4);
              bool[] visited2 = new bool[Graph_2_waw.Count];
            Tarjan_Graph T1 = new Tarjan_Graph(Graph_2_waw);
            T1.Tarjan_Bridges(Graph_2_waw, 0, T1.visited);
            
            Console.WriteLine();
            iterator_one = 1;

           // T1.set_DFS_Array();
            //T1.set_Parents_Array
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
            Console.WriteLine();
           
           // DFS_Order_R(Graph_2_waw, 0,visited2);
         //   Clearing_Bool_Table(visited2);
            //DFS_Order(Graph_1, 0);

          //   Tarjan_Bridges(Graph_2_waw,0,visited2);





            Console.WriteLine();
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
            
            //DFS_Spanning_Tree_R(Graph_1, 0, visited, Spanning_Tree_2);
            //Clearing_Bool_Table(visited);
            Console.WriteLine("dfs counting tests");
            
            int[] DFS_Numbers = new int[Graph_1.Count];
            int[] DFS_Numbers2 = new int[Graph_1.Count];
          //  DFS_Order_and_Counting(Graph_1,0,DFS_Numbers);
            List<int>[] Spanning_Tree_2 = new List<int>[Graph_1.Count];
            for (int i = 0; i < Spanning_Tree_2.Length; i++)
            {
                Spanning_Tree_2[i] = new List<int>();
            }
            // Spanning_Tree_2 = DFS_Spanning_Tree_and_Counting(Graph_1, 0, DFS_Numbers2); dziala!
            //Spanning_Tree_2 = DFS_Spanning_Tree_and_Counting_v2(Graph_1, 0, DFS_Numbers2);
            //Spanning_Tree_2 = DFS_Spanning_Tree_2(Graph_1, 0);
            //DFS_Spanning_Tree_and_Counting_R(Graph_1, 0, visited, Spanning_Tree_2, DFS_Numbers2);
            Console.WriteLine();
            //DFS_Order_And_Counting_R(Graph_1, 0, visited, DFS_Numbers2);
            Clearing_Bool_Table(visited);
            //iterator_one = 1;
            // int[] DFS_Numbers3 = new int[Graph_1.Count];
            // DFS_Numbers3 = DFS_Array(Graph_1, 0);
            // Console.WriteLine(iterator_one);
            // int?[] tablica = new int?[5];
            int?[] Parents_array = new int?[Graph_1.Count];
            //Parents_array = DFS_Parents_Array(Spanning_Tree_2);
            
            Console.ReadKey();
        }
        //DZIAŁA SŁABO!!!!
        public static void DFS_Order(List<List<int>>Adjacency_List, int First_Vertex) //vertices starting from 0 
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

        public static List<int>[] DFS_Spanning_Tree_and_Counting(List<List<int>> Adjacency_List, int First_Vertex, int[] Vertices_DFS_Numbers)
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
        public static List<int>[] DFS_Spanning_Tree_and_Counting_v2(List<List<int>> Adjacency_List, int First_Vertex, int[] Vertices_DFS_Numbers) //version where spanning tree doesnt have child-parent edges, only edges from parent to child
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
                        
                    }                                                                
                }
            }
            Console.WriteLine();
            DFS_Order_and_Counting(Adjacency_List, First_Vertex, Vertices_DFS_Numbers);
            return Tree;
        }
        public static List<int>[] DFS_Spanning_Tree_1(List<List<int>> Adjacency_List, int First_Vertex) //returns array of lists building up DFS spanning tree, stack version
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
        public static List<int>[] DFS_Spanning_Tree_2(List<List<int>> Adjacency_List, int First_Vertex) //returns array of lists building up DFS spanning tree, stack version
        {//version where spanning tree doesnt have child-parent edges, only edges from parent to child

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
                        
                    }                                                                
                }
            }
            Console.WriteLine();

            return Tree;

        }
        public static void DFS_Spanning_Tree_and_Counting_R(List<List<int>> Adjacency_List, int First_Vertex, bool[] visited, List<int>[] Spanning_Tree_2, int[] Vertices_DFS_Numbers) //altering array of lists building up DFS spanning tree, recursive version
        {
            //version where spanning tree doesnt have child-parent edges, only edges from parent to child
            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            Vertices_DFS_Numbers[current_Vertex] = iterator_one;
            iterator_one++;
            Console.Write(current_Vertex + " ");

            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]] != true) //unvisited neighboor
                {

                    Spanning_Tree_2[current_Vertex].Add(Adjacency_List[current_Vertex][i]); //adding edge connecting parent and child
                    
                    DFS_Spanning_Tree_and_Counting_R(Adjacency_List, Adjacency_List[current_Vertex][i], visited, Spanning_Tree_2,Vertices_DFS_Numbers); 

                }
            }
        }


        public static void DFS_Spanning_Tree_R(List<List<int>> Adjacency_List, int First_Vertex, bool[]visited,List<int>[] Spanning_Tree_2) //altering array of lists building up DFS spanning tree, recursive version
        {
            //version where spanning tree doesnt have child-parent edges, only edges from parent to child
            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            //Console.Write(current_Vertex + " ");

            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]] != true) //unvisited neighboor
                {

                    Spanning_Tree_2[current_Vertex].Add(Adjacency_List[current_Vertex][i]); //adding edge connecting parent and child
                    DFS_Spanning_Tree_R(Adjacency_List, Adjacency_List[current_Vertex][i], visited,Spanning_Tree_2); 

                }
            }
        }

        public static void DFS_Order_R(List<List<int>> Adjacency_List, int First_Vertex, bool[]visited)
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
            //Console.WriteLine("koniec galezi");
        }

        public static void DFS_Order_and_Counting(List<List<int>> Adjacency_List, int First_Vertex, int[]Vertices_DFS_Numbers) //vertices starting from 0
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

        public static void DFS_Order_And_Counting_R(List<List<int>> Adjacency_List, int First_Vertex, bool[] visited, int[] Vertices_DFS_Numbers)
        {


            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            Vertices_DFS_Numbers[current_Vertex] = iterator_one;
            iterator_one++;
            

            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]] != true) //unvisited neighbor
                {

                    DFS_Order_And_Counting_R(Adjacency_List, Adjacency_List[current_Vertex][i], visited, Vertices_DFS_Numbers);

                }
            }
           

        }
        public static void Clearing_Bool_Table(bool[] t1)
        {
            for (int i = 0; i < t1.Length; i++)
            {
                t1[i] = false;
            }
        }

        public static void DFS_Array_R(List<List<int>> Adjacency_List, int First_Vertex, bool[] visited, int[] Vertices_DFS_Numbers)//array for vertices dfs numbers
        {
            int current_Vertex = First_Vertex;
            visited[current_Vertex] = true;
            Vertices_DFS_Numbers[current_Vertex] = iterator_one;
            iterator_one++;


            for (int i = 0; i < Adjacency_List[current_Vertex].Count; i++)
            {
                if (visited[Adjacency_List[current_Vertex][i]] != true) //unvisited neighbor
                {

                    DFS_Array_R(Adjacency_List, Adjacency_List[current_Vertex][i], visited, Vertices_DFS_Numbers);

                }
            }
        }
    public    static int?[] DFS_Parents_Array(List<int>[] DFS_Spanning_Tree) //array for vertices' parents
        {
            int?[] Parents_Array = new int?[DFS_Spanning_Tree.Length];
            for (int i = 0; i < DFS_Spanning_Tree.Length; i++) //parents
            {
                for (int j = 0; j < DFS_Spanning_Tree[i].Count; j++) //kids
                {
                    Parents_Array[DFS_Spanning_Tree[i][j]] = i;
                }
            }
            return Parents_Array;
        }
      public  static void Tarjan_Bridges(List<List<int>> Adjacency_List, int First_Vertex, bool[] visited)
        {
            List<int>[] spanning_tree_2 = new List<int>[Adjacency_List.Count];
            int[] dfs_numbers = new int[Adjacency_List.Count];
            for (int i = 0; i < spanning_tree_2.Length; i++)
            {
                spanning_tree_2[i] = new List<int>();
            }

            int[] low_array = new int[Adjacency_List.Count]; //array for low parameter for every vertex
            DFS_Spanning_Tree_R(Adjacency_List,First_Vertex,visited,spanning_tree_2); //dfs spanning tree
            int?[] parents_array = DFS_Parents_Array(spanning_tree_2); //array of parents for every vertex
            Clearing_Bool_Table(visited);
            DFS_Array_R(Adjacency_List, First_Vertex, visited, dfs_numbers); //array for dfs numbers of vertices
            
            Console.WriteLine();
        }
    }
}
