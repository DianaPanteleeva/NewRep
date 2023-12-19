using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        double[] numbers = new double[10]; 
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = (random.NextDouble() - 0.5) * 20; // заполняем массив случайными дробными числами от -10 до 10
        }
        
        double[] positiveNumbers = new double[numbers.Length]; 
        double[] negativeNumbers = new double[numbers.Length]; // создаем массив с тем же размером, что и исходный массив

        int positiveIndex = 0; 
        int negativeIndex = 0; 
       
        foreach (double number in numbers)// разделение элементов исходного массива на положительные и отрицательные числа
        {
            if (number > 0)
            {
                positiveNumbers[positiveIndex] = number; 
                positiveIndex++; 
            }
            else if (number < 0)
            {
                negativeNumbers[negativeIndex] = number; 
                negativeIndex++;
            }
        }
        
        Array.Resize(ref positiveNumbers, positiveIndex);
        Array.Resize(ref negativeNumbers, negativeIndex);// уменьшение размера новых массивов до количества фактически добавленных элементов
        
        Console.WriteLine("Исходный массив:");
        foreach (double number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine("\n\nМассив с положительными числами:");
        foreach (double number in positiveNumbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine("\n\nМассив с отрицательными числами:");
        foreach (double number in negativeNumbers)
        {
            Console.Write(number + " ");
        }
    }
}