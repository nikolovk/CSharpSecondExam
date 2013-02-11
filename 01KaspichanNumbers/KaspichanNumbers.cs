using System;

class KaspichanNumbers
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        if (number == 0)
        {
            Console.WriteLine("A");
            return;
        }
        string result = "";
        while (number > 0)
        {
            ulong remainder = number % 256;
            number = number / 256;
            string kaspichanDigit = DecimalToKaspichan(remainder);
            result = kaspichanDigit + result;
        }
        Console.WriteLine(result);
    }

    static string DecimalToKaspichan(ulong number)
    {
        ulong firstNumber = number / 26;
        ulong secondNumber = number % 26;
        string firstLetter = "";
        if (firstNumber > 0)
        {
            char letter = (char)(96 + firstNumber);
            firstLetter = "" + letter;
        }
        char secondLetter = (char)(65 + secondNumber);
        return firstLetter + secondLetter;
    }
}
