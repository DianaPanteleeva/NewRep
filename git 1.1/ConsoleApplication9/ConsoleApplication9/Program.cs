using System;

namespace ConsoleApplication9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(1, 100);
                Console.WriteLine(numbers[i]);
            }
            int minIndex = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[minIndex])
                {
                    minIndex = i;
                }
            } 
            Console.WriteLine($"Номер минимального элемента:{minIndex}");

        }
    }
}