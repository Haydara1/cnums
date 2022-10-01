using static cnums.PrivateFunctions;

namespace cnums.Symbolic;

public class Polynomial
{
    private List<SymbolContainer> container;

    internal List<SymbolContainer> Container
    {
        get { return container; }
        set { container = value; }
    }

    internal Polynomial(List<SymbolContainer> symbolContainers)
        => container = symbolContainers;

    internal Polynomial(Polynomial polynomial, bool _)
        => container = polynomial.Container;

    public override string ToString()
    {
        string poly = "";

        if (Container == null) return "0";

        foreach (SymbolContainer sym in Container)
            poly += sym.ToString();

        return poly;
    }

    private bool ContainsConstant()
    {
        foreach (SymbolContainer symbolContainer in this.Container)
            if (symbolContainer.isConstant())
                return true;

        return false;
    }

    private int getConstantIndex()
    {
        foreach (SymbolContainer symbolContainer in this.Container)
            if (symbolContainer.isConstant())
                return Container.IndexOf(symbolContainer);

        return -1;
    }

    private bool ContainsSymbol(Symbol symbol)
    {
        foreach (SymbolContainer symbolContainer in this.Container)
            if (symbolContainer.symbol.Contains(symbol))
                return true;

        return false;
    }

    private int FindTerm(Symbol symbol, double exponent)
    {
        foreach (SymbolContainer symbolContainer in this.Container)
            if (symbolContainer.symbol.Count is 1
                && symbolContainer.symbol[0] == symbol
                && symbolContainer.Exponent[0] == exponent)
                return this.Container.IndexOf(symbolContainer);

        return -1;
    }

    #region Addition

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator +(Polynomial polynomial, double number)
    {
        var container = polynomial.Container;
        if (polynomial.ContainsConstant())
            container[polynomial.getConstantIndex()] = (SymbolContainer)
                (polynomial.Container[polynomial.getConstantIndex()] + number);
        else
            container.Add(new SymbolContainer(number));
        
        return new(container);
    }

    public static Polynomial operator +(double number, Polynomial polynomial)
        => polynomial + number;

    public static Polynomial operator +(Polynomial polynomial, Symbol symbol)
    {
        var container = polynomial.Container;
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
        var container = polynomial.Container;
        for (int i = 0; i < container.Count; i++)
            container[i] = -container[i];

        return new(container);
    }

    public static Polynomial operator -(Polynomial polynomial, double number)
    {
        var container = polynomial.Container;
        if (polynomial.ContainsConstant())
            container[polynomial.getConstantIndex()] = (SymbolContainer)
                (polynomial.Container[polynomial.getConstantIndex()] - number);
        else
            container.Add(new SymbolContainer(-number));

        return new(container);
    }

    public static Polynomial operator -(double number, Polynomial polynomial)
        => -(-number + polynomial);

    public static Polynomial operator -(Polynomial polynomial, Symbol symbol)
    {
        var container = polynomial.Container;
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
        List<SymbolContainer> container = polynomial.Container;
        for (int i = 0; i < container.Count; i++)
            container[i] *= number;

        return new(container);
    }

    public static Polynomial operator *(Polynomial polynomial, Symbol symbol)
    {
        List<SymbolContainer> container = polynomial.Container;
        for (int i = 0; i < container.Count; i++)
            container[i] *= symbol;

        return new(container);
    }


    #endregion
}
