namespace cnums.Symbolic;

public class Function
{

    private object function;

    private Domain? domain;

    public Domain? Domain
    {
        get { return domain; }
        private set { domain = value; }
    }

    #region  Constructors

    internal Function(Polynomial polynomial)
    {
        function = polynomial;
        Domain = new();
    }

    internal Function(Symbol symbol)
    {
        function = symbol;
        Domain = new();
    }

    internal Function(double value)
    {
        function = value;
        Domain = new();
    }

    internal Function(int value)
    {
        function = value;
        Domain = new();
    }

    #endregion 

    public override string? ToString()
        => function.ToString();

    #region Addition

    public static Function operator +(Function function)
        => function;

    public static Function operator +(Function function, double number)
    {
        if (function.function.GetType() == typeof(double))
            return new((double)function.function + number);

        else if (function.function.GetType() == typeof(int))
            return new((int)function.function + number);

        else if (function.function.GetType() == typeof(Polynomial))
            return new((Polynomial)function.function + number);

        else if (function.function.GetType() == typeof(Symbol))
            return new((Symbol)function.function + number);

        throw new CnumsException();
    }

    public static Function operator +(double number, Function function)
        => function + number;

    public static Function operator +(Function function, Symbol symbol)
    {
        if (function.function.GetType() == typeof(double))
            return new((double)function.function + symbol);

        else if (function.function.GetType() == typeof(int))
            return new((int)function.function + symbol);

        else if (function.function.GetType() == typeof(Polynomial))
            return new((Polynomial)function.function + symbol);

        else if (function.function.GetType() == typeof(Symbol))
            return new((Symbol)function.function + symbol);

        throw new CnumsException();
    }

    public static Function operator +(Symbol symbol, Function function)
        => function + symbol;

    #endregion

}

