using cnums.Symbolic;

namespace cnums;

internal class SymbolContainer
{
    public List<Symbol> symbol = new();

    public double Coefficient;

    public List<double> Exponent = new() { };

    public bool Negative = false;

    public Dictionary<Symbol, double> SymExp = new();

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
    {
        Coefficient = number;
        Exponent.Add(0);
        symbol.Add(new('x'));
    }

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

    public override string ToString()
    {
        string result = $"{Coefficient}";

        for (int i = 0; i < symbol.Count; i++)
            result += $"*{symbol[i]}^{Exponent[i]}";

        return result;
    }

    public static SymbolContainer operator +(SymbolContainer symbolContainer)
        => symbolContainer;

    public static object operator +(SymbolContainer symbolContainer, double num)
    {
        for(int i = 0; i < symbolContainer.Exponent.Count; i++)
            if (symbolContainer.Exponent[i] != 0)
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
        if (symbolContainer1.symbol == symbolContainer2.symbol
            && symbolContainer1.Exponent == symbolContainer2.Exponent)
            return new SymbolContainer(symbolContainer1.symbol,
                symbolContainer1.Coefficient + symbolContainer2.Coefficient,
                symbolContainer1.Exponent);

        return new Polynomial(new List<SymbolContainer>() { symbolContainer1, symbolContainer2 });
    }

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
        if (symbolContainer1.symbol == symbolContainer2.symbol
            && symbolContainer1.Exponent == symbolContainer2.Exponent)
            return new SymbolContainer(symbolContainer1.symbol,
                symbolContainer1.Coefficient - symbolContainer2.Coefficient,
                symbolContainer1.Exponent);

        return new Polynomial(new List<SymbolContainer>() { symbolContainer1, -symbolContainer2 });
    }

    public static SymbolContainer operator *(SymbolContainer symbolContainer, double num)
        => new(symbolContainer.symbol, symbolContainer.Coefficient * num, symbolContainer.Exponent);

    public static SymbolContainer operator /(SymbolContainer symbolContainer, double num)
        => new(symbolContainer.symbol, symbolContainer.Coefficient / num, symbolContainer.Exponent);

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
}
