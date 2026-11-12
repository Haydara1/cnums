namespace cnums.Main.Analysis.Fields;

public class Complex(float real, float imaginary)
{
    # region Attributes
    
    private float RealPart { get; set; } = real;
    private float ImaginaryPart { get; set; } = imaginary;
    
    #endregion 

    # region Constructors
    
    public Complex() : this(0, 0)
    { }
    
    public Complex(float real) : this(real, 0) 
    { }
    
    # endregion
    
    # region Operators
    
    // Addition
    public static Complex operator +(Complex a, Complex b)
        => new Complex(a.RealPart + b.RealPart,
            a.ImaginaryPart + b.ImaginaryPart);

    public static Complex operator +(Complex a, float b)
        => new Complex(a.RealPart + b, a.ImaginaryPart);

    public static Complex operator +(float a, Complex b)
        => b + a;

    // Multiplication
    public static Complex operator *(Complex a, float b)
        => new Complex(a.RealPart * b, a.ImaginaryPart * b);

    public static Complex operator *(float a, Complex b)
        => new Complex(a * b.RealPart, a * b.ImaginaryPart);
    
    public static Complex operator *(Complex a, int b)
        => a * (float)b;
    
    public static Complex operator *(int a, Complex b)
        => (float)a * b;
    
    // (a + ib) * (c + id) = (ac - bd) + i(bc + ad)
    public static Complex operator *(Complex a, Complex b)
        => new Complex(a.RealPart * b.RealPart - a.ImaginaryPart * b.ImaginaryPart,
            a.ImaginaryPart * b.RealPart + a.RealPart * b.ImaginaryPart);

    // Subtraction
    public static Complex operator -(Complex a)
        => -1 * a;

    public static Complex operator -(Complex a, Complex b)
        => a + -(b);
    

    # endregion
    
    # region Public Methods
    
    public override string ToString()
        => this.RealPart + " + " + this.ImaginaryPart + "i";

    /// <summary>
    /// Returns whether two complex numbers are equal
    /// </summary>
    /// <param name="other">The other complex number to be compared.</param>
    /// <returns></returns>
    public bool Equals(Complex other) // Compare respective parts.
        => this.RealPart.Equals(other.RealPart) &&
           this.ImaginaryPart.Equals(other.ImaginaryPart);
    
    /// <summary>
    /// Returns whether a complex number is a real number.
    /// </summary>
    /// <returns></returns>
    public bool IsReal()
        => this.ImaginaryPart.Equals(0);
    
    /// <summary>
    /// Returns whether a complex number is an imaginary number.
    /// </summary>
    /// <returns></returns>
    public bool IsImaginary()
        => this.RealPart.Equals(0);

    # endregion
}

