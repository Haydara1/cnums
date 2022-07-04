namespace MathH;


/// <summary>
///     Provides a list of most used mathematics constants.
/// </summary>
public static class Consts
{
    /// <summary>
    ///     Represents the natural logarithmic base, specified by the constant, e.
    /// </summary>
    public const double E = 2.7182818284590451;

    /// <summary>
    ///     Represents the ratio of the circumference of a circle to its diameter, specified
    ///     by the constant, π.
    /// </summary>  
    public const double PI = 3.1415926535897931;

    /// <summary>
    ///     Represents the number of radians in one turn, specified by the constant, τ.
    /// </summary>
    public const double Tau = 6.2831853071795862;

    ///<summary>
    ///     Represents the Euler-Mascheroni constant.
    ///</summary>
    public const double Gamma = 0.57721566490153286060;

    ///<summary>
    ///     Represents the golden ratio, specified by the constant φ.
    /// </summary>
    public const double Phi = 1.61803398874989484820;
}

public static class Maths
{
    
    #region Absolute value.

    /// <summary>
    ///     Returns the absolute value of a System.Decimal number.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.Decimal.MinValue, but less than or equal to System.Decimal.MaxValue.</param>
    /// <returns>
    ///     A decimal number, x, such that 0 ≤ x ≤ System.Decimal.MaxValue.
    /// </returns>
    public static decimal Abs(decimal value)
    {
        if (value < 0)
            value *= -1;
        
        return value;
    }

    /// <summary>
    ///     Returns the absolute value of a double-precision floating-point number.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.Double.MinValue, but less than or equal to System.Double.MaxValue.</param>
    /// <returns>
    ///     A double-precision floating-point number, x, such that 0 ≤ x ≤ System.Double.MaxValue.
    /// </returns>
    public static double Abs(double value)
    {
        if (value < 0)
            value *= -1;

        return value;
    }

    /// <summary>
    ///     Returns the absolute value of a 16-bit signed integer.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.Int16.MinValue, but less than or equal to System.Int16.MaxValue.</param>
    /// <returns>
    ///     A 16-bit signed integer, x, such that 0 ≤ x ≤ System.Int32.MaxValue.
    /// </returns>
    public static short Abs(short value)
    {
        if (value < 0)
            value *= -1;

        return value;
    }

    /// <summary>
    ///     Returns the absolute value of a 32-bit signed integer.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.Int32.MinValue, but less than or equal to System.Int32.MaxValue.</param>
    /// <returns>
    ///     A 32-bit signed integer, x, such that 0 ≤ x ≤ System.Int32.MaxValue.
    /// </returns>
    public static int Abs(int value)
    {
        if (value < 0)
            value *= -1;

        return value;
    }

    /// <summary>
    ///     Returns the absolute value of a 64-bit signed integer.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.Int64.MinValue, but less than or equal to System.Int64.MaxValue.</param>
    /// <returns>
    ///     A 64-bit signed integer, x, such that 0 ≤ x ≤ System.Int64.MaxValue.
    /// </returns>
    public static long Abs(long value)
    {
        if (value < 0)
            value *= -1;

        return value;
    }

    /// <summary>
    ///     Returns the absolute value of a native signed integer.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.IntPtr.MinValue, but less than or equal to System.IntPtr.MaxValue.</param>
    /// <returns>
    ///     A native signed integer, x, such that 0 ≤ x ≤ System.IntPtr.MaxValue.
    /// </returns>
    public static nint Abs(nint value)
    {
        if (value < 0)
            value *= -1;

        return value;
    }

    /// <summary>
    ///     Returns the absolute value of an 8-bit signed integer.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.SByte.MinValue, but less than or equal to System.SByte.MaxValue.</param>
    /// <returns>
    ///     An 8-bit signed integer, x, such that 0 ≤ x ≤ System.SByte.MaxValue.
    /// </returns>
    public static sbyte Abs(sbyte value)
    {
        if (value < 0)
            value *= -1;

        return value;
    }

    /// <summary>
    ///     Returns the absolute value of a single-precision floating-point number.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to System.Single.MinValue, but less than or equal to System.Single.MaxValue.</param>
    /// <returns>
    ///     A single-precision floating-point number, x, such that 0 ≤ x ≤ System.Single.MaxValue.
    /// </returns>
    public static float Abs(float value)
    {
        if (value < 0)
            value *= -1;

        return value;
    }

    #endregion

    #region Trigonometric functions.

        
    #endregion
}

public static class PreCalculus
{

}


public static class Calculus
{

}


