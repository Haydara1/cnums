namespace cnums.Symbolic;

internal class Cosine : TrigonometricFunction
{
    #region Constructors

    public Cosine(Function function)
        : base(function) { type = "cos"; }

    #endregion

    public override string ToString()
        => $"cos({Func})";
}
