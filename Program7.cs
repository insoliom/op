
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Сколько электроэнергии было потрачено за месяц?");
        double x = Convert.ToDouble(Console.ReadLine());
        double y = 0;
        if (x >= 250)
        {
            y = x * 1.68;
        }
        else
        {
            y = x * 1.44;
        }
        Console.WriteLine("Сумма к оплате равна " + y);

    }
