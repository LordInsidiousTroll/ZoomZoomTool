using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator.Structures {
    [Serializable]
    public class Edge {

        //using strings to store system names
        public string System1;
        public string System2;

        //using node references to store the nodes themselves
        public Node NodeSystem1;
        public Node NodeSystem2;

        public Edge(Node n1, Node n2) {
            NodeSystem1 = n1;
            NodeSystem2 = n2;
        }
    }
}
