

using Squares.Model;

namespace Squares.Services;

public static class PrinterService
{
    public static void PrintCoordinateSys(IList<Point> points, int size)
    {
        int height = size;
        int width = size;

        Console.WriteLine("↑");
        for (int i = height - 1; i > 0; i--)
        {
            Console.Write($"{i}");

            for (int j = 0; j < width; j++)
            {
                if (points.FirstOrDefault(p => p.X == j && p.Y == i) is not null)
                {
                    Console.Write($"*({j},{i})");
                }

                Console.Write("\t");
            }

            Console.WriteLine("\n|\n|");
        }

        Console.Write(0);

        for (int i = 1; i <= width; i++)
        {
            Console.Write($"-------{i}");
        }

        Console.WriteLine(">");
    }
}
