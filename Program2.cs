class Program
{

    public static void Main(string[] args)

    {

        Console.WriteLine("Enter num");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine("we cant use negative\n");
            return;

        }
        if (n == 0 || n == 1)
        {
            Console.WriteLine("is not prime number\n");

        }
        else
        {
            for (int a = 2; a <= n / 2; a++)
            {
                if (n % a == 0)
                {
                    Console.WriteLine("is not prime number\n");
                    return;
                }

            }
            Console.WriteLine("is  prime number\n");

        }
        /*   Enter num
             0
             is not prime number
             Enter num
             1
             is not prime number
             Enter num
             2
             is prime number
             Enter num
             3
             is prime number
             Enter num
             4
             is not prime number
             Enter num
            -1
             we cant use negative*/
    }

}