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

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator -(Polynomial polynomial)
    {
        for (int i = 0; i < polynomial.Container.Count; i++)
            polynomial.Container[i] = -polynomial.Container[i];

        return polynomial;
    }

}

    