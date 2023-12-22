using System;

class Program
{
    static void Main()
    {
        int[] mas = new int[10];
        int a = 1;
        for (int i = 0; i < mas.Length; i++)
        {
            mas[i] = a;
            a += 2;
        }
        for (int i = 0; i < mas.Length; i++)
        {
            Console.Write(mas[i] + " ");
        }
    }
}