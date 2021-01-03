using MapGenerator.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MapGenerator.Helpers {
    public class SystemHelper {

        public static Node BuildUnconnectedSystem(SolarSystemStaticDataParser dataParser) {

            Node node = new Node();

            //node name
            node.SystemName = dataParser.SystemName;
            //node id1
            node.solarSystemID = dataParser.GetSolarSystemId();
            //node id2
            node.solarSystemNameID = dataParser.GetSolarSystemNameId();

            //node coordinates
            var coords = dataParser.parseOutCenterCoordinates();
            node.centerX = coords[0];
            node.centerY = coords[1];
            node.centerZ = coords[2];


            //stargate shit to figure out edges/connections
            node.stargates = dataParser.GetStargates();

            return node;
        }


        public static List<Edge> CreateListOfEdges(List<Node> allNodes) {

            List<Edge> edges = new List<Edge>();

            List<Stargate> allGates = new List<Stargate>();
            allNodes.ForEach(n => allGates.AddRange(n.stargates));

            foreach (var gate in allGates) {
                var edge = new Edge {
                    System1Name = gate.HomeSystemName,
                    System2Name = allGates.Where(g => g.StargateId == gate.DestinationGateId).FirstOrDefault().HomeSystemName
                };
                edges.Add(edge);
            }

            var distinctEdges = edges.Distinct().ToList();
            return distinctEdges;
        }

        public static void ConnectSystems(List<Node> nodes, List<Edge> edges) {
            foreach (var node in nodes) {
                node.ConnectedEdges.AddRange(edges.Where(e => e.HasSystem(node.SystemName)));
            }
        }

        //should be able to use this to find the heuristic for A* if I choose to go that route
        //consider only using x and y or x and z (eliminate vertical component to improve performance)
        public static double DistanceBetweenSystems(Node n1, Node n2) {
            double dx2 = Math.Pow(n2.centerX - n1.centerX, 2);
            double dy2 = Math.Pow(n2.centerY - n1.centerY, 2);
            double dz2 = Math.Pow(n2.centerZ - n1.centerZ, 2);

            double distance = Math.Sqrt(dx2 + dy2 + dz2);
            return distance;
        }
    }
}
