using System;  
using System.IO; 
using System.Linq; 

class MainClass {  
    public static void Main (string[] args)  
    {  
        string path = @"C:\Users\public.COPP\Desktop\numsTask5.txt";  
        StreamReader reader = new StreamReader(path);
        string[] numbers = File.ReadAllText(path).Split(' ');
        int[] number = new int[numbers.Length];
       
        for (int i = 0; i < numbers.Length; i++) 
        { 
            number[i] = int.Parse(numbers[i]); //преобразуем строки целых чисел в формат int 
        }
        int min = number.Min();
        int max = number.Max();
        
        int sum = 0;
        int count = 0;
        int startIndex = Array.IndexOf(number, min) + 1; // Индекс следующего элемента после минимального
        int endIndex = Array.IndexOf(number, max); // Индекс максимального элемента

        for (int i = startIndex; i < endIndex; i++)
        {
            sum += number[i];
            count++;
        }
        
        double average = (double)sum / count;
        
        Console.WriteLine($"Среднее арифметическое элементов между минимальным и максимальным: {average}");
    }
}