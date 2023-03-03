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

        //Sort the words alphabetically
        BubbleSort(words);

       // Replace output.txt with the path to your output file
        string outputFilePath = "output.txt";
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (string word in words)
            {
                writer.WriteLine(word);
            }
        }

        Console.WriteLine("Done!");
        
    }
    static void BubbleSort(string[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    string temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}