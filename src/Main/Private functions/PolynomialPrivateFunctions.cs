namespace cnums;

internal static partial class PrivateFunctions
{
    internal static List<Polynomial> DividePolynomial(Polynomial polynomial)
    {
        List<object> cn = polynomial.Container;
        List<Polynomial> polynomials = new();
        List<object> SinglePolynomial = new();

        for (int i = 0; i < cn.Count; i++)
        {
            if (cn[i].ToString() == "+")
            {
                polynomials.Add(new(SinglePolynomial));
                SinglePolynomial = new();
                SinglePolynomial.Add('+');
            }
            else if (cn[i].ToString() == "-")
            {
                polynomials.Add(new(SinglePolynomial));
                SinglePolynomial = new();
                SinglePolynomial.Add('-');
            }
            else
                SinglePolynomial.Add(cn[i]);
        }

        polynomials.Add(new(SinglePolynomial));

        return polynomials;
    }

    internal static bool SingleTerm(Polynomial polynomial)
    {
        int index = 0;

        foreach (object obj in polynomial.Container)
            if (obj.ToString() == "+"
                || obj.ToString() == "-")
                index++;

        return !(index > 1);
    }

    internal static bool ContainsSymbols(Polynomial polynomial)
    {
        for (int i = 0; i < polynomial.Container.Count; i++)
            if (polynomial.Container[i].GetType() == typeof(cnums.Symbol))
                return true;
        return false;
    }

    internal static Symbol[] GetSymbols(Polynomial polynomial)
    {
        polynomial.SetDictionaries();
        Dictionary<int, Symbol> symbols = polynomial.SymbolsDicitonary;

        Symbol[] result = symbols.Values.ToArray();
        result = result.Distinct().ToArray();

        return result;
    }
}