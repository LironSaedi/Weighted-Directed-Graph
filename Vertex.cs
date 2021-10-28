using System;
using System.Collections.Generic;
using System.Text;

namespace Weighted_Directed_Graphs
{
    class Vertex <T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

        public int NeighborCount => Neighbors.Count;

        public Vertex(T value) 
        {
        
        }
    }
}
