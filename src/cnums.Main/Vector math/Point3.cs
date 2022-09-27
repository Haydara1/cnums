using static cnums.Maths;

namespace cnums.Vector_math;

public struct Point3
{
    private double x;
    private double y;
    private double z;

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

    public double Z
    {
        get { return z; }
        private set { z = value; }
    }

    public Point3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Point3)) return false;

        Point3 other = (Point3)obj;
        return this.x == other.x
            && this.y == other.y
            && this.z == other.z;
    }

    public static double Magnitude(Point3 point)
        => Sqrt(Power(point.x) + Power(point.y) + Power(point.z));

    public static bool operator ==(Point3 left, Point3 right)
        => left.Equals(right);

    public static bool operator !=(Point3 left, Point3 right)
        => !left.Equals(right);

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

