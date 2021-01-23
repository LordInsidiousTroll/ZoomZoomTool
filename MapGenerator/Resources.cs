using System;
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
        public static double MAX_JUMP_DISTANCE = double.MinValue;
    }
}
