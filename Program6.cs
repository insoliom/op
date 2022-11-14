
public class Program
{
    public static void Main()
    {
        double fr;
        Console.WriteLine("Введите сопротивление первого резистора");
        double r1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите сопротивление второго резистора");
        double r2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите сопротивление третьего резистора");
        double r3 = Convert.ToDouble(Console.ReadLine());

        double sr = (1 / r1) + (1 / r2) + (1 / r3);
        fr = 1 / sr;
        Console.WriteLine("Общее сопротивление = " + fr);

    }
