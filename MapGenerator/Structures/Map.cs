using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator.Structures {
    [Serializable]
    public class Map {

        public List<Node> NodeList;
        public List<Edge> EdgeList;

        public Map(List<Node> nodes, List<Edge> edges) {
            this.NodeList = nodes;
            this.EdgeList = edges;
        }
    }
}
