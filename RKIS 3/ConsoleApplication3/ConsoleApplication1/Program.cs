using System.IO;
using System.Runtime.CompilerServices;

namespace ConsoleApplication3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\public.COPP\Desktop\nums.txt";
            using StreamReader reader = new StreamReader(path);
            string numbersStr = reader.ReadToEnd();
            reader.Close();
            string[] numbers = numbersStr.Split(' ');
            string a = ""; //строка для хранения нечетных чисел
            foreach (var number in numbers) //перебор всех чисел из файла
            {
                int num;
                if (int.TryParse(number, out num)) // проверяем, яв-ся ли число целым
                {
                    if (num % 2 != 0)
                    {
                        a += number + " ";
                    }
                }
            }

            using StreamWriter writer = new StreamWriter(path);
            writer.Write(a);
            writer.Close();
        }
    }
}

