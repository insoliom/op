class Program
{
    public static void Main(string[] args)
    {
        
        while (true)
        {
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
                if (n % i == 0 || n == 1 || n == 2)
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
            /* Enter Number 0
               This is not prime number

               Enter Number 1
               This is not prime number

               Enter Number 2
               This is not prime number

               Enter Number 3
              This is prime number

               Enter Number 4
               This is not prime number
               Enter Number 5

               This is prime number

            */
        }
    }
            
}
