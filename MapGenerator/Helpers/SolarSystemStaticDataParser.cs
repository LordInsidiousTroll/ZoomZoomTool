using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace MapGenerator.Helpers {
    public class SolarSystemStaticDataParser {

        public string dataFilePath;

        public SolarSystemStaticDataParser(string filePath) {
            this.dataFilePath = filePath;
        }


        public List<double> parseOutCenterCoordinates() {
            List<string> lines = File.ReadAllLines(this.dataFilePath).ToList();

            List<double> coordLines = new List<double>();

            for (int i = 0; i < lines.Count; i++) {
                if (lines[i].Contains("center")) {
                    coordLines.Add(double.Parse(lines[i + 1].Substring(2)));
                    coordLines.Add(double.Parse(lines[i + 2].Substring(2)));
                    coordLines.Add(double.Parse(lines[i + 3].Substring(2)));
                    return coordLines;
                }
            }

            throw new Exception("Did not find the 'center' line within data file");
        }

    }
}
