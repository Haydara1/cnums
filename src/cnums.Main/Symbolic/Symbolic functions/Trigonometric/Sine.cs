namespace cnums.Symbolic;

internal class Sine : TrigonometricFunction
{

    #region Constructors

    public Sine(Function function)
        : base(function) { type = "sin"; }

    #endregion

    public override string ToString()
        => $"sin({Func})";
}
