using static cnums.Maths;

namespace cnums
{
    public class SpecialFunctions
    {
        public static double Beta(double a, double b)
           => (Gamma(a) * Gamma(b)) / Gamma(a + b);

        public static double Gamma(double num)
        {

            double product = Exp(Consts.Gamma * num);
            product *= num;

            for (int i = 1; i < 1000; i++)
            {
                double helper = 1 + (num / i);
                helper *= Exp(-(num / i));
                product *= helper;
            }

            return 1 / product;
        }

    }
}
