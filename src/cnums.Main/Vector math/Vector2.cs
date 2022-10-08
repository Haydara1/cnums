using static cnums.Maths;

namespace cnums.Vector_math;

public struct Vector2
{
    public static readonly Vector2 ZERO = new(0, 0);

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

    public Vector2(Point2 BeginningPoint, Point2 EndPoint)
    {
        this.x = EndPoint.X - BeginningPoint.X;
        this.y = EndPoint.Y - BeginningPoint.Y;
    }

    public Vector2(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Vector2)) return false;
        Vector2 other = (Vector2)obj;
        return x == other.x && y == other.y;
    }

    public override string ToString()
        => $"({this.x}, {this.y})";

    public static bool operator ==(Vector2 left, Vector2 right)
        => left.Equals(right);

    public static bool operator !=(Vector2 left, Vector2 right)
        => !left.Equals(right);

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static double Angle(Vector2 vec1, Vector2 vec2)
        => Acos(Dot(vec1, vec2) / vec1.Magnitude() * vec2.Magnitude());

    public static double Dot(Vector2 vec1, Vector2 vec2)
        => vec1.x * vec2.x
         + vec1.y * vec2.y;

    public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        => new(vec1.x + vec2.x, vec1.y + vec2.y);

    public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        => new(vec2.x - vec1.x, vec2.y - vec1.y);

    public static Vector2 operator *(Vector2 vector, double scalar)
        => new(vector.x * scalar, vector.y * scalar);

    public static Vector2 operator *(double scalar, Vector2 vector)
        => new(vector.x * scalar, vector.y * scalar);

    public static Vector2 operator /(Vector2 vector, double scalar)
        => new(vector.x / scalar, vector.y / scalar);

    public static Vector2 operator /(double scalar, Vector2 vector)
        => new(vector.x / scalar, vector.y / scalar);

}
