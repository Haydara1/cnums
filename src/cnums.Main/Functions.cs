using cnums.Symbolic;
using static cnums.Variables;

namespace cnums;

public static class Functions
{
    public readonly static Function constant = 1.ToFunction();

    public readonly static Function linear = x.ToFunction();

    public readonly static Function rLinear = (-x).ToFunction();

    public readonly static Function quadratic = (x * x + x + 1).ToFunction();

    #region Return functions

#pragma warning disable IDE1006

    public static Function getConstant(double value)
        => value.ToFunction();

    public static Function getLinear(Symbol symbol, double coefficient)
        => (symbol * coefficient).ToFunction();

    public static Function getQuadratic(Symbol symbol, double a, double b, double c)
        => (symbol * symbol * a + symbol * b + c).ToFunction();

    public static Function getCubic(Symbol symbol, double a, double b, double c, double d)
        => (symbol * symbol * symbol * a
        + symbol * symbol * b
        + symbol * c
        + d).ToFunction();

    public static Function getNthPolynomial(Symbol symbol, params double[] coefficients)
    {
        Function function = 0.ToFunction();

        for(int i = coefficients.Length - 1; i >= 0; i--)
            function += coefficients[i] * Maths.Power(symbol, i);

        return function;
    }

#pragma warning restore IDE1006

    #endregion
}
