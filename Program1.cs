class HelloWorld
{
    static void Main()
    {
        /* Тестові сценерії:
              1: xn = 0; n = 0;
              2: xn = 1; n = 1;
              3: xn = 5; n = 3; */

        Console.WriteLine("xn= ");
        double xn = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("n= ");
        double n = Convert.ToDouble(Console.ReadLine());
        double x0 = 1.23;
        double b = 12.6;
        for (int i = 0; i < n; i++)
        {
            double x = x0 + i * (xn - x0) / n;
            Console.WriteLine("x= " + Math.Round(x, 2));
            double y = 15.28 * Math.Pow(Math.Abs(x), -3 / 2) + Math.Cos(Math.Log(Math.Abs(x), Math.E) + b);
            Console.WriteLine("y= " + Math.Round(y, 2));

        }

        /* Тестові сценарії:
         1: x= не число; y= не число 
         
         2: x= 1,23; y= 13,39
           
         3: x= 1,23; y= 13,39
            x= 2,49; y= 6,73
            x= 3,74; y= 4,3
              */
    }
}