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

    public override string ToString()
    {
        Clean();

        if (isNull())
            return "";
        else if (isConstant())
            return Coefficient > 0 ? "+" + Maths.Abs(Coefficient).ToString() :
                                     "-" + Maths.Abs(Coefficient).ToString();

        if (Utils.Unicode)
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

    public string ToUnicodeString()
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

    private static bool equalExpSym(List<Symbol> sym1, 
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

    #endregion

    #region Multiplication

    public static SymbolContainer operator *(SymbolContainer symbolContainer, double num)
        => new(symbolContainer.symbol, symbolContainer.Coefficient * num, symbolContainer.Exponent);

    public static SymbolContainer operator *(SymbolContainer symbolContainer, Symbol symbol)
    {
        if (symbolContainer.symbol.Contains(symbol))
            symbolContainer.Exponent[symbolContainer.symbol.IndexOf(symbol)]++;
        else
        {
            symbolContainer.symbol.Add(symbol);
            symbolContainer.Exponent.Add(1);
        }

        return new(symbolContainer.symbol, symbolContainer.Coefficient, symbolContainer.Exponent);
    }

    public static SymbolContainer operator *(SymbolContainer symbolContainer1, SymbolContainer symbolContainer2)
    {
        List<Symbol> symList = symbolContainer1.symbol;
        List<double> expList = symbolContainer1.Exponent;

        for(int i = 0; i < symbolContainer2.symbol.Count; i++)
        {
            if (symList.Contains(symbolContainer2.symbol[i]))
                expList[symList.IndexOf(
                    symbolContainer2.symbol[i])] += symbolContainer2.Exponent[i];
            else
            {
                symList.Add(symbolContainer2.symbol[i]);
                expList.Add(symbolContainer2.Exponent[i]);
            }
        }

        return new(symList,
            symbolContainer1.Coefficient * symbolContainer2.Coefficient,
            expList);
    }

    #endregion

    #region Division

    public static SymbolContainer operator /(SymbolContainer symbolContainer, double num)
        => new(symbolContainer.symbol, symbolContainer.Coefficient / num, symbolContainer.Exponent);
    

    #endregion
}
