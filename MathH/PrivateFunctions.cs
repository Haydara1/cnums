using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathH
{
    internal class PrivateFunctions
    {
        private static double Normalize(double num)
        {
            char[] numArray = num.ToString().ToCharArray();
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
            
            foreach(char c in str)
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
            List<int> resultList = new List<int>();

            double[] arr = GreaterThanOne(num);
            num = arr[0];
            double sign = arr[1];

            for(int _ = 0; _ < accuracy; _++)
            {
                int DigitsNum = DigitCounter(num) - 1;
                resultList.Add(DigitsNum);

                num = Normalize(num);
                num = Maths.Power(num, 10);
            }

            double result = ListToDouble(resultList);
            return sign * result;
        }
    }
}
