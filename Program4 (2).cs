
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите  A1");
        double a1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите  B1");
        double b1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите  C1");
        double c1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите  A2");
        double a2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите  B2");
        double b2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите  C2");
        double c2 = Convert.ToDouble(Console.ReadLine());

        double x = ((c1 * b1) - (c2 * b2)) / ((a1 * b1) - (a2 * b2));
        Console.WriteLine(" Х равен " + x);

    }
