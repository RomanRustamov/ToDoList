using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    static class Menu
    {
        static public void Show(int selectedItemNum)
        {
            if(selectedItemNum == 1)
            {
                Console.Clear();
                BlackOnWhiteSubtitle("1. Создать задачу");
                Console.WriteLine("2. Просмотреть список текущих задач");
                Console.WriteLine("3. Выход");
            }
            else if(selectedItemNum == 2)
            {
                Console.Clear();
                Console.WriteLine("1. Создать задачу");
                BlackOnWhiteSubtitle("2. Просмотреть список текущих задач");
                Console.WriteLine("3. Выход");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("1. Создать задачу");
                Console.WriteLine("2. Просмотреть список текущих задач");
                BlackOnWhiteSubtitle("3. Выход");
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
