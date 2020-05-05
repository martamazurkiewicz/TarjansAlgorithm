using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public partial class Graph
    {
        //Tarjan's algorithm output - list of bridges
        //integer arrays in list always have 2 elements - 2 vertices of an edge
        public List<int[]> Bridges { get; private set; }
    }
}
