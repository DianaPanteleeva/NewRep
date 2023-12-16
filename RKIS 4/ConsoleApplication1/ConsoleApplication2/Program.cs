using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string path = @"C:\Users\public.COPP\Desktop\numsTask2.txt";
        StreamReader reader = new StreamReader(path);
        string[] nums = File.ReadAllText(path).Split(';');
        double sum = 0;
        double a = 0;
        foreach (string num in nums)
        {
            double.TryParse(num, out a);
            if (a <= 0)
            {
                break;
            }

            sum += a;
        }
        Console.WriteLine(sum);
    }
}