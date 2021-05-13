using System;
using System.Collections.Generic;
using System.IO;

public class DNA_Analyzer
{
    public static string Analyzer(FileInfo file) 
    {
        //Variable setup.
        List<string> Protiens = new List<string>();
        string Text = File.ReadAllText(file.FullName);
        string TempString = "";
        int TempInt = 0;
        int MaxCounter = 0;
        int MaxInt = 0;
        string Classification = "";
        
        foreach (char c in Text) 
        {
            //Triplet setup for DNA.
            TempString += c;
            TempInt++;
            if (TempInt == 3) 
            {
                Protiens.Add(TempString);
                TempString = "";
                TempInt = 0;

            }

        }

        foreach (string protien in Protiens)
        {
            //Search for repeating data.
            if (protien == "CAG") 
            {
                MaxCounter++;

                if (MaxCounter > MaxInt)
                {
                    MaxInt = MaxCounter;

                }
                else 
                {
                    MaxCounter = 0;
                    
                }
            }
        }

        if (MaxInt <= 26)
        {
            Classification = "Normal";
        }

        else if (MaxInt <= 35) 
        {
            Classification = "Intermediate";
        }

        else if (MaxInt <= 39)
        {
            Classification = "Reduced Performance";
        }

        else if (MaxInt >= 40)
        {
            Classification = "Full Penetrance";
        }
        return Classification;
    }
}
