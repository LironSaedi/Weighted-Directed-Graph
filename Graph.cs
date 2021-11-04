using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Weighted_Directed_Graphs
{
    class Graph<T>
    {
        private List<Vertex<T>> vertices;

        public IReadOnlyList<Vertex<T>> Vertices => vertices;
        //    public IReadOnlyList<Edges<T>> Edges { get { } }

        public int VertexCount => vertices.Count;

        public Graph() { }

        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex == null)
            {
                throw new Exception("does not exist");
            }

            if (vertex.Neighbors.Count != 0)
            {
                throw new Exception("has neighbors");
            }
            this.vertices.Add(vertex);


            if (Search(vertex.Value) != null)//Search
            {
                throw new Exception(" ");
            }


        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (!vertices.Contains(vertex))
            {
                return false;
            }

            foreach (var obj in vertices)
            {
                for (int i = 0; i < obj.Neighbors.Count; i++)
                {
                    if (obj.Neighbors[i].EndingPoint == vertex)
                    {
                        //Remove Edge
                    }
                }
            }

            return vertices.Remove(vertex);

        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            if (!vertices.Contains(a) && !vertices.Contains(b))
            {
                return false;
            }

            a.Neighbors.Add(new Edge<T>(a, b, distance));
            return true;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!vertices.Contains(a) && !vertices.Contains(b))
            {
                return false;
            }

            for (int i = 0; i < a.Neighbors.Count; i++)
            {

                if (a.Neighbors[i].EndingPoint == b)
                {
                    a.Neighbors.RemoveAt(i);
                    return true;
                }

            }
            return false;

            throw new Exception(" did not run");
        }

        Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!vertices.Contains(a) && !vertices.Contains(b))
            {
                return null;
            }

            for (int i = 0; i < a.Neighbors.Count; i++)
            {

                if (a.Neighbors[i].EndingPoint == b)
                {
                    return a.Neighbors[i];
                }

            }
            return null;
        }
        string humanToString(int number) => number switch
        {
            1 => "one",
            2 => "two",
            3 => "three",
            _ => "unknown"
        };

        public Vertex<T> Search(T value)
        {
            return vertices.Where(vertex => vertex.Value.Equals(value)).FirstOrDefault();
            /*
            int myNumber = 4;
            string s = myNumber.ToHumanString();
            string str = humanToString(myNumber);

            //linq lets you deal with "C# data": collections of stuff
            //collections are lists, dictionaries, sets, (your custom) trees, etc.

            List<int> myList = new List<int>();
            Dictionary<string, int> myDict = new Dictionary<string, int>();


            //linq is a bunch of extension methods
            //lets you process collections "naturally"

            //imperative way: change the data
            List<string> humanList = new List<string>();
            foreach (int n in myList)
            {
                humanList.Add(n.ToHumanString());
            }

            List<int> counts = new List<int>();
            foreach (string humanNumber in humanList)
            {
                counts.Add(humanNumber.Length);
            }

            //declarative way: describe how the data is transformed
            //I want to describe a transformation from ints in myList to strings in some result
            var humanEnumerable = myList.Select(transformNumber).Where(selectStrings).First();

            //SQL queries:
            //Users Table:
            //entry 1: UserID = 000001, Username = "First", Password = "imfirst"
            //entry 2: UserID = 000002, Username = "Me too", Password = "paswor"
            //SELECT UserID FROM Users WHERE Username = "Bob"
            //result: list of IDs. Could have nothing, or one value, or many values
            return value;
            */
        }

        private string transformNumber(int n)
        {
            return n.ToHumanString();
        }

        private bool selectStrings(string s)
        {
            return s.Length < 15;
        }
    }

    public static class Extensions
    {
        public static string ToHumanString(this int n)
        {
            return n.ToString() + " is human";
        }

        public static void Blah<T>(this IEnumerable<T> data, int maxLength)
        {

        }
    }
}

/*
 public static Point ToPoint(this Vector2 v)

//I have a Vector2, I want a Point (to make a Rectangle, whatever>.)
//new Point((int)myVector.X, (int)myVector.Y)
//INSTEAD: myVector.ToPoint()
 */


/*
 class MyOwnClassThatBarelyWrapsFunctionality()
{
    LinkedList list;
    public void Push(T value) {
list.AddFirst(value);
}
//pop.. peek
}

INSTEAD: public static void Push(this LinkedList stack, T value) {
}
 */