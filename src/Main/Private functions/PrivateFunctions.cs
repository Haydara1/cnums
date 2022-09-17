using cnums.Symbolic;

namespace cnums
{
    internal static partial class PrivateFunctions
    {
        private static double Normalize(double num)
        {
            string number = num.ToString();

            char[] numArray = number.ToCharArray();
            List<char> numList = numArray.ToList(); //Convert number to char list.

            if (numList.Contains('.')) numList.Remove('.'); //Remove '.' if found.
            numList.Insert(1, '.'); //Add '.' at index one.

            string str = String.Empty;

            foreach (char c in numList) str += c; //Build list into one string.

            return Convert.ToDouble(str);
        }

        private static int DigitCounter(double num)
        {
            string str = num.ToString();
            int len = 0;

            foreach (char c in str)
            {
                if (c == '.') break;
                len++;
            }

            return len;
        }

        private static double[] GreaterThanOne(double num)
        {
            double[] arr = new double[2];

            if (num < 1)
            {
                num = 1 / num;
                arr[0] = num;
                arr[1] = -1;

                return arr;
            }

            arr[0] = num;
            arr[1] = 1;

            return arr;
        }

        private static double ListToDouble(List<int> list)
        {
            double sum = 0;

            for (int i = 0; i < list.Count; i++)
                sum += list[i] * Maths.Power(10, -i);

            return sum;
        }

        internal static double LogTen(double num, int accuracy = 100)
        {
            List<int> resultList = new();

            double[] arr = GreaterThanOne(num);
            num = arr[0];
            double sign = arr[1];

            for (int _ = 0; _ < accuracy; _++)
            {
                int DigitsNum = DigitCounter(num) - 1; //Depending on the eqaution: Number of digits = 1 + log(num)
                resultList.Add(DigitsNum);

                num = Normalize(num);
                num = Maths.Power(num, 10);
            }

            double result = ListToDouble(resultList);
            return sign * result; // log(a) = -log(1/a)
        }

        internal static double ModPi(double angle)
            => angle % Consts.Tau;

        internal static bool IsInteger(double number)
            => number % 1 == 0;

        internal static double AngleShift(double alpha, double beta)
        {
            double gamma;

            if (alpha < beta)
                gamma = beta - ((beta - alpha) % (2.0 * Consts.PI)) + 2.0 * Consts.PI;
            else
                gamma = beta + ((alpha - beta) % (2.0 * Consts.PI));

            return gamma;
        }

        internal static double[,] MatricesMultiplication(double[,] arr1, double[,] arr2)
        {
            int rA = arr1.GetLength(0);
            int cA = arr1.GetLength(1);
            int rB = arr2.GetLength(0);
            int cB = arr2.GetLength(1);

            double temp;
            double[,] result = new double[rA, cB];

            if (cA != rB)
                throw new Exception("Incompatible matrices.");
            
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    temp = 0;
                    for (int k = 0; k < cA; k++)
                        temp += arr1[i, k] * arr2[k, j];
                        
                    result[i, j] = temp;
                }
            }
            return result;
        }
    }
}
