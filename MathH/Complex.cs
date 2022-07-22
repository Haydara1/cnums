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
            Real = R * Maths.Cos(Theta);
            Immaginary = R * Maths.Sin(Theta);
        }

        public double Modulus()
            => Abs(new Complex(Real, Immaginary));

        public double Arg()
        {
            double t, r;
            r = Sqrt(Power(Real) + Power(Immaginary));

            double cs, sn;

            cs = Real / r;
            sn = Immaginary / r;

            t = Acos(cs);

            if (cs >= 0 && sn >= 0) return t;
            else if (cs <= 0 && sn >= 0) return PI - t;
            else if (cs <= 0 && sn <= 0) return PI + t;
            else return -t;
            
        }


    }
}
