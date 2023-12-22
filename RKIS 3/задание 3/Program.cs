using System; 
using System.IO; 

class MainClass { 
    public static void Main (string[] args) 
    { 
        string path = @"C:\Users\public.COPP\Desktop\height.txt"; 
        StreamReader reader = new StreamReader(path); 
        string lines = reader.ReadLine(); 
        reader.Close(); 
        int[] height = new int[lines.Length]; 
        for (int i = 0; i < lines.Length; i++) //для обработки каждой строки в массиве
        { 
            height[i] = int.Parse(lines[i].ToString()); //строку в целое число
        }
        int r = 0;
        int maxArea = 0; 
        int left = 0; 
        int right = height.Length - 1; 

        while (left < right) 
        { 
            int area = Math.Min(height[left], height[right]) * (right - left); // мин.высота линии на расстр.между ними
            if (area > maxArea) 
            { 
                maxArea = area; 
            } 

            if (height[left] < height[right]) 
            { 
                left++; 
            } 
            else 
            { 
                right--; 
            }
            
        } r += maxArea;
        string output = @"C:\Users\public.COPP\Desktop\output.txt"; 
        StreamWriter writer = new StreamWriter(output); 
        writer.WriteLine(r); 
        writer.Close();
    } 
}