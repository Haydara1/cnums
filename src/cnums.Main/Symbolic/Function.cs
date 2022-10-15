namespace cnums.Symbolic;

public class Function
{

    internal object function;
    
    internal Type type;

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
        type = typeof(Polynomial);
        Domain = new();
    }

    internal Function(Symbol symbol)
    {
        function = symbol;
        type = typeof(Symbol);
        Domain = new();
    }

    internal Function(double value)
    {
        function = value;
        type = typeof(double);
        Domain = new();
    }

    #endregion 

    public object Evaluate(Symbol symbol, double value)
    {
        if (type == typeof(double))
            return this;

        else if (type == typeof(Symbol)
            && symbol == (Symbol)this.function)
            return value;

        else if (type == typeof(Symbol))
            return this.function;

        else if (type == typeof(Polynomial))
            return PrivateFunctions.Evaluate(
                (Polynomial) this.function,symbol, value);

        throw new CnumsException();
    }

    public object Evaluate(Symbol[] symbol, double[] value)
    {
        if (symbol.Length != value.Length)
            throw new ArgumentException("Arguments must be the same length");

        if (type == typeof(double))
            return this;

        else if (type == typeof(Symbol)
            && symbol.Contains((Symbol)function))
            return value;

        else if (type == typeof(Symbol))
            return this.function;

        else if (type == typeof(Polynomial))
        {
            Polynomial polynomial = PrivateFunctions.Instance((Polynomial)function);
            return polynomial.Evaluate(symbol, value);
        }

        throw new CnumsException();
    }

    public double getDegree()
    {
        if (type == typeof(double))
            return 0;
        else if (type == typeof(Symbol))
            return 1;
        else if (type == typeof(Polynomial))
            return PrivateFunctions.getDegree((Polynomial)function);

        throw new CnumsException();
    }

    public override string? ToString()
        => function.ToString();

    #region Addition

    public static Function operator +(Function function)
        => function;

    public static Function operator +(Function function, double number)
    {   
        if (function.type == typeof(double))
            return new((double)function.function + number);

        else if (function.type == typeof(Polynomial))
            return new((Polynomial)function.function + number);

        else if (function.type == typeof(Symbol))
            return new((Symbol)function.function + number);

        throw new CnumsException();
    }

    public static Function operator +(double number, Function function)
        => function + number;

    public static Function operator +(Function function, Symbol symbol)
    {
        if (function.type == typeof(double))
            return new((double)function.function + symbol);

        else if (function.type == typeof(Polynomial))
            return new((Polynomial)function.function + symbol);

        else if (function.type == typeof(Symbol))
            return new((Symbol)function.function + symbol);

        throw new CnumsException();
    }

    public static Function operator +(Symbol symbol, Function function)
        => function + symbol;

    public static Function operator +(Function function1, Function function2)
    {
        if (function1.type == typeof(double)
            && function2.type == typeof(double))
            return new((double)function1.function + (double)function2.function);

        else if (function1.type == typeof(double)
            && function2.type == typeof(Symbol))
            return new((double)function1.function + (Symbol)function2.function);

        else if (function1.type == typeof(double)
            && function2.type == typeof(Polynomial))
            return new((double)function1.function + (Polynomial)function2.function);

        else if (function1.type == typeof(Symbol)
            && function2.type == typeof(double))
            return new((Symbol)function1.function + (double)function2.function);

        else if (function1.type == typeof(Symbol)
            && function2.type == typeof(Symbol))
            return new((Symbol)function1.function + (Symbol)function2.function);

        else if (function1.type == typeof(Symbol)
            && function2.type == typeof(Polynomial))
            return new((Symbol)function1.function + (Polynomial)function2.function);

        else if (function1.type == typeof(Polynomial)
            && function2.type == typeof(double))
            return new((Polynomial)function1.function + (double)function2.function);

        else if (function1.type == typeof(Polynomial)
            && function2.type == typeof(Symbol))
            return new((Polynomial)function1.function + (Symbol)function2.function);

        else if (function1.type == typeof(Polynomial)
            && function2.type == typeof(Polynomial))
            return new((Polynomial)function1.function + (Polynomial)function2.function);

        throw new CnumsException();
    }

    #endregion

    #region Substraction 

    public static Function operator -(Function function)
    {
        if (function.type == typeof(double))
            return new(-(double)function.function);

        else if(function.type == typeof(Symbol))
            return new(-(Symbol)function.function);

        else if (function.type == typeof(Polynomial))
            return new(-(Polynomial)function.function);

        throw new CnumsException();
    }

    public static Function operator -(Function function, double number)
        => function + -number;

    public static Function operator -(double number, Function function)
        => -function + number;

    public static Function operator -(Function function, Symbol symbol)
        => function + -symbol;

    public static Function operator -(Symbol symbol, Function funciton)
        => -funciton + symbol;

    public static Function operator -(Function function1, Function function2)
        => function1 + -function2;

    #endregion

    #region Multiplication

    public static Function operator *(Function function, double number)
    {
        if (function.type == typeof(double))
            return new((double)function.function * number);

        else if (function.type == typeof(Polynomial))
            return new((Polynomial)function.function * number);

        else if (function.type == typeof(Symbol))
            return new((Symbol)function.function * number);

        throw new CnumsException();
    }

    public static Function operator *(double number, Function function)
        => function * number;

    public static Function operator *(Function function, Symbol symbol)
    {
        if (function.type == typeof(double))
            return new((double)function.function * symbol);

        else if (function.type == typeof(Polynomial))
            return new((Polynomial)function.function * symbol);

        else if (function.type == typeof(Symbol))
            return new((Symbol)function.function * symbol);

        throw new CnumsException();
    }

    public static Function operator *(Symbol symbol, Function function)
        => function * symbol;

    #endregion

    #region Division

    #endregion

}

