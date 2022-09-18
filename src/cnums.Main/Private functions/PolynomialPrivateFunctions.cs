using cnums.Symbolic;

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
                SinglePolynomial = new() { '+' };
            }
            else if (cn[i].ToString() == "-")
            {
                polynomials.Add(new(SinglePolynomial));
                SinglePolynomial = new() { '-' };
            }
            else
                SinglePolynomial.Add(cn[i]);
        }

        polynomials.Add(new(SinglePolynomial));

        return polynomials;
    }

    internal static bool SingleTerm(this Polynomial polynomial)
    {
        int index = 0;

        foreach (object obj in polynomial.Container)
            if (obj.ToString() == "+"
                || obj.ToString() == "-")
                index++;

        return !(index > 1);
    }

    internal static bool ContainsSymbols(this Polynomial polynomial)
    {
        foreach(object obj in polynomial.Container)
            if (obj.GetType() == typeof(Symbol))
                return true;
        return false;
    }

    internal static Symbol[] GetSymbols(this Polynomial polynomial)
    {
        polynomial.SetDictionaries();
        return polynomial.SymbolsDicitonary.Values.Distinct().ToArray(); ;
    }

    internal static Symbol[] GetSymbols(this Polynomial polynomial, bool distinct)
    {
        if (distinct)
            return GetSymbols(polynomial);
        return polynomial.SymbolsDicitonary.Values.ToArray();
    }

    internal static int GetPartsCount(this Polynomial polynomial)
    {
        Object[] cn = polynomial.Container.ToArray();
        int index = 0;

        if (!(cn[index].ToString() == "+"
            || cn[index].ToString() == "-"))
                index++;

        foreach (object obj in cn)
            if (obj.ToString() == "+"
                || obj.ToString() == "-")
                index++;

        return index;
    }

    internal static int GetConstantIndex(Polynomial polynomial)
    {
        for (int i = 0; i < polynomial.Container.Count; i++)
            if (polynomial.Container.GetType() == typeof(double))
                return i;
        return -1;
    }
}