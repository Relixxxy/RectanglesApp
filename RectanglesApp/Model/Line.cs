namespace Rects.Model;

public class Line
{
    public Line(Point p1, Point p2)
    {
        Points =  new List<Point>()
        {
            p1,
            p2
        };
    }

    public IList<Point> Points { get; set; }
    public double Length 
    { 
        get 
        {
            double d = Math.Sqrt(Math.Pow(Points.Last().X - Points.First().X, 2) + Math.Pow(Points.Last().Y - Points.First().Y, 2));
            return Math.Round(d, 2);
        }
    }

    public override string ToString()
    {
        return $"P1:{Points.First()}, P2:{Points.Last()}, Len:{Length}";
    }
}
