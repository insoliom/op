
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите R");
        double R = Convert.ToDouble(Console.ReadLine());

        double S = 4 * Math.PI * R * R;
        double V = (S * R) / 3;
        Console.WriteLine("Площадь сфери = " + S + "; Обьем сферы = " + V + ".");

    }
