
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите, пожалуйста, температуру воды");
        double x = Convert.ToDouble(Console.ReadLine());
        if (x <= 0)
        {
            Console.WriteLine("Вода в твёрдом состоянии");
        }
        if ((x >= 0) && (x < 100))
        {
            Console.WriteLine("Вода в жидком состоянии");
        }
        if (x >= 100)
        {
            Console.WriteLine("Вода в газоподобном состоянии");

        }
