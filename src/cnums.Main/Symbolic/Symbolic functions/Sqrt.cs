namespace cnums.Symbolic;

public class Sqrt
{
    #region Properties

    private object? radicand = null;

    public object? Radicand
    {
        get { return radicand; }
        set { radicand = value; }
    }

    #endregion

    #region Constructors

    public Sqrt(Symbol symbol) 
        => radicand = symbol;

    public Sqrt(double num) 
        => radicand = num;

    #endregion

    public override string ToString()
        => $"Sqrt({radicand})";

}
