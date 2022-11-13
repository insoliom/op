
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter  first (x,y)");
        double ax = Convert.ToDouble(Console.ReadLine());
        double ay = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter second (x,y)");
        double bx = Convert.ToDouble(Console.ReadLine());
        double by = Convert.ToDouble(Console.ReadLine());

        double res_x = bx - ax;
        double res_y = by - ay;

        double length = Math.Sqrt(res_x * res_x + res_y * res_y);
        Console.WriteLine("The length of this vector is " + length);

    }
}
