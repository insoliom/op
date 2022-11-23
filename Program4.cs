class Program
{
    /*
     Тестові сценаріх
    перше чсило=10
    друге число=0
    третє число =1565

     */
    static double Factorial(double n)
    {
        double fact = 1;
        for (int j = 1; j <= n; j++)
            fact *= j;
        return fact;
    }
    static double Power(double x, double n)
    {
        double res = x;
        if (n == 0) return 1;
        for (int j = 1; j < n; j++)
            res *= x;
        return res;
    }

    static double Sinus(double znach)
    {
        while (znach > Math.PI * 2)
        {
            znach -= Math.PI * 2;
        }
        double result = 0;
        for (int i = 0; i < 10; i++)
        {
            result += Power(-1, i) * Power(znach, (2 * i) + 1) / Factorial((2 * i) + 1);

        }

        return result;
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Input number: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("With  Library: " + Math.Sin(a));
            Console.WriteLine("Without library: " + Sinus(a));
        }

    }
    /*
    Тестові сценаріх
    sin (10)=-0,540211
    sin (0) = 0
    sin (1565) =0,467851
 */
}