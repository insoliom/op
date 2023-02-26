using System;
using System.IO;

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
                string[] parts = line.Split(',');

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
}