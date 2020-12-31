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

    }
}
