using MapGenerator.Helpers;
using MapGenerator.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MapGenerator {
    public class Program {
        public static void Main(string[] args) {
            
        }

        public static Map BuildMap() {

            List<Node> allNodes = new List<Node>();

            //iterate through directory of regions
            //string regionalPath = Resources.PathToRegionalDirectory;
            List<string> regionalPaths = Directory.GetDirectories(Resources.PathToRegionalDirectory).ToList();
            foreach (var region in regionalPaths) {
                List<string> constellationPaths = Directory.GetDirectories(region).ToList();
                foreach (var constellation in constellationPaths) {
                    List<string> systemPaths = Directory.GetDirectories(constellation).ToList();
                    foreach (var system in systemPaths) {
                        Node node = SystemHelper.BuildSystem(new SolarSystemStaticDataParser(system));
                        allNodes.Add(node);
                    }
                }
            }
                //iterate through each constellation in each region
                    //iterate through each system folder to get at the system data file in each

        }
    }
}
