
class Percolation
{
    static int[,] init(int n)//иницылизация и заполнения матрицы 0 1 2
    {
        Random rnd = new Random();
        int[,] arr = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int x = rnd.Next(2);
                if (x == 0)
                {
                    arr[i, j] = 2;
                }
                else if (x == 1 && i == 0)
                {
                    arr[i, j] = 0;
                }
                else if (x == 1)
                {
                    arr[i, j] = 1;
                }
            }
        }
        return arr;
    }
    static int[,] Open(int row, int col, int[,] arr) //проверка влево вправо открытых для хаполнения
    {
        int a = 2, b = 2, c = 2, d = 2;

        if (row != 0) a = arr[row - 1, col];
        if (col != 0) b = arr[row, col - 1];
        if (row < arr.GetLength(0) - 1) c = arr[row + 1, col];
        if (col < arr.GetLength(1) - 1) d = arr[row, col + 1];
        if (arr[row, col] == 1
            && (a == 0 || b == 0 || c == 0 || d == 0))
        {
            arr[row, col] = 0;
            return arr;
        }
        return arr;
    }

    static bool isOpen(int row, int col, int[,] arr) // проверка откырта ли ячейка
    {
        if (arr[row, col] == 2) return false;
        return true;
    }
    static bool isFull(int row, int col, int[,] arr)// проверка полная ли ячейка
    {
        if (arr[row, col] == 1) return false;
        return true;
    }
    static int numberOfOpenSites(int[,] arr)//кол открытх ячеек
    {
        int count = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0 || arr[i, j] == 1)
                {
                    count++;
                }
            }
        }
        return count;
    }

    static bool percolates(int[,] arr)// есть ли проход проводника к последней   строчке
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            if (arr[arr.GetLength(1) - 1, i] == 0)
            {
                return true;
            }
        }
        return false;
    }
    static void print(int[,] arr)//замена и вывод вместо 0 1 2 цветов
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (arr[i, j] == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (arr[i, j] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

            }
            Console.WriteLine();
        }
    }
    static int[,] Result(int[,] arr)//резултат
    {
        int sum = 0;
        int etnsum = 0;
        bool x = true;
        while (x)
        {
            etnsum = sum;
            sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr = Open(i, j, arr);
                    sum += arr[i, j];
                }
            }
            if (etnsum == sum)
            {
                x = false;
            }
        }
        return arr;
    }
    static void Main(String[] args)//главная часть
    {
        while (true)
        {
            Console.Write("int n \n");
            int n = int.Parse(Console.ReadLine());
            if (n<0)
            {
                Console.WriteLine("n can not be negative");
                break;
            }
            int[,] arr = init(n);
            print(arr);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("n=" + n);
            arr = Result(arr);
            print(arr);
            if (percolates(arr))
            {
                Console.WriteLine("is percolates");
            }
            else
            {
                Console.WriteLine("is not percolates");
            }
            Console.ReadLine();
            Console.Clear();
        }

    }

}

