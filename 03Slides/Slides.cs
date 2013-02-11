using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Slides
{
    static int width, height, depth;
    static string[,,] actions;

    static void Main()
    {
        string[] dimension = Console.ReadLine().Split(' ');
        width = int.Parse(dimension[0]);
        height = int.Parse(dimension[1]);
        depth = int.Parse(dimension[2]);
        actions = new string[width, height, depth];
        ReadActions();
        string[] start = Console.ReadLine().Split(' ');
        int ballW = int.Parse(start[0]);
        int ballD = int.Parse(start[1]);
        int ballH = 0;
        bool inGame = true;
        while (inGame && ballH < height)
        {
            string[] action = actions[ballW,ballH,ballD].Split(' ');
            if (action[0] == "B")
            {
                break;
            }
            if (action[0] == "E")
            {
                if (ballH < height -1)
                {
                    ballH++;
                }
                else
                {
                    inGame = false;
                    break;
                }
            }
            if (action[0] == "T")
            {
                ballW = int.Parse(action[1]);
                ballD = int.Parse(action[2]);
            }
            if (action[0] == "S")
            {
                if (ballH == height-1)
                {
                    inGame = false;
                    break;
                }
                else
                {
                    int addDepth = 0;
                    int addWidth = 0;
                    foreach (char letter in action[1])
                    {
                        switch (letter)
                        {
                            case 'B':
                                addDepth = +1;
                                break;
                            case 'F':
                                addDepth = -1;
                                break;
                            case 'R':
                                addWidth = +1;
                                break;
                            case 'L':
                                addWidth = -1;
                                break;
                            default:
                                break;
                        }
                    }
                    if (ballW+addWidth < 0 || ballW + addWidth >= width || ballD+addDepth < 0 || ballD+addDepth >= depth)
                    {
                        break;
                    }
                    else
                    {
                        ballW += addWidth;
                        ballD += addDepth;
                        ballH++;
                    }
                }
            }
        }
        if (inGame)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine("Yes");
        }
        Console.WriteLine("{0} {1} {2}",ballW,ballH,ballD);
    }

    static void ReadActions()
    {
        for (int h = 0; h < height; h++)
        {
            string[] lineDepths = Console.ReadLine().Split('|');
            for (int d = 0; d < depth; d++)
            {
                string[] widths = lineDepths[d].Trim().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    actions[w, h, d] = widths[w];
                }
            }
        }
    }
}
