using System;
using System.Collections.Generic;

namespace RKIS
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string[] months = new string [12] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};

            Dictionary<string, int[]> Pogoda = new Dictionary<string, int[]>();

            Random rnd = new Random();
            
           for (int i = 0; i < 12; i++)
            {
                int[] temperature = new int[30];
                for (int j = 0; j < temperature.Length; j++)
                {
                    temperature[j] = rnd.Next(-20, 30);
                }
                Pogoda.Add(months[i], temperature);
            }

            Console.WriteLine("Погода на каждый месяц :");
            foreach (var d in Pogoda)
            {
                Console.Write($"{d.Key}: ");
                for (int i = 0; i < d.Value.Length; i++)
                {
                    Console.Write($"{d.Value[i]};  ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Средняя температура за каждый месяц: ");
            Dictionary<string, double> TempSr = FindSrTemp(Pogoda);

            foreach (var d in TempSr)
            {
                Console.WriteLine($"За {d.Key} = {d.Value}");
            }
        }
      
      public static  Dictionary<string, double> FindSrTemp(Dictionary<string, int[]> dict)
        {
            Dictionary<string, double> TempSr = new Dictionary<string, double>();
            
           string[] months = new string [12] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};

            int number_month = 0;
            foreach (var d in dict)
            {
                double sum = 0;
                for (int j = 0; j < d.Value.Length; j++)
                {
                    sum += d.Value[j];
                }
                double srednee = Math.Round((sum / d.Value.Length),  2);
                TempSr.Add(months[number_month], srednee);
                number_month++ ;
            }
            
           return TempSr;
        }
        
   }
}
