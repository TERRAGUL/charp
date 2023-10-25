using System.ComponentModel.Design;
using System.Xml;

namespace zametki
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime date = DateTime.Today;

            NOTEeeee firstnote = new NOTEeeee();
            firstnote.note = " Похмелдос";
            firstnote.opisanie = " Надо похмелиться";
            firstnote.date = DateTime.Today;

            NOTEeeee secondnote = new NOTEeeee();
            secondnote.note = " Отходняк";
            secondnote.opisanie = " Не надо похмелиться";
            secondnote.date = DateTime.Today.AddDays(+1);

            NOTEeeee thirtynote = new NOTEeeee();
            thirtynote.note = " Наконец-то едааа";
            thirtynote.opisanie = " А вот теперь можно и нормально покушать";
            thirtynote.date = DateTime.Today.AddDays(+2);

            NOTEeeee firthnote = new NOTEeeee();
            firthnote.note = " Вспомнить про любимца";
            firthnote.opisanie = " Ну а на четвертый день, пора покормить кота";
            firthnote.date = DateTime.Today.AddDays(+3);

            NOTEeeee fivthnote = new NOTEeeee();
            fivthnote.note = " Нужно начать заниматься делами";
            fivthnote.opisanie = " Хочу сделать питон";
            fivthnote.date = DateTime.Today.AddDays(+4);

            NOTEeeee sixthnote = new NOTEeeee();
            sixthnote.note = " Надоело заниматься делами";
            sixthnote.opisanie = " Сегодня без питона";
            sixthnote.date = DateTime.Today.AddDays(+5);

            NOTEeeee seventhnote = new NOTEeeee();
            seventhnote.note = " Что?";
            seventhnote.opisanie = " Съездить на киевкский и побрить бомжа";
            seventhnote.date = DateTime.Today.AddDays(+6);


            int y_Position = 1;

            Dictionary<DateTime, NOTEeeee> Notes = new Dictionary<DateTime, NOTEeeee> { };
            Notes.Add(firstnote.date, firstnote);
            Notes.Add(secondnote.date, secondnote);
            Notes.Add(thirtynote.date, thirtynote);
            Notes.Add(firthnote.date, firthnote);
            Notes.Add(fivthnote.date, fivthnote);
            Notes.Add(sixthnote.date, sixthnote);
            Notes.Add(seventhnote.date, seventhnote);



            while (true)
            {
                Console.Clear();

                Console.WriteLine(date.ToString("dd.MM.yyyy"));

                foreach (var note in Notes)
                {
                    DateTime data = note.Key;
                    NOTEeeee nenot = note.Value;

                    if (date.ToString("dd.MM.yyyy") == data.ToString("dd.MM.yyyy"))
                    {
                        Console.WriteLine("  " + nenot.note);
                    }
                }

                while (true)
                {
                    Console.SetCursorPosition(0, y_Position);
                    Console.WriteLine("->");

                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        date = AddDay(date);
                        break;
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        date = RemoveDay(date);
                        break;
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {
                        DateTime selectedDate = date;

                        if (Notes.ContainsKey(selectedDate))
                        {
                            NOTEeeee selectedNote = Notes[selectedDate];
                            Console.Clear();
                            Console.WriteLine("Название: " + selectedNote.note);
                            Console.WriteLine(" ");
                            Console.WriteLine("Описание: " + selectedNote.opisanie);
                            Console.WriteLine(" ");
                            Console.WriteLine("Дата: " + selectedNote.date.ToString("dd.MM.yyyy"));

                            Console.WriteLine("\nНажмите Enter, чтобы вернуться к календарю...");
                            ConsoleKeyInfo returnKey = Console.ReadKey();
                            if (returnKey.Key == ConsoleKey.Enter)
                            {
                                break; 
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Нет заметки на выбранную дату.");
                            Console.WriteLine("\nНажмите Enter, чтобы вернуться к календарю...");
                            ConsoleKeyInfo returnKey = Console.ReadKey();
                            if (returnKey.Key == ConsoleKey.Enter)
                            {
                                break; 
                            }
                        }

                        Console.SetCursorPosition(0, y_Position);
                        Console.WriteLine("  ");

                        switch (key.Key)
                        {

                            case ConsoleKey.UpArrow:
                                if (y_Position != 1)
                                {
                                    y_Position--;
                                }
                                else if (y_Position == 1)
                                {
                                    y_Position = 3;
                                }
                                break;


                            case ConsoleKey.DownArrow:
                                if (y_Position != 3)
                                {
                                    y_Position++;
                                }
                                else if (y_Position == 3)
                                {
                                    y_Position = 1;
                                }
                                break;
                        }
                    }

                }
                static void Menu(ConsoleKeyInfo key)
                {

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("->");

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:

                            break;

                        case ConsoleKey.DownArrow:

                            break;
                    }
                }
                static DateTime AddDay(DateTime date)
                {
                    return date.AddDays(1);
                }
                static DateTime RemoveDay(DateTime date)
                {
                    return date.AddDays(-1);
                }
            }
        }
    }
}
