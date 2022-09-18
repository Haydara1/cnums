namespace cnums;

public static partial class Maths
{
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

        if (num > -1 && num < 1)
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

        for (int i = 1; i < 100; i++) //Precision error when num < 1
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


}