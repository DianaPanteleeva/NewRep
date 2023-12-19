using System;   
using System.IO;  
using System.Linq;  

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("введите кол-во строк");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("введите кол-во столбцов");
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            Console.WriteLine("введите элементы матрицы");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = int.Parse(Console.ReadLine());
                }
                Console.Write(a[n,m]);
            }

            int[,] newA = new int[n, m + 1];//создаем новую матрицу
            for (int i = 0; i < n; i++)//копируем элементы из 1ой матрицы
            {
                for (int j = 0; j < m; j++)
                {
                    newA[i, j] = a[i, j];
                }
            }

            for (int i = 0; i < n; i++)//добавляем новый столбец с чет.кол-вом единиц
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] == 1)
                    {
                        count++;
                    }
                }

                newA[i, m] = count % 2 == 0 ? 0 : 1;
            }
            Console.WriteLine("новая матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m+1; j++)
                {
                    Console.Write(newA[i,j]+ " "); 
                }
                Console.WriteLine();
            }

        }
    }
}