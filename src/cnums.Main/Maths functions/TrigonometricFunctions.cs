using cnums.Symbolic;
using static cnums.Consts;

namespace cnums;

public static partial class Maths
{
    #region Trigonometric functions.

    //precise
    /// <summary>
    /// Returns the sine value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x, such that -1 ≤ x ≤ 1. Returns System.Double.NaN, if x equals System.Double.NaN, or System.Double.Negative infinity, or System.Double.PositiveInfinity
    /// </returns>
    public static double Sin(double angle)
    {
        (_, double sinAngle) = Cordic_SinCos(angle);
        return sinAngle;
    }

    /// <summary>
    /// Returns the cosine value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x, such that -1 ≤ x ≤ 1. Returns System.Double.NaN, if x equals System.Double.NaN, or System.Double.Negative infinity, or System.Double.PositiveInfinity
    /// </returns>
    public static double Cos(double angle)
    {
        (double cosAngle, _) = Cordic_SinCos(angle);
        return cosAngle;
    }

    /// <summary>
    /// Returns the tangent value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x. 
    /// </returns>
    public static double Tan(double angle)
    {
        (double cosAngle, double sinAngle) = Cordic_SinCos(angle);
        return sinAngle / cosAngle;
    }

    /// <summary>
    /// Returns the cotangent value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x.
    /// </returns>
    public static double Cot(double angle)
    {
        (double cosAngle, double sinAngle) = Cordic_SinCos(angle);
        return cosAngle / sinAngle;
    }

    public static double Sec(double angle)
        => 1 / Cos(angle);

    public static double Csc(double angle)
        => 1 / Sin(angle);

    /// <summary>
    /// Returns Sin(x) / x value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x.
    /// </returns>
    public static double Sinc(double angle)
    {
        angle = PrivateFunctions.ModPi(angle);

        if (angle == 0) throw new Exception("Undefined");
        return Sin(angle) / angle;
    }

    #endregion

    #region Inverse Trigonometric functions.

    public static double Asin(double num)
    {
        if (1 < Abs(num)) throw new Exception("ArcSin cannot evaluate values higher than one, or lower than minus one.");

        if (num == 0) return 0;

        double theta = 0;
        double[,] z = { { 1, 0 } };

        double PowerOfTwo = 1;

        double angle = 0;

        for (int i = 0; i < 100; i++)
        {
            double sign_z2, sigma;

            if (z[0, 0] < 0)
                sign_z2 = -1;
            else
                sign_z2 = 1;

            if (num >= z[0, 1])
                sigma = +sign_z2;
            else
                sigma = -sign_z2;

            if (i < Angles.Length)
                angle = Angles[i];
            else
                angle /= 2;

            double[,] RotationMatrix =
            {
                {1, sigma * PowerOfTwo },
                {-sigma * PowerOfTwo, 1 }
            };

            z = PrivateFunctions.MatricesMultiplication(
                PrivateFunctions.MatricesMultiplication(z, RotationMatrix),
                RotationMatrix);

            theta += 2.0 * sigma * angle;
            num += num * PowerOfTwo * PowerOfTwo;
            PowerOfTwo /= 2.0;
        }
        return theta;
    }

    public static double Acos(double num)
    {
        if (1 < Abs(num)) throw new Exception("ArcCos cannot evaluate values higher than one, or lower than minus one.");

        double theta = 0;
        double[,] z = { { 1, 0 } };

        double PowerOfTwo = 1;

        double angle = 0;

        for (int i = 0; i < 100; i++)
        {
            double sign_z2, sigma;

            if (z[0, 1] < 0)
                sign_z2 = -1;
            else
                sign_z2 = 1;

            if (num <= z[0, 0])
                sigma = +sign_z2;
            else
                sigma = -sign_z2;

            if (i < Angles.Length)
                angle = Angles[i];
            else
                angle /= 2;

            double[,] RotationMatrix =
            {
                {1, sigma * PowerOfTwo },
                {-sigma * PowerOfTwo, 1 }
            };

            z = PrivateFunctions.MatricesMultiplication(
                PrivateFunctions.MatricesMultiplication(z, RotationMatrix),
                RotationMatrix);

            theta += 2.0 * sigma * angle;
            num += num * PowerOfTwo * PowerOfTwo;
            PowerOfTwo /= 2.0;
        }
        return theta;
    }

    public static double Atan(double num)
    {
        double x1 = 1, y1 = num;
        double signFactor;

        if (x1 < 0 && y1 < 0)
        {
            x1 *= -1;
            y1 *= -1;
        }

        if (x1 < 0)
        {
            x1 *= -1;
            signFactor = -1;
        }
        else if (y1 < 0)
        {
            y1 *= -1;
            signFactor = -1;
        }
        else
            signFactor = 1;

        double theta = 0;
        double PowerOfTwo = 1;

        double sigma, angle = 0;

        for (int i = 0; i < 100; i++)
        {
            if (y1 <= 0.0)
                sigma = +1.0;
            else
                sigma = -1.0;

            if (i < Angles.Length)
                angle = Angles[i];
            else
                angle /= 2.0;

            double x2 = x1 - sigma * PowerOfTwo * y1;
            double y2 = sigma * PowerOfTwo * x1 + y1;

            theta -= sigma * angle;

            x1 = x2;
            y1 = y2;

            PowerOfTwo /= 2;
        }

        theta *= signFactor;
        return theta;
    }

    public static double Asec(double num)
       => Acos(1 / num);

    public static double Acsc(double num)
        => Asin(1 / num);

    public static double Acot(double num)
        => (Consts.PI / 2) - Atan(num);

    #endregion

    private static (double cos, double sin) Cordic_SinCos(double beta)
    {
        double theta = PrivateFunctions.AngleShift(beta, -PI);
        double SignFactor;

        if (theta < -0.5 * PI)
        {
            theta += PI;
            SignFactor = -1.0;
        }
        else if (0.5 * PI < theta)
        {
            theta -= PI;
            SignFactor = -1.0;
        }
        else
            SignFactor = +1.0;

        double[,] v = { { 1, 0 } };
        double PowerOfTwo = 1;
        double angle = Consts.Angles[0];

        double sigma;

        for (int i = 0; i < 100; i++)
        {
            if (theta < 0.0)
                sigma = -1.0;
            else
                sigma = 1.0;

            double factor = sigma * PowerOfTwo;

            double[,] RotationMatrix =
            {
                {1, factor },
                {-factor, 1 }
            };

            v = PrivateFunctions.MatricesMultiplication(v, RotationMatrix);

            theta -= sigma * angle;
            PowerOfTwo /= 2;

            if (Angles.Length <= (i + 1))
                angle /= 2.0;
            else
                angle = Angles[i + 1];
        }

        v[0, 0] *= KProd * SignFactor;
        v[0, 1] *= KProd * SignFactor;


        return (v[0, 0], v[0, 1]);
    }

    #region Symbolic Constructors

    public static Function Sin(Symbol symbol)
        => new Sine(new(symbol)).ToFunction();

    public static Function Cos(Symbol symbol)
        => new Cosine(new(symbol)).ToFunction();

    #endregion
}

