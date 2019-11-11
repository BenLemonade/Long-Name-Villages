using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Homework1_VillageNameLength {
    class Program {
        static void Main()
        {
            //Set Toal Villages Counter = 0
            int TotalVillageCounter = 0;

            //Set Long Name Counter = 0
            int LongNameVillageCounter = 0;

            //Read all lines of telepulesek.txt
            string[] lines = System.IO.File.ReadAllLines
            (@"C:\Visual Studio for C#\Projects\C-Homework-Projects\telepulesek.txt");
            
            //Clear the LongNameVillages.txt file of any text.
            File.WriteAllText(@"C:\Visual Studio for C#\Projects\C-Homework-Projects\LongNameVillages.txt", String.Empty);

            //Foreach line in telepulesek.txt:
            foreach (string line in lines)
            {
                //Add +1 to Total Village Counter
                TotalVillageCounter++;

                //Store current line as variable "name", and check character length (stored as name.Length)
                string name = line;
                int nameLength = name.Length;

                //If current line is longer than 8 characters:
                bool condition = true;
                if(name.Length > 8)
                {
                    //Add +1 to long names counter,
                    LongNameVillageCounter++;

                    //Write Current line to console, and
                    Console.WriteLine("\t" + line + "   " + name.Length);

                    //Write line to output file
                    File.AppendAllText(@"C:\Visual Studio for C#\Projects\C-Homework-Projects\LongNameVillages.txt", "\t" + line + "   " + name.Length + Environment.NewLine);
                }
            }
            //Write to the file the amount of Long Name Villages out of Total Villages
            File.AppendAllText(@"C:\Visual Studio for C#\Projects\C-Homework-Projects\LongNameVillages.txt", "The amount of villages with names longer than eight characters is " + LongNameVillageCounter + " villages out of " + TotalVillageCounter + " total villages.");

            //Write to the console the amount of Long Name Villages out of Total Villages
            Console.WriteLine("The amount of villages with names longer than eight characters is " + LongNameVillageCounter + " villages out of " + TotalVillageCounter + " total villages.");

            //Read in the lines from telepulesek.txt again.
            lines = System.IO.File.ReadAllLines(@"C:\Visual Studio for C#\Projects\C-Homework-Projects\telepulesek.txt");
            
            //Use the lines to create a dictionary, with the village name lengths as categories.
            Dictionary<int, List<string>> VillageDictionary = new Dictionary<int, List<string>>();
            
            //Foreach line from telepulesek:
            foreach (string line in lines)
            {
                //If "Village Dictionary" doesn't contain new length/category:
                If (!VillageDictionary.ContainsKey(line.Length));
                {
                    //Add to "Village Dictionary" the new length as a key/category.
                    VillageDictionary.Add(line.Length, new List<string>());
                }
                //Else add to the appropriate key/category count (++).
                VillageDictionary[line.Length].Add(line);
            }
            
            //Foreach key in "Village Dictionary's" keys:
            foreach (int key in VillageDictionary.Keys)
            {
                //Write to the console the key name + the number count of that key.
                Console.WriteLine(key + ": " + VillageDictionary[key].Count);
            }
            Console.ReadKey();
            
            //Keep console open with prompt to press any key to exit
            Console.WriteLine("Press any Key to Exit");
            System.Console.ReadKey(true);
        }
        
    }
}
