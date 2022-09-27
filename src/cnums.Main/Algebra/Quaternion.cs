// Pulled from https://en.wikipedia.org/wiki/Quaternion

namespace cnums.Algebra;

public struct Quaternion
{
    private readonly double a;
    private readonly double b;
    private readonly double c;
    private readonly double d;

    public double A => a;
    public double B => b;
    public double C => c;
    public double D => d;

    public Quaternion(double a, double b, double c, double d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }

    public static Quaternion Conjugate(Quaternion quaternion)
        => new(quaternion.A,
               -quaternion.B,
               -quaternion.C,
               -quaternion.D);

    public static Quaternion operator +(Quaternion quaternion)
        => quaternion;

    public static Quaternion operator +(Quaternion quaternion1, Quaternion quaternion2)
        => new(quaternion1.A + quaternion2.A,
               quaternion1.B + quaternion2.B,
               quaternion1.C + quaternion2.C,
               quaternion1.D + quaternion2.D);

    public static Quaternion operator +(Quaternion quaternion, double scalar)
        => new(quaternion.A + scalar,
               quaternion.B,
               quaternion.C,
               quaternion.D);

    public static Quaternion operator +(double scalar, Quaternion quaternion)
        => quaternion + scalar;

    public static Quaternion operator -(Quaternion quaternion)
        => quaternion * -1;

    public static Quaternion operator -(Quaternion quaternion1, Quaternion quaternion2)
        => new(quaternion1.A - quaternion2.A,
               quaternion1.B - quaternion2.B,
               quaternion1.C - quaternion2.C,
               quaternion1.D - quaternion2.D);

    public static Quaternion operator -(Quaternion quaternion, double scalar)
        => new(quaternion.A - scalar,
               quaternion.B,
               quaternion.C,
               quaternion.D);

    public static Quaternion operator -(double scalar, Quaternion quaternion)
        => -quaternion + scalar;

    public static Quaternion operator *(Quaternion quaternion1, Quaternion quaternion2)
        => new(quaternion1.A * quaternion2.A - quaternion1.B * quaternion2.B - quaternion1.C * quaternion2.C - quaternion1.D * quaternion2.D,
               quaternion1.A * quaternion2.B + quaternion1.B * quaternion2.A + quaternion1.C * quaternion2.D - quaternion1.D * quaternion2.C,
               quaternion1.A * quaternion2.C - quaternion1.B * quaternion2.D + quaternion1.C * quaternion2.A + quaternion1.D * quaternion2.B,
               quaternion1.A * quaternion2.D + quaternion1.B * quaternion2.C - quaternion1.C * quaternion2.B + quaternion1.D * quaternion2.A);

    public static Quaternion operator *(Quaternion quaternion, double scalar)
    => new(quaternion.A * scalar,
           quaternion.B * scalar,
           quaternion.C * scalar,
           quaternion.D * scalar);

    public static Quaternion operator *(double scalar, Quaternion quaternion)
    => new(quaternion.A * scalar,
           quaternion.B * scalar,
           quaternion.C * scalar,
           quaternion.D * scalar);

}
