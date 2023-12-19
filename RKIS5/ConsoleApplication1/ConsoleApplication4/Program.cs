using System;   
using System.IO;  
using System.Linq;  

class MainClass {   
    public static void Main (string[] args)   
    {   
        string path = @"C:\Users\public.COPP\Desktop\numsTask4.txt";   
        StreamReader reader = new StreamReader(path);
        string lines = reader.ReadLine();

        int [] nums = Array.ConvertAll(lines.Split(' '), int.Parse);
        reader.Close();
        int sum = 0;
        int max = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > max)//проверка, яв-ся ли текущее число макс.
            {
                max = nums[i];
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (Math.Abs(nums[i] - max) == 1) //отличается ли текущее число от макс. на 1
            {
                sum += nums[i];
            }
        }
        Console.WriteLine(sum);
    }  
}