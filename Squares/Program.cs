using Squares.Services;

int max = 10;
var initialPoints = CreatorService.GeneratePoints(20, max);

PrinterService.PrintCoordinateSys(initialPoints, max);

var lines = CreatorService.CreateLines(initialPoints);

var squares = FinderService.FindSquares(lines);

foreach (var square in squares)
{
    Console.WriteLine(square);
}
