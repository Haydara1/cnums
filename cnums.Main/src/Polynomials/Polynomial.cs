namespace cnums.Main;

/// <summary>
/// Single variable polynomial
/// </summary>
public class Polynomial
{
    // Attributes
    
    // Store the coefficients as a list, where the ith number is the coefficient to the ith degree.
    private int[] Coefficients;
    private int Degree;
    
    // Constructors:
    
    /// <summary>
    /// Construct a polynomial from a list of its coefficients
    /// </summary>
    /// <param name="coefficients"></param>
    public Polynomial(List<int> coefficients)
    {
        this.Coefficients = coefficients.ToArray();
        this.Degree = this.Coefficients.Length; 
    }

    /// <summary>
    /// Construct a polynomial from an array of its coefficients
    /// </summary>
    /// <param name="coefficients"></param>
    public Polynomial(int[] coefficients)
    {
        this.Coefficients = coefficients;
        this.Degree = this.Coefficients.Length;
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

    public static Polynomial operator +(Polynomial p1, Polynomial p2)
    {
        if (p1.Degree > p2.Degree) return (p2 + p1);

        List<int> coefficients = new List<int>();

        for (int i = 0; i < p1.Degree; i++)
            coefficients.Add(p1.Coefficients[i] + p2.Coefficients[i]);
        
        // Add the remaining coefficients:
        for(int i = p1.Degree; i < p2.Degree; i++)
            coefficients.Add(p2.Coefficients[i]);
        
        return new Polynomial(coefficients);
    }

    #endregion
    
}