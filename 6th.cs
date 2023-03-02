class Program
{
    static void Main(string[] args)
    {
        // Read CSV file
        string[] lines = File.ReadAllLines("students.csv");

        // Convert CSV data to binary format
        using (BinaryWriter writer = new BinaryWriter(File.Open("students.bin", FileMode.Create)))
        {
            foreach (string line in lines)
            {
                string[] fields = Split(line,',');
                string id = fields[0];
                string name = fields[1];
                int score = int.Parse(fields[2]);

                // Write data to binary file
                writer.Write(id);
                writer.Write(name);
                writer.Write(score);
            }
        }

        // Read binary file and create new binary file with selected records
        using (BinaryReader reader = new BinaryReader(File.Open("students.bin", FileMode.Open)))
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("high_score.bin", FileMode.Create)))
            {
                int numRecords = lines.Length; // assume one record per line in CSV
                int numSelected = 0;

                for (int i = 0; i < numRecords; i++)
                {
                    string id = reader.ReadString();
                    string name = reader.ReadString();
                    int score = reader.ReadInt32();

                    if (score > 95)
                    {
                        numSelected++;

                        // Write data to output binary file
                        writer.Write(id);
                        writer.Write(name);
                        writer.Write(score);
                    }
                }

                // Write number of selected records to output binary file
                writer.Write(numSelected);
            }
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