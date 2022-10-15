using cnums.Algebra;

namespace cnums;

public static partial class Maths
{
    public static Fraction Abs(Fraction fraction)
        => new(Abs(fraction.Numerator), Abs(fraction.Denominator));

    public static Fraction Power(Fraction fraction, int power = 2)
        => new(Power(fraction.Numerator, power), Power(fraction.Denominator, power));

    public static Fraction Power(Fraction fraction, double power)
        => new(Power(fraction.Numerator, power), Power(fraction.Denominator, power));

    public static Fraction Sqrt(Fraction fraction)
        => new(Sqrt(fraction.Numerator), Sqrt(fraction.Denominator));

    public static Fraction Cbrt(Fraction fraction)
        => new(Cbrt(fraction.Numerator), Cbrt(fraction.Denominator));

    public static double GetValue(this Fraction fraction)
        => fraction.Numerator / fraction.Denominator;
}