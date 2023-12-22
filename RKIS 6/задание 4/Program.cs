using System; 
class Program
{
    static void Main()
    {
        Console.WriteLine("введите положительное число а");
        int a = int.Parse(Console.ReadLine());
        int sum = 0;

        while (true)
        {
            Console.WriteLine("введите число, для завершения введите отрицательное число ");
            int b = int.Parse(Console.ReadLine());
            if (b < 0)
            {
                break;
            }

            if (b % a == 0)
            {
                sum += b;
            }
        }
        Console.WriteLine($"сумма чисел, делящихся на {a} нацело = {sum}");
    }
}