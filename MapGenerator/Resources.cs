﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MapGenerator {
    public static class Resources {


        //directory paths
        public static string _pathToEveStuff = @"C:\Users\Lord\Downloads";
        public static string _pathToRegionalDirectory = @"sde\sde\fsd\universe\eve";

        public static string PathToRegionalDirectory { get { return Path.Combine(_pathToEveStuff, _pathToRegionalDirectory); } }

        //jump values and such
        public static double AUS_IN_LIGHTYEAR = 63241.077;
        public static double MAX_JUMP_DISTANCE_LY = 8;
        public static double MAX_JUMP_DISTANCE_AUS { get { return MAX_JUMP_DISTANCE_LY * AUS_IN_LIGHTYEAR; } }

        //save files
        public static string baseSaveFilePath = @"%LOCALAPPDATA\ZoomZoomTool\%";
        public static string savedSystemDataPath = @"SavedSystemData";
        public static string NodeSaveFilePath { get { return Path.Combine(baseSaveFilePath, savedSystemDataPath, "nodes.dat"); } }
        public static string EdgeSaveFilePath { get { return Path.Combine(baseSaveFilePath, savedSystemDataPath, "edges.dat"); } }

        //base level data i.e. stuff that will be the same every fucking time
        public static string StargateNodes { get { return Path.Combine(baseSaveFilePath, savedSystemDataPath, "staticStargateNodes.dat"); } }
        public static string StargateEdges { get { return Path.Combine(baseSaveFilePath, savedSystemDataPath, "staticStargateEdges.dat"); } }

    }
}
