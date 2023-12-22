using System; 
using System.IO;
using System.Linq;

class MainClass { 
    public static void Main (string[] args) 
    { 
       
        string path = @"C:\Users\public.COPP\Desktop\numsTask3.txt";  
        StreamReader reader = new StreamReader(path); 

        string[] numbers = File.ReadAllText(path).Split(' ');
        int[] intNumbers = new int[numbers.Length];//массив для хранения чисел в формате int
        for (int i = 0; i < numbers.Length; i++)
        {
            intNumbers[i] = int.Parse(numbers[i]); //преобразуем строки целых чисел в формат int
        }

        int minIndex = Array.IndexOf(intNumbers, intNumbers.Min());
        if (minIndex > 0)
        {
            int sum = 0;
            for (int i = 0; i < minIndex; i++)
            {
                sum += intNumbers[i];
            }

            double a = (double)sum / minIndex;
            Console.WriteLine($"среднее арифметическое элементов до минимального = {a}");
        }
        else
        {
            Console.WriteLine("невозможно найти ср.арифметическое(элемент находится в начале массива)");
        }
    }
}