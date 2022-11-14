
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введіть, будь-ласка, к-ть діб");
        double days = Convert.ToDouble(Console.ReadLine());
        double h = days * 24;
        double min = h * 60;
        double s = min * 60;
        Console.WriteLine($"Днів: {days}  Годин: {h}  Хвилин: {min}  Секунд: {s}");
    }
