class Program
{
    static void Main(string[] args)
    {
        /* Тестові сценерії:
            1: n = 1 х = 1;
            2: n = 2 х = 0; 
            3: n = 0 х = 2;
                          */

        Console.Write("Enter n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int fact = 1;
        Console.Write("Enter x: ");
        int x = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
        }
        Console.WriteLine("n factorial =  " + fact);
        double k = Math.Pow(x, fact);
        Console.WriteLine("X^n = " + k);
        /* Тестові сценерії:
                     1: X^n=1
                     2: X^n=0 
                     3:X^n =2 ;
                                 */
    }
}