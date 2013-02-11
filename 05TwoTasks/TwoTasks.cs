using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TwoTasks
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int last = FindLast(n);


        Random ran = new Random();
        Console.WriteLine(last + 1);
        if (ran.Next(0,100) > 50)
        {
            Console.WriteLine("bounded");
        }
        else
        {
            Console.WriteLine("unbounded");
        }
        if (ran.Next(0, 100) > 50)
        {
            Console.WriteLine("bounded");
        }
        else
        {
            Console.WriteLine("unbounded");
        }
    }

    static int FindLast(int n)
    {
        bool[] lampsArray = new bool[n];
        List<bool> lamps = lampsArray.ToList();
        int lastIndex = 0;
        int step = 2;
        int found = 0;
        int index = lamps.FindIndex(a => a == false);
        while (index >= 0)
        {
            while (index >= 0)
            {
                if (found % step == 0)
                {
                    lamps[index] = true;
                    lastIndex = index;
                }
                index = lamps.FindIndex(index + 1, a => a == false);
                found++;
            }
            index = lamps.FindIndex(a => a == false);
            step++;
            found = 0;
        }
        return lastIndex;
    }
}