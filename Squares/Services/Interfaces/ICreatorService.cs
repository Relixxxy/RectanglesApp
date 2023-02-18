using Rects.Model;

namespace Rects.Services.Interfaces;

public interface ICreatorService
{
    IList<Point> GeneratePoints(int size, int max);
    IList<Line> CreateLines(IList<Point> initialPoints);
}
