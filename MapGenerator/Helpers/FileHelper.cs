using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

using MapGenerator.Structures;

namespace MapGenerator.Helpers {
    public static class FileHelper {


        public static void SaveNodesToFile(List<Node> nodes) {
            SaveNodesToFile(nodes, Resources.NodeSaveFilePath);
        }

        public static void SaveNodesToFile(List<Node> nodes, string filePath) {
            SaveListToFile(nodes, filePath);
        }

        public static void SaveEdgesToFile(List<Edge> edges) {
            SaveEdgesToFile(edges, Resources.EdgeSaveFilePath);
        }

        public static void SaveEdgesToFile(List<Edge> edges, string filePath) {
            SaveListToFile(edges, filePath);
        }

        public static void SaveListToFile<T>(List<T> list, string filePath) {
            using (Stream stream = File.Open(filePath, FileMode.Create)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, list);
            }
        }
    }
}
