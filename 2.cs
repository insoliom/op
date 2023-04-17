using System;

namespace Polymorhism
{
    abstract class Vessel
    {
        class Program
        {
            static void Main(string[] args)
            {
                Vessel[] ves = new Vessel[]
                {
            new SailingVessel(),
            new Submarine()
                };
                foreach (Vessel vessel in ves)
                {
                    vessel.PrepareToMoving();
                }



                foreach (Vessel vessel in ves)
                {
                    vessel.Move();
                }
            }
        }
        public abstract void PrepareToMoving();
        public abstract void Move();


        class SailingVessel : Vessel
        {
            public override void PrepareToMoving()
            {
                Console.WriteLine("SailingVessel is prepare to move");
            }

            public override void Move()
            {
                Console.WriteLine("SailingVessel is moving");
            }
        }

        class Submarine : Vessel
        {
            public override void PrepareToMoving()
            {
                Console.WriteLine("Submarine is prepare to move");
            }
            public override void Move()
            {
                Console.WriteLine("Submarine is moving");
            }
        }




    }
}

       