using Rects.Model;
using Rects.Services.Interfaces;

namespace Rects.Services;

public class FinderService : IFinderService
{
    public IList<Rect> FindRects(IList<Line> lines)
    {
        var rects = new List<Rect>();
        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = i + 1; j < lines.Count; j++)
            {
                if (IsRect(lines[i], lines[j]))
                {
                    var rect = new Rect(lines[i], lines[j]);

                    if (!rects.Contains(rect))
                    {
                        rects.Add(rect);
                    }
                }
            }
        }

        return rects;
    }

    private bool IsRect(Line line1, Line line2)
    {
        if (line1.Length != line2.Length)
        {
            return false;
        }

        return IsParallel(line1, line2) && HasSameDiagonals(line1, line2);
    }

    private bool IsParallel(Line line1, Line line2)
    {
        double y1 = line1.Points.First().Y - line1.Points.Last().Y;
        double x1 = line1.Points.First().X - line1.Points.Last().X;

        double y2 = line2.Points.First().Y - line2.Points.Last().Y;
        double x2 = line2.Points.First().X - line2.Points.Last().X;

        return y1 / x1 == y2 / x2;
    }

    private bool HasSameDiagonals(Line line1, Line line2)
    {
        var linesFromA = new List<Line>()
        {
            new (line1.Points.First(), line2.Points.First()),
            new (line1.Points.First(), line2.Points.Last()),
        };

        var linesFromB = new List<Line>()
        {
            new (line1.Points.Last(), line2.Points.First()),
            new (line1.Points.Last(), line2.Points.Last()),
        };

        var isSameDiagonals = linesFromA.Max(l => l.Length) == linesFromB.Max(l => l.Length);
        var isSameSide = linesFromA.Min(l => l.Length) == linesFromB.Min(l => l.Length);

        return isSameDiagonals && isSameSide;
    }
}
