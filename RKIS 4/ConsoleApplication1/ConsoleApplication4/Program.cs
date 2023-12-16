using System; 
using System.IO;

class MainClass
{
    public static void Main(string[] args)
    {
        string path = @"C:\Users\public.COPP\Desktop\Task4.txt";
        StreamReader reader = new StreamReader(path);
        string[] numbers = File.ReadAllText(path).Split(' ');
        int count = 0;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                count++;
            }
        }

        Console.WriteLine(count);

    }
}