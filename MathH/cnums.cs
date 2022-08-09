namespace cnums;

/// <summary>
///     Provides a list of most used mathematics constants.
/// </summary>
public static class Consts
{
    /// <summary>
    ///     Represents the natural logarithmic base, specified by the constant, e.
    /// </summary>
    public const double E = 2.7182818284590451; //1 / 10 ^ 16 precision 

    /// <summary>
    ///     Represents the ratio of the circumference of a circle to its diameter, specified
    ///     by the constant, π.
    /// </summary>  
    public const double PI = 3.1415926535897931; //1 / 10 ^ 16 precision 

    /// <summary>
    ///     Represents the number of radians in one turn, specified by the constant, τ.
    /// </summary>
    public const double Tau = 6.2831853071795862; //1 / 10 ^ 16 precision 

    ///<summary>
    ///     Represents the Euler-Mascheroni constant.
    ///</summary>
    public const double Gamma = 0.57721566490153286060; //1 / 10 ^ 20 precision 

    ///<summary>
    ///     Represents the golden ratio, specified by the constant φ.
    /// </summary>
    public const double Phi = 1.61803398874989484820; //1 / 10 ^ 20 precision 

    ///<summary>
    ///     Represents the square root of -1, specified by the constant i.
    /// </summary>
    public static readonly Complex j = new(0, 1);
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