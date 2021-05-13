using System;

public class FileWalker
{
    public static string WalkDirectoryTree(System.IO.DirectoryInfo root, System.IO.DirectoryInfo trueRoot)
    {
        System.IO.FileInfo[] files = null;
        string csv = "";
        System.IO.DirectoryInfo[] subDirs = null;
        // First, process all the files directly under this folder
        try
        {
            files = root.GetFiles("*.txt");
        }
        // This is thrown if even one of the files requires permissions greater
        // than the application provides.
        catch (UnauthorizedAccessException e)
        {
            // This code just writes out the message and continues to recurse.
            // You may decide to do something different here. For example, you
            // can try to elevate your privileges and access the file again.
            Console.WriteLine(e.Message);
        }
        catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        if (files != null)
        {
            foreach (System.IO.FileInfo fi in files)
            {
                //Creates the CSV file.
                string csvLine = "";
                csvLine += fi.Name.Substring(0, fi.Name.Length - 4);
                string seperator = root.FullName.Replace(trueRoot.FullName, "");
                seperator = seperator.Replace("\\", ",");
                csvLine += seperator;
                csvLine += ",";
                csvLine += DNA_Analyzer.Analyzer(fi);
                csvLine += "\n";
                if (DNA_Analyzer.Analyzer(fi) != "Normal")
                {
                    csv += csvLine;
                    Console.WriteLine(csvLine);
                }
            }

            // Now find all the subdirectories under this directory.
            subDirs = root.GetDirectories();

            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                // Resursive call for each subdirectory.
                csv += WalkDirectoryTree(dirInfo, trueRoot);
            }
        }
        return csv;
    }
}