using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    class Task
    {
        public string Name { get; set; }
        public string Description {get;set;}
        public DateTime PeriodOfExecution { get; set;}
    }

    internal class Program
    {
        private static List<Task> tasks = new List<Task>();
        private static string filePath = "tasks.json";

        static void Main()
        {
            LoadTasks();

            while (true)
            {
                Console.WriteLine("A. Добавить задачу");
                Console.WriteLine("B. Удалить задачу");
                Console.WriteLine("C. Редактировать задачу");
                Console.WriteLine("D. Посмотреть все задачи на сегодня");
                Console.WriteLine("E. Посмотреть все задачи на завтра");
                Console.WriteLine("F. Посмотреть все задачи на неделю");
                Console.WriteLine("G. Посмотреть список всех задач");
                Console.WriteLine("H. Посмотреть список предстоящих задач");
                Console.WriteLine("I. Посмотреть список прошедших задач");
                Console.WriteLine("0. Выйти");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "A":
                        AddTask();
                        break;
                    case "B":
                        DeleteTask();
                        break;
                    case "C":
                        EditTask();
                        break;
                    case "D" :
                        ViewTheTasksForDate(DateTime.Today);
                        break;
                    case "E":
                        ViewTheTasksForDate(DateTime.Today.AddDays(1));
                        break;
                    case "F":
                        ViewTheTasksForWeek();
                        break;
                    case "G":
                        ViewTheListOfAllTasks();
                        break;
                    case "H":
                        ViewUpcomingTasks();
                        break;
                    case "I":
                        ViewPastTasks();
                        break;
                    case "0":
                        SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Нет такого варианта выбора");
                        break; 
                }
            }
        }

        static void AddTask()  // метод для добавления задачи
        {
            Console.WriteLine("Введите название задачи:");
            string name = Console.ReadLine();
            Console.WriteLine("Добавьте описание задачи:");
            string description = Console.ReadLine();
            Console.WriteLine("Введите дату выполнения задачи в формате ГГГГ-ММ-ДД:");
            DateTime periodOfExecution = DateTime.Parse(Console.ReadLine());

            Task newTask = new Task { Name = name, Description = description, PeriodOfExecution = periodOfExecution };
            tasks.Add(newTask);
        }

        static void DeleteTask() // метод удаления задач
        {
            Console.WriteLine("Введите номер задачи, которую хотите удалить:");
            int num = int.Parse(Console.ReadLine()) -1;
            if (num >= 0 && num < tasks.Count)
            {
                tasks.RemoveAt(num);
            }
            else
            {
                Console.WriteLine("Нет такого варианта выбора");
            }
        }

        static void EditTask()  //метод для редактирования задачи
        {
            Console.WriteLine("Введите номер задачи для редактирования:");
            int num = int.Parse(Console.ReadLine()) -1;
            if (num >= 0 && num < tasks.Count)
            {
               Console.WriteLine("Введите новое название задачи:");
               tasks[num].Name = Console.ReadLine();
               Console.WriteLine("Введите новое описание задачи");
               tasks[num].Description = Console.ReadLine();
               Console.WriteLine("Введите новую дату выполнения задачи");
               tasks[num].PeriodOfExecution = DateTime.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Некорректный номер задачи");
            }
        }

        static void ViewTheTasksForDate(DateTime date) //метод просмотра задач на сегодня
        {
            Console.WriteLine($"Все задачи на {date.ToShortDateString()}:");
            foreach (var task in tasks)
            {
                if (task.PeriodOfExecution == date.Date)
                {
                    Console.WriteLine($"{task.Name} ({task.Description})");
                }
            }
        }

        static void ViewTheTasksForWeek()  //метод просмотра задач на неделю
        {
            DateTime today = DateTime.Today;
            for (int i = 0; i < 7; i++)
            {
                ViewTheTasksForDate(today.AddDays(i));
            }
        }

        static void ViewTheListOfAllTasks()  //список всех задач
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i+1}.{tasks[i].Name} ({tasks[i].Description}) {tasks[i].PeriodOfExecution.ToShortDateString()}");
            }
        }

        static void ViewUpcomingTasks()  //предстоящие задачи
        {
            Console.WriteLine("Предстоящие задачи:");
            foreach (var task in tasks)
            {
                if (task.PeriodOfExecution >= DateTime.Today)
                {
                    Console.WriteLine($"{task.Name} ({task.Description})-Дата выполнения: {task.PeriodOfExecution.ToShortDateString()}");
                }
            }
        }

        static void ViewPastTasks()  //прошедшие задачи
        {
            Console.WriteLine("Прошедшие задачи:");
            foreach (var task in tasks)
            {
                if (task.PeriodOfExecution < DateTime.Today)
                {
                    Console.WriteLine($"{task.Name} ({task.Description})-Дата выполнения: {task.PeriodOfExecution.ToShortDateString()}");
                }
            }
        }

        static void SaveTasks()  //сохранение задач в json файл
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filePath,json);
        }

        static void LoadTasks()  //загрузка задач из файла
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks =  JsonConvert.DeserializeObject<List<Task>>(json);
            }
        } 
    }
}