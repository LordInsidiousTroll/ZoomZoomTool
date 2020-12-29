using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace MapGenerator.Helpers {
    public class SolarSystemStaticDataParser {

        public string dataFilePath;

        public SolarSystemStaticDataParser(string filePath) {
            if (!File.Exists(filePath)) {
                throw new FileNotFoundException($"[SolarSystemStaticDataParser] Did not find file: {filePath}");
            }
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

        public List<string> GetStargateDestinations() {
            List<string> lines = File.ReadAllLines(this.dataFilePath).ToList();

            List<string> stargateSection = new List<string>();

            int lineCount = 0;
            while (!lines.ElementAt(lineCount).Contains("stargates")) {
                lineCount++;
            }
            while (lines.ElementAt(lineCount).StartsWith('\t')) {
                stargateSection.Add(lines.ElementAt(lineCount));
            }

            return parseStargateSection(stargateSection);
        }

        private List<string> parseStargateSection(List<string> section) {
            List<string> destinations = new List<string>();

            foreach (var line in section) {
                if (line.Contains("destination")) {
                    destinations.Add(line.Trim().Split(' ')[1]);
                }
            }

            return destinations;
        }
    }
}
