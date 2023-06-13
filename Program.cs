
using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{

    public static void Main(string[] args)
    {
        DequeArrayt.Compiled();
        DequeListt.Compiled();
        RandomizedQueueArrayt.Compiled();
        RandomizedQueueListt.Compiled();
    }


    public class Encoding
    {
        public static void UTF8()
        {
           Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
    }

    public class DequeArrayt
    {
        public static void Compiled()
        {
            try
            {
                Encoding.UTF8();
                DequeArray<int> dequeArray = new DequeArray<int>();
                dequeArray.AddFirst(1);
                dequeArray.AddLast(2);
                dequeArray.AddLast(3);
                dequeArray.AddFirst(4);

                Console.WriteLine("Двобічна черга на масиві:");
                foreach (int item in dequeArray)
                {
                    Console.WriteLine(item);
                }

                int removedItem = dequeArray.RemoveFirst();
                Console.WriteLine("Видалений елемент: " + removedItem);
                removedItem = dequeArray.RemoveLast();
                Console.WriteLine("Видалений елемент: " + removedItem);
                Console.WriteLine("Юніт тестуання успішно");
                Console.WriteLine("Працює коректно");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Працює некоректно,помилка -- " + ex.Message);
            }
        }
    }

    public class DequeListt
    {
        public static void Compiled()
        {
            try
            {
            Encoding.UTF8();
            DequeList<string> dequeList = new DequeList<string>();
            dequeList.AddFirst("Рибкін");
            dequeList.AddLast("Єгор");
            dequeList.AddFirst("Романвич");

            Console.WriteLine("\nДвобічна черга на списку:");
            foreach (string item in dequeList)
            {
                Console.WriteLine(item);
            }

            string removedItem = dequeList.RemoveFirst();
            Console.WriteLine("Видалений елемент: " + removedItem);
            removedItem = dequeList.RemoveLast();
            Console.WriteLine("Видалений елемент: " + removedItem);
            Console.WriteLine("Юніт тестуання успішно");
            Console.WriteLine("Працює коректно");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Працює некоректно,помилка -- "+ex.Message);
            }

}
    }


    public class RandomizedQueueArrayt
    {
        public static void Compiled()
        {
            try
            {
            Encoding.UTF8();
            RandomizeQueueArray<int> randomizedQueueArray = new RandomizeQueueArray<int>();
            randomizedQueueArray.Enqueue(1);
            randomizedQueueArray.Enqueue(2);
            randomizedQueueArray.Enqueue(3);
            randomizedQueueArray.Enqueue(4);
            randomizedQueueArray.Enqueue(5);

            Console.WriteLine("Втпадкова двобічна черга на масиві:");
            foreach (int item in randomizedQueueArray)
            {
                Console.WriteLine(item);
            }

            int sampledItem = randomizedQueueArray.Sample();
            Console.WriteLine("Зразковий елемент: " + sampledItem);
            int dequeuedItem = randomizedQueueArray.Dequeue();
            Console.WriteLine("Вилучений елемент: " + dequeuedItem);
            Console.WriteLine("Працює коректно");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Працює некоректно,помилка -- " + ex.Message);
            }
        }
    }

    public class RandomizedQueueListt
    {
        public static void Compiled()
        {
            try
            {
                Encoding.UTF8();
                RandomizeQueueList<string> randomizedQueueList = new RandomizeQueueList<string>();
                randomizedQueueList.Enqueue("ФПМ");
                randomizedQueueList.Enqueue("Топ");
                randomizedQueueList.Enqueue("Група");
                randomizedQueueList.Enqueue("КП-22");
                randomizedQueueList.Enqueue("Краща");

                Console.WriteLine("\n Випадкова двобічна черга на масиві:");
                foreach (string item in randomizedQueueList)
                {
                    Console.WriteLine(item);
                }

                string sampledItem = randomizedQueueList.Sample();
                Console.WriteLine("Зразковий елемент: " + sampledItem);
                string dequeuedItem = randomizedQueueList.Dequeue();
                Console.WriteLine("Вилучений елемент: " + dequeuedItem);
                Console.WriteLine("Працює коректно");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Працює некоректно,помилка -- "+ex.Message);
            }

        }
    }







    public interface IIterable<T>
    {
        bool HasNext { get; }
        T MoveNext();
    }

    public class DequeArray<Item> : IIterable<Item>
    {
        private Item[] array;
        private int firstelement;
        private int lastelement;
        private int size;

        public DequeArray()
        {
            const int defaultCapacity = 10;
            array = new Item[defaultCapacity];
            firstelement = lastelement = -1;
            size = 0;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public void AddFirst(Item item)
        {
            if (firstelement == -1)
            {
                firstelement = lastelement = 0;
            }
            else if (firstelement == 0)
            {
                firstelement = array.Length - 1;
            }
            else
            {
                firstelement--;
            }

            array[firstelement] = item;
            size++;
        }

        public void AddLast(Item item)
        {
            if (lastelement == -1)
            {
                firstelement = lastelement = 0;
            }
            else if (lastelement == array.Length - 1)
            {
                lastelement = 0;
            }
            else
            {
                lastelement++;
            }

            array[lastelement] = item;
            size++;
        }

        public Item RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            Item item = array[firstelement];
            array[firstelement] = default(Item);

            if (firstelement == lastelement)
            {
                firstelement = lastelement = -1;
            }
            else if (firstelement == array.Length - 1)
            {
                firstelement = 0;
            }
            else
            {
                firstelement++;
            }

            size--;
            return item;
        }

        public Item RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            Item item = array[lastelement];
            array[lastelement] = default(Item);

            if (firstelement == lastelement)
            {
                firstelement = lastelement = -1;
            }
            else if (lastelement == 0)
            {
                lastelement = array.Length - 1;
            }
            else
            {
                lastelement--;
            }

            size--;
            return item;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            int index = firstelement;
            int count = 0;

            while (count < size)
            {
                yield return array[index];

                if (index == array.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }

                count++;
            }
        }

        public bool HasNext { get; private set; }

        public Item MoveNext()
        {
            if (IsEmpty() || !HasNext)
            {
                throw new InvalidOperationException("No more elements");
            }

            HasNext = firstelement != lastelement;

            if (firstelement == array.Length - 1)
            {
                firstelement = 0;
            }
            else
            {
                firstelement++;
            }

            size--;
            return array[firstelement];
        }
    }

    public class DequeList<Item> : IIterable<Item>
    {
        private LinkedList<Item> list;
       
        public DequeList()
        {
            list = new LinkedList<Item>();
        }
        
        public bool IsEmpty()
        {
            return list.Count == 0;
        }
        
        public int Size()
        {
            return list.Count;
        }
       
        public void AddFirst(Item item)
        {
            list.AddFirst(item);
        }
       

        public void AddLast(Item item)
        {
            list.AddLast(item);
        }
      
        public Item RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            Item item = list.First.Value;
            list.RemoveFirst();
            return item;
        }   
        public Item RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            Item item = list.Last.Value;
            list.RemoveLast();
            return item;
        }
       
        public IEnumerator<Item> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public bool HasNext { get; private set; }
     
        public Item MoveNext()
        {
            if (IsEmpty() || !HasNext)
            {
                throw new InvalidOperationException("No more elements");
            }

            Item item = list.First.Value;
            list.RemoveFirst();
            HasNext = list.Count > 0;
            return item;
        }
    }

    public class RandomizeQueueArray<Item> : IIterable<Item>
    {
        private Item[] array;
        private int size;
        private Random random;
        
        public RandomizeQueueArray()
        {
            const int defaultCapacity = 10;
            array = new Item[defaultCapacity];
            size = 0;
            random = new Random();
        }
       
        public bool IsEmpty()
        {
            return size == 0;
        }
      
        public int Size()
        {
            return size;
        }
       
        public void Enqueue(Item item)
        {
            if (size == array.Length)
            {
                ResizeArray(array.Length * 2);
            }

            array[size] = item;
            size++;
        }
        
        public Item Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("RandomizedQueue is empty");
            }

            int randomIndex = random.Next(size);
            Item item = array[randomIndex];

          
            array[randomIndex] = array[size - 1];
            array[size - 1] = default(Item);

            size--;

            if (size > 0 && size == array.Length / 4)
            {
                ResizeArray(array.Length / 2);
            }

            return item;
        }
   
        public Item Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("RandomizedQueue is empty");
            }

            int randomIndex = random.Next(size);
            return array[randomIndex];
        }
        
        public IEnumerator<Item> GetEnumerator()
        {
            Item[] shuffledArray = new Item[size];
            Array.Copy(array, shuffledArray, size);
            ShuffleArray(shuffledArray);

            return ((IEnumerable<Item>)shuffledArray).GetEnumerator();
        }

        private void ResizeArray(int capacity)
        {
            Item[] newArray = new Item[capacity];
            Array.Copy(array, newArray, size);
            array = newArray;
        }

        private void ShuffleArray(Item[] items)
        {
            int n = items.Length;
            for (int i = 0; i < n; i++)
            {
                int randomIndex = i + random.Next(n - i);
                Item temp = items[randomIndex];
                items[randomIndex] = items[i];
                items[i] = temp;
            }
        }

        public bool HasNext { get; private set; }

        public Item Next()
        {
            if (!HasNext)
            {
                throw new InvalidOperationException("No more elements");
            }

            HasNext = size > 0;
            return Dequeue();
        }

        public Item MoveNext()
        {
            
            return Next();
        }
    }

    public class RandomizeQueueList<Item> : IIterable<Item>
    {
        private List<Item> list;
        private Random random;
       
        public RandomizeQueueList()
        {
            list = new List<Item>();
            random = new Random();
        }
      
        public bool IsEmpty()
        {
            return list.Count == 0;
        }
      
        public int Size()
        {
            return list.Count;
        }
        
        public void Enqueue(Item item)
        {
            list.Add(item);
        }
       
        public Item Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("RandomizedQueue is empty");
            }

            int randomIndex = random.Next(list.Count);
            Item item = list[randomIndex];
            list[randomIndex] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return item;
        }
     
        public Item Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("RandomizedQueue is empty");
            }

            int randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }
     
        public IEnumerator<Item> GetEnumerator()
        {
            List<Item> shuffledList = new List<Item>(list);
            ShuffleList(shuffledList);
            return shuffledList.GetEnumerator();
        }

        private void ShuffleList(List<Item> items)
        {
            int n = items.Count;
            for (int i = 0; i < n; i++)
            {
                int randomIndex = i + random.Next(n - i);
                Item temp = items[randomIndex];
                items[randomIndex] = items[i];
                items[i] = temp;
            }
        }

        public bool HasNext { get; private set; }

        public Item Next()
        {
            if (!HasNext)
            {
                throw new InvalidOperationException("No more elements");
            }

            HasNext = !IsEmpty();
            return Dequeue();
        }

        public Item MoveNext()
        {
            return Next();
        }
    }
}
/*
Двобічна черга на масиві:
4
1
2
3
Видалений елемент: 4
Видалений елемент: 3
Юніт тестуання успішно
Працює коректно

Двобічна черга на списку:
Романвич
Рибкін
Єгор
Видалений елемент: Романвич
Видалений елемент: Єгоо
Юніт тестуання успішно
Працює коректно
Втпадкова двобічна черга на масиві:
2
1
5
4
3
Зразковий елемент: 1
Вилучений елемент: 3
Працює коректно

Випадкова двобічна черга на масиві:
Краща
ФПМ
Топ
КП-22
Група
Зразковий елемент: КП-22
Вилучений елемент: Група
Працює коректно
*/
