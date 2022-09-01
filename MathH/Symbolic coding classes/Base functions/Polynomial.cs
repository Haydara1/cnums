namespace cnums;

public class Polynomial
{
    private List<object> container;

    private List<object> Container
    {
        get { return container; }
        set { container = value; }
    }

    internal Polynomial(List<object> objects)
        => container = objects; 

    private void SimplifyPolinomial()
    {
       
    }

    public override string ToString()
    {
        string poly = "";

        if (Container == null) return "0";

        foreach(object obj in Container)
            poly += obj.ToString();

        return poly;
    }

    #region Addition

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator +(Polynomial polynomial, double number)
    {
        if(number == 0) return polynomial;

        List<object> cn = polynomial.Container;
        bool insert = true;

        //Numbers can only be surounded by '-' or '+' operators,
        //using this logic helps us finding the polynomial's constant,
        //and then adding the number.

        //Putting in mind that number can be a negative number too, 
        //which requires changing the sign of the constant after the addition. 

        for (int i = 0; i < cn.Count; i++)
        {
            if (cn[i].GetType() != number.GetType()) //Check element's type
                continue;

            //Different index cases

            if(i == 0)
            {
                if (i == cn.Count - 1)
                {
                    cn[i] = number + Convert.ToDouble(cn[i]);

                    if (Convert.ToDouble(cn[i]) < 0)
                    {
                        cn[i] = Maths.Abs(Convert.ToDouble(cn[i]));
                        cn.Insert(0, '-');
                    }
                    else if (Convert.ToDouble(cn[i]) == 0)
                        cn = new List<object> { 0d };

                    insert = false;
                    break;
                }
                else
                {
                    if (cn[i + 1].ToString() == "+"
                        || cn[i + 1].ToString() == "-")
                    {
                        cn[i] = number + Convert.ToDouble(cn[i]);

                        if (Convert.ToDouble(cn[i]) < 0)
                        {
                            cn[i] = Maths.Abs(Convert.ToDouble(cn[i]));
                            cn.Insert(0, '-');
                        }
                        else if (Convert.ToDouble(cn[i]) == 0)
                            cn = new List<object> { 0d };

                        insert = false;
                        break;
                    }

                    continue;
                }
            }
            else if(i == cn.Count - 1)
            {
                if (cn[i - 1].ToString() == "+"
                        || cn[i - 1].ToString() == "-")
                {
                    if (cn[i - 1].ToString() == "+")
                    {
                        cn[i] = number + Convert.ToDouble(cn[i]);
                        if (Convert.ToDouble(cn[i]) < 0)
                        {
                            cn[i] = Maths.Abs(Convert.ToDouble(cn[i]));
                            cn[i - 1] = '-';
                        }
                    }
                    else
                    {
                        cn[i] = -Convert.ToDouble(cn[i]) + number;
                        if (Convert.ToDouble(cn[i]) < 0)
                        {
                            cn[i] = Maths.Abs(Convert.ToDouble(cn[i]));
                            cn[i - 1] = '+';
                        }
                    }

                    if (Convert.ToDouble(cn[i]) == 0)
                    {
                        cn.RemoveAt(i);
                        cn.RemoveAt(i - 1);
                    }

                    insert = false;
                    break;
                }

                continue;
            }
            else
            {
                if ((cn[i - 1].ToString() == "+"
                        || cn[i - 1].ToString() == "-")
                        && (cn[i + 1].ToString() == "+"
                        || cn[i + 1].ToString() == "-"))
                {
                    if (cn[i - 1].ToString() == "+")
                    {
                        cn[i] = number + Convert.ToDouble(cn[i]);
                        if (Convert.ToDouble(cn[i]) < 0)
                        {
                            cn[i] = Maths.Abs(Convert.ToDouble(cn[i]));
                            cn[i - 1] = '-';
                        }
                    }
                    else
                    {
                        cn[i] = -Convert.ToDouble(cn[i]) + number;
                        if (Convert.ToDouble(cn[i]) < 0)
                        {
                            cn[i] = Maths.Abs(Convert.ToDouble(cn[i]));
                            cn[i - 1] = '+';
                        }
                    }

                    if (Convert.ToDouble(cn[i]) == 0)
                    {
                        cn.RemoveAt(i);
                        cn.RemoveAt(i - 1);
                    }

                    insert = false;
                    break;
                }

                continue;
            }
        }

        if (insert)
        {
            if (number < 0)
                cn.Add('-');
            else
                cn.Add('+');

            cn.Add(Math.Abs(number));
        }

        return new(cn);
    }

    public static Polynomial operator +(double number, Polynomial polynomial)
        => polynomial + number;

    public static Polynomial operator +(Polynomial polynomial, Symbol symbol)
    {   
        List<object> cn = polynomial.Container;
        bool insert = true;

        for(int i = 0; i < cn.Count; i++)
        {
            if (!symbol.Equals(cn[i]))
                continue;

            bool brk = false;

            if (i == 0)
            {
                if (cn[i + 1].ToString() == "+" 
                    || cn[i + 1].ToString() == "-")
                {
                    cn.Insert(0, "*");
                    cn.Insert(0, 2d);

                    insert = false;
                    break;
                }

                continue;
            }

            else if(i == cn.Count - 1)
            {
                switch(cn[i - 1].ToString())
                {
                    case "+":
                        cn.Insert(i, "*");
                        cn.Insert(i, 2d);

                        brk = true;
                        insert = false;
                        break;

                    case "-":
                        cn.RemoveAt(i);
                        cn.RemoveAt(i - 1);

                        brk = true;
                        insert = false;
                        break;

                    case "*":
                        if (cn[i - 2].GetType() == typeof(double))
                        {
                            if(i < 3)
                                cn[i - 2] = Convert.ToDouble(cn[i - 2]) + 1d;
                            else
                            {
                                if (cn[i - 3].ToString() == "+")
                                    cn[i - 2] = Convert.ToDouble(cn[i - 2]) + 1d;
                                else if (cn[i - 3].ToString() == "-")
                                {
                                    cn[i - 2] = -Convert.ToDouble(cn[i - 2]) + 1d;
                                    if (Convert.ToDouble(cn[i - 2]) < 0)
                                        cn[i - 2] = Math.Abs(Convert.ToDouble(cn[i - 2]));
                                    else if(Convert.ToDouble(cn[i - 2]) > 0)
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

                if (cn[i - 1].ToString() == "+")
                {
                    cn.Insert(i, "*");
                    cn.Insert(i, 2d);

                    insert = false;
                    break;
                }
                else if (cn[i - 1].ToString() == "-")
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
                        if (i < 3)
                            cn[i - 2] = Convert.ToDouble(cn[i - 2]) + 1d;
                        else
                        {
                            if (cn[i - 3].ToString() == "+")
                                cn[i - 2] = Convert.ToDouble(cn[i - 2]) + 1d;
                            else if (cn[i - 3].ToString() == "-")
                            {
                                cn[i - 2] = -Convert.ToDouble(cn[i - 2]) + 1d;
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
            cn.Add("+");
            cn.Add(symbol);
        }

        return new(cn);
    }

    public static Polynomial operator +(Symbol symbol, Polynomial polynomial)
        => polynomial + symbol;

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

        if (cn[0].ToString() != "+" || cn[0].ToString() != "-")
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
}

