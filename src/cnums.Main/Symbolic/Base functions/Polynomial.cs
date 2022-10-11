using static cnums.PrivateFunctions;

namespace cnums.Symbolic;

public struct Polynomial
{
    private List<SymbolContainer> container = new() { };

    public List<SymbolContainer> Container 
    { 
        get { return container; } 
        set { container = value; }
    }

    public Polynomial(List<SymbolContainer> symbolContainers)
        => this.container = symbolContainers;

    internal Polynomial(Polynomial polynomial, bool _)
        => this.container = polynomial.container;

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

    private int getConstantIndex()
    {
        foreach (SymbolContainer symbolContainer in this.container)
            if (symbolContainer.isConstant())
                return container.IndexOf(symbolContainer);

        return -1;
    }

    private bool ContainsSymbol(Symbol symbol)
    {
        foreach (SymbolContainer symbolContainer in this.container)
            if (symbolContainer.symbol.Contains(symbol))
                return true;

        return false;
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

    public static Polynomial operator +(Polynomial polynomial, SymbolContainer symbolContainer)
    {
        Polynomial result = polynomial.Instance();

        if (PolynomialContainsSymbol(result, symbolContainer))
        {
            int index = IndexOfSymbol(result, symbolContainer);
            result.Container[index] = (SymbolContainer)(result.Container[index] + symbolContainer);
        }
        else
            result.Container.Add(symbolContainer);

        return result;
    }

    public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
    {
        Polynomial result = polynomial1.Instance();

        for (int i = 0; i < polynomial2.Container.Count; i++)
            result += polynomial2.Container[i];

        return result;
    }

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

    public static Polynomial operator -(Polynomial polynomial, SymbolContainer symbolContainer)
        => polynomial + (-symbolContainer);

    public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        => polynomial1 + (-polynomial2);

    #endregion

    #region Multiplication

    public static Polynomial operator *(Polynomial polynomial, double number)
    {
        Polynomial result = polynomial.Instance();
        for (int i = 0; i < result.container.Count; i++)
            result.container[i] *= number;

        return result;
    }

    public static Polynomial operator *(Polynomial polynomial, Symbol symbol)
    {
        Polynomial result = polynomial.Instance();
        for (int i = 0; i < result.container.Count; i++)
            result.container[i] *= symbol;

        return result;
    }

    #endregion

    public static Polynomial operator /(Polynomial polynomial, double number)
    {
        {
            Polynomial result = polynomial.Instance();
            for (int i = 0; i < result.container.Count; i++)
                result.container[i] /= number;

            return result;
        }
    }
}
