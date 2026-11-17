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
    private T[] coefficients;
    private int coefficientsNum;
    
    // Constructors:
    
    /// <summary>
    /// Construct a polynomial from a list of its coefficients
    /// </summary>
    /// <param name="coefficients"></param>
    public Polynomial(List<T> coefficients)
    {
        this.coefficients = coefficients.ToArray();
        this.coefficientsNum = this.coefficients.Length; 
    }

    /// <summary>
    /// Construct a polynomial from an array of its coefficients
    /// </summary>
    /// <param name="coefficients"></param>
    public Polynomial(T[] coefficients)
    {
        this.coefficients = coefficients;
        this.coefficientsNum = this.coefficients.Length;
    }

    public Polynomial(T coefficient)
    {
        this.coefficients = [coefficient];
        this.coefficientsNum = 1;
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
        
        if (p1.coefficientsNum > p2.coefficientsNum) return (p2 + p1);

        List<T> coefficients = new List<T>();

        for (int i = 0; i < p1.coefficientsNum; i++)
            coefficients.Add(p1.coefficients[i] + p2.coefficients[i]);
        
        // Add the remaining coefficients:
        for(int i = p1.coefficientsNum; i < p2.coefficientsNum; i++)
            coefficients.Add(p2.coefficients[i]);
        
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
        T[] newCoefficients = polynomial.coefficients.Clone() as T[] ?? new T[polynomial.coefficientsNum];
        
        for(int i = 0; i < polynomial.coefficientsNum; i++)
            newCoefficients[i] *= multiplicand;
        
        return new Polynomial<T>(newCoefficients);
    }
    
    public static Polynomial<T> operator *(Polynomial<T> polynomial, T multiplicand)
        => multiplicand * polynomial;

    public static Polynomial<T> operator *(Polynomial<T> p1, Polynomial<T> p2)
    {
        T[] newCoefficients = new T[p2.coefficientsNum + p1.coefficientsNum - 1];

        for (int i = 0; i < p1.coefficientsNum; i++)
            for (int j = 0; j < p2.coefficientsNum; j++)
                newCoefficients[i + j] += p1.coefficients[i] * p2.coefficients[j];
        
        return new Polynomial<T>(newCoefficients);
    }
    
    #endregion

    
    # region Public methods
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (this.coefficientsNum == 1) sb.Append(coefficients[0]);

        else
        {
            for (int i = 0; i < coefficientsNum; i++)
            {
                T coefficient = coefficients[i];

                if (coefficient == T.Zero) continue;

                sb.Append($" + ({coefficient.ToString()})x^{i}");
            }
        }

        return sb.ToString();
    }
    
    /// <summary>
    /// Returns the degree of the polynomial.
    /// </summary>
    /// <returns></returns>
    public int GetDegree() => this.coefficientsNum - 1;

    public bool Equals(Polynomial<T> polynomial)
    {
        this.ClearCoefficients();
        polynomial.ClearCoefficients();
        
        if(this.coefficientsNum != polynomial.coefficientsNum) return false;
        
        for(int i = 0; i < this.coefficientsNum; i++)
            if(this.coefficients[i] != polynomial.coefficients[i])
                return false;
        
        return true;
    }
    
    # endregion
    
    # region Public static methods
    
    public static Polynomial<T> Zero() => new Polynomial<T>(T.Zero);
    
    # endregion
    
    # region Private methods

    private void ClearCoefficients()
    {
        int index = 0;
        
        for(int i = coefficientsNum - 1; i >= 0; i--)
            if (coefficients[i] == T.Zero)
                continue;
            else
            {
                index = i;
                break;
            }
        
        coefficients = coefficients.Take(index + 1).ToArray();
        coefficientsNum = coefficients.Length;
    }

    private T[] ClearCoefficients(T[] coefficientsList)
    {
        int index = 0;
        
        for(int i = coefficientsList.Length - 1; i >= 0; i--)
            if (coefficientsList[i] == T.Zero)
                continue;
            else
            {
                index = i;
                break;
            }
        
        coefficientsList = coefficientsList.Take(index + 1).ToArray();
        
        return coefficientsList;
    }
    
    # endregion
}