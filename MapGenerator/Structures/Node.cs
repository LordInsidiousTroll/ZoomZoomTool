using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator.Structures {
    [Serializable]
    public class Node : IEquatable<Node> {

        public string SystemName;
        public string solarSystemID;
        public string solarSystemNameID;

        //system position coordinates
        public double centerX;
        public double centerY;
        public double centerZ;

        public List<Stargate> stargates;
        public List<Edge> ConnectedEdges;

        public SecurityStatus SecurityStatus;


        #region A* stuff

        public int G;
        public int H;
        public int F { get { return G + H; } }

        #endregion


        #region Equality and Comparison stuff
        public override bool Equals(object obj) {
            return Equals(obj as Node);
        }

        public bool Equals(Node other) {
            return other != null &&
                   SystemId == other.SystemId;
        }

        public override int GetHashCode() {
            return HashCode.Combine(SystemId);
        }
        #endregion

    }

    public enum SecurityStatus {
        High,
        Low,
        Null,
        Wormhole
    }
}
