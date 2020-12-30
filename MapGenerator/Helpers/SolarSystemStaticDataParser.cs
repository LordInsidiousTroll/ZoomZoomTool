using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using MapGenerator.Structures;
using System.Text.RegularExpressions;

namespace MapGenerator.Helpers {
    public class SolarSystemStaticDataParser {

        public string dataFilePath;
        public string SystemName;

        public SolarSystemStaticDataParser(string filePath) {
            if (!File.Exists(filePath)) {
                throw new FileNotFoundException($"[SolarSystemStaticDataParser] Did not find file: {filePath}");
            }
            this.dataFilePath = filePath;
            SystemName = Directory.GetParent(dataFilePath).Name;
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

        public List<Stargate> GetStargates() {
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

        private List<Stargate> parseStargateSection(List<string> section) {
            List<Stargate> gates = new List<Stargate>();

            //regex section
            Regex sg_rx = new Regex(@"\t(\d+):");
            Regex sg_dest_rx = new Regex(@"\t\tdestination: (\d+)");

            MatchCollection matches;
            for (int i = 0; i < section.Count; i++) {
                matches = sg_rx.Matches(section[i]);
                if(matches.Count > 0) {
                    var sg = new Stargate {
                        HomeSystemName = this.SystemName,
                        StargateId = matches.FirstOrDefault().Groups[0].Value,
                        DestinationGateId = sg_dest_rx.Matches(section[i + 1]).FirstOrDefault().Groups[0].Value
                    };
                    gates.Add(sg);
                }
            }

            return gates;
        }

        public string GetSolarSystemId() {
            List<string> lines = File.ReadAllLines(this.dataFilePath).ToList();

            foreach (var line in lines) {
                if (line.Contains("solarSystemID")) {
                    var id = line.Trim().Split(' ')[1].Trim();
                    return id;
                }
            }
            throw new Exception("[SolarSystemStataticDataParser] [GetSolarSystemId] Could not find solar system id.");
        }

        public string GetSolarSystemNameId() {
            List<string> lines = File.ReadAllLines(this.dataFilePath).ToList();

            foreach (var line in lines) {
                if (line.Contains("solarSystemNameID")) {
                    var id = line.Trim().Split(' ')[1].Trim();
                    return id;
                }
            }
            throw new Exception("[SolarSystemStataticDataParser] [GetSolarSystemNameId] Could not find solar system id.");
        }
    }
}
