using static cnums.PrivateFunctions;

namespace cnums.Symbolic;

public struct Polynomial
{
    public List<SymbolContainer> container = new() { };

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

    #region Addition

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator +(Polynomial polynomial, double number)
    {
        var container = polynomial.container;
        if (polynomial.ContainsConstant())
            container[polynomial.getConstantIndex()] = (SymbolContainer)
                (polynomial.container[polynomial.getConstantIndex()] + number);
        else
            container.Add(new SymbolContainer(number));
        
        return new(container);
    }

    public static Polynomial operator +(double number, Polynomial polynomial)
        => polynomial + number;

    public static Polynomial operator +(Polynomial polynomial, Symbol symbol)
    {
        var container = polynomial.container;
        if (polynomial.ContainsSymbol(symbol))
            container[polynomial.FindTerm(symbol, 1)].Coefficient++;
        else
            container.Add(new SymbolContainer(symbol));

        return new(container);
    }

    public static Polynomial operator +(Symbol symbol, Polynomial polynomial)
        => polynomial + symbol;

    #endregion


    #region Substraction

    public static Polynomial operator -(Polynomial polynomial)
    {
        // Asked for a question in Stack Overflow: https://stackoverflow.com/questions/73918546/static-operator-function-in-c-sharp-affecting-the-given-arguments
        // Asked again in Stack Overflow: https://stackoverflow.com/questions/74003130/operator-overloading-changes-operands

        Polynomial result = polynomial;

        for (int i = 0; i < result.container.Count; i++)
            result.container[i] = -result.container[i];

        return result;
    }

    public static Polynomial operator -(Polynomial polynomial, double number)
    {
        var container = polynomial.container;
        if (polynomial.ContainsConstant())
            container[polynomial.getConstantIndex()] = (SymbolContainer)
                (polynomial.container[polynomial.getConstantIndex()] - number);
        else
            container.Add(new SymbolContainer(-number));

        return new(container);
    }

    public static Polynomial operator -(double number, Polynomial polynomial)
        => -(-number + polynomial);

    public static Polynomial operator -(Polynomial polynomial, Symbol symbol)
    {
        var container = polynomial.container;
        if (polynomial.ContainsSymbol(symbol))
            container[polynomial.FindTerm(symbol, 1)].Coefficient--;
        else
            container.Add(-new SymbolContainer(symbol));

        return new(container);
    }

    //public static Polynomial operator -(Symbol symbol, Polynomial polynomial)
    //    => -(-symbol + polynomial);

    #endregion

    #region Multiplication

    public static Polynomial operator *(Polynomial polynomial, double number)
    {
        List<SymbolContainer> container = polynomial.container;
        for (int i = 0; i < container.Count; i++)
            container[i] *= number;

        return new(container);
    }

    public static Polynomial operator *(Polynomial polynomial, Symbol symbol)
    {
        List<SymbolContainer> container = polynomial.container;
        for (int i = 0; i < container.Count; i++)
            container[i] *= symbol;

        return new(container);
    }


    #endregion
}
