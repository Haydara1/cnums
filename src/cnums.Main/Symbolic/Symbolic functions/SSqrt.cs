namespace cnums.Symbolic;

public class SSqrt
{
    private object? radicand = null;

    public object? Radicand
    {
        get { return radicand; }
        set { radicand = value; }
    }

    public SSqrt(Symbol symbol) => radicand = symbol;

    public SSqrt(double num) => radicand = num;




}
