using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите начало диапазона:");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите конец диапазона:");
        int end = int.Parse(Console.ReadLine());
        int[] array = RandomArray(start, end);
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
    }
    
    static int[] RandomArray(int start, int end)
    {
        Random rnd = new Random();
        int[] array = new int[10];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(start, end +1);
        }
        return array;
    }
}