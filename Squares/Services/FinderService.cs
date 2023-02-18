using Squares.Model;

namespace Squares.Services;

public static class FinderService
{
    public static IList<Square> FindSquares(IList<Line> lines)
    {
        var squares = new List<Square>();
        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = i + 1; j < lines.Count; j++)
            {
                if (IsSquare(lines[i], lines[j]))
                {
                    var square = new Square(lines[i], lines[j]);

                    if (!squares.Contains(square))
                    {
                        squares.Add(square);
                    }

                }
            }
        }

        return squares;
    }

    private static bool IsSquare(Line line1, Line line2)
    {
        if (line1.Length != line2.Length)
        {
            return false;
        }

        return IsParallel(line1, line2) && HasSameDiagonals(line1, line2);
    }

    private static bool IsParallel(Line line1, Line line2)
    {
        double y1 = line1.Points.First().Y - line1.Points.Last().Y;
        double x1 = line1.Points.First().X - line1.Points.Last().X;

        double y2 = line2.Points.First().Y - line2.Points.Last().Y;
        double x2 = line2.Points.First().X - line2.Points.Last().X;

        return y1 / x1 == y2 / x2;
    }

    private static bool HasSameDiagonals(Line line1, Line line2)
    {
        var linesFromA = new List<Line>()
        {
            new(line1.Points.First(), line2.Points.First()),
            new(line1.Points.First(), line2.Points.Last()),
        };

        var linesFromB = new List<Line>()
        {
            new(line1.Points.Last(), line2.Points.First()),
            new(line1.Points.Last(), line2.Points.Last()),
        };

        var isSameDiagonals = linesFromA.Max(l => l.Length) == linesFromB.Max(l => l.Length);
        var isSameSide = linesFromA.Min(l => l.Length) == linesFromB.Min(l => l.Length);

        return isSameDiagonals && isSameSide;
    }
}
