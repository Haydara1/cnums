namespace cnums;

public static partial class Maths
{
    public static Symbol Power(Symbol symbol, double power = 2)
        => new(symbol.sym, symbol.coefficient, symbol.power * power);

}