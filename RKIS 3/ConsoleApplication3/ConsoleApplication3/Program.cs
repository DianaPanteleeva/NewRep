using System; 
using System.IO; 

class MainClass { 
    public static void Main (string[] args) 
    { 
        string path = @"C:\Users\public.COPP\Desktop\input.txt"; 
        StreamReader reader = new StreamReader(path); 
        string[] lines = File.ReadAllLines(path);
        string[] selectedNumbers = lines[0].Split(' ');
        int n = int.Parse(lines[1]);//преобразуем в целое число
        string[] tickets = new string[n];
        for (int i = 0; i < n; i++)//чтение каждого лотерейного билета
        {
            tickets[i] = lines[i + 2];
        }
        string k = "";
        // Проверка билетов на выигрыш
        string[] results = new string[n];//массив для хр.результатов
        for (int i = 0; i < n; i++)
        {
            string[] numbers = tickets[i].Split(' ');
            int count = 0;
            for (int j = 0; j < 6; j++)//проверка каждого числа в билете
            {
                if (Array.IndexOf(selectedNumbers, numbers[j]) >= 0)//есть ли число из билета
                {
                    count++;
                }
            }
            results[i] = (count >= 3) ? "Lucky" : "Unlucky";
            k += results[i];
        }
        string r = @"C:\Users\public.COPP\Desktop\output.txt";
        using StreamWriter writer = new StreamWriter(r);
        writer.WriteLine(k);
        writer.Close();
    }
}

