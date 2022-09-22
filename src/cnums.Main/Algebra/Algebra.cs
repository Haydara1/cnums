namespace cnums.Algebra;

public static class Algebra
{
    public static Quaternion Conjugate(this Quaternion quaternion)
        => new(quaternion.A,
               -quaternion.B,
               -quaternion.C,
               -quaternion.D);


    public static double Norm(this Quaternion quaternion)
        => Maths.Sqrt(Maths.Power(quaternion.A)
            + Maths.Power(quaternion.B)
            + Maths.Power(quaternion.C)
            + Maths.Power(quaternion.D));

}
