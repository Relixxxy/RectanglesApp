using System.Linq;

namespace Squares.Model;

public class Square
{
	public Square(Line l1, Line l2)
	{
		Points = new List<Point>();

		foreach (var p in l1.Points)
		{
			Points.Add(p);
		}

        foreach (var p in l2.Points)
        {
            Points.Add(p);
        }
    }
    public IList<Point> Points { get; set; }

    public override string ToString()
    {
        var res = string.Empty;

        foreach (var p in Points)
        {
            res += $"{p} ";
        }

        return res;
    }

    public override bool Equals(object? obj)
    {
        var square = (obj as Square) !;

        var firstNotSecond = square.Points.Except(Points).ToList();
        var secondNotFirst = Points.Except(square.Points).ToList();


        return !firstNotSecond.Any() && !secondNotFirst.Any();
    }

    public override int GetHashCode()
    {
        int value = 0;

        foreach (var p in Points)
        {
            value ^= p.GetHashCode();
        }

        return value;
    }
}
