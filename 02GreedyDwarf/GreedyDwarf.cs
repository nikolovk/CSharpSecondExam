using System;
using System.Collections.Generic;
using System.Linq;

class GreedyDwarf
{
    static List<int> valley = new List<int>();
    static void Main()
    {
        valley = StringToList(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int bestResult = int.MinValue;
        for (int i = 0; i < m; i++)
        {
            string paternString = Console.ReadLine();
            int result = Walk(StringToList(paternString));
            if (result > bestResult)
            {
                bestResult = result;
            }
        }
        Console.WriteLine(bestResult);
    }

    static List<int> StringToList(string text)
    {
        List<int> result = new List<int>();
        string[] stringsArray = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in stringsArray)
        {
            result.Add(int.Parse(item));
        }
        return result;
    }

    static int Walk(List<int> pattern)
    {
        List<int> currentValley = valley.ToList();
        int result = 0;
        int index = 0;
        int patternIndex = 0;
        while ((index >=0) && (index < currentValley.Count) && (currentValley[index] < 1001))
        {
            result += currentValley[index];
            currentValley[index] = 1002;
            index += pattern[patternIndex];
            patternIndex++;
            if (patternIndex == pattern.Count)
            {
                patternIndex = 0;
            }
        }
        return result;
    }
}
