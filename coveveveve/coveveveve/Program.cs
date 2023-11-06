class Program
{
    static void Main()
    {
        Console.WriteLine("Введи путь к файлу:");
        string filePath = Console.ReadLine();

        FileManager fileManager = new FileManager(filePath);
        DataModel data = fileManager.ReadFile();

        Console.WriteLine("Содержимое Сия чуда:");
        foreach (string property in data.Properties)
        {
            Console.WriteLine(property);
        }

        while (true)
        {
            Console.WriteLine("Нажми F1 для сохранения, Escape для выхода:");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.F1)
            {
                fileManager.SaveFile(data);
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }
            else
            {
                Console.WriteLine();
                data.Properties.Add(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Содержимое файла:");
                foreach (string property in data.Properties)
                {
                    Console.WriteLine(property);
                }
            }
        }
    }
}



