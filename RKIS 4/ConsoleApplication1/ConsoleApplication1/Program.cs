using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int product = 1;
        for (int i = 3; i <= n; i += 3)
        {
            product *= i;
            
        }
        Console.WriteLine(product);

    }
}