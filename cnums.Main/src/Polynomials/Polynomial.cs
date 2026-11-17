using System.Text;
using System.Numerics;

namespace cnums.Main.Polynomials;

/// <summary>
/// Single variable polynomial
/// </summary>
public class Polynomial<T> where T : INumber<T>
{
    // Attributes
    
    // Store the coefficients as a list, where the ith number is the coefficient to the ith degree.
    private T[] Coefficients;
    private int Degree;
    
    // Constructors:
    
    /// <summary>
    /// Construct a polynomial from a list of its coefficients
    /// </summary>
    /// <param name="coefficients"></param>
    public Polynomial(List<T> coefficients)
    {
        this.Coefficients = coefficients.ToArray();
        this.Degree = this.Coefficients.Length; 
    }

    /// <summary>
    /// Construct a polynomial from an array of its coefficients
    /// </summary>
    /// <param name="coefficients"></param>
    public Polynomial(T[] coefficients)
    {
        this.Coefficients = coefficients;
        this.Degree = this.Coefficients.Length;
    }

    public Polynomial(T coefficient)
    {
        this.Coefficients = [coefficient];
        this.Degree = 0;
    }

    /// <summary>
    /// Construct a polynomial from a string representation:
    /// </summary>
    /// <param name="polynomial"></param>
    public Polynomial(String polynomial)
    {
        // TODO
    }


    #region Operators Overloads

    /// <summary>
    /// Adds two polynomials
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Polynomial<T> operator +(Polynomial<T> p1, Polynomial<T> p2)
    {
        // TODO optimize addition.
        
        if (p1.Degree > p2.Degree) return (p2 + p1);

        List<T> coefficients = new List<T>();

        for (int i = 0; i < p1.Degree; i++)
            coefficients.Add(p1.Coefficients[i] + p2.Coefficients[i]);
        
        // Add the remaining coefficients:
        for(int i = p1.Degree; i < p2.Degree; i++)
            coefficients.Add(p2.Coefficients[i]);
        
        return new Polynomial<T>(coefficients);
    }

    public static Polynomial<T> operator -(Polynomial<T> p1, Polynomial<T> p2)
        => p1 + (T.CreateChecked(-1) * p2);
    
    /// <summary>
    /// Multiplies an integer with a polynomial
    /// </summary>
    /// <param name="multiplicand"></param>
    /// <param name="polynomial"></param>
    /// <returns></returns>
    public static Polynomial<T> operator *(T multiplicand, Polynomial<T> polynomial)
    {
        T[] newCoefficients = polynomial.Coefficients;
        
        for(int i = 0; i < polynomial.Degree; i++)
            newCoefficients[i] *= multiplicand;
        
        return new Polynomial<T>(newCoefficients);
    }
    
    public static Polynomial<T> operator *(Polynomial<T> polynomial, T multiplicand)
        => multiplicand * polynomial;

    public static Polynomial<T> operator *(Polynomial<T> p1, Polynomial<T> p2)
    {
        T[] newCoefficients = new T[p2.Degree + p1.Degree];

        for (int i = 0; i < p1.Degree; i++)
            for (int j = 0; j < newCoefficients.Length; j++)
                newCoefficients[i + j] += p1.Coefficients[i] * p2.Coefficients[j];
        
        return new Polynomial<T>(newCoefficients);
    }
    
    #endregion

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Degree; i++)
            sb.Append($"{Coefficients[i]}x^{i}");
        
        return sb.ToString();
    }
    
}