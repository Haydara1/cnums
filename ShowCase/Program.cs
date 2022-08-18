using cnums;
using static cnums.Maths;
using static cnums.Consts;
using static cnums.SpecialFunctions;

//while (true)
//{
//    double num1 = Convert.ToDouble(Console.ReadLine());
//    double num2 = Convert.ToDouble(Console.ReadLine());

//    Fraction fraction = new(num1, num2);
//    Console.WriteLine(fraction.ToString());
//    fraction.Simplify();
//    Console.WriteLine(fraction.ToString());
//}

Domain domain = new(10, double.PositiveInfinity, openBeginning:false) ;
Domain dm = new(12, 30);
Domain dm2 = new(30, 40);

domain.AddExceptionDomains(dm);
domain.AddExceptionDomains(dm2);

Console.WriteLine(domain);

