using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<int> num = new List<int>();
        Console.WriteLine ("Введите число(для завершения введите 0)");
        while (true)
            
        {
            int a = int.Parse(Console.ReadLine());
            if (a == 0)
            {
                break;

            }
            num.Add(a);
        }
        int sum = 0;
        int mult = 1;
        foreach (int numbers in num)
        {
            sum += numbers;
            mult *= numbers;
        }
        double srednee = (double)sum / num.Count;
        Console.WriteLine($"Сумма всех чисел = {sum}, Произведение чисел = {mult}, Среднее = {srednee} ");
    }
}