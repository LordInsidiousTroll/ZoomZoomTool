using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator.Structures {
    [Serializable]
    public class Map {

        public List<Node> NodeList = new List<Node>();
        public List<Edge> EdgeList = new List<Edge>();


    }
}
