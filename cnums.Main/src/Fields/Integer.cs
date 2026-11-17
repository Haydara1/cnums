using cnums.Main.Fields.Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace cnums.Main.Fields;

public class Integer(int value) : IRing<Integer>
{
    private int Value { get; } = value;

    public static Integer AdditiveIdentity => new Integer(0);
    public static Integer MultiplicativeIdentity => new Integer(1);
    
    public static Integer operator +(Integer a, Integer b)
        => new Integer(a.Value + b.Value);

    public static Integer operator -(Integer a)
        => new Integer(-a.Value);
    
    public static Integer operator *(Integer a, Integer b)
        => new Integer(a.Value * b.Value);

    public static bool operator ==(Integer a, Integer b)
        => a.Value == b.Value;
    
    public static bool operator !=(Integer a, Integer b)
        => a.Value != b.Value;
    
    public static Integer CreateChecked(object a)
    {
        if (a is int i) return new Integer(i);
        
        throw new InvalidCastException();
    }

    public static bool CanParse(string s)
    {
        throw new NotImplementedException();
    }
}