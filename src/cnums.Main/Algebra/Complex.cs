using static cnums.Consts;
using static cnums.Maths;

namespace cnums.Algebra
{
    public struct Complex //a + ib
    {
        //Zero Complex
        public static readonly Complex Zero = new(0, 0);

        //One Complex
        public static readonly Complex One = new(1, 0);

        //One Imaginary
        public static readonly Complex ImaginaryOne = new(0, 1);

        private double Real; //Real part of the complex number. (a)

        public double Re
        {
            get { return Real; }
            set { Real = value; }
        }

        private double Imaginary; //Immaginary part of the complex number. (b)

        public double Im
        {
            get { return Imaginary; }
            set { Imaginary = value; }
        }

        public Complex(double Re = 0, double Im = 0) //Constructor
        {
            Real = Re;
            Imaginary = Im;
        }

        public Complex(uint Modulus = 0, double Theta = 0) //Constuctor, given parameters in polar form.
        {
            Real = Modulus * Cos(Theta); // a = r * cos(theta)
            Imaginary = Modulus * Sin(Theta); //b = r * sin(theta)
        }

        public double Modulus() // The same as taking the absolute value of a complex number
            => Algebra.Abs(new Complex(Real, Imaginary));

        public double Arg()
        {
            // Getting magnitude
            double magnitude = Algebra.Abs(new Complex(Real, Imaginary));

            double theta = Asin(Abs(Imaginary) / magnitude); // Sin(theta) = b / r

            if (Imaginary >= 0 && Real >= 0) return theta; // First quadrant
            else if (Imaginary >= 0 && Real <= 0) return PI - theta; // Second quadrant
            else if (Imaginary <= 0 && Real <= 0) return PI + theta; // Third quadrant
            else return -theta; // Fourth quadrant
        }

        public Complex Conjugate()
            => new(Real, -Imaginary);

        public string DescartianForm()
        {
            string s = Real.ToString();

            if (Real == 0 && Imaginary == 0) return "0";

            else if (Real == 0)
            {
                if (Imaginary == 1) return "i";
                else if (Imaginary == -1) return "-i";
                else return $"{Imaginary}i";
            }

            else if (Imaginary == 0) return $"{Real}";

            if (Imaginary > 0) s += $"+{Imaginary}i";
            else if (Imaginary == 0) { }
            else s += $"{Imaginary}i";

            return s;
        }

        public override string ToString()
            => DescartianForm();

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            Complex complex = (Complex)obj;
            return Im == complex.Im && Re == complex.Re;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool isConjugate(Complex c1)
            => Re == c1.Re && Im == -c1.Im;

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
            => c.Conjugate() * n / Power(c.Modulus(), 2);

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

