using System;
using System.Collections.Generic;
using System.Text;

class ConsoleJustification
{

    static StringBuilder justify = new StringBuilder();
    static int w;
    static List<string> text = new List<string>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        w = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                text.Add(word);
            }
        }
        int lastInLine = 0;
        int firstInLine = 0;
        int countLetters = 0;
        int currentLetters = 0;
        for (int i = 0; i < text.Count; i++)
        {
            currentLetters += text[i].Length;

            if (currentLetters + lastInLine - firstInLine+1 > w)
            {
                AddToJustify(firstInLine, lastInLine, countLetters);
                firstInLine = i;
                lastInLine = i;
                countLetters = text[i].Length;
                currentLetters = countLetters;
            }
            else
            {
                countLetters = currentLetters;
                lastInLine = i;
            }
        }
        AddToJustify(firstInLine, lastInLine, countLetters);
        Console.WriteLine(justify);
    }

    static void AddToJustify(int firstWord, int lastWord, int countLetters)
    {
        if (firstWord == lastWord)
        {
            justify.Append(text[firstWord]);
            justify.Append("\r\n");
            return;
        }
        int allSpaces = w - countLetters;
        int shortSpace = allSpaces / (lastWord - firstWord);
        int add = allSpaces % (lastWord - firstWord);
        for (int i = firstWord; i <= lastWord; i++)
        {
            justify.Append(text[i]);
            if (i < lastWord)
            {
                justify.Append(new string(' ', shortSpace));
                if (add > 0)
                {
                    justify.Append(" ");
                    add--;
                }
            }
            else
            {
                justify.Append("\r\n");
            }
        }
    }
}
