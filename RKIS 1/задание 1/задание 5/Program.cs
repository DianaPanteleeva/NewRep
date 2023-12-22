using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку");
        string a = Console.ReadLine();
        string[] words = a.Split(' ');
        Console.WriteLine($"количество слов в строке:{words.Length}");
        string result = "Start " + a + " End";
        Console.WriteLine(result);
    }
}