using MapGenerator.Helpers;
using MapGenerator.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MapGenerator.Handlers {
    public  class MapHandler {

        public Map map;

        public Node start;
        public Node destination;

        List<AStarNodeWrapper> openList;
        List<AStarNodeWrapper> closedList;

        public MapHandler(Map map) {
            this.map = map;
        }

        public MapHandler() {
            this.map = BuildMap();
        }

        public static Map BuildMap() {

            List<Node> allNodes = new List<Node>();

            //iterate through directory of regions
            //string regionalPath = Resources.PathToRegionalDirectory;
            List<string> regionalPaths = Directory.GetDirectories(Resources.PathToRegionalDirectory).ToList();
            foreach (var region in regionalPaths) {
                //iterate through each constellation in each region
                List<string> constellationPaths = Directory.GetDirectories(region).ToList();
                foreach (var constellation in constellationPaths) {
                    //iterate through each system folder to get at the system data file in each
                    List<string> systemPaths = Directory.GetDirectories(constellation).ToList();
                    foreach (var system in systemPaths) {
                        Node node = SystemHelper.BuildUnconnectedSystem(new SolarSystemStaticDataParser(system));
                        allNodes.Add(node);
                    }
                }
            }

            List<Edge> allEdges = SystemHelper.CreateListOfEdges(allNodes);

            Map map = new Map(allNodes, allEdges);
            return map;
        }


        #region Map traversal
        public List<Node> FindRoute(Node start, Node destination) {
            this.start = start;
            this.destination = destination;

            this.openList = new List<AStarNodeWrapper>();
            this.closedList = new List<AStarNodeWrapper>();


            //initialize all nodes in map with distance to end (
            List<AStarNodeWrapper> allNodesWrapped = new List<AStarNodeWrapper>();
            foreach (var node in map.NodeList) {

            }










            AStarNodeWrapper current;
            int g = 0;


            //logic begins
            openList.Add(new AStarNodeWrapper(start));
            while(openList.Count > 0) {
                //algorithm's logic goes here
                var lowest = openList.Min(n => n.F);

            }
        }

        

        //distance from this node to destination
        public double ComputeHScore(Node node) {
            return SystemHelper.DistanceBetweenSystems(node, this.destination);
        }

        //distance from start to this node
        public double ComputeGScore(Node node) {
            return SystemHelper.DistanceBetweenSystems(node, this.start);
        }


        #endregion
    }
}
