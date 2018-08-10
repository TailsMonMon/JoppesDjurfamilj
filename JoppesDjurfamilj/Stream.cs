﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    internal class Stream {
        // Filenames
        internal static readonly string statusFile = "status.txt"; // to remember status of pets and balls
        internal static readonly string logFile = "log.txt"; // a log of what happens in the program
        // References
        Petowner petowner = new Petowner();

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

        internal static List<string> ReadFromFile(string _fileName) {
            List<string> linesFromFile = new List<string>();
            try {
                using(StreamReader streamReader = new StreamReader(_fileName)) {
                    string singleLine = streamReader.ReadLine();
                    while(singleLine != null) {
                        if(_fileName == statusFile) {
                            UpdateStatusFile(singleLine);
                        }
                        else {
                            linesFromFile.Add(singleLine);
                            singleLine = streamReader.ReadLine(); 
                        }
                    }
                    streamReader.Close();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return linesFromFile;
        }

        private static void UpdateStatusFile(string line) {
            //Debug.Assert(line.Contains("Pet") == false, "the line does contain pet");
            if(line.Contains("Pet")) { // Something is wrong here
                int index = 0;
                for(int i = 6; i < 9; i++) { // Can find up to 3 digit integers
                    if(char.IsDigit(line[i])) {
                        index += i;
                    }
                }
                List<string> petData = line.Split(',').ToList();
                foreach(string foo in petData) {
                    WriteToFile("newFile.txt", foo);
                }
            }
        }

        internal void GetPet(int index, List<string> petData) {
            List<Animal> pets = petowner.GetPets;
            pets[index].Name = petData[0];
            pets[index].Age = Convert.ToInt32(petData[1]);
            pets[index].Breed = petData[2];
            pets[index].Hungry = Convert.ToBoolean(petData[3]);
            pets[index].FavFood = petData[4];
        }

    }
}
