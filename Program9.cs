
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите, пожалуйста, номер месяца");
        int x = Convert.ToInt16(Console.ReadLine());
        if ((x >= 1) && (x <= 2))
        {
            Console.WriteLine("Сейчас зима");
        }
        if ((x >= 3) && (x <= 5))
        {
            Console.WriteLine("Сейчас весна");
        }
        if ((x >= 6) && (x <= 8))
        {
            Console.WriteLine("Сейчас лето");
        }
        if ((x >= 9) && (x <= 11))
        {
            Console.WriteLine("Сейчас осень");
        }
        if (x == 12)
        {
            Console.WriteLine("Сейчас зима");
        }
        if (x < 0)
        {
            Console.WriteLine("Такого месяца не существует");
        }
        if (x > 12)
        {
            Console.WriteLine("Такого месяца не существует");
        }
    }
