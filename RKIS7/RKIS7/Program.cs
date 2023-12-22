using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace RKIS7
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
        private static string filePath = "tasks.json";  //путь к файлу с задачами
        
        static void Main()
        {
            LoadTasks(); //загрузка задач из файла

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
        
        static void AddTask() //метод добавления задачи
        {
            try
            {
                Console.WriteLine("Введите название задачи:");
                string name = Console.ReadLine();
                Console.WriteLine("Добавьте описание задачи:");
                string description = Console.ReadLine();
                Console.WriteLine("Введите дату выполнения задачи в формате ГГГГ-ММ-ДД:");
                DateTime periodOfExecution = DateTime.Parse(Console.ReadLine());

                Task newTask = new Task
                    { Name = name, Description = description, PeriodOfExecution = periodOfExecution };
                tasks.Add(newTask);
                SaveTasks();
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Неверный формат даты");
            }
        }

        static void DeleteTask()  //метод удаления задачи
        {
            try
            {
                Console.WriteLine("Введите номер задачи, которую хотите удалить");
                int num;
                if (int.TryParse(Console.ReadLine(), out num) && num > 0 && num <= tasks.Count)
                {
                    tasks.RemoveAt(num - 1);
                    SaveTasks();
                }
                else
                {
                    Console.WriteLine("Неверный номер задачи");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Неверный формат номера задачи");
            }
        }

        static void EditTask()  //метод редактирования задачи
        {
            try
            {
                Console.WriteLine("Введите номер задачи, которую хотите отредактировать");
                int num;
                if (int.TryParse(Console.ReadLine(), out num) && num > 0 && num <= tasks.Count)
                {
                    Task taskToEdit = tasks[num - 1];
                    Console.WriteLine("Введите новое название задачи:");
                    taskToEdit.Name = Console.ReadLine();
                    Console.WriteLine("Введите новое описание задачи:");
                    taskToEdit.Description = Console.ReadLine();
                    Console.WriteLine("Введите новую дату выполнения задачи в формате ГГГГ-ММ-ДД:");
                    DateTime newDate;
                    if (DateTime.TryParse(Console.ReadLine(), out newDate))
                    {
                        taskToEdit.PeriodOfExecution = newDate;
                        SaveTasks();
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный номер задачи");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Неверный формат номера задачи");
            }
        }

        static void ViewTheTasksForDate(DateTime date)  // метод просмотра задач на сегодня
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
            for (int i = 0; i<tasks.Count; i++)
            {
                Console.WriteLine($"{i+1}.{tasks[i].Name}({tasks[i].Description}) - Дата выполнения: {tasks[i].PeriodOfExecution.ToShortDateString()}");
            }
        }

        static void ViewUpcomingTasks()  //список предстоящих задач
        {
            Console.WriteLine("Предстоящие задачи");
            foreach (var task in tasks)
            {
                if (task.PeriodOfExecution >= DateTime.Today)
                {
                    Console.WriteLine($"-{task.Name} ({task.Description}) - Дата выполнения: {task.PeriodOfExecution.ToShortDateString()}");
                }
            }
        }

        static void ViewPastTasks()  //список прошедших задач
        {
            Console.WriteLine("Прошедшие задачи:");
            foreach (var task in tasks)
            {
                if (task.PeriodOfExecution < DateTime.Today)
                {
                    Console.WriteLine($"-{task.Name} ({task.Description})- Дата выполнения: {task.PeriodOfExecution.ToShortDateString()}");
                }
            }
        }

        static void SaveTasks()  //метод сохранения задач
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filePath,json);
        } 
        static void LoadTasks() //метод загрузки задач из json файла
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonConvert.DeserializeObject<List<Task>>(json);
            }
        }
    }
}