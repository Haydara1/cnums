namespace cnums;

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

    public static uint Max(uint a, uint b)
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

    public static uint Min(uint a, uint b)
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
