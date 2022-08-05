using cnums;
using static cnums.Maths;
using static cnums.Consts;
using static cnums.Complex;

class Program
{
   

    static void Main(string[] args)
    {
        //Console.WriteLine(10E-2);

        //for(double i = -1; i < 1; i+= 0.001)
        //{
        //    double a = Asin(i);
        //    double b = Math.Asin(i);

        //    double d = Abs(a - b);
        //    Console.WriteLine(d);
        //}

        while(true)
        {
            int r = Convert.ToInt32(Console.ReadLine());
            int[] f = PrimeFactors(r, true);
            foreach (int i in f) Console.Write(i + " ");
            Console.WriteLine();
        }
    }

}

