namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;

            // Create a text file containing 15 random real numbers
            using (StreamWriter sw = new StreamWriter("file.txt"))
            {
                Random rnd = new Random();
                for (int i = 0; i < 15; i++)
                {
                    int num = rnd.Next(1, 100);
                    sw.Write(num + " ");

                    // Find the maximum number
                    if (num > max)
                    {
                        max = num;
                    }
                }
            }

            // Write the maximum number to another file 
            using (StreamWriter sw = new StreamWriter("max.txt"))
            {
                sw.Write(max);
            }

            Console.WriteLine("The maximum number is: " + max);
        }
    }
}