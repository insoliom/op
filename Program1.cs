using System;
using System.Xml.Linq;

public class ProgramLekt
{
    public static void Main()
    {
        double a = 0;
        double b = 0;
        double c = 0;
        double d = 0;
        Console.Write("Enter value for a: ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter value for b: ");
        b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter value for c: ");
        c = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter value for d: ");
        d = Convert.ToDouble(Console.ReadLine());

        if (a < b)
        {
            if (a < c)
            {
                if (a < d)
                {
                    Console.WriteLine("a-minimal " + a);
                }
                else
                {
                    Console.WriteLine("c-minimal " + c);
                }
            }
            else
            {
                if (c < d)
                {
                    Console.WriteLine("c-minimal " + c);
                }
                else
                {
                    Console.WriteLine("d-minimal " + d);
                }
            }
        }
        else
        {
            if (b < c)
            {
                if (b < d)
                {
                    Console.WriteLine("b-minimal " + b);
                }
                else
                {
                    Console.WriteLine("d-minimal " + d);
                }
            }
            else
            {
                if (c < d)
                {
                    Console.WriteLine("c-minimal " + c);
                }
                else
                {
                    Console.WriteLine("d-minimal " + d);
                }

            }
}
