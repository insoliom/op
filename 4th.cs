using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("students.csv");

            bool found = false;

            // Loop through each line in the file
            foreach (string line in lines)
            {
                string[] parts = Split(line, ',');

                // Extract the first name, last name, and score
                string firstName = parts[0];
                string lastName = parts[1];
                int score = int.Parse(parts[2]);

                // Check if the score is less than 60
                if (score < 60)
                {
                    Console.WriteLine(firstName + " " + lastName + " - " + score);
                    found = true;
                }
            }

            // If no students with score less than 60 were found
            if (!found)
            {
                Console.WriteLine("No students with score less than 60 were found.");
            }

        }
        catch (IOException e)
        {
            Console.WriteLine("Error reading file: " + e.Message);
        }
    }

    static string[] Split(string input, char delimiter)
    {
        List<string> substrings = new List<string>();
        int start = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == delimiter)
            {
                substrings.Add(input.Substring(start, i - start));
                start = i + 1;
            }
        }

        substrings.Add(input.Substring(start));

        return substrings.ToArray();
    }
}