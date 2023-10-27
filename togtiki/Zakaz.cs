using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace togtiki
{
    internal class Zakaz
    {
        public static void neMain()
        {
            int price = 0;
            Cake cake = new Cake();



            while (true)
            {


                Console.WriteLine("Давай-ка заказывай какой торт желаешь!\nВыбирай какой торт будешь хавать!\n\n-------------------------------");

                Console.WriteLine("  Форма вашего тортика        |");
                Console.WriteLine("  Размер тортика              |");
                Console.WriteLine("  Вкус коржиков               |");
                Console.WriteLine("  Кол-во коржей               |");
                Console.WriteLine("  Глазурь                     |");
                Console.WriteLine("  Декор                       |");
                Console.WriteLine("  Конец заказа                |");
                Console.WriteLine("-------------------------------");

                Console.WriteLine("Цена твоего шедевра: " + price + "\nТвое чудо: " + " Форма - " + cake.form + "; Размер - " + cake.size + "; Вкус - " + cake.tasty + "; Количество - " + cake.count + "; Глазурь - " + cake.glaze + "; Декор - " + cake.decor + ";");

                int choiceuser = Menu.menushka(10);
                Console.WriteLine(choiceuser);
                switch (choiceuser)
                {
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Давай-ка заказывай какой торт желаешь!\nВыбирай какой торт будешь хавать!\n\n-------------------------------");

                        Console.WriteLine("  Круглая - 120");
                        Console.WriteLine("  Квадратная - 150");
                        Console.WriteLine("  параллелепипед - 700");
                        Console.WriteLine("  НЛО?? - 2000");

                        int choiceForm = Menu.menushka(7);

                        switch (cake.form)
                        {
                            case "Круглая":
                                price = price - 120;
                                break;
                            case "Квадратная":
                                price = price - 150;
                                break;
                            case "параллелепипед":
                                price = price - 700;
                                break;
                            case "НЛО??":
                                price = price - 2000;
                                break;

                        }

                        switch (choiceForm)
                        {
                            case 4:
                                cake.form = "Круглая";
                                price = price + 120;
                                break;

                            case 5:
                                cake.form = "Квадратная";
                                price = price + 150;
                                break;
                            case 6:
                                cake.form = "параллелепипед";
                                price = price + 700;
                                break;

                            case 7:
                                cake.form = "НЛО??";
                                price = price + 2000;
                                break;

                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Давай-ка заказывай какой торт желаешь!\nВыбирай какой торт будешь хавать!\n\n-------------------------------");

                        Console.WriteLine("  Огромный - 5000");
                        Console.WriteLine("  Большой - 3000");
                        Console.WriteLine("  Хиленький - 2000");
                        Console.WriteLine("  Нормальный - 1000");

                        int choiceSize = Menu.menushka(7);

                        switch (cake.size)
                        {
                            case "Огромный":
                                price = price - 5000;
                                break;
                            case "Большой":
                                price = price - 3000;
                                break;
                            case "Хиленький":
                                price = price - 2000;
                                break;
                            case "Нормальный":
                                price = price - 1000;
                                break;

                        }

                        switch (choiceSize)
                        {
                            case 4:
                                cake.size = "Огромный";
                                price = price + 5000;
                                break;

                            case 5:
                                cake.size = "Большой";
                                price = price + 3000;
                                break;
                            case 6:
                                cake.size = "Хиленький";
                                price = price + 2000;
                                break;

                            case 7:
                                cake.size = "Нормальный";
                                price = price + 1000;
                                break;

                        }
                        break;


                    case 6:
                        Console.Clear();
                        Console.WriteLine("Давай-ка заказывай какой торт желаешь!\nВыбирай какой торт будешь хавать!\n\n-------------------------------");

                        Console.WriteLine("  Чоколадка - 100");
                        Console.WriteLine("  Кремовый - 200");
                        Console.WriteLine("  Клубничка - 200");
                        Console.WriteLine("  Шикарный банан - 450");

                        int choiceTasty = Menu.menushka(7);



                        switch (cake.tasty)
                        {
                            case "Чоколадка":
                                price = price - 100;
                                break;
                            case "Кремовый":
                                price = price - 200;
                                break;
                            case "Клубничка":
                                price = price - 200;
                                break;
                            case "Шикарный банан":
                                price = price - 450;
                                break;

                        }
                        switch (choiceTasty)
                        {
                            case 4:
                                cake.tasty = "Чоколадка";
                                price = price + 100;
                                break;

                            case 5:
                                cake.tasty = "Кремовый";
                                price = price + 200;
                                break;
                            case 6:
                                cake.tasty = "Клубничка";
                                price = price + 200;
                                break;

                            case 7:
                                cake.tasty = "Шикарный банан";
                                price = price + 450;
                                break;

                        }
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("Давай-ка заказывай какой торт желаешь!\nВыбирай какой торт будешь хавать!\n\n-------------------------------");

                        Console.WriteLine("  1 cлой - 0");
                        Console.WriteLine("  2 слоя - 1000");
                        Console.WriteLine("  3 слоя - 2000");
                        Console.WriteLine("  4 слоя - 5000");

                        int choicecount = Menu.menushka(7);

                        switch (cake.count)
                        {
                            case 1:
                                price = price - 0;
                                break;
                            case 2:
                                price = price - 1000;
                                break;
                            case 3:
                                price = price - 2000;
                                break;
                            case 4:
                                price = price - 5000;
                                break;

                        }
                        switch (choicecount)
                        {
                            case 4:
                                cake.count = 1;
                                price = price + 0;
                                break;
                            case 5:
                                cake.count = 2;
                                price = price + 1000;
                                break;
                            case 6:
                                cake.count = 3;
                                price = price + 2000;
                                break;
                            case 7:
                                cake.count = 4;
                                price = price + 5000;
                                break;
                        }
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("Давай-ка заказывай какой торт желаешь!\nВыбирай какой торт будешь хавать!\n\n-------------------------------");

                        Console.WriteLine("  Черная - 120");
                        Console.WriteLine("  Белая - 200");
                        Console.WriteLine("  Серая - 10");
                        Console.WriteLine("  Коричневая - 200");

                        int choiceglaze = Menu.menushka(7);

                        switch (cake.glaze)
                        {
                            case "Черная":
                                price = price - 120;
                                break;
                            case "Белая":
                                price = price - 200;
                                break;
                            case "Серая":
                                price = price - 10;
                                break;
                            case "Коричневая":
                                price = price - 200;
                                break;

                        }

                        switch (choiceglaze)
                        {
                            case 4:
                                cake.glaze = "Черная";
                                price = price + 120;
                                break;
                            case 5:
                                cake.glaze = "Белая";
                                price = price + 200;
                                break;
                            case 6:
                                cake.glaze = "Серая";
                                price = price + 10;
                                break;
                            case 7:
                                cake.glaze = "Коричневая";
                                price = price + 200;
                                break;
                        }
                        break;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("Давай-ка заказывай какой торт желаешь!\nВыбирай какой торт будешь хавать!\n\n-------------------------------");

                        Console.WriteLine("  Звездочки - 100");
                        Console.WriteLine("  Круглишки - 200");
                        Console.WriteLine("  Шипики - 300");
                        Console.WriteLine("  Пирамидки - 500");

                        int choicedecor = Menu.menushka(7);

                        switch (cake.decor)
                        {
                            case "Звездочки":
                                price = price - 100;
                                break;
                            case "Круглишки":
                                price = price - 200;
                                break;
                            case "Шипики":
                                price = price - 300;
                                break;
                            case "Пирамидки":
                                price = price - 500;
                                break;

                        }

                        switch (choicedecor)
                        {
                            case 4:
                                cake.decor = "Звездочки";
                                price = price + 100;
                                break;
                            case 5:
                                cake.decor = "Круглишки";
                                price = price + 200;
                                break;
                            case 6:
                                cake.decor = "Шипики";
                                price = price + 300;
                                break;
                            case 7:
                                cake.decor = "Пирамидки";
                                price = price + 500;
                                break;
                        }
                        break;

                    case 10:
                        Console.Clear();
                        Console.WriteLine("Ты умница, сделал шикарный заказ, ожидай :)");
                        File.AppendAllText("C:\\Users\\MACHENIKE\\Documents\\cake.txt", "\n\nЗаказ: " + DateTime.Now);
                        File.AppendAllText("C:\\Users\\MACHENIKE\\Documents\\cake.txt", "\nТвое чудо: " + " Форма - " + cake.form + "; Размер - " + cake.size + "; Вкус - " + cake.tasty + "; Количество - " + cake.count + "; Глазурь - " + cake.glaze + "; Декор - " + cake.decor + "; ");
                        File.AppendAllText("C:\\Users\\MACHENIKE\\Documents\\cake.txt", "\nЦена: " + price);
                        break;



                }

                Console.Clear();
            }
        }
    }
}