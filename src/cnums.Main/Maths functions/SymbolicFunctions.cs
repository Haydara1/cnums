using cnums.Symbolic;

namespace cnums;

public static partial class Maths
{   

    public static Function Power(Symbol symbol, int power)
        // Transforms the symbol to a new symbol container whose coefficient is one, and its exponent is the power.
        // Then transfor the symbol container to Polynomial then to Function.
        => new Polynomial(new() { new(symbol, coefficient: 1, exponent: power) }).ToFunction();
    

}