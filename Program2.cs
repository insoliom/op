
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите сторону А");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите сторону B");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите сторону C");
        double c = Convert.ToDouble(Console.ReadLine());

        double p = (a + b + c) / 2;
        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        Console.WriteLine(S + " - площа вашого трикутника");

    }
