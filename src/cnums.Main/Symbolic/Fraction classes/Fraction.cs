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

    public Fraction(double number)
    {
    }

    public Fraction(double numerator, double denominator)
    {
        if (denominator == 0) throw new DivideByZeroException("Cannot divide by zero.");

        this.numerator = Abs(numerator) * (Sign(numerator) * Sign(denominator));
        this.denominator = Abs(denominator);
    }

    static public Fraction Reduce(Fraction fraction)
    {
        if (PrivateFunctions.IsInteger(fraction.Numerator) && PrivateFunctions.IsInteger(fraction.Denominator))
        {
            int a = Convert.ToInt32(fraction.Numerator);
            int b = Convert.ToInt32(fraction.Denominator);

            fraction.Numerator /= GCD(a, b);
            fraction.Denominator /= GCD(a, b);
        }

        return new(fraction.Numerator, fraction.Denominator);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (obj.GetType() != this.GetType())
            return false;

        Fraction fraction = (Fraction)obj;
        if (this.Numerator * fraction.Denominator
            == this.Denominator * fraction.Numerator)
            return true;

        return false;
    }

    public override int GetHashCode()
        => throw new NotImplementedException();

    public override string ToString()
        => $"{numerator}/{denominator}";

    #region Addition

    public static Fraction operator +(Fraction fraction)
        => Reduce(fraction);

    public static Fraction operator +(Fraction fraction, double number)
    {
        Fraction frc = new(number, 1);
        return frc + fraction;
    }

    public static Fraction operator +(double number, Fraction fraction)
        => fraction + number;

    public static Fraction operator +(Fraction fraction1, Fraction fraction2)
    {
        if (fraction1.Denominator != fraction2.Denominator)
        {
            fraction1.Numerator *= fraction2.Denominator;
            fraction2.Numerator *= fraction1.Denominator;
        }

        return Reduce(new(fraction1.Numerator + fraction2.Numerator, fraction1.Denominator));
    }

    #endregion

    #region Substraction

    public static Fraction operator -(Fraction fraction)
        => new(-fraction.Numerator, fraction.Denominator);

    public static Fraction operator -(Fraction fraction, double number)
    {
        Fraction frc = new(number, 1);
        return fraction - frc;
    }

    public static Fraction operator -(double number, Fraction fraction)
        => -fraction + number;

    public static Fraction operator -(Fraction fraction1, Fraction fraction2)
    {
        if (fraction1.Denominator != fraction2.Denominator)
        {
            fraction1.Numerator *= fraction2.Denominator;
            fraction2.Numerator *= fraction1.Denominator;
        }

        return new(fraction1.Numerator - fraction2.Numerator, fraction1.Denominator);
    }

    #endregion

    #region Multiplication

    public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        => new(fraction1.Numerator * fraction2.Numerator, fraction1.Denominator * fraction2.Denominator);

    public static Fraction operator *(Fraction fraction, double number)
        => new(fraction.Numerator * number, fraction.Denominator);

    public static Fraction operator *(double number, Fraction fraction)
        => new(number * fraction.Numerator, fraction.Denominator);

    #endregion

    #region Division

    public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        => fraction1 * new Fraction(fraction2.Denominator, fraction2.Numerator);

    public static Fraction operator /(Fraction fraction, double number)
        => new(fraction.Numerator, number * fraction.Denominator);

    public static Fraction operator /(double number, Fraction fraction)
        => new(number * fraction.Denominator, fraction.Numerator);

    #endregion

    #region Comparision

    public static bool operator ==(Fraction fraction1, Fraction fraction2)
        => fraction1.Equals(fraction2);

    public static bool operator !=(Fraction fraction1, Fraction fraction2)
        => !fraction1.Equals(fraction2);

    public static bool operator ==(Fraction fraction, double number)
        => fraction.Equals(new Fraction(number, 1));

    public static bool operator !=(Fraction fraction, double number)
        => !fraction.Equals(new Fraction(number, 1));

    public static bool operator ==(double number, Fraction fraction)
        => fraction.Equals(new Fraction(number, 1));

    public static bool operator !=(double number, Fraction fraction)
        => !fraction.Equals(new Fraction(number, 1));

    #endregion
}

