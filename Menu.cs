using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace togtiki
{
    internal class Menu
    {
        public static int menushka(int maximumpos)
        {
            int position = 4;

            while (true)
            {
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");

                ConsoleKeyInfo key = Console.ReadKey();

                //Обраьботчик клавиш 
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(0, position);
                        Console.WriteLine("  ");

                        if (position != 4)
                        {
                            position--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(0, position);
                        Console.WriteLine("  ");

                        if (position != maximumpos)
                        {
                            position++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        return  position;
                        break;

                }
            }
        }
    }
}
