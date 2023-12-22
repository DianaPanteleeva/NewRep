using System;

class Program
{
    static void Main()
    {
        int[,] mas = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            mas[0, i] = 1; //заполняем 1-ую строку "1"
            mas[i, 0] = 1; // заполняем 1 столбец "1"
            
        }

        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                mas[i, j] = mas[i - 1, j] + mas[i, j - 1]; //находим сумму верхнего и левого соседей
            }
        }

        for (int i = 0; i < 4; i++) //выводим всю матрицу
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(mas[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}