using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "Code", "Sleep", "Repeat" };
        int[] numbers = { 19, -10, 12, -6, -3, 34, -2, 5 };
        int[] intArray = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        // Problem (a)
        Console.WriteLine("Subsets of words:");
        PrintAllSubsets(words, 0, new List<string>());

        // Problem (b)
        int[] filteredArray = RemoveNegativeNumbers(numbers);
        Console.WriteLine("\nFiltered array:");
        Console.WriteLine(string.Join(", ", filteredArray));

        // Problem (c)
        Dictionary<int, int> occurrenceCount = CountOccurrences(intArray);
        Console.WriteLine("\nElement occurrences:");
        foreach (var kvp in occurrenceCount)
        {
            Console.WriteLine($"{kvp.Key} => {kvp.Value} times");
        }
        // Problem (d)
        Tuple<List<int>, List<int>> randomNumbers = GenerateRandomNumbers();
        Console.WriteLine("\nRandom Odd Numbers:");
        Console.WriteLine(string.Join(", ", randomNumbers.Item1));
        Console.WriteLine("\nRandom Even Numbers:");
        Console.WriteLine(string.Join(", ", randomNumbers.Item2));
    }
    // Problem (a): Recursive method to print all subsets of words
    static void PrintAllSubsets(string[] words, int index, List<string> currentSubset)
    {
        if (index == words.Length)
        {
            Console.WriteLine("(" + string.Join(" ", currentSubset) + ")");
            return;
        }

        PrintAllSubsets(words, index + 1, currentSubset); // Exclude current word
        currentSubset.Add(words[index]);
        PrintAllSubsets(words, index + 1, currentSubset); // Include current word
        currentSubset.RemoveAt(currentSubset.Count - 1);
    }

    // Problem (b): Method to remove negative numbers from an array
    static int[] RemoveNegativeNumbers(int[] numbers)
    {
        return numbers.Where(num => num >= 0).ToArray();
    }

    // Problem (c): Method to count occurrences of elements in an array
    static Dictionary<int, int> CountOccurrences(int[] intArray)
    {
        Dictionary<int, int> occurrenceCount = new Dictionary<int, int>();
        foreach (int num in intArray)
        {
            if (occurrenceCount.ContainsKey(num))
                occurrenceCount[num]++;
            else
                occurrenceCount[num] = 1;
        }
        return occurrenceCount;
    }

    // Problem (d): Method to generate random unique odd and even numbers
    static Tuple<List<int>, List<int>> GenerateRandomNumbers()
    {
        Random random = new Random();
        List<int> oddNumbers = new List<int>();
        List<int> evenNumbers = new List<int>();

        while (oddNumbers.Count < 8)
        {
            int randomNumber = random.Next(10, 26);
            if (randomNumber % 2 != 0 && !oddNumbers.Contains(randomNumber))
                oddNumbers.Add(randomNumber);
        }

        while (evenNumbers.Count < 8)
        {
            int randomNumber = random.Next(10, 26);
            if (randomNumber % 2 == 0 && !evenNumbers.Contains(randomNumber))
                evenNumbers.Add(randomNumber);
        }

        return Tuple.Create(oddNumbers, evenNumbers);
    }
}
