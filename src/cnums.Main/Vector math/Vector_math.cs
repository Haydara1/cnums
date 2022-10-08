// Reference: https://en.wikipedia.org/wiki/Euclidean_vector

using static cnums.Maths;

namespace cnums.Vector_math;

public static class Vector_math
{
    public static double Magnitude(this Vector2 vector)
        => Sqrt(Power(vector.X) + Power(vector.Y));

    public static bool isNullVector(this Vector2 vector)
        => vector == Vector2.ZERO;

    public static bool isNullVector(this Vector3 vector)
        => vector.X == 0 && vector.Y == 0 && vector.Z == 0;

    public static bool areOpposite(Vector2 vector1, Vector2 vector2)
        => vector1.X == -vector2.X
        && vector1.Y == -vector2.Y;

    public static bool areOpposite(Vector3 vector1, Vector3 vector2)
        => vector1.X == -vector2.X
        && vector1.Y == -vector2.Y
        && vector1.Z == -vector2.Z;

    public static Vector2 getUnitVector(Vector2 vector)
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

}
