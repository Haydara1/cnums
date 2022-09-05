using static cnums.Maths;

namespace cnums
{
    /// <summary>
    /// Includes a list of special functions used in mathematics.
    /// </summary>
    public class SpecialFunctions
    {

        public static double Beta(double a, double b)
           // Β(a, b) = (Γ(a) * Γ(b)) / Γ(a + b)
           => (Gamma(a) * Gamma(b)) / Gamma(a + b);

        public static double Gamma(double num)
        {
            // Γ(z) = [z * exp(z * gamma) * Product(r = 0 -> inf){(1 + z / r) * exp(-z / r)}] ^ -1

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
