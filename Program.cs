using System;
using System.Collections.Generic;
using System.IO;

namespace Finals
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Part 1 section for kidDna test.
            //Ask the user what folder they would like to use to compare the kidsDna to the Suspected fathers.
            Console.WriteLine("Please enter the file path to the folder you want to use: ");
            
            string path = Console.ReadLine();
            
            DirectoryInfo di = new DirectoryInfo(path);
            
            Dictionary<string, int[]> Children = new Dictionary<string, int[]>();
            
            int[] children2 = new int[0];


            //Loops through the fileinfo of the given directory and prints there fullnames, Cuts them based on the given data and splits them accordingly.
            //Creates new comparison obj equal to the length of splitlines.
            // if the name does not equal KidsDna, add to children List and remove any extension parts.
            foreach (FileInfo fi in di.GetFiles())
            {
                string finished_path = File.ReadAllText(fi.FullName);
                
                finished_path = finished_path.Replace("GAATTC", "G/AATTC");
                
                finished_path = finished_path.Replace("GGATCC", "G/GATCC");
                
                finished_path = finished_path.Replace("AAGCTT", "A/AGCTT");
                
                string[] splitlines = finished_path.Split("/");
                
                int[] comparison = new int[splitlines.Length];

                for (int i = 0; i < splitlines.Length; i++)
                {
                    comparison[i] = splitlines[i].Length;
                    Console.WriteLine(comparison[i]);
                    
                }

                if (fi.Name != "kidDNA.txt")
                {
                    Children.Add(fi.Name.Substring(0, fi.Name.Length - 4), comparison);
                    Console.WriteLine("Boop!");
                }
                
                else
                {
                    children2 = comparison;
                }
                
                Console.WriteLine();
            }

            
            Dictionary<string, int> highestCounter = new Dictionary<string, int>();
            
            int highestCounter2 = 0;
            
            foreach (KeyValuePair<string, int[]> FoundChild in Children) 
            {
                int maxcounter = 0;
                
                for (int i = 0; i < FoundChild.Value.Length; i++) 
                {
                    for (int j = 0; j < children2.Length; j++) 
                    {
                        
                        if (children2[j] == FoundChild.Value[i]) 
                        {
                            maxcounter++;

                            Console.WriteLine("A comparision has been made.");
                        }
                    }

                }
                if (maxcounter > highestCounter2) 
                {
                    highestCounter2 = maxcounter;
                    
                    highestCounter = new Dictionary<string, int>();
                    
                    highestCounter.Add(FoundChild.Key, maxcounter);
                    
                }
                
                else if (maxcounter == highestCounter2) 
                {
                    highestCounter.Add(FoundChild.Key, maxcounter);
                }
            }
            

            //Creates a new binary tree obj, and creates a csv list obj to import exsisting csv data.
            //Makes nodes based on csv data.
            //Converting Keyvalue pairs to int, and using the given ID number as the node root.
            BinaryTree binaryTree = new BinaryTree();
            
            List<String[]> CSVImportedfile = new CSVImport().CSV();
            
            foreach (string[] File in CSVImportedfile) 
            {
                int.TryParse(File[0], out int Path5);
                binaryTree.put(new Node(Path5, File));
            }

            foreach (KeyValuePair<string, int> Bonk in highestCounter) 
            {
                int.TryParse(Bonk.Key, out int BonkReworked);
                Node newBonk = binaryTree._searchTree(BonkReworked, binaryTree.root);
                foreach (string moreBonk in newBonk.employee)
                {
                    Console.WriteLine(moreBonk);
                }
                Console.WriteLine("^ This is the suspected person.");
            }

            //Part2 Hunigtons Disease DNA test.
            //Converts String to directory and allows the program to search the given directory. Gives the user the ability to save csv data.
            Console.WriteLine("Enter the directory you want to search through: ");
            string Dir = Console.ReadLine();
            DirectoryInfo Dirp = new DirectoryInfo(Dir);
            string csv = FileWalker.WalkDirectoryTree(Dirp, Dirp);
            Console.Clear();
            Console.WriteLine(csv);
            Console.WriteLine("Choose a location to save the csv file: ");
            string savedFile = Console.ReadLine();
            File.WriteAllTextAsync(savedFile + ".csv", csv);
        }
    }
}
