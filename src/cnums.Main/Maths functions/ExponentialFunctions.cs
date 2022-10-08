namespace cnums;

public static partial class Maths
{
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

    #region Exponential functions.

    /// <summary>
    /// Returns the number e raised to power num.
    /// </summary>
    /// <param name="num">Double-precision floating point number, representing the power wanted.</param>
    /// <returns>Returns e raised to specified power. </returns>
    public static double Exp(double num)
    {
        if(num > 709)
            return System.Double.PositiveInfinity;

        long x = Floor(num, true);

        //Determine the weights.
        double PowerOfTwo = 0.5;
        double z = num - x;
        double[] w = new double[100];

        for (int i = 0; i < 100; i++)
        {
            if (PowerOfTwo < z)
            {
                w[i] = 1;
                z -= PowerOfTwo;
            }

            PowerOfTwo /= 2;
        }

        //Calculate products.
        double fx = 1;
        double ai = 0;

        for (int i = 0; i < 100; i++)
        {
            if (i < Consts.ExpValues.Length)
                ai = Consts.ExpValues[i];
            else ai = 1 + (ai - 1) / 2;

            if (0 < w[i]) fx *= ai;
        }

        //Perform residual multiplication.
        fx = fx
            * (1 + z
            * (1 + z / 2
            * (1 + z / 3
            * (1 + z / 4))));

        //Account for factor exp(X_INT).
        if (x < 0)
            for (int i = 0; i < -x; i++)
                fx /= Consts.E;
        else
            for (int i = 0; i < x; i++)
                fx *= Consts.E;

        return fx;
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
