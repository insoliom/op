using System;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
       // Replace input.txt with the path to your input file
        string inputFilePath = "input.txt";
        string[] words = File.ReadAllLines(inputFilePath);

       // Sort the words alphabetically
        words = words.OrderBy(w => w).ToArray();

        //Replace output.txt with the path to your output file
        string outputFilePath = "output.txt";
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (string word in words)
            {
                writer.WriteLine(word);
            }
        }

        Console.WriteLine("Done"!);
    }
}
