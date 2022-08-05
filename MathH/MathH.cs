using System.Diagnostics;

namespace cnums;

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

    ///<summary>
    ///     Represents the square root of -1, specified by the constant i.
    /// </summary>
    public static readonly Complex j = new(0, 1);
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

    /// <summary>
    ///     Returns the absolute value of a complex number.
    /// </summary>
    /// <param name="value">A cnums.Complex number.</param>
    /// <returns>
    ///     A cnums.Complex number, the modulus of the given number.
    /// </returns>
    public static double Abs(Complex c)
        => Sqrt(Power(c.Re) + Power(c.Im));

    #endregion

    #region Factorial functions

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value want to be found.</param>
    /// <returns>Returns an double-precision floating-point number.</returns>
    public static double Factorial(double num)
    {
        double f;

        if (num == 0 || num == 1)
            return 1;

        else
            f = num * Factorial((double)num - 1);

        return f;
    }

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value want to be found.</param>
    /// <returns>Returns an single-precision floating-point number.</returns>
    public static float Factorial(float num)
    {
        float f;

        if (num == 0 || num == 1)
            return 1;

        else
            f = num * Factorial((float)num - 1);

        return f;
    }

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value want to be found.</param>
    /// <returns>Returns an Int32 number.</returns>
    public static int Factorial(int num)
    {
        int f;

        if (num == 0 || num == 1)
            return 1;

        else
            f = num * Factorial((int)num - 1);

        return f;
    }

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value want to be found.</param>
    /// <returns>Returns an Int64 number.</returns>
    public static long Factorial(long num)
    {
        long f;

        if (num == 0 || num == 1)
            return 1;

        else
            f = num * Factorial((long)num - 1);

        return f;
    }

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value want to be found.</param>
    /// <returns>Returns an Int16 number.</returns>
    public static short Factorial(short num)
    {
        short f;

        if (num == 0 || num == 1)
            return 1;

        else
            f = (short)(num * Factorial((short)num - 1));

        return f;
    }

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value want to be found.</param>
    /// <returns>Returns a decimal number.</returns>
    public static decimal Factorial(decimal num)
    {
        decimal f;

        if (num == 0 || num == 1)
            return 1;

        else
            f = (decimal)(num * Factorial((decimal)num - 1));

        return f;
    }

    public static double Gamma(double num)
    {
        if(num % 0.5 == 0)
        {
            double p = Sqrt(Consts.PI);
            
            while(num != 0.5)
            {
                p *= num;
                num -= 1;
            }

            return p;
        }


        double product = Exp(Consts.Gamma * num);
        product *= num;

        for(int i = 1; i < 100; i++)
        {
            double helper = 1 + (num / i);
            helper *= Exp(-(num / i));
            product *= helper;
        }

        return 1 / product;
    }

    #endregion

    #region Miscellaneous.

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
    /// Returns the square root of the given complex number.
    /// </summary>
    /// <param name="num">The number whose square root want to be found.</param>
    /// <returns>Returns a cnums.Complex number, representing the square root of the given number.</returns>
    public static Complex Sqrt(Complex complex)
    {
        double real, immaginary;

        real = Sqrt((complex.Modulus() + complex.Re) / 2);
        immaginary = complex.Im / Abs(complex.Im);
        immaginary *= Sqrt((complex.Modulus() - complex.Re) / 2);

        return new(real, immaginary);
    }

    /// <summary>
    /// Converts given number in degrees to radians.
    /// </summary>
    /// <param name="num">Double-precision floating-point number mesured in degrees.</param>
    /// <returns>Returns a double-precision floating-point number in radians. Returns System.Double.NaN if num was equal to System.Double.NaN</returns>
    public static double ToRadian(this double num)
        => Consts.PI * num / 180;

    /// <summary>
    /// Return the greatest common divisor of the given numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>Returns Int32, the greatest common divisior of the given numbers.</returns>
    public static int GCD(int a, int b)
    {
        if (a == 0 || b == 0) return Statistics.Max(a, b);

        int g;

        if (a > b)
        {
            int r = a % b;
            g = GCD(b, r);
        }

        else
        {
            int r = b % a;
            g = GCD(a, r);
        }

        return g;
    }

    public static int LCM(int a, int b)
        => (a * b) / GCD(a, b);

    public static int[] PrimeFactors(int num, bool DistinctFactors = false)
    {
        int divisor = 2;
        List<int> list = new();


        while(true)
        {
            if(num % divisor == 0)
            {
                list.Add(divisor);
                num /= divisor;

                if (num == 1) break;

                continue;
            }

            divisor++;

            
            for(int i = 0; i < list.Count; i++)
            {
                if(divisor % list[i] == 0)
                {
                    divisor++;
                    i = 0;
                    continue;
                }
            }
        }

        if (DistinctFactors) return list.Distinct().ToArray();

        return list.ToArray();
    }

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
        =>(Consts.PI / 2) - Asin(num);

    public static double Atan(double num)
    {
        double sum = 0;

        if(num < 1 && num > -1)
        {
            for(int c = 0; c < 100; c++)
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
        => (Exp(num) - Exp(-num)) / 2;

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

    #region Inverse hyperbolic functions

    public static double Asinh(double num)
    {
        double sum;

        if(num > -1 && num < 1)
        {
            sum = num;

            for (int i = 1; i < 151; i++)
            {
                double helper = Power(num, (i * 2) + 1) / ((i * 2) + 1);

                double multi = 1, div = 1;

                for (int j = 1; j <= i * 2; j++)
                    if (j % 2 == 0) div *= j;
                    else multi *= j;

                helper *= multi;
                helper /= div;

                if (i % 2 == 0) sum += helper;
                else sum -= helper;
            }

            return sum;
        }

        sum = Ln(2 * num);

        for(int i = 1; i < 100; i++) //Precision error when num < 1
        {
            int k = i * 2;

            double helper;
            double multi = 1, div = 1;

            div *= k * Power(num, k);

            for (int j = 1; j <= k; j++)
                if (j % 2 == 0) div *= j;
                else multi *= j;

            helper = multi / div;

            if (i % 2 == 0) sum -= helper;
            else sum += helper;
        }

        if (num <= -1) sum *= -1;

        return sum;
    }

    public static double Atanh(double num)
    {
        if (num >= 1 || num <= -1) return System.Double.NaN;

        double sum = 0;

        for (int i = 0; i < 100; i++)
            sum += Power(num, (i * 2) + 1) / ((i * 2) + 1);

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
            sum += Power(num, i) / Factorial((double)i);

        return sum;
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
    /// Returns the number x raised to power y.
    /// </summary>
    /// <param name="x">Power base.</param>
    /// <param name="y">Decimal (non-integer) power.</param>
    /// <returns>Returns double-point floating-value number.</returns>
    public static double Power(double x, double y)
        => Exp(y * Ln(x));

    #endregion

}

public static class Probabilites 
{
    #region nPr

#pragma warning disable IDE1006 // Naming Styles
    public static double nPr(double n, double r)
#pragma warning restore IDE1006 // Naming Styles
        => Maths.Factorial(n) / Maths.Factorial(n - r);

#pragma warning disable IDE1006 // Naming Styles
    public static float nPr(float n, float r)
        => Maths.Factorial((float)n) / Maths.Factorial((float)n - r);

    public static int nPr(int n, int r)
        => Maths.Factorial((int)n) / Maths.Factorial((int)n - r);

    public static long nPr(long n, long r)
        => Maths.Factorial((long)n) / Maths.Factorial((long)n - r);

    public static decimal nPr(decimal n, decimal r)
        => Maths.Factorial((decimal)n) / Maths.Factorial((decimal)n - r);

    public static short nPr(short n, short r)
        => (short)(Maths.Factorial((short)n) / Maths.Factorial((short)n - r));


    #endregion

    #region nCr

    public static double nCr(double n, double r)
        => Maths.Factorial((double)n) / (Maths.Factorial((double)n - r) * Maths.Factorial((double)r));

    public static float nCr(float n, float r)
        => (float)(Maths.Factorial((float)n) / (Maths.Factorial((float)n - r) * Maths.Factorial((float)r)));

    public static int nCr(int n, int r)
        => (int)Maths.Factorial((int)n) / (int)(Maths.Factorial((int)n - r) * Maths.Factorial((int)r));

    public static long nCr(long n, long r)
        => (long)Maths.Factorial((long)n) / (long)(Maths.Factorial((long)n - r) * Maths.Factorial((long)r));

    public static short nCr(short n, short r)
        => (short)((short)Maths.Factorial((short)n) / (short)(Maths.Factorial((short)n - r) * Maths.Factorial((short)r)));

    public static decimal nCr(decimal n, decimal r)
        => (decimal)Maths.Factorial((decimal)n) / (decimal)(Maths.Factorial((decimal)(n - r)) * Maths.Factorial((decimal)r));

#pragma warning restore IDE1006 // Naming Styles
    #endregion
}

public static class Statistics
{
    #region Max and min functions.

    public static int Max(int a, int b)
    {
        if (a >= b) return a;
        return b;
    }

    public static double Max(double a, double b)
    {
        if (a >= b) return a;
        return b;
    }

    public static float Max(float a, float b)
    {
        if (a >= b) return a;
        return b;
    }

    public static long Max(long a, long b)
    {
        if (a >= b) return a;
        return b;
    }

    public static short Max(short a, short b)
    {
        if (a >= b) return a;
        return b;
    }

    public static decimal Max(decimal a, decimal b)
    {
        if (a >= b) return a;
        return b;
    }

    public static int Min(int a, int b)
    {
        if (a <= b) return a;
        return b;
    }

    public static double Min(double a, double b)
    {
        if (a <= b) return a;
        return b;
    }

    public static float Min(float a, float b)
    {
        if (a <= b) return a;
        return b;
    }

    public static long Min(long a, long b)
    {
        if (a <= b) return a;
        return b;
    }

    public static short Min(short a, short b)
    {
        if (a <= b) return a;
        return b;
    }

    public static decimal Min(decimal a, decimal b)
    {
        if (a <= b) return a;
        return b;
    }

    #endregion

    #region Mean functions

    public static double Mean(double[] array)
    {
        double sum = 0;

        foreach (double d in array) sum += d;

        return sum / array.Length;
    }

    public static float Mean(float[] array)
    {
        float sum = 0;

        foreach (float f in array) sum += f;

        return sum / array.Length;
    }

    public static int Mean(int[] array)
    {
        int sum = 0;

        foreach (int i in array) sum += i;

        return sum / array.Length;
    }

    public static long Mean(long[] array)
    {
        long sum = 0;

        foreach (long l in array) sum += l;

        return sum / array.Length;
    }

    public static short Mean(short[] array)
    {
        short sum = 0;

        foreach (short s in array) sum += s;

        return (short)(sum / array.Length);
    }

    public static decimal Mean(decimal[] array)
    {
        decimal sum = 0;

        foreach (decimal d in array) sum += d;

        return sum / array.Length;
    }

    public static uint Mean(uint[] array)
    {
        uint sum = 0;

        foreach (uint u in array) sum += u;

        return (uint)(sum / array.Length);
    }

    #endregion

    #region Median functions.

    public static double Median(double[] array)
    {
        Array.Sort(array);

        int index;

        if (array.Length % 2 != 0) index = (array.Length + 1) / 2;
        else index = array.Length / 2;

        return array[index];
    }

    #endregion
}

public static class Calculus
{

}

//How are you Julia?