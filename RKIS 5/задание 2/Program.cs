using System;    
using System.IO;

class MainClass {    
    public static void Main (string[] args)    
    {    
        string path = @"C:\Users\Pante\Desktop\numsTask2.txt";    
        StreamReader reader = new StreamReader(path); 
        string lines = reader.ReadLine(); 
 
        string[] numStrings = lines.Split(';'); 
        double[] numbers = new double[numStrings.Length]; 
        for (int i = 0; i < numbers.Length; i++) 
        { 
            numbers[i] = double.Parse(numStrings[i]); //преобр. в вещественное число
        } 
        reader.Close(); 
        
        for (int i = 0; i < numbers.Length - 1; i++)//перебираем каждый элемент массива кроме последнего 
        { 
            int minIndex = i; 
            for (int j = i + 1; j < numbers.Length; j++) 
            { 
                if (numbers[j] < numbers[minIndex]) //находим инд. наименьшего числа 
                { 
                    minIndex = j; 
                } 
            } 
            double temp = numbers[i];//меняем текущий элемент с элементом с мин.знач 
            numbers[i] = numbers[minIndex]; 
            numbers[minIndex] = temp; 
        } 
 
        StreamWriter writer = new StreamWriter(path); 
        foreach (double num in numbers) 
        { 
            writer.Write(num + ";"); 
        } 
        writer.Close(); 
    }   
}