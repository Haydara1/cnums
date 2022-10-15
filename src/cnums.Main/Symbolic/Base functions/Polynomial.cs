using static cnums.PrivateFunctions;

namespace cnums.Symbolic;

public struct Polynomial
{
    #region Properties

    private List<SymbolContainer> container = new() { };

    internal List<SymbolContainer> Container 
    { 
        get { return container; } 
        set { container = value; }
    }

    #endregion

    #region Constructors

    internal Polynomial(List<SymbolContainer> symbolContainers)
        => this.container = symbolContainers;

    internal Polynomial(Polynomial polynomial, bool _)
        => this.container = polynomial.container;

    #endregion

#pragma warning disable IDE1006

    public override string ToString()
    {
        string poly = "";

        if (container == null) return "0";

        foreach (SymbolContainer sym in container)
            poly += sym.ToString();

        return poly;
    }

    private bool ContainsConstant()
    {
        foreach (SymbolContainer symbolContainer in this.container)
            if (symbolContainer.isConstant())
                return true;

        return false;
    }

    private bool ContainsSymbol(Symbol symbol)
    {
        foreach (SymbolContainer symbolContainer in this.container)
            if (symbolContainer.symbol.Contains(symbol))
                return true;

        return false;
    }

    private int getConstantIndex()
    {
        foreach (SymbolContainer symbolContainer in this.container)
            if (symbolContainer.isConstant())
                return container.IndexOf(symbolContainer);

        return -1;
    }

    private int FindTerm(Symbol symbol, double exponent)
    {
        foreach (SymbolContainer symbolContainer in this.container)
            if (symbolContainer.symbol.Count is 1
                && symbolContainer.symbol[0] == symbol
                && symbolContainer.Exponent[0] == exponent)
                return this.container.IndexOf(symbolContainer);

        return -1;
    }

    internal double getDegree()
    {
        double degree = 0;
        
        foreach(SymbolContainer symbolContainer in this.container)
            degree = Statistics.Max(degree, symbolContainer.getDegree());

        return degree;
    }

    /// <summary>
    /// Changes the symbol a to symbol b.
    /// </summary>
    /// <param name="a">The symbol wanted to be changed.</param>
    /// <param name="b">The symbol that will be updated to.</param>
    public Polynomial ChangeSymbol(Symbol a, Symbol b)
    {
        Polynomial polynomial = this.Instance();

        for (int i = 0; i < polynomial.Container.Count; i++)
            polynomial.Container[i] = polynomial.Container[i].ChangeSymbol(a, b);

        return polynomial;
    }

    public Polynomial Evaluate(Symbol symbol, double value)
        => PrivateFunctions.Evaluate(this, symbol, value);

    public Polynomial Evaluate(Symbol[] symbols, double[] values)
    {
        if (symbols.Length != values.Length)
            throw new ArgumentException("Arrays must be the same size.");

        Polynomial result = this.Instance();

        for(int i = 0; i < symbols.Length; i++)
            result = PrivateFunctions.Evaluate(result, symbols[i], values[i]);

        return result;
    }

    public Function ToFunction()
        => new(this);

#pragma warning restore IDE1006

    #region Addition

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator +(Polynomial polynomial, double number)
    {
        Polynomial result = polynomial.Instance();

        if (result.ContainsConstant())
            result.container[result.getConstantIndex()] = (SymbolContainer)
                (result.container[result.getConstantIndex()] + number);
        else
            result.container.Add(new SymbolContainer(number));
        
        return result;
    }

    public static Polynomial operator +(double number, Polynomial polynomial)
        => polynomial + number;

    public static Polynomial operator +(Polynomial polynomial, Symbol symbol)
    {
        Polynomial result = polynomial.Instance();
        SymbolContainer symbolContainer = new(symbol);

        if (PolynomialContainsSymbol(result, symbolContainer))
        {
            int index = IndexOfSymbol(result, symbolContainer);
            result.container[index] = new(result.container[index].symbol,
                                    result.container[index].Coefficient + 1,
                                    result.container[index].Exponent);
        }
        else
            result.container.Add(new SymbolContainer(symbol));

        return result;
    }

    public static Polynomial operator +(Symbol symbol, Polynomial polynomial)
        => polynomial + symbol;

    public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
    {
        Polynomial result = polynomial1.Instance();

        for (int i = 0; i < polynomial2.Container.Count; i++)
            result += polynomial2.Container[i];

        return result;
    }

    public static Function operator +(Function function, Polynomial polynomial)
    {
        if (function.type == typeof(double))
            return new((double)function.function + polynomial);

        else if (function.type == typeof(Polynomial))
            return new((Polynomial)function.function + polynomial);

        else if (function.type == typeof(Symbol))
            return new((Symbol)function.function + polynomial);

        throw new CnumsException();
    }

    public static Function operator +(Polynomial polynomial, Function function)
        => function + polynomial;

    #endregion


    #region Substraction

    public static Polynomial operator -(Polynomial polynomial)
    {
        // Asked for a question in Stack Overflow: https://stackoverflow.com/questions/73918546/static-operator-function-in-c-sharp-affecting-the-given-arguments
        // Asked again in Stack Overflow: https://stackoverflow.com/questions/74003130/operator-overloading-changes-operands

        Polynomial result = new(new List<SymbolContainer>());

        for (int i = 0; i < polynomial.container.Count; i++)
            result.container.Add(-polynomial.container[i]);

        return result;
    }

    public static Polynomial operator -(Polynomial polynomial, double number)
    {
        Polynomial result = polynomial.Instance();

        if (result.ContainsConstant())
            result.container[result.getConstantIndex()] = (SymbolContainer)
                (result.container[result.getConstantIndex()] - number);
        else
            result.container.Add(new SymbolContainer(-number));

        return result;
    }

    public static Polynomial operator -(double number, Polynomial polynomial)
        => -(-number + polynomial);

    public static Polynomial operator -(Polynomial polynomial, Symbol symbol)
    {
        Polynomial result = polynomial.Instance();
        SymbolContainer symbolContainer = new(symbol);

        if (PolynomialContainsSymbol(result, symbolContainer))
        {
            int index = IndexOfSymbol(result, symbolContainer);
            result.container[index] = new(result.container[index].symbol,
                                    result.container[index].Coefficient - 1,
                                    result.container[index].Exponent);
        }
        else
            result.container.Add(-new SymbolContainer(symbol));

        return result;
    }

    public static Polynomial operator -(Symbol symbol, Polynomial polynomial)
        => symbol + (-polynomial);

    public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        => polynomial1 + (-polynomial2);

    public static Function operator -(Function function, Polynomial polynomial)
        => function + -polynomial;

    public static Function operator -(Polynomial polynomial, Function function)
        => polynomial + -function;

    #endregion

    #region Multiplication

    public static Polynomial operator *(Polynomial polynomial, double number)
    {
        Polynomial result = polynomial.Instance();
        for (int i = 0; i < result.container.Count; i++)
            result.container[i] *= number;

        return result;
    }

    public static Polynomial operator *(double number, Polynomial polynomial)
        => polynomial * number;

    public static Polynomial operator *(Polynomial polynomial, Symbol symbol)
    {
        Polynomial result = polynomial.Instance();
        for (int i = 0; i < result.container.Count; i++)
            result.container[i] *= symbol;

        return result;
    }

    public static Polynomial operator *(Symbol symbol, Polynomial polynomial)
        => polynomial * symbol;

    public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
    {
        Polynomial polynomial = polynomial1.Instance();

        foreach (SymbolContainer symbolContainer in polynomial2.container)
            polynomial *= symbolContainer;

        return polynomial;
    }

    #endregion

    #region Division

    public static Polynomial operator /(Polynomial polynomial, double number)
    {
        {
            Polynomial result = polynomial.Instance();
            for (int i = 0; i < result.container.Count; i++)
                result.container[i] /= number;

            return result;
        }
    }

    public static RationalFunction operator /(double number, Polynomial polynomial)
        => new(new(new() { new(number) }), polynomial);

    public static RationalFunction operator /(Polynomial polynomial, Symbol symbol)
        => new(polynomial, new(new() { new(symbol) }));

    public static RationalFunction operator /(Symbol symbol, Polynomial polynomial)
        => new(new(new() { new(symbol) }), polynomial);

    public static RationalFunction operator /(Polynomial polynomial1, Polynomial polynomial2)
        => new(polynomial1, polynomial2);

    #endregion
}
