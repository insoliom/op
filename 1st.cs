using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fileName = "mytextfile.txt";

        try
        {
            // Create the text file
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine("This is the first line.");
            writer.WriteLine("This is the second line.");
            writer.Close();

            // Read the contents of the text file and display them on the screen
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

        }
        catch (IOException e)
        {
            Console.WriteLine("Error creating or reading file: " + e.Message);
        }
    }
}