using Rects.Model;
using Rects.Services.Interfaces;

namespace Rects.Services;

public class PrinterService : IPrinterService
{
    public void PrintCoordinateSys(IList<Point> points, int size)
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

    public void PrintResult(IList<Rect> rects)
    {
        Console.WriteLine("Result");
        foreach (var rect in rects)
        {
            Console.WriteLine(rect);
        }
    }
}
