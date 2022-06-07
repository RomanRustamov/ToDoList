using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    {
        static private void BlackOnWhiteSubtitle(string menuItem)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(menuItem);
            Console.ResetColor();
        }

        private static void PrintColorText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.Title = "Добро пожаловать в ListTask!";
            Console.CursorVisible = false;
            while (true)
            {
                begin:
                Menu.Show(1);
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    while (true)
                    {
                        Menu.Show(2);
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.UpArrow)
                            break;
                        else if (cki.Key == ConsoleKey.DownArrow)
                            while (true)
                            {
                                Menu.Show(3);
                                cki = Console.ReadKey();
                                if (cki.Key == ConsoleKey.UpArrow) break;
                                else if (cki.Key == ConsoleKey.DownArrow) goto begin;
                                else if (cki.Key == ConsoleKey.Enter) return;
                            }
                        else if(cki.Key == ConsoleKey.Enter)
                        {
                            while (true)
                            {
                                Console.Clear();
                                BlackOnWhiteSubtitle("Список текущих задач:\n");
                                TaskDB.ViewTaskList();
                                Console.WriteLine("\n0. Выход в меню\n");
                                Console.Write("Введите номер задачи для её просмотра и нажмите \"Enter\": ");
                                var taskNumber = int.Parse(Console.ReadLine());
                                if (taskNumber == 0) break;
                                Console.Clear();
                                PrintColorText(ConsoleColor.DarkYellow, $"{TaskDB.GetTask(taskNumber).TaskName}:");
                                Console.WriteLine($"\t{TaskDB.GetTask(taskNumber).TaskDescription}\n");
                                Console.WriteLine("\n1. Завершить задачу\n0. Вернуться к списку задач");
                                Console.Write("Введите номер пункта меню и нажмите \"Enter\": ");
                                var n = int.Parse(Console.ReadLine());
                                if (n == 1)
                                {
                                    TaskDB.CompleteTask(TaskDB.GetTask(taskNumber));
                                    Console.Clear();
                                    Console.WriteLine("Задача выполнена!\n\nНажмите любую клавишу для возвращения к списку задач...");
                                    Console.ReadKey();
                                }
                            }

                        }
                    }
                }
                else if(cki.Key == ConsoleKey.UpArrow)
                {
                    while (true)
                    {
                        Menu.Show(3);
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.DownArrow)
                            break;
                        else if (cki.Key == ConsoleKey.UpArrow)
                            while (true)
                            {
                                Menu.Show(2);
                                cki = Console.ReadKey();
                                if (cki.Key == ConsoleKey.DownArrow) break;
                                if (cki.Key == ConsoleKey.UpArrow) goto begin;
                            }
                        else if (cki.Key == ConsoleKey.Enter) return;
                    }

                }
                else if(cki.Key == ConsoleKey.Enter)
                {
                    while (true)
                    {
                        Console.Clear();
                        Task newTask = new Task();
                        TaskDB.AddTask(newTask);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        while (true)
                        {
                            Console.Clear();
                            PrintColorText(ConsoleColor.Magenta, "Задача добавлена в список задач!");
                            BlackOnWhiteSubtitle("\nСоздать задачу");
                            Console.WriteLine("Выйти в меню");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter) continue;
                            else if (cki.Key == ConsoleKey.DownArrow || cki.Key == ConsoleKey.UpArrow)
                            {
                                Console.Clear();
                                PrintColorText(ConsoleColor.Magenta, "Задача добавлена в список задач!");
                                Console.WriteLine("\nСоздать задачу");
                                BlackOnWhiteSubtitle("Выйти в меню");
                                cki = Console.ReadKey();
                                if (cki.Key == ConsoleKey.Enter) goto begin;
                                else if (cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.DownArrow) continue;
                            }
                        }
                    }
                }
            }
        }
    }
}
