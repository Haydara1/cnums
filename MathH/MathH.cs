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

    #region Absolute value functions.

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

    #region Useful functions.

    /// <summary>
    /// Returns the cubic root of the given number.
    /// </summary>
    /// <param name="num">The number whose cubic root want to be found.</param>
    /// <returns>Returns a double-precision floating-point number, representing the cubic root of the given number.
    /// Returns System.Double.NaN if num equals System.Double.Nan.</returns>
    public static double Cbrt(double num)
    {
        double sum = num;
        double n = (double)1 / 3;

        double u;

        do
        {
            u = sum;
            sum = (2 * sum) + (num / Power(sum));
            sum *= (double)n;

        } while (Abs((double)sum - u) > 10E-15);

        return sum;
    }

    /// <summary>
    /// Returns the factorial value of a double-point floating-value number.
    /// </summary>
    /// <param name="num">Double-point floating-value number.</param>
    /// <returns>Returns a double-point floating-value number.</returns>
    public static double Factorial(double num)
    {
        double f;

        if (num == 0 || num == 1)
            return 1;

        else
            f = num * Factorial(num - 1);

        return f;
    }

    public static int Floor(double num)
    {
        string s = num.ToString();

        if (!s.Contains('.')) return (int)num;

        string n = String.Empty;

        foreach (char c in s)
        {
            if (c == '.') break;
            n += c;
        }

        num = Convert.ToInt32(n);

        if (n[0] == '-')
        {
            num--;
        }

        return (int)num;
    }

    public static int Ceiling(double num)
    {
        string s = num.ToString();

        if (!s.Contains('.')) return (int)num;

        string n = String.Empty;

        foreach (char c in s)
        {
            if (c == '.') break;
            n += c;
        }

        num = Convert.ToInt32(n);

        if (n[0] != '-')
        {
            num++;
        }

        return (int)num;
    }

    /// <summary>
    /// Returns the number x raised to power y.
    /// </summary>
    /// <param name="x">Power base.</param>
    /// <param name="y">Power.</param>
    /// <returns>Returns double-point floating-value number.</returns>
    public static double Power(double x, int y = 2)
    {
        double pow = 1;
        bool NGPow = false;

        if (y < 0)
        {
            y *= -1;
            NGPow = true;
        }

        while (y > 0)
        {
            pow *= x;
            --y;
        }

        if (NGPow)
            return 1 / pow;

        return pow;
    }

    /// <summary>
    /// Returns the square root of the given number.
    /// </summary>
    /// <param name="num">The number whose square root want to be found.</param>
    /// <returns>Returns a double-precision floating-point number, representing the square root of the given number.
    /// Returns System.Double.NaN if num equals System.Double.Nan or is smaller than zero.</returns>
    public static double Sqrt(double num)
    {
        if (double.IsNaN(num))
            return System.Double.NaN;

        if (num == System.Double.PositiveInfinity)
            return System.Double.PositiveInfinity;

        double sum = num;
        double u;

        do
        {
            u = sum;
            sum = (sum + (num / sum));
            sum *= 0.5;

        } while (Abs((double)sum - u) > 10E-15);

        return sum;
    }

    /// <summary>
    /// Converts given number in degrees to radians.
    /// </summary>
    /// <param name="num">Double-precision floating-point number mesured in degrees.</param>
    /// <returns>Returns a double-precision floating-point number in radians. Returns System.Double.NaN if num was equal to System.Double.NaN</returns>
    public static double ToRadian(this double num)
        => Consts.PI * num / 180;

    #endregion

    #region Trigonometric functions.

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

        double sum = 0;
        double u;
        int i = 0;

        do
        {
            u = sum;

            if (i % 2 == 0)
                sum += Power((double)angle, 2 * i + 1) / (double)Factorial(2 * i + 1);

            else
                sum -= Power((double)angle, 2 * i + 1) / (double)Factorial(2 * i + 1);

            i++;

        } while (Abs((double)sum - u) > 10E-100);

        Console.WriteLine(i);

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

        double sum = 0;

        for (int i = 0; i < 100; i++)
        {
            if (i % 2 == 0)
                sum += Power((double)angle, 2 * i) / (double)Factorial(2 * i);

            else
                sum -= Power((double)angle, 2 * i) / (double)Factorial(2 * i);
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

        for(int i = 1; i < 100; i++)
        {
            double helper = Power(num, (i * 2) + 1) / ((i * 2) + 1);

            double multi = 1, div = 1;

            for(int j = 1; j <= i * 2; j++)
                if (j % 2 == 0) div *= j;
                else multi *= j;

            helper *= multi;
            helper /= div;

            sum += helper;
        }

        return sum;
    }

    public static double Acos(double num)
        =>(Consts.PI / 2) - Asin(num);

    public static double Atan(double num)
    {
        double sum = 0;

        if(num < 1 && num > -1)
        {
            for(int i = 0; i < 100; i++)
            {
                if (i % 2 == 0) sum += Power(num, (i * 2 + 1)) / ((i * 2) + 1);
                else sum -= Power(num, (i * 2 + 1)) / ((i * 2) + 1);
            }

            return sum;
        }

        if (num >= 1) sum += Consts.PI / 2;
        else if (num <= -1) sum -= Consts.PI / 2;

        for(int i = 0; i < 100; i++)
        {
            double helper = 1 / (((2 * i) + 1) * Power(num, (i * 2) + 1));

            if (i % 2 == 0) sum -= helper;
            else sum += helper;
        }

        return sum;
    }

    public static double Asec(double num)
       => Acos(1 / num);

    public static double Acsc(double num)
        => Asin(1 / num);

    public static double Acot(double num)
        => (Consts.PI / 2) - Atan(num);

    #endregion

    #region Logarithmic functions.

    /// <summary>
    /// Returns the natural base (e) logarithm, for the given number.
    /// </summary>
    /// <param name="num">The number whose logarithm value want to be found.</param>
    /// <returns>Returns double-precision floating-point number. Returns System.Double.NaN if num is smaller than or equals 0.</returns>
    public static double Ln(double num)
    {
        if (num <= 0) return System.Double.NaN;

        return PrivateFunctions.LogTen(num) / PrivateFunctions.LogTen(Consts.E);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <param name="logBase"></param>
    /// <returns></returns>
    public static double Log(double num, double logBase)
    {
        if (num <= 0 || logBase == 1 || logBase <= 0) return System.Double.NaN;

        return PrivateFunctions.LogTen(num) / PrivateFunctions.LogTen(logBase); // Logb(a) = log(a) / log(b)
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static double Log10(double num)
    {
        if (num <= 0) return System.Double.NaN;

        return PrivateFunctions.LogTen(num) / PrivateFunctions.LogTen(10);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static double Log2(double num)
    {
        if (num <= 0) return System.Double.NaN;

        return PrivateFunctions.LogTen(num) / PrivateFunctions.LogTen(2);
    }

    #endregion

    #region Hyperbolic functions.

    /// <summary>
    /// Returns the sinh of the given number.
    /// </summary>
    /// <param name="num">An angle, measured in radians.</param>
    /// <returns>The sinh of the given number.</returns>
    public static double Sinh(double num)
    {
        double sum = num;

        for (int i = 3; i < 100; i += 2)
            sum += Power(num, i) / Factorial(i);

        return sum;
    }

    /// <summary>
    /// Returns the cosh of the given number.
    /// </summary>
    /// <param name="num">An angle, measured in radians.</param>
    /// <returns>The cosh of the given number.</returns>
    public static double Cosh(double num)
    {
        double sum = 1;

        for (int i = 2; i < 100; i += 2)
            sum += Power(num, i) / Factorial(i);

        return sum;
    }

    #endregion

    #region Exponential functions.

    /// <summary>
    /// Returns the number e raised to power num.
    /// </summary>
    /// <param name="num">Double-precision floating point number, representing the power wanted.</param>
    /// <returns>Returns e raised to specified power. </returns>
    public static double Exp(double num)
    {
        double sum = 1;

        for (int i = 1; i < 100; i++)
            sum += Power(num, i) / Factorial(i);

        return sum;
    }


    #endregion

}

public static class PreCalculus
{

}


public static class Calculus
{

}


