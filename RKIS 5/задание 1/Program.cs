using System;  
using System.IO; 
using System.Linq; 

class MainClass {  
    public static void Main (string[] args)  
    {  
        string path = @"C:\Users\public.COPP\Desktop\numsTask1.txt";  
        StreamReader reader = new StreamReader(path);
        string[] numbers = File.ReadAllText(path).Split(' ');
        int[] Intnumbers = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            Intnumbers[i] = int.Parse(numbers[i]);
        }
        int min = Array.IndexOf(Intnumbers,Intnumbers.Min()); 
        int minIndex = 0; 
        for (int i = 1; i < numbers.Length; i++) //находим мин.элемент и его индекс
        { 
            if (Intnumbers[i] < min) 
            { 
                min = Intnumbers[i]; 
                minIndex = i; 
            } 
        } 
        
        int product = 1; 
        for (int i = minIndex + 1; i < numbers.Length; i++) 
        { 
            product *= Intnumbers[i]; 
        } 
        Console.WriteLine($"произведение элементов после минимального = {product}"); 
    } 
}