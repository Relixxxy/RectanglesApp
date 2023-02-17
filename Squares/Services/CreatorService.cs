using Squares.Model;

namespace Squares.Services;

public static class CreatorService
{
    public static IList<Point> GeneratePoints(int size, int max)
    {
        var rand = new Random(DateTime.Now.Millisecond);
        var points = new List<Point>(20);

        for (int i = 0; i < size; i++)
        {
            Point point;
            do
            {
                point = new Point(rand.Next(1, max), rand.Next(1, max));
            }
            while (points.Contains(point));

            points.Add(point);
        }

        return points;
    }

    public static IList<Line> CreateLines(IList<Point> initialPoints)
    {
        var lines = new List<Line>();

        for (int i = 0; i < initialPoints.Count(); i++)
        {
            for (int j = i + 1; j < initialPoints.Count(); j++)
            {
                lines.Add(new (initialPoints[i], initialPoints[j]));
            }
        }

        return lines;
    }
}
