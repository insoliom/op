class Program
{
    static double Power(double x, double n)
    {
        double res = x;
        if (n == 0) return 1;
        for (int j = 1; j < n; j++)
            res *= x;
        return res;
    }

    static void Main(string[] args)
    {
        /* Тестові сценерії:
            1: n = 1 х = 1;
            2: n = 2 х = 0; 
            3: n = 0 х = 2;
                          */

        Console.Write("Enter n: ");
        long n = Convert.ToInt64(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine("we cant find factorial from negative num");
            return;
        }
        long fact = 1;
        Console.Write("Enter x: ");
        long x = Convert.ToInt64(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
        }
        Console.WriteLine("n factorial =  " + fact);
        double k = Power(x, fact);
        Console.WriteLine("X^n = " + k);
        /* Тестові сценерії:
                     1: X^n=1
                     2: X^n=0 
                     3:X^n =2 ;
                                 */
    }
}
