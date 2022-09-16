using System.Diagnostics.CodeAnalysis;

namespace cnums.Vector_math;

public struct Point2
{
    private double x;
    private double y;

    public double X
    {
        get { return x; }
        private set { x = value; }
    }

    public double Y
    {
        get { return y; }
        private set { y = value; }
    }

    public Point2(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj)
    {
        if(obj == null) return false;
        if(obj.GetType() != typeof(Point2)) return false;

        Point2 other = (Point2)obj;
        return this.x == other.x && this.y == other.y;
    }

    public static bool operator ==(Point2 left, Point2 right)
        => left.Equals(right);

    public static bool operator !=(Point2 left, Point2 right)
        => !left.Equals(right);

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

