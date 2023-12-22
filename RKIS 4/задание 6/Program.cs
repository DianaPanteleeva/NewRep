using System; 

class MainClass { 
    public static void Main (string[] args)
    {
        Console.Write("Введите значение координаты a = ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("Введите значение координаты b = ");
        float b = float.Parse(Console.ReadLine());

        if ((b >= -3) && (b <= (2 * a) + 2) && (b <= (-2 * a) + 2))
        {
            Console.WriteLine("Точка принадлежит заштрихованной области");
        }
        else
        {
            Console.WriteLine("Точка не приндалежит заштрихованной области");
        }
        Console.ReadLine();
    }
}