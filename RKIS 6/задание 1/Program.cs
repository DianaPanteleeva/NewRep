using System;  
using System.IO;

class MainClass {  
    public static void Main (string[] args)  
    {  
        string path = @"C:\Users\Pante\Desktop\numsTask1.txt";  
        StreamReader reader = new StreamReader(path);
        string line = reader.ReadLine();
        
        string word = "";
        
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] != ' ')
            {
                word += line[i];
            }
            else
            {
                if (word.Length % 2 != 0)
                {
                    Console.WriteLine(word);
                }

                word = "";
            }
        }
        if (word.Length % 2 != 0)
        {
            Console.WriteLine(word);
        }
        reader.Close();
    }
}