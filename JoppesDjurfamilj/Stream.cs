﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    internal class Stream {
        // Filenames
        internal static string statusFile = "status.txt"; // to remember status of pets and balls
        internal static string logFile = "log.txt"; // a log of what happens in the program

        internal static void WriteToFile(string fileName, string text) {
            try {
                using(var streamWriter = new StreamWriter(fileName, true)) {
                    streamWriter.WriteLine($"[{DateTime.Now}]: {text}");
                    streamWriter.Close();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        internal static List<string> ReadFromFile(string fileName) {
            List<string> lines = new List<string>();
            try {
                using(StreamReader streamReader = new StreamReader(fileName)) {
                    string line = streamReader.ReadLine();
                    while(line != null) {
                        lines.Add(line);
                        line = streamReader.ReadLine();
                    }
                    if(fileName == statusFile) {
                        UpdateStatusFile(line);
                    }
                    streamReader.Close();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return lines;
        }

        private static void UpdateStatusFile(string line) {
            if(line.Contains("[Pet]")) {
                int index = 0;
                for(int i = 6; i < 9; i++) { // Can find up to 3 digit integers
                    if(char.IsDigit(line[i])) {
                        index += i;
                    }
                }
                // TODO: update pet based on it's index.
                
            }
        }


    }
}