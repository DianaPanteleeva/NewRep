using System;

namespace ConsoleApplication3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("введите любое число");
            int a = int.Parse(Console.ReadLine());

            if (a % 2 == 0 && a % 10 == 0)
            {
                Console.WriteLine("число четное и кратно 10");
            }
            else
            {
                Console.WriteLine("число не является четным или кратным 10");
            }
        }
    }
}