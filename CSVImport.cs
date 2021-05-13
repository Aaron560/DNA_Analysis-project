using System;
using System.Collections.Generic;
using System.IO;

public class CSVImport
{
    public List<string[]> CSV()
    {
        //Imports CSV from user input.
        Console.WriteLine("Enter teh path to your csv: ");

        string path = Console.ReadLine();

        string path2 = File.ReadAllText(path);

        string[] path3;

        path3 = path2.Split("\n");

        List<string[]> path4 = new List<string[]>();

        for (int i = 0; i < path3.Length; i++)
        {
            path4.Add(path3[i].Split(","));
        }
        return path4;
    }
}