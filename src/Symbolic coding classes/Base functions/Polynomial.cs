﻿using System.Linq;

namespace cnums;

public class Polynomial
{
    private List<object> container;

    private List<object> Container
    {
        get { return container; }
        set { container = value; }
    }

    private Dictionary<int, double> DoublesDictionary = new();

    private Dictionary<int, Symbol> SymbolsDicitonary = new();

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

    private void SetDictionaries()
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

    private static List<Polynomial> DividePolynomial(Polynomial polynomial)
    {
        List<object> cn = polynomial.Container;
        List<Polynomial> polynomials = new();
        List<object> SinglePolynomial = new();

        for(int i = 0; i < cn.Count; i++)
        {
            if (cn[i].ToString() == "+")
            {
                polynomials.Add(new(SinglePolynomial));
                SinglePolynomial = new();
                SinglePolynomial.Add('+');
            }
            else if (cn[i].ToString() == "-")
            {
                polynomials.Add(new(SinglePolynomial));
                SinglePolynomial = new();
                SinglePolynomial.Add('-');
            }
            else
                SinglePolynomial.Add(cn[i]);
        }

        polynomials.Add(new(SinglePolynomial));

        return polynomials;
    }

    private static bool SingleTerm(this Polynomial polynomial)
    {
        int index = 0;

        foreach (object obj in polynomial.Container)
            if (obj.ToString() == "+"
                || obj.ToString() == "-")
                index++;

        return !(index > 1);
    }

    private static bool ContainsSymbols(this Polynomial polynomial)
    {
        for(int i = 0; i < polynomial.Container.Count; i++) 
            if(polynomial.Container[i].GetType() == typeof(cnums.Symbol))
                return true;
        return false;
    }

    #region Addition

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator +(Polynomial polynomial, double number)
    {
        if(number == 0) return polynomial;

        else if(number < 0) return polynomial - Maths.Abs(number);

        polynomial.SetDictionaries();
        List<object> cn = polynomial.Container;

        Dictionary<int, double> dict = polynomial.DoublesDictionary;
        bool insert = true, before = true;

        foreach ((int index, double constant) in dict)
        {
            bool begin = false, end = false;

            try
            {
                if (cn[index - 1].ToString() == "+"
                || cn[index - 1].ToString() == "-")
                    begin = true;
            }
            catch
            {
                begin = true;
                before = false;
            }
            
            try
            {   
                if (cn[index + 1].ToString() == "+"
                || cn[index + 1].ToString() == "-")
                    end = true;
            }
            catch
            {  
                end = true;
            }

            if(begin && end)
            {
                if(before)
                {
                    if (cn[index - 1].ToString() == "-")
                    {
                        if(number > constant)
                        {
                            cn[index] = number - constant;
                            cn[index - 1] = '+';
                        }
                        else
                            cn[index] = constant - number;
                        
                    }
                    else
                        cn[index] = constant + number;
                }
                insert = false;
                break;
            }
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

        polynomial.SetDictionaries();
        List<object> cn = polynomial.Container;

        Dictionary<int, Symbol> dict = polynomial.SymbolsDicitonary;
        bool insert = true, before = true;

        foreach ((int index, Symbol sym) in dict)
        {
            if (sym != symbol) continue;

            bool begin = false, end = false;

            try
            {
                if (cn[index - 1].ToString() == "+"
                || cn[index - 1].ToString() == "-")
                    begin = true;
            }
            catch
            {
                begin = true;
                before = false;
            }

            try
            {
                if (cn[index + 1].ToString() == "+"
                || cn[index + 1].ToString() == "-")
                    end = true;
            }
            catch
            {
                end = true;
            }

            if (begin && end)
            {
                if (before)
                {
                    if (cn[index - 1].ToString() == "-")
                    {
                        if (number > constant)
                        {
                            cn[index] = number - constant;
                            cn[index - 1] = '+';
                        }
                        else
                            cn[index] = constant - number;

                    }
                    else
                        cn[index] = constant + number;
                }
                insert = false;
                break;
            }
        }

        if (insert)
        {
            cn.Add('+');
            cn.Add(number);
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
        => polynomial + (-number);

    public static Polynomial operator -(double number, Polynomial polynomial)
        => -polynomial + number;

    public static Polynomial operator -(Polynomial polynomial, Symbol symbol)

    {
        List<object> cn = polynomial.Container;
        bool insert = true;

        for (int i = 0; i < cn.Count; i++)
        {
            if (!symbol.Equals(cn[i]))
                continue;

            bool brk = false;

            if (i == 0)
            {
                if (cn[i + 1].ToString() == "+"
                    || cn[i + 1].ToString() == "-")
                {
                    cn[i] = 0d;

                    insert = false;
                    break;
                }

                continue;
            }

            else if (i == cn.Count - 1)
            {
                switch (cn[i - 1].ToString())
                {
                    case "-":
                        cn.Insert(i, "*");
                        cn.Insert(i, 2d);

                        brk = true;
                        insert = false;
                        break;

                    case "+":
                        cn.RemoveAt(i);
                        cn.RemoveAt(i - 1);

                        brk = true;
                        insert = false;
                        break;

                    case "*":
                        if (cn[i - 2].GetType() == typeof(double))
                        {
                            if (i < 3)
                                cn[i - 2] = Convert.ToDouble(cn[i - 2]) - 1d;
                            else
                            {
                                if (cn[i - 3].ToString() == "+")
                                    cn[i - 2] = Convert.ToDouble(cn[i - 2]) - 1d;
                                else if (cn[i - 3].ToString() == "-")
                                {
                                    cn[i - 2] = -Convert.ToDouble(cn[i - 2]) - 1d;
                                    if (Convert.ToDouble(cn[i - 2]) < 0)
                                        cn[i - 2] = Math.Abs(Convert.ToDouble(cn[i - 2]));
                                    else if (Convert.ToDouble(cn[i - 2]) > 0)
                                    {
                                        cn[i - 2] = Math.Abs(Convert.ToDouble(cn[i - 2]));
                                        cn[i - 3] = '+';
                                    }
                                    else
                                    {
                                        cn.RemoveAt(i);
                                        cn.RemoveAt(i - 1);
                                        cn.RemoveAt(i - 2);
                                        cn.RemoveAt(i - 3);
                                    }

                                }
                            }

                                brk = true;
                            insert = false;
                        }
                        break;
                }
                if (brk) break;

            }

            else
            {
                if (!(cn[i + 1].ToString() == "+"
                    || cn[i + 1].ToString() == "-"))
                    continue;

                if (cn[i - 1].ToString() == "-")
                {
                    cn.Insert(i, "*");
                    cn.Insert(i, 2d);

                    insert = false;
                    break;
                }
                else if (cn[i - 1].ToString() == "+")
                {
                    cn.RemoveAt(i);
                    cn.RemoveAt(i - 1);

                    insert = false;
                    break;
                }
                else if (cn[i - 1].ToString() == "*")
                {

                    if (cn[i - 2].GetType() == typeof(double))
                    {
                        if (cn[i - 3].ToString() == "+")
                            cn[i - 2] = Convert.ToDouble(cn[i - 2]) - 1d;
                        else if (cn[i - 3].ToString() == "-")
                        {
                            cn[i - 2] = -Convert.ToDouble(cn[i - 2]) - 1d;
                            if (Convert.ToDouble(cn[i - 2]) < 0)
                                cn[i - 2] = Math.Abs(Convert.ToDouble(cn[i - 2]));
                            else if (Convert.ToDouble(cn[i - 2]) > 0)
                            {
                                cn[i - 2] = Math.Abs(Convert.ToDouble(cn[i - 2]));
                                cn[i - 3] = '+';
                            }
                            else
                            {
                                cn.RemoveAt(i);
                                cn.RemoveAt(i - 1);
                                cn.RemoveAt(i - 2);
                                cn.RemoveAt(i - 3);
                            }

                        }
                    

                        insert = false;
                        break;
                    }
                    continue;
                }
                continue;
            }
        }

        if (insert)
        {
            cn.Add("-");
            cn.Add(symbol);
        }

        return new(cn);
    }

    public static Polynomial operator -(Symbol symbol, Polynomial polynomial)
        => -polynomial + symbol;

    #endregion

    #region Multiplication

    public static Polynomial operator *(Polynomial polynomial, double number)
    {
        if (number == 0)
            return new(new() { 0d }); // a * 0 = 0

        else if (number < 0)
            return -polynomial * Maths.Abs(number); // a * (-b) = -a * b

        polynomial.SetDictionaries();
        List<object> cn = polynomial.Container;

        foreach ((int index, double num) in polynomial.DoublesDictionary)
            cn[index] = Math.Abs(number * num);

        polynomial.SetDictionaries();
        cn = polynomial.Container;

        foreach ((int index, _) in polynomial.SymbolsDicitonary)
        {
            if(index == 0)
            {
                cn.Insert(0, '*');
                cn.Insert(0, Maths.Abs(number));

                polynomial.SetDictionaries();
                cn = polynomial.Container;
                continue;
            }

            if (cn[index - 1].ToString() == "*")
                continue;

            cn.Insert(index, '*');
            cn.Insert(index, Maths.Abs(number));

            polynomial.SetDictionaries();
            cn = polynomial.Container;
            continue;
        }
        
        return new(cn);
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

