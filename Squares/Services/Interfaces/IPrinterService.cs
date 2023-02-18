using Rects.Model;

namespace Rects.Services.Interfaces;

public interface IPrinterService
{
    void PrintCoordinateSys(IList<Point> points, int size);
    void PrintResult(IList<Rect> rects);
}
