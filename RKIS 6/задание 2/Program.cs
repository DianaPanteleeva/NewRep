using System;
using System.IO;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Pante\Desktop\numsTask2.txt";
            StreamReader reader = new StreamReader(path);
            string line = "";
            
            while (!reader.EndOfStream)//достигнут ли конец файла
            {
                string word = reader.ReadLine();
                line += word + " "; //считывается каждая строка из файла и добавляется к переменной line
            }
            
            Console.WriteLine(line);
            reader.Close();
        }
    }
}