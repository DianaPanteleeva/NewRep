using System;

class Program
{
    static void Main()
    {
        int[] mas = new int[100];
        int a = 300;
        for (int i = 0; i < mas.Length; i++)
        {
            mas[i] = a;
            a -= 3;
        }

        for (int i = 0; i < mas.Length; i++)
        {
            Console.Write(mas[i] + " ");
        }
    }
}