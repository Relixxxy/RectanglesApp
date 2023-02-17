using Squares.Model;
using Squares.Services;

int max = 10;
var initialPoints = CreatorService.GeneratePoints(20, max);
/*var initialPoints = new List<Point>()
{
    new(8,9),
    new(2,3),
    new(9,2),
    new(3,8),
};*/

PrinterService.PrintCoordinateSys(initialPoints, max);

var lines = CreatorService.CreateLines(initialPoints);

var squares = FinderService.FindSquares(lines);

foreach (var square in squares)
{
    Console.WriteLine(square);
}

