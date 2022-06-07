using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    static class MenuItemCreateTask
    {
        static public void Show(int selectedItem)
        {
            Task newTask = new Task();
            TaskDB.AddTask(newTask);
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Задача добавлена в список задач!");
                Console.ResetColor();
                BlackOnWhiteSubtitle("Создать задачу");
                Console.WriteLine("Выйти в меню");
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter) continue;
                else if(cki.Key == ConsoleKey.DownArrow) 
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Задача добавлена в список задач!");
                    Console.ResetColor();
                    Console.WriteLine("Создать задачу");
                    BlackOnWhiteSubtitle("Выйти в меню");

                }

            }
        }
        static private void BlackOnWhiteSubtitle(string menuItem)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(menuItem);
            Console.ResetColor();
        }
    }
}
