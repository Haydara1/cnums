using static cnums.Maths;

namespace cnums;

public class Fraction
{
    private double numerator;

    public double Numerator
    {
        get { return numerator; }
        private set { numerator = value; }
    }

    private double denominator;

    public double Denominator
    {
        get { return denominator; }
        private set { denominator = value; }
    }

    public Fraction(double numerator, double denominator)
    {
        if (denominator == 0) throw new Exception("Cannot divide by zero.");

        this.numerator = numerator;
        this.denominator = denominator; 
    }


    public Fraction(Function func1, Function func2)
    {

    }

    public void Simplify()
    {
        if((numerator < 0 && denominator < 0) || denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }

        if(PrivateFunctions.IsInteger(numerator) && PrivateFunctions.IsInteger(denominator))
        {
            int a = Convert.ToInt32(numerator);
            int b = Convert.ToInt32(denominator);

            numerator /= GCD(a, b);
            denominator /= GCD(a, b);
        }
    }

    public override string ToString()
        => $"{numerator}/{denominator}";

    public static Fraction operator +(Fraction fraction) => fraction;

    public static Fraction operator -(Fraction fraction) => new(-fraction.Numerator, fraction.Denominator);

    public static Fraction operator +(Fraction fraction1, Fraction fraction2)
    {
        if(fraction1.Denominator != fraction2.Denominator)
        {
            fraction1.Numerator *= fraction2.Denominator;
            fraction2.Numerator *= fraction1.Denominator;
        }

        return new(fraction1.Numerator + fraction2.Numerator, fraction1.Denominator);
    }

    public static Fraction operator -(Fraction fraction1, Fraction fraction2)
    {
        if (fraction1.Denominator != fraction2.Denominator)
        {
            fraction1.Numerator *= fraction2.Denominator;
            fraction2.Numerator *= fraction1.Denominator;
        }

        return new(fraction1.Numerator - fraction2.Numerator, fraction1.Denominator);
    }

    public static Fraction operator *(Fraction fraction1, Fraction fraction2) 
        => new(fraction1.Numerator * fraction2.Numerator, fraction1.Denominator * fraction2.Denominator);

    public static Fraction operator /(Fraction fraction1, Fraction fraction2) 
        => fraction1 * new Fraction(fraction2.Denominator, fraction2.Numerator);
}

