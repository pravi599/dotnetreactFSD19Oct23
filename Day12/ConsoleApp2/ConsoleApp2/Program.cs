
using System;

public class Program
{
    public static void DrawParallelogram(int width, int height)
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 0; k < width; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        int width = Convert.ToInt32(Console.ReadLine());
        int height = Convert.ToInt32(Console.ReadLine());
        DrawParallelogram(width, height);
    }
}

