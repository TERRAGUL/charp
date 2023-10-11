int[] octavaNumberOne = new int[] { 1635, 1732, 1835, 1945, 2060, 2183, 2312, 2450, 2596, 2750, 2914 };

while (true)
{
    ConsoleKeyInfo klavishi = Console.ReadKey();

    Console.Clear();
    if (klavishi.Key == ConsoleKey.F1 || klavishi.Key == ConsoleKey.F2)
    {
        octavaNumberOne = Change(klavishi);
    }
    else
    {
        sound(klavishi, octavaNumberOne);
    }
}
static void sound(ConsoleKeyInfo klavishi, int[] octavaNumberOne)
{
    switch (klavishi.Key)
    {
        case ConsoleKey.A:
            Console.Beep(octavaNumberOne[0], 100);
            break;
        case ConsoleKey.W:
            Console.Beep(octavaNumberOne[1], 100);
            break;
        case ConsoleKey.S:
            Console.Beep(octavaNumberOne[2], 100);
            break;
        case ConsoleKey.E:
            Console.Beep(octavaNumberOne[4], 100);
            break;
        case ConsoleKey.D:
            Console.Beep(octavaNumberOne[5], 100);
            break;
        case ConsoleKey.F:                                            // Жмякать только клавиши: A,W,S,E,D,F,T,G,Y,H
            Console.Beep(octavaNumberOne[6], 100);                    // Переключение октав на клавиши: F1,F2
            break;
        case ConsoleKey.T:
            Console.Beep(octavaNumberOne[7], 100);
            break;
        case ConsoleKey.G:
            Console.Beep(octavaNumberOne[8], 100);
            break;
        case ConsoleKey.Y:
            Console.Beep(octavaNumberOne[9], 100);
            break;
        case ConsoleKey.H:
            Console.Beep(octavaNumberOne[10], 100);
            break;
    }
}
static int[] Change(ConsoleKeyInfo klavishi)
{
    int[] octapervoe = new int[] { 1635, 1732, 1835, 1945, 2060, 2183, 2312, 2450, 2596, 2750, 2914 };
    int[] octavtoroe = new int[] { 3270, 3465, 3671, 3889, 4120, 4365, 4625, 4900, 5191, 5500, 5827 };

    switch (klavishi.Key)
    {
        case ConsoleKey.F1:
            Console.WriteLine("первая октавка");
            return octapervoe;
            break;
        case ConsoleKey.F2:
            Console.WriteLine("вторая октавка");
            return octavtoroe; 
            break;
        default: return octavtoroe;
    }
}