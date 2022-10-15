using cnums.Symbolic;

namespace cnums;

internal class SymbolContainer
{
    public List<Symbol> symbol = new();

    public double Coefficient;

    public List<double> Exponent = new() { };

    #region Constructors

    public SymbolContainer(Symbol symbol, double coefficient, double exponent)
    {
        this.symbol.Add(symbol);
        Coefficient = coefficient;
        Exponent.Add(exponent);
    }

    public SymbolContainer(List<Symbol> symbol, double coefficient, List<double> exponent)
    {
        this.symbol = symbol;
        Coefficient = coefficient;
        Exponent = exponent;
    }

    public SymbolContainer(double number)
        => Coefficient = number;

    public SymbolContainer(Symbol symbol)
    {
        this.Coefficient = 1;
        Exponent.Add(1);
        this.symbol.Add(symbol);
    }

    public SymbolContainer(Symbol symbol, double coefficient)
    {
        this.Coefficient = coefficient;
        Exponent.Add(1);
        this.symbol.Add(symbol);
    }

    #endregion

#pragma warning disable IDE1006

    public override string ToString()
    {
        Clean();

        if (isNull())
            return "";
        else if (isConstant())
            return Coefficient > 0 ? "+" + Maths.Abs(Coefficient).ToString() :
                                     "-" + Maths.Abs(Coefficient).ToString();

        if (Cnums.Unicode)
            return ToUnicodeString();

        string result;

        if (Coefficient is 1)
            result = "+";
        else if (Coefficient is -1)
            result = "-";
        else 
            result = Coefficient < 0 ? Coefficient.ToString() : "+" + Coefficient.ToString();

        for (int i = 0; i < symbol.Count; i++)
        {
            if(result is "+" or "-")
                result += Exponent[i] == 1 ? symbol[i] : $"{symbol[i]}^{Exponent[i]}";
            else
                result += Exponent[i] == 1 ? "*" + symbol[i] : $"*{symbol[i]}^{Exponent[i]}";
        }   

        return result;
    }

    private string ToUnicodeString()
    {
        string result;

        if (Coefficient is 1)
            result = "+";
        else if (Coefficient is -1)
            result = "-";
        else
            result = Coefficient < 0 ? Coefficient.ToString() : "+" + Coefficient.ToString();

        for (int i = 0; i < symbol.Count; i++)
        {
            if (result is "+" or "-")
                result += Exponent[i] == 1 ? symbol[i] : $"{symbol[i]}{Exponent[i].UnicodeExponent()}";
            else
                result += Exponent[i] == 1 ? symbol[i] : $"{symbol[i]}{Exponent[i].UnicodeExponent()}";
        }

        return result;
    }

    internal static bool equalExpSym(List<Symbol> sym1, 
                                    List<Symbol> sym2, 
                                    List<double> exp1, 
                                    List<double> exp2)
    {
        if (sym1.Count != sym2.Count)
            return false;

        for(int i = 0; i < sym1.Count; i++)
        {
            if (!sym2.Contains(sym1[i]))
                return false;

            if (exp1[i] != exp2[sym2.IndexOf(sym1[i])])
                return false;
        }

        return true;
    }

    internal bool isConstant()
    {
        foreach(double exponent in Exponent)
            if(exponent != 0)
                return false;

        return true;
    }

    private bool isNull()
        => Coefficient == 0;

    private bool isNegative()
        => Coefficient < 0;

    private void Clean()
    {
        for(int i = 0; i < this.Exponent.Count; i++)
            if (this.Exponent[i] == 0)
            {
                this.Exponent.RemoveAt(i);
                this.symbol.RemoveAt(i);
                i--;
            }
    }
    
    public double getDegree()
        => Exponent.Count != 0 ? Exponent.Max() : 0;

    private static SymbolContainer Instance(SymbolContainer reference)
    {
        List<Symbol> resultSym = new();
        resultSym.AddRange(reference.symbol);

        List<double> resultExponent = new();
        resultExponent.AddRange(reference.Exponent);

        return new(resultSym, reference.Coefficient, resultExponent);
    }

    internal SymbolContainer ChangeSymbol(Symbol a, Symbol b)
    {
        if (!this.symbol.Contains(a))
            return this;

        SymbolContainer symbolContainer = Instance(this);
        symbolContainer.symbol[symbolContainer.symbol.IndexOf(a)] = b;

        return symbolContainer;
    }

    internal static SymbolContainer Evaluate(SymbolContainer symbolContainer, Symbol symbol, double value)
    {
        SymbolContainer result = Instance(symbolContainer);

        int index = result.symbol.IndexOf(symbol);

        if (index == -1)
            return result;

        if(PrivateFunctions.IsInteger(result.Exponent[index]))
            value = Maths.Power(value, (int)result.Exponent[index]);
        else
            value = Maths.Power(value, result.Exponent[index]);

        result.Exponent.RemoveAt(index);
        result.symbol.Remove(symbol);

        result.Coefficient *= value;

        return result;
    }

#pragma warning restore IDE1006

    #region Addition

    public static SymbolContainer operator +(SymbolContainer symbolContainer)
        => symbolContainer;

    public static object operator +(SymbolContainer symbolContainer, double num)
    {
        if (!symbolContainer.isConstant())
            return new Polynomial(new List<SymbolContainer>() { symbolContainer, new SymbolContainer(num) });

        return new SymbolContainer(symbolContainer.symbol,
            symbolContainer.Coefficient + num,
            symbolContainer.Exponent);
    }

    public static object operator +(SymbolContainer symbolContainer, Symbol symbol)
    {
        if (symbolContainer.symbol.Contains(symbol) &&
            symbolContainer.symbol.Count == 1 &&
            symbolContainer.Exponent[0] == 1)
            return new SymbolContainer(symbolContainer.symbol,
                symbolContainer.Coefficient + 1,
                symbolContainer.Exponent);

        return new Polynomial(new List<SymbolContainer>() { symbolContainer, new SymbolContainer(symbol) });
    }

    public static object operator +(SymbolContainer symbolContainer1, SymbolContainer symbolContainer2)
    {
        if (equalExpSym(symbolContainer1.symbol, symbolContainer2.symbol,
                        symbolContainer1.Exponent, symbolContainer2.Exponent))
            return new SymbolContainer(symbolContainer1.symbol,
                symbolContainer1.Coefficient + symbolContainer2.Coefficient,
                symbolContainer1.Exponent);

        return new Polynomial(new List<SymbolContainer>() { symbolContainer1, symbolContainer2 });
    }

    public static Polynomial operator +(Polynomial polynomial, SymbolContainer symbolContainer)
    {
        Polynomial result = polynomial.Instance();

        if (PrivateFunctions.PolynomialContainsSymbol(result, symbolContainer))
        {
            int index = PrivateFunctions.IndexOfSymbol(result, symbolContainer);
            result.Container[index] = (SymbolContainer)(result.Container[index] + symbolContainer);
        }
        else
            result.Container.Add(symbolContainer);

        return result;
    }

    #endregion

    #region Substraction

    public static SymbolContainer operator -(SymbolContainer symbolContainer)
        => new(symbolContainer.symbol, -symbolContainer.Coefficient, symbolContainer.Exponent);

    public static object operator -(SymbolContainer symbolContainer, double num)
    {
        for (int i = 0; i < symbolContainer.Exponent.Count; i++)
            if (symbolContainer.Exponent[i] != 0)
                return new Polynomial(new List<SymbolContainer>() { symbolContainer, new SymbolContainer(-num) });

        return new SymbolContainer(symbolContainer.symbol,
            symbolContainer.Coefficient - num,
            symbolContainer.Exponent);
    }

    public static object operator -(SymbolContainer symbolContainer, Symbol symbol)
    {
        if (symbolContainer.symbol.Contains(symbol) &&
            symbolContainer.symbol.Count == 1 &&
            symbolContainer.Exponent[0] == 1)
            return new SymbolContainer(symbolContainer.symbol,
                symbolContainer.Coefficient - 1,
                symbolContainer.Exponent);

        return new Polynomial(new List<SymbolContainer>() { symbolContainer, new SymbolContainer(symbol, coefficient: -1) });
    }

    public static object operator -(SymbolContainer symbolContainer1, SymbolContainer symbolContainer2)
    {
        if (equalExpSym(symbolContainer1.symbol, symbolContainer2.symbol,
                        symbolContainer1.Exponent, symbolContainer2.Exponent))
            return new SymbolContainer(symbolContainer1.symbol,
                symbolContainer1.Coefficient - symbolContainer2.Coefficient,
                symbolContainer1.Exponent);

        return new Polynomial(new List<SymbolContainer>() { symbolContainer1, -symbolContainer2 });
    }

    public static Polynomial operator -(Polynomial polynomial, SymbolContainer symbolContainer)
        => polynomial + (-symbolContainer);

    #endregion

    #region Multiplication

    public static SymbolContainer operator *(SymbolContainer symbolContainer, double num)
        => new(symbolContainer.symbol, symbolContainer.Coefficient * num, symbolContainer.Exponent);

    public static SymbolContainer operator *(SymbolContainer symbolContainer, Symbol symbol)
    {
        SymbolContainer result = Instance(symbolContainer);


        if (result.symbol.Contains(symbol))
            result.Exponent[result.symbol.IndexOf(symbol)]++;
        else
        {
            result.symbol.Add(symbol);
            result.Exponent.Add(1);
        }

        return result;
    }

    public static SymbolContainer operator *(SymbolContainer symbolContainer1, SymbolContainer symbolContainer2)
    {
        SymbolContainer result = Instance(symbolContainer1);

        for(int i = 0; i < symbolContainer2.symbol.Count; i++)
        {
            if (result.symbol.Contains(symbolContainer2.symbol[i]))
                result.Exponent[result.symbol.IndexOf(
                    symbolContainer2.symbol[i])] += symbolContainer2.Exponent[i];
            else
            {
                result.symbol.Add(symbolContainer2.symbol[i]);
                result.Exponent.Add(symbolContainer2.Exponent[i]);
            }
        }

        result.Coefficient *= symbolContainer2.Coefficient;

        return result;
    }

    public static Polynomial operator *(Polynomial polynomial, SymbolContainer symbolContainer)
    {
        Polynomial result = polynomial.Instance();
        for (int i = 0; i < result.Container.Count; i++)
            result.Container[i] *= symbolContainer;

        return result;
    }

    public static Polynomial operator *(SymbolContainer symbolContainer, Polynomial polynomial)
        => polynomial * symbolContainer;

    #endregion

    #region Division

    public static SymbolContainer operator /(SymbolContainer symbolContainer, double num)
        => new(symbolContainer.symbol, symbolContainer.Coefficient / num, symbolContainer.Exponent);
    

    #endregion
}
