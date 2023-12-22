using System; 

class MainClass { 
    public static void Main (string[] args)
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double[,] x = new double[2, 2] { { -1, 3 }, { -2, 4 } };
        if (a >= x[0, 0] && a <= x[0, 1] && b >= x[1, 0] && b <= x[1, 1])
        {
            Console.WriteLine($"Точка с координатами ({a};{b}) принадлежит заштрихованной области");
        }
        else
        {
            Console.WriteLine($"Точка с координатами ({a};{b}) не принадлежит заштрихованной области");
        }
    }
}