namespace cnums;

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

