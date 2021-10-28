using System;
using System.Collections.Generic;
using System.Text;

namespace Weighted_Directed_Graphs
{
    class Edge<T>
    {
        public Vertex<T> StartingPoint { get; set; }
        public Vertex<T> EndingPoint { get; set; }
        public float Distance { get; set; }

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, float distance) {}
    }
}
