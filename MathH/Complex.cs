using static cnums.Maths;
using static cnums.Consts;

namespace cnums
{
    public class Complex
    {
        private double Real;

        public double Re 
        {
            get { return Real; }
            set { Real = value; } 
        }

        private double Immaginary;

        public double Im
        {
            get { return Immaginary; }
            set { Immaginary = value; }
        }

        public Complex(double Re = 0, double Im = 0)
        {
            Real = Re;
            Immaginary = Im;
        }

        public Complex(double R = 0, double Theta = 0, bool fromPolarForm = true)
        {
            if(!fromPolarForm)
            {
                Real = Re;
                Immaginary = Im;
            }
            Real = R * Cos(Theta);
            Immaginary = R * Sin(Theta);
        }

        public double Modulus()
            => Abs(new Complex(Real, Immaginary));

        public double Arg()
        {
            double magnitude = Abs(new Complex(Real, Immaginary));

            double snTheta = Asin(Immaginary / magnitude);
            double csTheta = Acos(Real / magnitude);

            double theta = (Abs(snTheta + csTheta)) / 2;

            if (snTheta >= 0 && csTheta >= 0) return theta;
            else if (snTheta >= 0 && csTheta <= 0) return PI - theta;
            else if (snTheta <= 0 && csTheta <= 0) return PI + theta;
            else return -theta;
        }

        public Complex Conjugate()
            => new(Real, -Immaginary);

        public string DescartianForm()
        {
            string s = Real.ToString();

            if (Immaginary > 0) s += $"+{Immaginary}i";
            else if( Immaginary == 0) { }
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

        #region Plus operator.
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


        #region Minus operator.
        public static Complex operator -(Complex c1)
            => new(-c1.Re, -c1.Im);
        public static Complex operator -(Complex c1, Complex c2)
            => new(c1.Re - c2.Re, c1.Im - c2.Im);
        public static Complex operator -(Complex c1, int n)
            => new(c1.Re - n, c1.Im - n);
        public static Complex operator -(Complex c1, short n)
            => new(c1.Re - n, c1.Im - n);
        public static Complex operator -(Complex c1, long n)
            => new(c1.Re - n, c1.Im - n);
        public static Complex operator -(Complex c1, double n)
            => new(c1.Re - n, c1.Im - n);
        public static Complex operator -(Complex c1, float n)
            => new(c1.Re - n, c1.Im - n);
        public static Complex operator -(Complex c1, uint n)
            => new(c1.Re - n, c1.Im - n);
        public static Complex operator -(Complex c1, ushort n)
            => new(c1.Re - n, c1.Im - n);
        public static Complex operator -(Complex c1, ulong n)
            => new(c1.Re - n, c1.Im - n);
        #endregion


        public static Complex operator *(Complex c1, Complex c2)
            => new(c1.Re * c2.Re - c1.Im * c2.Im, c2.Im * c1.Re + c1.Im * c2.Re);

        public static Complex operator /(Complex c1, Complex c2)
        {
            c1 *= c2.Conjugate();
            c1.Re /= c2.Modulus();
            c1.Im /= c2.Modulus();
            return c1;
        }
    }
}
