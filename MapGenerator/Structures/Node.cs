using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator.Structures {
    [Serializable]
    public class Node {

        public string SystemName;
        public string SystemId;

        //system position coordinates
        public double centerX;
        public double centerY;
        public double centerZ;
    }
}
