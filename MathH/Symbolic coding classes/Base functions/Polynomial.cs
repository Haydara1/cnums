namespace cnums;

public class Polynomial
{
    private List<object> container;

    public List<object> Container
    {
        get { return container; }
        private set { container = value; }
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

    public static Polynomial operator +(Polynomial polynomial)
        => polynomial;

    public static Polynomial operator +(Polynomial polynomial, double number)
    {
        if(number == 0) return polynomial;

        List<object> cn = polynomial.Container;
        bool insert = true;

        for (int i = 0; i < cn.Count; i++)
        {
            if (cn[i].GetType() != number.GetType())
                continue;

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

    public static Polynomial operator -(Polynomial polynomial)
    {
        List<object> cn = polynomial.Container;

        cn.Insert(0, '(');
        cn.Insert(0, '-');
        cn.Add(')');

        return new(cn);
    }

    public static Polynomial operator -(Polynomial polynomial, double number)
        => polynomial + (-number);

    public static Polynomial operator -(double number, Polynomial polynomial)
        => -polynomial + number;
}

