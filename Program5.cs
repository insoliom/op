
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter pls the number");
        int rows = Convert.ToInt32(Console.ReadLine());
        int res = 1;
        int x;
        int i; // number of column
        int j; // number of elements

        for (i = 0; i < rows; i++)
        {
            for (x = 1; c <= rows - i; x++)
            {
                Console.Write(" "); // spaces
            }
            for (j = 0; j <= i; j++)
            {
                if (j == 0 || i == 0 || j == i)
                {
                    res = 1;
                }
                else
                {
                    res = res * (i - j + 1) / j;
                }
                Console.Write(" " + res);
            }
            Console.WriteLine();
        }
