using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<string> strings = new List<string>();
        Console.WriteLine("Введите строку или пустую строку для завешения");
        string a = Console.ReadLine();
        while (true)
        {
            if (a == "")
            
                break;
            strings.Add(a);
        }
        string shortest = strings[0];
        string longest = strings[0];
        foreach (string str in strings)
        {
            if (str.Length < shortest.Length)
            {
                shortest = str;
            }
            else if (str.Length > longest.Length)
            {
                longest = str;
            }
            Console.WriteLine($"Самый короткий элемент из списка: {shortest}");
            Console.WriteLine($"Самый длинный элемент из списка:{longest}");
        }
    }
}   