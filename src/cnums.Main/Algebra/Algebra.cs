using static cnums.Consts;
using static cnums.Maths;

namespace cnums.Algebra;

/// <summary>
/// Contains extension methods for quaternions and complex numbers.
/// </summary>
public static class Algebra
{
    public static Quaternion Conjugate(this Quaternion quaternion)
        => new(quaternion.A,
               -quaternion.B,
               -quaternion.C,
               -quaternion.D);


    public static double Norm(this Quaternion quaternion)
        => Maths.Sqrt(Power(quaternion.A)
            + Power(quaternion.B)
            + Power(quaternion.C)
            + Power(quaternion.D));

    /// <summary>
    ///     Returns the absolute value of a complex number.
    /// </summary>
    /// <param name="value">A cnums.Complex number.</param>
    /// <returns>
    ///     A double-precision floating-point, the modulus of the given number.
    /// </returns>
    public static double Abs(Complex c)
        => Maths.Sqrt(Power(c.Re) + Power(c.Im));

    //precise
    /// <summary>
    /// Returns the square root of the given complex number.
    /// </summary>
    /// <param name="num">The number whose square root is to be found.</param>
    /// <returns>Returns a cnums.Complex number, representing the square root of the given number.</returns>
    public static Complex Sqrt(Complex complex)
    {
        double real, immaginary;

        real = Maths.Sqrt((complex.Modulus() + complex.Re) / 2);
        immaginary = complex.Im / Maths.Abs(complex.Im);
        immaginary *= Maths.Sqrt((complex.Modulus() - complex.Re) / 2);

        return new(real, immaginary);
    }

    public static Complex Ln(Complex num)
        => new(Maths.Ln(num.Modulus()), num.Arg());

    #region Trigonometric functions for Complex numbers

    public static Complex Sin(Complex c)
        => new(Maths.Sin(c.Re) * Maths.Cosh(c.Im), Maths.Cos(c.Re) * Maths.Sinh(c.Im));

    public static Complex Cos(Complex c)
        => new(Maths.Cos(c.Re) * Cosh(c.Im), -Maths.Sin(c.Re) * Sinh(c.Im));

    public static Complex Tan(Complex c)
        => Sin(c) / Cos(c);

    public static Complex Cot(Complex c)
        => Cos(c) / Sin(c);

    public static Complex Sec(Complex c)
        => 1 / Cos(c);

    public static Complex Csc(Complex c)
        => 1 / Sin(c);

    #endregion


    #region Inverse trigonometric functions for Complex numbers

    public static Complex Asin(Complex c)
        => (1 / Complex.j) * Ln(Complex.j * c + Sqrt(-(c * c) + 1));

    public static Complex Acos(Complex c)
        => (1 / Complex.j) * Ln(c + Complex.j * Sqrt(-(c * c) + 1));

    public static Complex Atan(Complex c)
        => (1 / (Complex.j * 2)) * Ln((Complex.j - c) / (Complex.j + c));

    public static Complex Acot(Complex c)
        => Atan(1 / c);

    #endregion

}
