using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> strings = new List<string>();
        Console.WriteLine("Введите строку или пустую строку для завешения");
        string a = Console.ReadLine();

        while (!string.IsNullOrEmpty(a)) //пока не ввели пустую строку
        {
            strings.Add(a);
            a = Console.ReadLine();
        }

        if (strings.Count > 0)  //в списке есть хотя-бы 1 элемент
        {
            string shortest = strings[0];
            string longest = strings[0];

            for (int i = 1; i < strings.Count; i++)
            {
                if (strings[i].Length < shortest.Length)
                {
                    shortest = strings[i];
                }

                if (strings[i].Length > longest.Length)
                {
                    longest = strings[i];
                }
            }
            Console.WriteLine($"Самый короткий элемент из списка: {shortest}");
            Console.WriteLine($"Самый длинный элемент из списка: {longest}");
        }
        else
        {
            Console.WriteLine("Список пуст");
        }
    }
}