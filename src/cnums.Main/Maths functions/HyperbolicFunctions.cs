// Reference: https://en.wikipedia.org/wiki/Hyperbolic_functions

namespace cnums;

public static partial class Maths
{
    #region Hyperbolic functions.

    /// <summary>
    /// Returns the sinh of the given number.
    /// </summary>
    /// <param name="num">An angle, measured in radians.</param>
    /// <returns>The sinh of the given number.</returns>
    public static double Sinh(double num)
        => (Exp(2 * num) - 1) / 2 * Exp(num);

    /// <summary>
    /// Returns the cosh of the given number.
    /// </summary>
    /// <param name="num">An angle, measured in radians.</param>
    /// <returns>The cosh of the given number.</returns>
    public static double Cosh(double num)
        => (Exp(num) + Exp(-num)) / 2;

    public static double Tanh(double num)
        => Sinh(num) / Cosh(num);

    public static double Coth(double num)
        => Cosh(num) / Sinh(num);

    public static double Sech(double num)
        => 1 / Cosh(num);

    public static double Csch(double num)
        => 1 / Sinh(num);

    #endregion

    // Refernce: https://byjus.com/inverse-hyperbolic-functions-formula/

    #region Inverse hyperbolic functions

    public static double Asinh(double d)
        => Ln(d + Sqrt(Power(d) + 1)); //precise

    public static double Acosh(double d)
    {
        if (d < 1)
            return double.NaN;

        return Ln(d + Sqrt(Power(d) - 1));
    } //precise

    public static double Atanh(double d)
    {
        if (d >= 1 || d <= -1) return System.Double.NaN;

        return 0.5 * Ln((1 + d) / (1 - d));
    } //precise

    public static double Acoth(double d)
    {
        if (d <= 1 && d >= -1) return System.Double.NaN;

        return 0.5 * Ln((d + 1) / (d - 1));
    } //precise

    public static double Acsch(double d)
    {
        if(d == 0) return System.Double.NaN;

        return Ln((1 / d) + Sqrt((1 / Power(d)) + 1));
    } //precise

    public static double Asech(double d)
    {
        if(d <= 0 || d > 1) return System.Double.NaN;

        return Ln((1 + Sqrt(Power(d) + 1) / d));
    } //precise

    #endregion
}