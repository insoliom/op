public class HashTable<KItem, VItem>
{
    private const int standartCapacity = 10;
    private LinkedList<KeyValuePair<KItem, VItem>>[] cell;

    public HashTable()
    {
        cell = new LinkedList<KeyValuePair<KItem, VItem>>[standartCapacity];
    }

    public HashTable(int initialCapacity)
    {
        cell = new LinkedList<KeyValuePair<KItem, VItem>>[initialCapacity];
    }

    private int GetBucketIndex(KItem key)
    {
        int hashCode = key.GetHashCode();
        int index = Math.Abs(hashCode) % cell.Length;
        return index;
    }

    public void Add(KItem key, VItem value)
    {
        int index = GetBucketIndex(key);
        if (cell[index] == null)
        {
            cell[index] = new LinkedList<KeyValuePair<KItem, VItem>>();
        }

        foreach (var pair in cell[index])
        {
            if (pair.Key.Equals(key))
            {
                throw new ArgumentException("An item with the same key already exists.");
            }
        }

        cell[index].AddLast(new KeyValuePair<KItem, VItem>(key, value));
    }

    public void Remove(KItem key)
    {
        int index = GetBucketIndex(key);
        if (cell[index] != null)
        {
            var pairs = cell[index];
            var node = pairs.First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    pairs.Remove(node);
                    return;
                }
                node = node.Next;
            }
        }
    }

    public VItem Get(KItem key)
    {
        int index = GetBucketIndex(key);
        if (cell[index] != null)
        {
            foreach (var pair in cell[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }

        throw new KeyNotFoundException("The specified key was not found.");
    }

    public bool Contains(KItem key)
    {
        int index = GetBucketIndex(key);
        if (cell[index] != null)
        {
            foreach (var pair in cell[index])
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Clear()
    {
        Array.Clear(cell, 0, cell.Length);
    }

    public int Size()
    {
        int count = 0;
        foreach (var cell in cell)
        {
            if (cell != null)
            {
                count += cell.Count;
            }
        }
        return count;
    }
}

public class Program
{
    private static HashTable<string, bool> dictionary;

    public static void Main(string[] args)
    {
        dictionary = new HashTable<string, bool>();

        dictionary.Add("hello", true);
        dictionary.Add("world", true);
        dictionary.Add("example", true);
        dictionary.Add("program", true);
        dictionary.Add("apple", true);
        dictionary.Add("peace", true);
        dictionary.Add("island", true);
        dictionary.Add("pepsi", true);
        dictionary.Add("cartoon", true);
        dictionary.Add("carrot", true);
        dictionary.Add("potato", true);
        dictionary.Add("major", true);
        dictionary.Add("computer", true);
        dictionary.Add("clear", true);
        dictionary.Add("fine", true);
        dictionary.Add("game", true);
        dictionary.Add("main", true);
        dictionary.Add("head", true);
        dictionary.Add("ex", true);
        dictionary.Add("war", true);
        dictionary.Add("lime", true);
        dictionary.Add("protein", true);
        dictionary.Add("headphones", true);
        dictionary.Add("laptop", true);
        dictionary.Add("keyboard", true);
        dictionary.Add("name", true);
        dictionary.Add("surname", true);
        dictionary.Add("fail", true);
        dictionary.Add("mistake", true);
        dictionary.Add("fly", true);
        dictionary.Add("airplane", true);
        dictionary.Add("sugar", true);
        dictionary.Add("coffe", true);
        dictionary.Add("telephone", true);
        dictionary.Add("crisp", true);
        dictionary.Add("movie", true);
        dictionary.Add("cahir", true);
        dictionary.Add("bad", true);
        dictionary.Add("friend", true);
        dictionary.Add("bed", true);
        dictionary.Add("like", true);
        dictionary.Add("dislike", true);
        dictionary.Add("football", true);
        dictionary.Add("volleyball", true);
        dictionary.Add("dance", true);
        dictionary.Add("bread", true);
        dictionary.Add("milk", true);
        dictionary.Add("funny", true);
        dictionary.Add("lamp", true);
        dictionary.Add("soldier", true);
        dictionary.Add("nickname", true);
        dictionary.Add("Ukraine", true);


        while (true)
        {
            Console.WriteLine("Enter the number corresponding to the action you want to perform:");
            Console.WriteLine("1. Add a word to the dictionary");
            Console.WriteLine("2. Delete a word from the dictionary");
            Console.WriteLine("3. Check if a word is in the dictionary");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the word to add: ");
                    string addWord = Console.ReadLine().ToLower();
                    dictionary.Add(addWord, true);
                    Console.WriteLine("Word added to the dictionary.");
                    break;
                case "2":
                    Console.Write("Enter the word to delete: ");
                    string deleteWord = Console.ReadLine().ToLower();
                    if (dictionary.Contains(deleteWord))
                    {
                        dictionary.Remove(deleteWord);
                        Console.WriteLine("Word deleted from the dictionary.");
                    }
                    else
                    {
                        Console.WriteLine("Word not found in the dictionary.");
                    }
                    break;
                case "3":
                    Console.Write("Enter the word to check: ");
                    string checkWord = Console.ReadLine().ToLower();
                    if (dictionary.Contains(checkWord))
                    {
                        Console.WriteLine("Ok.");
                    }
                    else
                    {
                        Console.WriteLine("Wrong spelling");
                    }
                    break;              
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
/*
 Enter the number corresponding to the action you want to perform:
1. Add a word to the dictionary
2. Delete a word from the dictionary
3. Check if a word is in the dictionary
1
Enter the word to add: Slava
Word added to the dictionary.

Enter the number corresponding to the action you want to perform:
1. Add a word to the dictionary
2. Delete a word from the dictionary
3. Check if a word is in the dictionary
3
Enter the word to check: slava
Ok.

Enter the number corresponding to the action you want to perform:
1. Add a word to the dictionary
2. Delete a word from the dictionary
3. Check if a word is in the dictionary
2
Enter the word to delete: slava
Word deleted from the dictionary.

Enter the number corresponding to the action you want to perform:
1. Add a word to the dictionary
2. Delete a word from the dictionary
3. Check if a word is in the dictionary
3
Enter the word to check: slava
Wrong spelling
 */