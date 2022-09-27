using static cnums.Maths;

namespace cnums.Vector_math;

public struct Vector3
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

    public Vector3(Point3 BeginningPoint, Point3 EndPoint)
    {
        this.x = EndPoint.X - BeginningPoint.X;
        this.y = EndPoint.Y - BeginningPoint.Y;
        this.z = EndPoint.Z - BeginningPoint.Z;
    }

    public Vector3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Vector3)) return false;
        Vector3 other = (Vector3)obj;
        return x == other.x
            && y == other.y
            && z == other.z;
    }

    public static bool operator ==(Vector3 left, Vector3 right)
        => left.Equals(right);

    public static bool operator !=(Vector3 left, Vector3 right)
        => !(left == right);

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static double Magnitude(Vector3 vector)
        => Sqrt(Power(vector.x) + Power(vector.y) + Sqrt(vector.z));

    public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        => new(vec1.x + vec2.x,
               vec1.y + vec2.y,
               vec1.z + vec2.z);

    public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        => new(vec2.x - vec1.x,
               vec2.y - vec1.y,
               vec2.z - vec1.z);
}
