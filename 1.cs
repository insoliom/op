namespace Sem_2_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Rec recs = new Rec();
            MainMenu(recs);
        }















        public static void CAATL(Rec recs)
        {
            Console.WriteLine("Введіть номер: ");

            int id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
            {
                Console.WriteLine("Номер має бути більше 0");            
                return;
            }

            Console.WriteLine("Введіть фамілію ");
            string surname = Console.ReadLine();
            if (surname.Length == 0)
            {
                Console.WriteLine("напиши хоч щось)");               
                return;
            }

            Console.WriteLine("введiть зарплату ");
            int salary = Convert.ToInt32(Console.ReadLine());
            if (salary <= 0)
            {
                Console.WriteLine("зарплата має бути хоч якась)");              
                return;
            }

            Console.WriteLine("Утримано ");
            int withheld = Convert.ToInt32(Console.ReadLine());
            
            if (withheld < 0   )
            {
                Console.WriteLine("має бути бiльше 0 або 0" );
                
                return;

            }
            if (withheld > salary)
            {
                Console.WriteLine("утримано не може бути бiльше зарплати");
                return;
            }

                Rec1 record = new Rec1(id, surname, salary, withheld);
            recs.AddRecord(record);
        }

        public static void PrintList(Rec recs)
        {
            for (int i = 0; i < recs.zapis.Count; i++)
            {
                Console.WriteLine(recs.zapis[i].print());
            }
            Console.WriteLine("продовжитиe");
            Console.ReadKey();
        }

        static void MainMenu(Rec recs)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Обери");
                Console.WriteLine("1. Додати робiтника");
                Console.WriteLine("2. подивитись список");
                Console.WriteLine("3. подивитись загальну суму");           
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (a == 1)
                {
                    CAATL(recs);
                }
                else if (a == 2)
                {
                    PrintList(recs);
                }
                else if (a == 3)
                {
                    Sum(recs);
                }
                else
                {
                    Console.WriteLine("Неправильно обрав)");
                }
            }
        }
        static void Sum(Rec recs)
        {
            int ssalary =0 ,swithheld = 0, spaid = 0;
                     
            for (int i = 0; i < recs.zapis.Count; i++)
            {
                ssalary = recs.zapis[i].Salary + ssalary;
                swithheld = recs.zapis[i].Withheld + swithheld;
                spaid = recs.zapis[i].paid() + spaid;
            }
            Console.WriteLine($"сумарно заплачено: {ssalary}, сумарно утримано: {swithheld}, сумарно виплачено: {spaid}");
            Console.WriteLine("натисни");
            Console.ReadKey();
        }

     
    }
    public class Rec
    {
        public List<Rec1> zapis;
        public Rec()
        {
            zapis = new List<Rec1>();
        }

        public void AddRecord(Rec1 rec)
        {
            zapis.Add(rec);
        }

        public void Sum()
        {
            int sum = 0;
            for (int i = 0; i < zapis.Count; i++)
            {
                sum = zapis[i].paid();
            }
        }
    }
    public class Rec1
    {
        public int Id;
        public string Surname;
        public int Salary;
        public int Withheld;

        public Rec1(int id, string surname, int salary, int withheld)
        {
            this.Id = id;
            this.Surname = surname;
            this.Salary = salary;
            this.Withheld = withheld;
        }

        public int paid()
        {
            return Salary - Withheld;
        }

        public string print()
        {
            return $"номер: {this.Id}, фамiлiя: {this.Surname}," +
            $" зарплата: {this.Salary}, утримано: {this.Withheld}, сплачено: {this.paid()};";
        }
    }
}

