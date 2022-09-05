using static cnums.Consts;
using static cnums.Maths;

namespace cnums
{
    public class Complex //a + ib
    {
        private double Real; //Real part of the complex number. (a)

        public double Re
        {
            get { return Real; }
            set { Real = value; }
        }

        private double Immaginary; //Immaginary part of the complex number. (b)

        public double Im
        {
            get { return Immaginary; }
            set { Immaginary = value; }
        }

        public Complex(double Re = 0, double Im = 0) //Constructor
        {
            Real = Re;
            Immaginary = Im;
        }

        public Complex(double R = 0, double Theta = 0, bool fromPolarForm = true) //Constuctor, given parameters in polar form.
        {
            if (!fromPolarForm)
            {
                Real = Re;
                Immaginary = Im;
            }
            Real = R * Cos(Theta); // a = r * cos(theta)
            Immaginary = R * Sin(Theta); //b = r * sin(theta)
        }

        public double Modulus() // The same as taking the absolute value of a complex number
            => Abs(new Complex(Real, Immaginary)); 

        public double Arg()
        {
            // Getting magnitude
            double magnitude = Abs(new Complex(Real, Immaginary)); 

            double theta = Asin(Abs(Immaginary) / magnitude); // Sin(theta) = b / r

            if (Immaginary >= 0 && Real >= 0) return theta; // First quadrant
            else if (Immaginary >= 0 && Real <= 0) return PI - theta; // Second quadrant
            else if (Immaginary <= 0 && Real <= 0) return PI + theta; // Third quadrant
            else return -theta; // Fourth quadrant
        }

        public Complex Conjugate()
            => new(Real, -Immaginary);

        public string DescartianForm()
        {
            string s = Real.ToString();

            if (Real == 0 && Immaginary == 0) return "0";

            else if (Real == 0)
            {
                if (Immaginary == 1) return "i";
                else if (Immaginary == -1) return "-i";
                else return $"{Immaginary}i";
            }

            else if (Immaginary == 0) return $"{Real}";

            if (Immaginary > 0) s += $"+{Immaginary}i";
            else if (Immaginary == 0) { }
            else s += $"{Immaginary}i";

            return s;
        }

        public override string ToString()
            => DescartianForm();

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Complex complex = (Complex)obj;
            return (this.Im == complex.Im && this.Re == complex.Re);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool isConjugate(Complex c1)
            => (this.Re == c1.Re && this.Im == -c1.Im);

        #region Addition.
        public static Complex operator +(Complex c1)
            => c1;

        public static Complex operator +(Complex c1, Complex c2)
            => new(c1.Re + c2.Re, c1.Im + c2.Im);

        public static Complex operator +(Complex c1, int n)
            => new(c1.Re + n, c1.Im);

        public static Complex operator +(Complex c1, long n)
            => new(c1.Re + n, c1.Im);

        public static Complex operator +(Complex c1, double n)
            => new(c1.Re + n, c1.Im);

        public static Complex operator +(Complex c1, short n)
            => new(c1.Re + n, c1.Im);

        public static Complex operator +(Complex c1, float n)
            => new(c1.Re + n, c1.Im);
        #endregion

        #region Substraction.
        public static Complex operator -(Complex c1)
            => new(-c1.Re, -c1.Im);

        public static Complex operator -(Complex c1, Complex c2)
            => new(c1.Re - c2.Re, c1.Im - c2.Im);

        public static Complex operator -(Complex c1, int n)
            => new(c1.Re - n, c1.Im);

        public static Complex operator -(Complex c1, short n)
            => new(c1.Re - n, c1.Im);

        public static Complex operator -(Complex c1, long n)
            => new(c1.Re - n, c1.Im);

        public static Complex operator -(Complex c1, double n)
            => new(c1.Re - n, c1.Im);

        public static Complex operator -(Complex c1, float n)
            => new(c1.Re - n, c1.Im);

        public static Complex operator -(Complex c1, uint n)
            => new(c1.Re - n, c1.Im);

        public static Complex operator -(Complex c1, ushort n)
            => new(c1.Re - n, c1.Im);

        public static Complex operator -(Complex c1, ulong n)
            => new(c1.Re - n, c1.Im);
        #endregion

        #region Multiplication.

        public static Complex operator *(Complex c1, Complex c2)
            => new(c1.Re * c2.Re - c1.Im * c2.Im, c2.Im * c1.Re + c1.Im * c2.Re);

        public static Complex operator *(Complex c1, int n)
            => new(c1.Re * n, c1.Im * n);

        public static Complex operator *(Complex c1, short n)
            => new(c1.Re * n, c1.Im * n);

        public static Complex operator *(Complex c1, long n)
            => new(c1.Re * n, c1.Im * n);

        public static Complex operator *(Complex c1, double n)
            => new(c1.Re * n, c1.Im * n);

        public static Complex operator *(Complex c1, float n)
            => new(c1.Re * n, c1.Im * n);

        public static Complex operator *(Complex c1, uint n)
            => new(c1.Re * n, c1.Im * n);

        public static Complex operator *(Complex c1, ulong n)
            => new(c1.Re * n, c1.Im * n);

        public static Complex operator *(Complex c1, ushort n)
            => new(c1.Re * n, c1.Im * n);
        #endregion

        #region Division.
        public static Complex operator /(Complex c1, Complex c2)
        {
            c1 *= c2.Conjugate();
            c1.Re /= Power(c2.Modulus(), 2);
            c1.Im /= Power(c2.Modulus(), 2);
            return c1;
        }

        public static Complex operator /(Complex c1, int n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(Complex c1, uint n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(Complex c1, long n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(Complex c1, ulong n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(Complex c1, short n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(Complex c1, ushort n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(Complex c1, float n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(Complex c1, double n)
            => new(c1.Re / n, c1.Im / n);

        public static Complex operator /(double n, Complex c)
            => (c.Conjugate() * n) / (Power(c.Modulus(), 2));

        #endregion

        public static bool operator ==(Complex c1, Complex c2)
            => c1.Equals(c2);

        public static bool operator !=(Complex c1, Complex c2)
            => !c1.Equals(c2);


        //Complex number comparision is still undefined.

        //public static bool operator >(Complex c1, Complex c2)
        //    => c1.Modulus() > c2.Modulus();

        //public static bool operator <(Complex c1, Complex c2)
        //    => c1.Modulus() < c2.Modulus();

        //public static bool operator >=(Complex c1, Complex c2)
        //    => c1.Modulus() >= c2.Modulus();

        //public static bool operator <=(Complex c1, Complex c2)
        //    => c1.Modulus() <= c2.Modulus();
    }
}

