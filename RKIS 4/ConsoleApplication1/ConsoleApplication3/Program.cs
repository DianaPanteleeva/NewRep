using System; 
using System.IO;

class MainClass
{
    public static void Main(string[] args)
    {
        string path = @"C:\Users\public.COPP\Desktop\numsTask3.txt";
        StreamReader reader = new StreamReader(path);
        string[] numbersStr = File.ReadAllText(path).Split(',');
        int[] numbers = Array.ConvertAll(numbersStr, s => int.Parse(s));
        int min = Int32.MaxValue;
        int max = Int32.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            int num = int.Parse(numbers[i].ToString());
            if (num == 0)
            {
                break;
            }
            if (num < min)
            {
                min = num;
            }

            if (num > max)
            {
                max = num;
            }
        }
        double ratio = (double)min / max;
        Console.Write(ratio);
    }
}