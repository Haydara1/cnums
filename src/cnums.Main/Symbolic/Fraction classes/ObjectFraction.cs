namespace cnums;

internal class ObjectFraction : Fraction
{
    private object? numerator;

    public new object? Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    private object? denominator;

    public new object? Denominator
    {
        get { return denominator; }
        set { denominator = value; }
    }

    public ObjectFraction(object obj1, object obj2) : base(0, 0)
    {
        Numerator = obj1;
        Denominator = obj2;
    }
}