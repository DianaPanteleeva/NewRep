using System;
using System.ComponentModel;

class Program
{ 
    static void Main()
    {
        int[,] temperature = new int[12, 30];
        Random rnd = new Random();
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                temperature[i, j] = rnd.Next(-10, 30); //генерация случайной температуры
            }
        }
        int[] averagetemperature = CalculateAverageTemperatures(temperature); //создаем массив из средних температур
        Array.Sort(averagetemperature); //сортируем ср.тем. по возрастанию
        for (int i = 0; i < averagetemperature.Length; i++)
        {
            Console.WriteLine($"средняя температура в месяце {i + 1}: {averagetemperature[i]} градусов");
        }
    }
    static int[] CalculateAverageTemperatures(int[,] temperature)
    {
        int[] averageTemperature = new int [12];
        for (int i = 0; i < 12; i++)
        {
            int sum = 0;
            for (int j = 0; j < 30; j++)
            {
                sum += temperature[i, j];
            }
            averageTemperature[i] = sum / 30;
        }
        return averageTemperature;
    }
}