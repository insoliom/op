
public class Program
{
    public static void Main()
    {
        const double R = 5;
        const double H= 8;

        double Vc = H* Math.PI * Math.Pow(R, 2);
        double Vk = Vc / 3;
        Console.WriteLine("Обьем цилиндра = " + Vc + "; Обьем конуса = " + Vk + ";");

    }
