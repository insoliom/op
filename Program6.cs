namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            /// Зробити зсув масиву з додатковим масивом розміром k
            /// 
            /// 
            Console.Write("enter size ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("enter k ");
            int k = int.Parse(Console.ReadLine());
            if (k > size)
            {
                Console.WriteLine("Error!");
                return;
            }
            int[] arr = new int[size];

            int[] tempArr = new int[k];

            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }
            for (int i = k - 1; i >= 0; i--)
            {

                int ind = i - k;
                if (ind < 0)
                {
                    ;
                    arr[i] = tempArr[-ind - 1];
                }
                else
                {
                    arr[i] = arr[ind];

                }

            }

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(tempArr[i]);
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write(arr[i] + ", ");
            }

        }
    }
}