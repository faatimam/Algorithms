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

        // a. Create a recursive method which prints all subsets of a given set of N words. 
        Console.WriteLine("Subsets of words:");
        PrintAllSubsets(words, 0, new List<string>());

        // b. Create a method that will removes all negative numbers from a sequence of elements, then return a new array of elements
        int[] filteredArray = RemoveNegativeNumbers(numbers);
        Console.WriteLine("\nFiltered array:");
        Console.WriteLine(string.Join(", ", filteredArray));

        // c. Create a method that will find from a given array of integers (in the range [0…10]) how many times each of the elements occurs. 
        Dictionary<int, int> occurrenceCount = CountOccurrences(intArray);
        Console.WriteLine("\nElement occurrences:");
        foreach (var kvp in occurrenceCount)
        {
            Console.WriteLine($"{kvp.Key} => {kvp.Value} times");
        }
        /* d. Create a method that will generate random numbers between 10 and 25. 
         * The method should generate 8 unique (no duplicates) numbers for both odd and even numbers. 
         * Store odd and even numbers on separate lists, the method should return the two lists.*/
        Tuple<List<int>, List<int>> randomNumbers = GenerateRandomNumbers();
        Console.WriteLine("\nRandom Odd Numbers:");
        Console.WriteLine(string.Join(", ", randomNumbers.Item1));
        Console.WriteLine("\nRandom Even Numbers:");
        Console.WriteLine(string.Join(", ", randomNumbers.Item2));
    }
    
    //a: Recursive method to print all subsets of words
    static void PrintAllSubsets(string[] words, int index, List<string> currentSubset)
    {
        if (index == words.Length)
        {
            Console.WriteLine("(" + string.Join(" ", currentSubset) + ")");
            return;
        }

        PrintAllSubsets(words, index + 1, currentSubset); 
        currentSubset.Add(words[index]);
        PrintAllSubsets(words, index + 1, currentSubset); 
        currentSubset.RemoveAt(currentSubset.Count - 1);
    }

    // b: Method to remove negative numbers from an array
    static int[] RemoveNegativeNumbers(int[] numbers)
    {
        return numbers.Where(num => num >= 0).ToArray();
    }

    // c: Method to count occurrences of elements in an array
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

    // d: Method to generate random unique odd and even numbers
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
