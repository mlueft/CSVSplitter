using System;
using System.Collections.Generic;
using System.Text;

namespace CSVSplitter
{
    class Logger
    {

        public static string logFile;

        private static List<string> buffer = new List<string>();

        public static void  Log(string line)
        {
            buffer.Add(line);
        }

        public static void ClearBuffer()
        {
            buffer.Clear();
        }

        public static void WriteToFile()
        {
            System.IO.File.WriteAllLines( logFile, buffer.ToArray() );
            ClearBuffer();
        }

    }
}
