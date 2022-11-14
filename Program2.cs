class Program
{
    public static void Main(string[] args)
    {
        /* Тестові сценерії:
             1: n = 0;
             2: n = 1; 
             3: n = 5;
             4: n = -1;              */
        bool prime = true;
        Console.Write("Enter Number ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine("negative cant be prime");
            return;
        }
        for (int i = 2; i <= n / 2 + 2; i++)
        {
            if (n % i == 0 || n == 1)
            {
                prime = false;

            }
            else
            {
                prime = true;
            }
            break;
        }
        if (prime)
        {
            Console.WriteLine("This is prime number");
        }
        else
        {
            Console.WriteLine("This is not prime number");
        }
        /* Тестові сценерії:
            1:This is not prime number ;
            2:This is not prime number; ;
            3:This is prime number;  
            4:negative cant be prime 
        */
    }