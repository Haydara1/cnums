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

        Complex c1 = new(1, 1);
        Complex c2 = new(1, 2);

        Console.WriteLine(c1.Equals(c2));

    }

}

