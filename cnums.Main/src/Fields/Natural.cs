using cnums.Main.Fields.Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace cnums.Main.Fields;

public class Natural(int value) : IRing<Natural>
{
    private int Value { get; } = value;

    public static Natural AdditiveIdentity => new Natural(0);
    public static Natural MultiplicativeIdentity => new Natural(1);
    
    public static Natural operator +(Natural a, Natural b)
        => new Natural(a.Value + b.Value);

    public static Natural operator -(Natural a)
        => new Natural(-a.Value);
    
    public static Natural operator *(Natural a, Natural b)
        => new Natural(a.Value * b.Value);

    public static bool operator ==(Natural a, Natural b)
        => a.Value == b.Value;
    
    public static bool operator !=(Natural a, Natural b)
        => a.Value != b.Value;
    
    public static Natural CreateChecked(object a)
    {
        if (a is int i) return new Natural(i);
        
        throw new InvalidCastException();
    }
}