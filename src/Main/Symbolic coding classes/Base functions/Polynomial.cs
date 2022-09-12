using static cnums.PrivateFunctions;

namespace cnums;

public class Polynomial
{
    private List<object> container;

    internal List<object> Container
    {
        get { return container; }
        set { container = value; }
    }

    internal Dictionary<int, double> DoublesDictionary = new();

    internal Dictionary<int, Symbol> SymbolsDicitonary = new();

    internal Polynomial(List<object> objects)
        => container = objects; 

    public override string ToString()
    {
        string poly = "";

        if (Container == null) return "0";

        foreach(object obj in Container)
            poly += obj.ToString();

        return poly;
    }

    internal void SetDictionaries()
    {
        List<object> Cn = this.Container;

        Dictionary<int, double> doubleDict = new();   
        Dictionary<int, Symbol> symbolDict = new();

        for(int i = 0; i < Cn.Count; i++)
        {
            if (Cn[i].GetType() == typeof(System.Double))
                doubleDict.Add(i, (System.Double)Cn[i]);

            else if (Cn[i].GetType() == typeof(cnums.Symbol))
                symbolDict.Add(i, (cnums.Symbol)Cn[i]);

            else continue;
        }

        DoublesDictionary = doubleDict;
        SymbolsDicitonary = symbolDict;
    }

    #region Addition

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator +(Polynomial polynomial, double number)
    {
        if(number == 0) return polynomial;

        else if(number < 0) return polynomial - Maths.Abs(number);

        List<Polynomial> polynomials = DividePolynomial(polynomial);
        bool insert = true;

        List<object> cn = new();

        foreach(Polynomial poly in polynomials)
        {
            //void AddRange(List<object> x)
            //{
            //    cn.AddRange(x);
            //    return;
            //}

            bool c = poly.ContainsSymbols();

            if (poly.ContainsSymbols())
            {
                cn.AddRange(poly.Container);
                continue;
            }

            List<object> polyContainer = poly.Container;
            if (polyContainer.Count == 1)
                polyContainer[0] =
                    Convert.ToDouble(polyContainer[0]) + number;
            
            else
            {
                double part = Convert.ToDouble(polyContainer[1]);

                if (polyContainer[0].ToString() == "-")
                {
                    if (part == number)
                        polyContainer = new() { 0d };

                    else if (part > number)
                        polyContainer[1] = part - number;

                    else
                    {
                        polyContainer[1] = number - part;
                        polyContainer[0] = '+';
                    }
                }
                else if (polyContainer[0].ToString() == "+")
                {
                    polyContainer[1] =
                    Convert.ToDouble(polyContainer[1]) + number;
                }
            }
            insert = false;

            cn.AddRange(polyContainer);
            continue;
        }

        if(insert)
        {
            cn.Add('+');
            cn.Add(number);
        }

        return new(cn);
    }

    public static Polynomial operator +(double number, Polynomial polynomial)
        => polynomial + number;

    public static Polynomial operator +(Polynomial polynomial, Symbol symbol)
    {
        Symbol[] symbols = polynomial.GetSymbols();
        List<object> cn;

        if(!symbols.Contains(symbol))
        {
            cn = polynomial.Container;
            cn.Add('+');
            cn.Add(symbol);
            return new(cn);
        }

        List<Polynomial> polynomials = DividePolynomial(polynomial);
        cn = new();

        bool end = false;
        bool insert = true;

        foreach(Polynomial poly in polynomials)
        {   

            //void AddRange(List<object> x)
            //{
            //    cn.AddRange(x);
            //    return;
            //}

            if (end)
            {
                cn.AddRange(poly.Container);
                insert &= true;
                continue;
            }

            if (!poly.ContainsSymbols()) //Checks if it contains symbols.
            {
                cn.AddRange(poly.Container);
                insert &= true;
                continue;
            }

            symbols = poly.GetSymbols();

            if (!symbols.Contains(symbol) || //Checks if it contains the same symbol.
                symbols.Length > 1) //Checks if it contains more than one symbol.
            {
                cn.AddRange(poly.Container);
                insert &= true;
                continue;
            }

            List<object> polyContainer = poly.Container;

            //Checked that this part of polynomial only has one variable,
            //that is the same as the added one.

            for(int i = 0; i < polyContainer.Count; i++)
            {   
                if (polyContainer[i].GetType() != typeof(cnums.Symbol))
                    continue;

                else if (i < polyContainer.Count - 2
                    && polyContainer[i + 1].ToString() == "^")
                    break;

                if(i == 0)
                {
                    polyContainer.Insert(0, '*');
                    polyContainer.Insert(0, 2d);
                    break;
                }
                else if(i == 1)
                {
                    if (polyContainer[0].ToString() == "-")
                    {
                        polyContainer = new() { 0d };
                        break;
                    }
                    polyContainer.Insert(1, '*');
                    polyContainer.Insert(1, 2d);
                    break;
                    
                }
                else if(i == 3)
                {
                    if (polyContainer[1].ToString() == "1" 
                        && polyContainer[0].ToString() == "-")
                    {
                        polyContainer = new() { 0d };
                        break;
                    }
                }
                else if(i == 2)
                {
                    polyContainer[0] = 
                        Convert.ToDouble(polyContainer[0]) + 1d;
                    break;
                }
                else
                {
                    if (polyContainer[i - 1].ToString() == "*")
                    {
                        if(polyContainer[i - 3].ToString() == "-")
                        {
                            if (polyContainer[i - 2].ToString() == "1")
                            {
                                polyContainer.RemoveAt(i);
                                polyContainer.RemoveAt(i - 1);
                                polyContainer.RemoveAt(i - 2);
                                polyContainer.RemoveAt(i - 3);

                                if (polyContainer.Count == 0)
                                    polyContainer = new() { 0d };
                            }
                            else
                            {
                                polyContainer[i - 2] =
                                Convert.ToDouble(polyContainer[i - 2]) - 1d;
                            }
                        }
                        else
                        {
                            polyContainer[i - 2] =
                                Convert.ToDouble(polyContainer[i - 2]) + 1d;
                        }
                    }
                }

                insert = false;
            }

            end = true;

            cn.AddRange(poly.Container);
            continue;
        }

        if(insert)
        {
            cn.Add('+');
            cn.Add(symbol);
        }

        return new(cn);
    }

    public static Polynomial operator +(Symbol symbol, Polynomial polynomial)
        => polynomial + symbol;

    public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
    {

        return polynomial1;
    }

    #endregion

    #region Substraction

    public static Polynomial operator -(Polynomial polynomial)
    {   
        List<object> cn = polynomial.Container;

        for(int i = 0; i < cn.Count; i++)
        {
            if (cn[i].ToString() == "+")
                cn[i] = '-';
            else if (cn[i].ToString() == "-")
                cn[i] = "+";
            else
                continue;
        }

        if (!(cn[0].ToString() == "+" || cn[0].ToString() == "-"))
            cn.Insert(0, '-');  

        return new(cn);
    }

    public static Polynomial operator -(Polynomial polynomial, double number)
    { 
        if(number < 0) return polynomial + Maths.Abs(number);
        else if(number == 0) return polynomial;

        return -(-polynomial + number);
    }

    public static Polynomial operator -(double number, Polynomial polynomial)
        => -polynomial + number;

    public static Polynomial operator -(Polynomial polynomial, Symbol symbol)
        => -(-polynomial + symbol);

    public static Polynomial operator -(Symbol symbol, Polynomial polynomial)
        => -polynomial + symbol;

    #endregion

    #region Multiplication

    public static Polynomial operator *(Polynomial polynomial, double number)
    {
        if (number == 0)
            return new(new() { 0d }); // a * 0 = 0

        else if (number < 0)
            return -polynomial * Maths.Abs(number); // a * (-a) = -a * b

        if(polynomial.GetPartsCount() > 1)
        {
            Polynomial[] polynomials = DividePolynomial(polynomial).ToArray();
            List<object> cn = new();

            for (int i = 0; i < polynomials.Length; i++)
            {
                polynomials[i] *= number;

                foreach(object obj in polynomials[i].Container)
                    cn.Add(obj);
            }

            return new(cn);
        }

        if (polynomial.ContainsSymbols()) { }

        return new(new() { 0 });
    }

    public static Polynomial operator *(Polynomial polynomial, Symbol symbol)
    {
        polynomial.SetDictionaries();
        List<object> cn = polynomial.Container;

        foreach((int index, Symbol sym) in polynomial.SymbolsDicitonary)
        {
            if(sym == symbol)
            {
                if(index + 1 < polynomial.Container.Count)
                {
                    if (cn[index + 1].ToString() == "^") 
                        cn[index + 2] = Convert.ToDouble(cn[index + 2]) + 1;
                    
                }
                else
                {
                    cn.Insert(index + 1, 2d);
                    cn.Insert(index + 1, '^');
                }

                polynomial.SetDictionaries();
                cn = polynomial.Container;
            }
            else
            {
                if(index == 0)
                {
                    

                }
            }
        }

        return new(new(cn));
    }

    #endregion
}

