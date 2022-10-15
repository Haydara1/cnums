using cnums.Symbolic;

namespace cnums;

internal static partial class PrivateFunctions
{
    public static bool equalSymContainers(SymbolContainer symbolContainer1, SymbolContainer symbolContainer2)
        => SymbolContainer.equalExpSym(symbolContainer1.symbol,
                                        symbolContainer2.symbol,
                                        symbolContainer1.Exponent,
                                        symbolContainer2.Exponent);

    public static bool PolynomialContainsSymbol(Polynomial polynomial, SymbolContainer symbolContainer)
    {
        for (int i = 0; i < polynomial.Container.Count; i++)
            if (equalSymContainers(polynomial.Container[i], symbolContainer))
                return true;
        return false;
    }

    public static int IndexOfSymbol(Polynomial polynomial, SymbolContainer symbolContainer)
    {
        for (int i = 0; i < polynomial.Container.Count; i++)
            if (equalSymContainers(polynomial.Container[i], symbolContainer))
                return i;
        return -1;
    }

    public static double getDegree(Polynomial polynomiall)
        => polynomiall.getDegree();
    
    public static Polynomial Instance(this Polynomial reference)
    {
        Polynomial result = new(new List<SymbolContainer>());

        for (int i = 0; i < reference.Container.Count; i++)
            result.Container.Add(reference.Container[i]);

        return result;
    }

    public static Polynomial Evaluate(this Polynomial polynomial, Symbol symbol, double value)
    {
        Polynomial result = polynomial.Instance();

        for(int i = 0; i < result.Container.Count; i++)
        {
            if (result.Container[i].isConstant())
                continue;

            result.Container[i] = SymbolContainer.Evaluate(result.Container[i], symbol, value);

            if (result.Container[i].isConstant())
            {
                double val = result.Container[i].Coefficient;
                result.Container.RemoveAt(i);
                result += val;

                i--;
            }
        }

        return result;
    }
    
}