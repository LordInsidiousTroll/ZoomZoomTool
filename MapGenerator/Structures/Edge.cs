using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator.Structures {
    [Serializable]
    public class Edge {

        //using strings to store system names
        public string System1Name;
        public string System2Name;

        //using node references to store the nodes themselves
        public Node NodeSystem1;
        public Node NodeSystem2;

        public Edge() { }

        public Edge(Node n1, Node n2) {
            NodeSystem1 = n1;
            NodeSystem2 = n2;
        }

        public override bool Equals(object obj) {
            return obj is Edge edge &&
                   ((System1Name == edge.System1Name && System2Name == edge.System2Name) 
                   || (System1Name == edge.System2Name && System2Name == edge.System1Name));
        }

        public override int GetHashCode() {
            return HashCode.Combine(System1Name, System2Name);
        }
    }
}
