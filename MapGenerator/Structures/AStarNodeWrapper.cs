using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator.Structures {
    public class AStarNodeWrapper {

        public Node node;

        public int G;
        public int H;
        public int F { get { return G + H; } }
        public AStarNodeWrapper parent;

        public AStarNodeWrapper(Node node) {
            this.node = node;
        }
    }
}
