using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Path to input file
        string inputFile = "input1.txt";

        // Read the file
        string text = File.ReadAllText(inputFile);

        // Split the text into words
        string[] words = Split(text);

        // Count the number of occurrences of each word
        int[] wordCounts = new int[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            int count = 1;
            for (int j = i + 1; j < words.Length; j++)
            {
                if (words[i] == words[j])
                {
                    count++;
                    // Set the count to -1 to mark duplicate words
                    wordCounts[j] = -1;
                }
            }
            // Set the count for the current word
            wordCounts[i] = count;
        }

        // Print the word counts
        for (int i = 0; i < words.Length; i++)
        {
            if (wordCounts[i] != -1)
            {
                Console.WriteLine("{0} - {1}", words[i], wordCounts[i]);
            }
        }
    }
    static string[] Split(string input)
    {
        List<string> result = new List<string>();
        StringBuilder sb = new StringBuilder();

        foreach (char c in input)
        {
            if (c == '\n' || c == '\t' || c == '\r' || c == ',' || c == '-' || c == '.' || c == ' ')
            {
                if (sb.Length > 0)
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                }
            }
            else
            {
                sb.Append(c);
            }
        }

        if (sb.Length > 0)
        {
            result.Add(sb.ToString());
        }

        return result.ToArray();
    }

}
