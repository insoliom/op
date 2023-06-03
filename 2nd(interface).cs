using System;

namespace Polymorphism
{
    interface IVessel
    {
        void PrepareToMoving();
        void Move();
    }

    class Program
    {
        static void Main(string[] args)
        {
            IVessel[] vessels = new IVessel[]
            {
                new SailingVessel(),
                new Submarine()
            };

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Prepare and move Sailing Vessel");
                Console.WriteLine("2. Prepare and move Submarine");
                Thread.Sleep(500);
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":                        
                        vessels[0].PrepareToMoving();
                        Thread.Sleep(2000);
                        vessels[0].Move();
                        break;
                    case "2":                      
                        vessels[1].PrepareToMoving();
                        Thread.Sleep(2000);
                        vessels[1].Move();
                        break;                 
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    class SailingVessel : IVessel
    {
        public void PrepareToMoving()
        {
            Console.WriteLine("SailingVessel is prepared to move");
        }

        public void Move()
        {
            Console.WriteLine("SailingVessel is moving");
        }
    }

    class Submarine : IVessel
    {
        public void PrepareToMoving()
        {
            Console.WriteLine("Submarine is prepared to move");
        }

        public void Move()
        {
            Console.WriteLine("Submarine is moving");
        }
    }
}
