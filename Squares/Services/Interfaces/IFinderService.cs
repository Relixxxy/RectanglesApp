using Rects.Model;

namespace Rects.Services.Interfaces;

public interface IFinderService
{
    IList<Rect> FindRects(IList<Line> lines);
}
