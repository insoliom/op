
public class Program
{
    public static void Main()
    {
        Cdouble a;
        double b;
        char op;



        double res = 0;
        while (true)
        {
            Console.WriteLine("Enter the operation symbol");
            op = Convert.ToChar(Console.ReadLine());
            if (op == 'x')
            {
                Console.WriteLine("You want to stop the program? Y/N");
                op = Convert.ToChar(Console.ReadLine());
                if (op == 'Y'  op == 'y')
                {
                    break;
                }
                else if (op == 'N'  op == 'n')
                {
                    continue;
                }
            }

            Console.WriteLine("Enter the first number");
            a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number");
            b = Convert.ToDouble(Console.ReadLine());


            switch (op)
            {
                case '+':
                    res = a + b;
                    Console.WriteLine("Result is " + res);
                    break;
                case '-':
                    res = a - b;
                    Console.WriteLine("Result is " + res);
                    break;
                case '*':
                    res = a * b;
                    Console.WriteLine("Result is " + res);
                    break;
                case '/':
                    res = a / b;
                    Console.WriteLine("Result is " + res);
                    break;
                default:
                    Console.WriteLine("It is not an operation symbol");
                    break;
            }
}
