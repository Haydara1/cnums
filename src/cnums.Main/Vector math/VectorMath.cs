// Reference: https://en.wikipedia.org/wiki/Euclidean_vector

using static cnums.Maths;

namespace cnums.Vector_math;

public static class VectorMath
{
    #region 2D point functions

    public static Point2 GetSymetricPointTo(this Point2 point, Point2 reference)
        => new(2 * reference.A - point.A, 2 * reference.B - point.B);

    public static Point2 GetSymetricPointToOrigin(this Point2 point)
        => new(-point.A, -point.B);

    public static Point2 GetMidPoint(Point2 point1, Point2 point2)
        => new((point1.A + point2.A) / 2, (point1.B + point2.B) / 2);

    public static double GetDistanceFromOrigin(this Point2 point)
        => Sqrt(Power(point.A) + Power(point.B));

    public static double GetDistanceFrom(this Point2 point, Point2 point2)
        => Sqrt(Power(point.A - point2.A) + Power(point.B - point2.B));

    public static bool AreCollinearPoints(Point2 A, Point2 B, Point2 C)
        => A.A * (B.B - C.B) + B.A * (C.B - A.B) + C.A * (A.B - B.B) == 0; //Checks wether the triangle surface made with the three points equals zero

    public static bool MakeAnEquilateralTriangle(Point2 A, Point2 B, Point2 C)
        => A.GetDistanceFrom(B) == A.GetDistanceFrom(C) 
        && B.GetDistanceFrom(C) == A.GetDistanceFrom(B);

    #endregion

    #region 3D point functions

    public static Point3 GetSymetricPointTo(this Point3 point, Point3 reference)
        => new(2 * reference.X - point.X, 2 * reference.Y - point.Y, 2 * reference.Z - point.Z);

    public static Point3 GetSymetricPointToOrigin(this Point3 point)
        => new(-point.X, -point.Y, -point.Z);

    public static Point3 GetMidPoint(Point3 point1, Point3 point2)
        => new((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2, (point1.Z + point2.Z) / 2);

    public static double GetDistanceFromOrigin(this Point3 point)
        => Sqrt(Power(point.X) + Power(point.Y) + Power(point.Z));

    public static double GetDistanceFrom(this Point3 point, Point3 point2)
        => Sqrt(Power(point.X - point2.X) + Power(point.Y - point2.Y) + Power(point.Z - point2.Z));

    #endregion

    #region 2D vector functions

    public static double Magnitude(this Vector2 vector)
        => Sqrt(Power(vector.X) + Power(vector.Y));

    public static bool isNullVector(this Vector2 vector)
        => vector == Vector2.ZERO;

    public static bool areOpposite(Vector2 vector1, Vector2 vector2)
        => vector1.X == -vector2.X
        && vector1.Y == -vector2.Y;

    public static Vector2 Noramilze(this Vector2 vector)
        => vector / vector.Magnitude();

    public static double Dot(this Vector2 vector1, Vector2 vector2)
        => Dot(vector1, vector2);   

    public static bool Collinear(Vector2 vector1, Vector2 vector2) //Incorrect
    {
        if (vector1.isNullVector() || vector2.isNullVector())
            return true;
        else if ((vector1.X == 0 && vector2.Y != 0)
            || (vector1.Y == 0 && vector2.X != 0)
            || (vector2.X == 0 && vector1.Y != 0)
            || (vector2.Y == 0 && vector1.X != 0))
            return true;

        return false;
    }

    #endregion

    #region 3D vector functions

    public static double Magnitude(this Vector3 vector)
        => Sqrt(Power(vector.X) + Power(vector.Y) + Power(vector.Z));

    public static bool isNullVector(this Vector3 vector)
        => vector.X == 0 && vector.Y == 0 && vector.Z == 0;

    public static Vector3 Normalize(this Vector3 vector)
        => vector / vector.Magnitude();

    public static bool areOpposite(Vector3 vector1, Vector3 vector2)
        => vector1.X == -vector2.X
        && vector1.Y == -vector2.Y
        && vector1.Z == -vector2.Z;

    #endregion
}
