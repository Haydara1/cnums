namespace cnums.Symbolic;

public struct RationalFunction
{

    #region Properties

    private Polynomial numerator;

    private Polynomial denominator;

    internal Polynomial Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public Polynomial Denominator
    {
        get { return denominator; }
        set { denominator = value; }
    }

    #endregion

    #region Constructors

    public RationalFunction(Polynomial numerator, Polynomial denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    #endregion

    public override string ToString()
        => $"({Numerator})/({Denominator})";

    #region Addition

    public static RationalFunction operator +(RationalFunction rationalFunction)
        => rationalFunction;

    public static RationalFunction operator +(RationalFunction rationalFunction, double number)
        => new(rationalFunction.Numerator + (number * rationalFunction.Denominator), 
            rationalFunction.Denominator);

    public static RationalFunction operator +(double number, RationalFunction rationalFunction)
        => rationalFunction + number;

    public static RationalFunction operator +(RationalFunction rationalFunction, Symbol symbol)
        => new(rationalFunction.Numerator + (symbol * rationalFunction.Denominator),
            rationalFunction.Denominator);

    public static RationalFunction operator +(Symbol symbol, RationalFunction rationalFunction)
        => rationalFunction + symbol;

    public static RationalFunction operator +(RationalFunction rationalFunction, Polynomial polynomial)
        => new(rationalFunction.Numerator + (polynomial * rationalFunction.Denominator),
            rationalFunction.Denominator);

    public static RationalFunction operator +(Polynomial polynomial, RationalFunction rationalFunction)
        => rationalFunction + polynomial;

    public static RationalFunction operator +(RationalFunction rationalFunction1, RationalFunction rationalFunction2)
        => new(rationalFunction1.Numerator * rationalFunction2.Denominator
            + rationalFunction2.Numerator * rationalFunction1.Denominator,
            rationalFunction1.Denominator * rationalFunction2.Denominator);

    #endregion

    #region Substraction

    public static RationalFunction operator -(RationalFunction rationalFunction)
        => new(-rationalFunction.Numerator, rationalFunction.Denominator);

    public static RationalFunction operator -(RationalFunction rationalFunction, double number)
        => rationalFunction + (-number);

    public static RationalFunction operator -(double number, RationalFunction rationalFunction)
        => -rationalFunction + number;

    public static RationalFunction operator -(RationalFunction rationalFunction, Symbol symbol)
        => rationalFunction + (-symbol);

    public static RationalFunction operator -(Symbol symbol, RationalFunction rationalFunction)
        => -rationalFunction + symbol;

    public static RationalFunction operator -(RationalFunction rationalFunction, Polynomial polynomial)
        => rationalFunction + (-polynomial);

    public static RationalFunction operator -(Polynomial polynomial, RationalFunction rationalFunction)
        => -rationalFunction + polynomial;

    public static RationalFunction operator -(RationalFunction rationalFunction1, RationalFunction rationalFunction2)
        => rationalFunction1 + (-rationalFunction2);

    #endregion

    #region Multiplication

    public static RationalFunction operator *(RationalFunction rationalFunction, double number)
        => new(rationalFunction.Numerator * number, rationalFunction.Denominator);

    public static RationalFunction operator *(double number, RationalFunction rationalFunction)
        => rationalFunction * number;

    public static RationalFunction operator *(RationalFunction rationalFunction, Symbol symbol)
        => new(rationalFunction.Numerator * symbol, rationalFunction.Denominator);

    public static RationalFunction operator *(Symbol symbol, RationalFunction rationalFunction)
        => rationalFunction * symbol;

    public static RationalFunction operator *(RationalFunction rationalFunction, Polynomial polynomial)
        => new(rationalFunction.Numerator * polynomial, rationalFunction.Denominator);

    public static RationalFunction operator *(Polynomial polynomial, RationalFunction rationalFunction)
        => rationalFunction * polynomial;

    public static RationalFunction operator *(RationalFunction rationalFunction1, RationalFunction rationalFunction2)
        => new(rationalFunction1.Numerator * rationalFunction2.Numerator,
            rationalFunction1.Denominator * rationalFunction2.Denominator);

    #endregion

    #region Division

    public static RationalFunction operator /(RationalFunction rationalFunction, double number)
        => new(rationalFunction.Numerator, rationalFunction.Denominator * number);

    public static RationalFunction operator /(double number, RationalFunction rationalFunction)
        => new(rationalFunction.Denominator * number, rationalFunction.Numerator);

    public static RationalFunction operator /(RationalFunction rationalFunction, Symbol symbol)
        => new(rationalFunction.Numerator, rationalFunction.Denominator * symbol);

    public static RationalFunction operator /(Symbol symbol, RationalFunction rationalFunction)
        => new(rationalFunction.Denominator * symbol, rationalFunction.Numerator);

    public static RationalFunction operator /(RationalFunction rationalFunction, Polynomial polynomial)
        => new(rationalFunction.Numerator * polynomial, rationalFunction.Denominator);

    public static RationalFunction operator /(Polynomial polynomial, RationalFunction rationalFunction)
        => new(rationalFunction.Denominator * polynomial, rationalFunction.Numerator);

    public static RationalFunction operator /(RationalFunction rationalFunction1, RationalFunction rationalFunction2)
        => new(rationalFunction1.Numerator * rationalFunction2.Denominator,
            rationalFunction1.Denominator * rationalFunction2.Numerator);

    #endregion

}
