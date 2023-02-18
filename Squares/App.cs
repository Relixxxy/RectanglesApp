using Rects.Services;
using Rects.Services.Interfaces;

namespace Rects
{
    public class App
    {
        private readonly ICreatorService _creator;
        private readonly IPrinterService _printer;
        private readonly IFinderService _finder;

        public App(ICreatorService creator, IPrinterService printer, IFinderService finder)
        {
            _creator = creator;
            _printer = printer;
            _finder = finder;
        }

        public void Start()
        {
            int max = 10;
            var initialPoints = _creator.GeneratePoints(20, max);

            _printer.PrintCoordinateSys(initialPoints, max);

            var lines = _creator.CreateLines(initialPoints);
            var rects = _finder.FindRects(lines);

            _printer.PrintResult(rects);
        }
    }
}
