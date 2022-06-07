using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class TaskDB
    {
        static private readonly List<Task> listTask = new List<Task>();

        static public Task GetTask(int numberTask) 
        {
            return TaskDB.listTask[numberTask - 1];
        }
        private TaskDB() { }
        static public void AddTask(Task task)
        {
            BlackOnWhiteSubtitle("Введите заголовок задачи: ");
            task.TaskName = Console.ReadLine();
            BlackOnWhiteSubtitle("Введите описание задачи: ");
            task.TaskDescription = Console.ReadLine();
            listTask.Add(task);
        }

        static public void ViewTaskList()
        {
            for (int i = 0; i < listTask.Count; i++)
            {
                Console.WriteLine("{0}. {1}", (i + 1), listTask[i].TaskName);
            }
        }

        static public void CompleteTask(Task task)
        {
            listTask.Remove(task);
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
