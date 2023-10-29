using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проводник
{
    internal class Arrow()
    {
        public int Show(int min, int max)
        {
            int pos = 1;
            ConsoleKeyInfo key;
            do
            {
                if (max != 0)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("->");
                }
                
                key = Console.ReadKey(true);
                if (max != 0)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("  ");
                }
                if (key.Key == ConsoleKey.UpArrow && pos != min)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != max)
                {
                    pos++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    return -2;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    return -3;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    return -4;
                }
            } while (key.Key != ConsoleKey.Enter || max == 0);
            return pos;
        }
    }
}
