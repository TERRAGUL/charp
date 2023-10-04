using System;

public class Program
{
    // Метод для вывода меню
    static void ShowMenu()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Выберите программу:");
        Console.WriteLine("1 - Игра \"Угадай число\"");
        Console.WriteLine("2 - Таблица умножения");
        Console.WriteLine("3 - Вывод делителей числа");
        Console.WriteLine("0 - Выход");
        Console.WriteLine("---------------------");
    }

    // Метод для проверки ввода целого числа
    static int ValidateInput(string message)
    {
        int number;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Плохое число :(.Давай другое.");
            Console.Write(message);
        }
        return number;
    }

    // Метод для игры "Угадай число"
    static void GuessNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(101);
        int attempts = 0;
        int guess;

        Console.WriteLine("Угадай-ка число от 0 до 100.");
        do
        {
            guess = ValidateInput("Введите цифру: ");
            attempts++;
            if (guess < randomNumber)
            {
                Console.WriteLine("Это число больше :).");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Мое число меньше).");
            }
        } while (guess != randomNumber);

        Console.WriteLine($"Поздравляю! ТЫ угадали число {randomNumber} с {attempts} попыток.");
    }

    // Метод для создания и заполнения таблицы умножения
    static int[,] CreateMultiplicationTable()
    {
        int[,] table = new int[10, 10];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                table[i, j] = (i + 1) * (j + 1);
            }
        }

        return table;
    }

    // Метод для вывода таблицы умножения
    static void PrintMultiplicationTable(int[,] table)
    {
        Console.WriteLine("Таблица умножения:");

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write($"{table[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    // Метод для вывода всех делителей числа
    static void PrintDivisors(int number)
    {
        Console.WriteLine($"Делители числа {number}:");
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine(i);
            }
        }
    }

    public static void Main()
    {
        int choice;
        ShowMenu();
        choice = ValidateInput("Введите номер программы: ");

        while (choice != 0)
        {
            switch (choice)
            {
                case 1:
                    GuessNumber();
                    break;
                case 2:
                    int[,] multiplicationTable = CreateMultiplicationTable();
                    PrintMultiplicationTable(multiplicationTable);
                    break;
                case 3:
                    int number = ValidateInput("Введите числецо: ");
                    PrintDivisors(number);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }

            Console.WriteLine("---------------------");
            ShowMenu();
            choice = ValidateInput("Введите номер программы: ");
        }

        Console.WriteLine("Сбежать отсюда.");
    }
}
