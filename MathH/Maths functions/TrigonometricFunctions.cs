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
        if (angle == System.Double.PositiveInfinity || angle == System.Double.NegativeInfinity || angle == System.Double.NaN)
            return System.Double.NaN;

        angle = PrivateFunctions.ModPi(angle);

        double sum = 0;
        double u;
        int i = 0;

        do
        {
            u = sum;

            if (i % 2 == 0)
                sum += Power((double)angle, 2 * i + 1) / (double)Factorial((double)2 * i + 1);

            else
                sum -= Power((double)angle, 2 * i + 1) / (double)Factorial((double)2 * i + 1);

            i++;

        } while (Abs((double)sum - u) > 10E-100);

        if (Abs(sum - 0) < 10E-20)
            return 0;

        if (Abs(sum - 1) < 10E-10)
            return 1;

        if (Abs(sum - 1) < -10E-10)
            return -1;

        return sum;
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
        if (angle == System.Double.PositiveInfinity || angle == System.Double.NegativeInfinity || angle == System.Double.NaN)
            return System.Double.NaN;

        angle = PrivateFunctions.ModPi(angle);

        double sum = 0;

        for (int i = 0; i < 100; i++)
        {
            if (i % 2 == 0)
                sum += Power((double)angle, 2 * i) / (double)Factorial((double)2 * i);

            else
                sum -= Power((double)angle, 2 * i) / (double)Factorial((double)2 * i);
        }

        if (Abs(sum - 0) < 10E-10)
            return 0;

        if (Abs(sum - 1) < 10E-10)
            return 1;

        if (Abs(sum - 1) < -10E-10)
            return -1;

        return sum;
    }

    /// <summary>
    /// Returns the tangent value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x. 
    /// </returns>
    public static double Tan(double angle)
        => Sin(angle) / Cos(angle);

    /// <summary>
    /// Returns the cotangent value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x.
    /// </returns>
    public static double Cot(double angle)
        => Cos(angle) / Sin(angle);

    /// <summary>
    /// Returns Sin(x) / x value of the Double-precision floating-point given angle.
    /// </summary>
    /// <param name="angle">Double-precision floating-point angle mesured in radians.</param>
    /// <returns>
    /// A double-precision floating-point number, x.
    /// </returns>
    public static double Sinc(double angle)
    {
        if (angle == 0) return 1;
        return Sin(angle) / angle;
    }

    #endregion

    #region Inverse Trigonometric functions.

    public static double Asin(double num)
    {
        if (num < -1 || num > 1) return System.Double.NaN;

        double sum = num;
        double u;
        int i = 1;

        do
        {
            u = sum;
            double helper = Power(num, (i * 2) + 1) / ((i * 2) + 1);

            double multi = 1, div = 1;

            for (int j = 1; j <= i * 2; j++)
                if (j % 2 == 0) div *= j;
                else multi *= j;

            helper *= multi;
            helper /= div;

            sum += helper;

        } while (Abs((double)sum - u) > 10E-2);

        return sum;
    }

    public static double Acos(double num)
        => (Consts.PI / 2) - Asin(num);

    public static double Atan(double num)
    {
        double sum = 0;

        if (num < 1 && num > -1)
        {
            for (int c = 0; c < 100; c++)
            {
                if (c % 2 == 0) sum += Power(num, (c * 2 + 1)) / ((c * 2) + 1);
                else sum -= Power(num, (c * 2 + 1)) / ((c * 2) + 1);
            }

            return sum;
        }

        if (num >= 1) sum += Consts.PI / 2;
        else if (num <= -1) sum -= Consts.PI / 2;


        double u;
        int i = 0;

        do
        {
            u = sum;

            double helper = 1 / (((2 * i) + 1) * Power(num, (i * 2) + 1));

            if (i % 2 == 0) sum -= helper;
            else sum += helper;

            i++;

        } while (Abs((double)sum - u) > 10E-5);

        return sum;
    }

    public static double Asec(double num)
       => Acos(1 / num);

    public static double Acsc(double num)
        => Asin(1 / num);

    public static double Acot(double num)
        => (Consts.PI / 2) - Atan(num);

    #endregion
}

