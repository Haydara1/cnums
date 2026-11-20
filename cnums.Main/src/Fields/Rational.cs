using cnums.Main.Fields.Interfaces;

namespace cnums.Main.Fields;

public class Rational(int numerator, int denominator) : IRing<Rational>
{
    // Attributes
    private int Numerator { get; } =  numerator;
    private int Denominator { get; } = denominator;
    
    public static bool operator ==(Rational a, Rational b)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Rational a, Rational b)
    {
        throw new NotImplementedException();
    }

    public static Rational CreateChecked(object a)
    {
        throw new NotImplementedException();
    }

    public static bool CanParse(string s)
    {
        throw new NotImplementedException();
    }

    public static Rational AdditiveIdentity { get; }
    
    public static Rational operator +(Rational a, Rational b)
    {
        throw new NotImplementedException();
    }

    public static Rational operator -(Rational a)
    {
        throw new NotImplementedException();
    }

    public static Rational MultiplicativeIdentity { get; }
    
    public static Rational operator *(Rational a, Rational b)
        => new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    
}