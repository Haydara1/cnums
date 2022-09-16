namespace cnums.Vector_math;

public struct Vector2
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
        if(obj == null) return false;
        if(obj.GetType() != typeof(Vector2)) return false;
        Vector2 other = (Vector2)obj;
        return x == other.x && y == other.y;
    }

    public static bool operator ==(Vector2 left, Vector2 right)
        => left.Equals(right);

    public static bool operator !=(Vector2 left, Vector2 right)
        => !left.Equals(right);

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        => new(vec1.x + vec2.x, vec1.y + vec2.y);

    public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        => new(vec2.x - vec1.x, vec2.y - vec1.y);
}
