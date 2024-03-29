﻿using System.Numerics;

namespace cnums;

public static partial class Maths
{
    //precise
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

    //precise
    #region Factorial functions

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value is to be found.</param>
    /// <returns>Returns a double-precision floating-point number.</returns>
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
    /// <param name="num">Number whose factorial value is to be found.</param>
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
    /// <param name="num">Number whose factorial value is to be found.</param>
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
    /// <param name="num">Number whose factorial value is to be found.</param>
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
    /// <param name="num">Number whose factorial value is to be found.</param>
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

    /// <summary>
    /// Returns the factorial value of the given number.
    /// </summary>
    /// <param name="num">Number whose factorial value is to be found.</param>
    /// <returns>Returns a BigInteger.</returns>
    public static BigInteger Factorial(BigInteger num)
    {
        BigInteger f;

        if (num == 0 || num == 1)
            return 1;
        else
            f = (BigInteger)(num * Factorial((BigInteger)num - 1));

        return f;
    }

    #endregion

    #region Clamp

    public static int Clamp(int min, int max, int number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static uint Clamp(uint min, uint max, uint number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static short Clamp(short min, short max, short number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static ushort Clamp(ushort min, ushort max, ushort number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static long Clamp(long min, long max, long number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static ulong Clamp(ulong min, ulong max, ulong number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static byte Clamp(byte min, byte max, byte number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static float Clamp(float min, float max, float number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static double Clamp(double min, double max, double number)
        => Statistics.Max(Statistics.Min(number, max), min);

    public static decimal Clamp(decimal min, decimal max, decimal number)
        => Statistics.Max(Statistics.Min(number, max), min);

    #endregion

    #region Miscellaneous.

    //precise
    /// <summary>
    /// Returns the cubic root of the given number.
    /// </summary>
    /// <param name="num">The number whose cubic root is to be found.</param>
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

    //precise
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

    //precise
    internal static long Floor(double num, bool _)
    {
        string s = num.ToString();

        if (!s.Contains('.')) return (long)num;

        string n = String.Empty;

        foreach (char c in s)
        {
            if (c == '.') break;
            n += c;
        }

        num = Convert.ToInt64(n);

        if (n[0] == '-')
        {
            num--;
        }

        return (long)num;
    }

    //precise
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

    //precise
    /// <summary>
    /// Returns the square root of the given number.
    /// </summary>
    /// <param name="num">The number whose square root is to be found.</param>
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

    //precise
    /// <summary>
    /// Converts given number in degrees to radians.
    /// </summary>
    /// <param name="num">Double-precision floating-point number mesured in degrees.</param>
    /// <returns>Returns a double-precision floating-point number in radians. Returns System.Double.NaN if num was equal to System.Double.NaN</returns>
    public static double ToRadian(this double num)
        => Consts.PI * num / 180;

    //precise, only including integers.
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

    //precise, only including integers.
    public static int LCM(int a, int b)
        => (a * b) / GCD(a, b);

    //precise
    /// <summary>
    /// Returns the prime factors of the given number.
    /// </summary>
    /// <param name="num">The number whose primes factors is to be found.</param>
    /// <param name="DistinctFactors">If True, returns an array with only distinct prime factors, otherwise, multiple prime factors may be repeated.</param>
    /// <returns>An integer array, containing the prime factors of the given number.</returns>
    public static int[] Factorize(int num, bool DistinctFactors = false)
    {
        int divisor = 2;
        List<int> list = new();


        while (true)
        {
            if (num % divisor == 0)
            {
                list.Add(divisor);
                num /= divisor;

                if (num == 1) break;

                continue;
            }

            divisor++;


            for (int i = 0; i < list.Count; i++)
            {
                if (divisor % list[i] == 0)
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

    //precise
    /// <summary>
    /// Checks if the given integer is prime.
    /// </summary>
    /// <param name="num">An integer number.</param>
    /// <returns>Returns True if num is prime, otherwise, returns False.</returns>
    public static bool isPrime(int num)
    {
        int index = 2;

        while (true)
        {
            if (num % index == 0) break;
            index++;
        }

        return (index == num);

    }

    /// <summary>
    /// Returns 1 or -1, depending on the given number.
    /// </summary>
    /// <param name="num">Double-precision floating-number whose sign is to be found.</param>
    /// <returns>Returns 1 if num > 0, retunr -1 if num < 0.</returns>
    public static int Sign(double num)
        => (int)(num / Abs(num));

    #endregion
}
