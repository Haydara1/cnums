using cnums.Symbolic;
using static cnums.Maths;

namespace cnums.Vector_math;

public struct Point2
{
    private double a;
    private double b;

    public double A
    {
        get { return a; }
        private set { a = value; }
    }

    public double B
    {
        get { return b; }
        private set { b = value; }
    }

    private Symbol? x;
    private Symbol? y;

    public Symbol? X => x;
    public Symbol? Y => y;

    private readonly bool symbolic;

    public Point2(double a, double b)
    {
        this.a = a;
        this.b = b;
        this.x = null;
        this.y = null;
        symbolic = false;
    }

    public Point2(Symbol x, Symbol y)
    {
        this.a = 1;
        this.b = 1;
        this.x = x;
        this.y = y;
        symbolic = true;
    }

    public Point2(Symbol x, double coefficient_x, Symbol y, double coefficient_y)
    {
        this.a = coefficient_x;
        this.b = coefficient_y;
        this.x = x;
        this.y = y;
        symbolic = true;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Point2)) return false;

        Point2 other = (Point2)obj;
        if (other.symbolic && this.symbolic)
#pragma warning disable CS8604 // Possible null reference argument.
            return this.a == other.a && this.b == other.b
                && this.x == other.x && this.y == other.y;
#pragma warning restore CS8604 // Possible null reference argument.
        else if (!other.symbolic && !this.symbolic)
            return this.a == other.a && this.b == other.b;
        return false;
    }

    public override string ToString()
    {
        if (symbolic)
            return $"{A}*{X}, {B}*{Y}";
        return $"{A}, {B}";
    }

    public static double Magnitude(Point2 point)
        => Sqrt(Power(point.a) + Power(point.b));

    public static bool operator ==(Point2 left, Point2 right)
        => left.Equals(right);

    public static bool operator !=(Point2 left, Point2 right)
        => !left.Equals(right);

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

