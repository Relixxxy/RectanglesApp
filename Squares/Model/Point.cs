namespace Squares.Model;

public class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object? obj)
    {
        var point = obj as Point;

        if (point == null)
        {
            return false;
        }

        return point.X.Equals(X) && point.Y.Equals(Y);
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public override string ToString()
    {
        return $"(X:{X}, Y:{Y})";
    }
}
