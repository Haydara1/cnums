using cnums.Symbolic;

namespace cnums;

public static class Cnums
{
    #region printing

    internal static bool Unicode = false;

    private readonly static char[] digits = "0123456789".ToCharArray();

    private readonly static char[] UnicodeSubsctipts = new char[] { 
        '\u2080', 
        '\u2081', 
        '\u2082',
        '\u2083',
        '\u2084',
        '\u2085',
        '\u2086',
        '\u2087',
        '\u2088',
        '\u2089',
    };

    public static void InitPrinting(bool useUnicode = true)
    {
        Unicode = useUnicode;

        if (useUnicode)
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        else
            Console.OutputEncoding = System.Text.Encoding.Default;
    }

    internal static string UnicodeExponent(this double number)
    {
        string result = "";

        string num = number.ToString();

        foreach(char c in num)
            switch (c)
            {
                case '0':
                    result += "\u2070";
                    break;

                case '1':
                    result += "\u00B9";
                    break;

                case '2':
                    result += "\u00B2";
                    break;

                case '3':
                    result += "\u00B3";
                    break;

                case '4':
                    result += "\u2074";
                    break;

                case '5':
                    result += "\u2075";
                    break;

                case '6':
                    result += "\u2076";
                    break;

                case '7':
                    result += "\u2077";
                    break;

                case '8':
                    result += "\u2078";
                    break;

                case '9':
                    result += "\u2079";
                    break;
            }

        return result;
    }

    internal static string UnicodeSubscript(this uint number)
    {
        string result = "";

        string num = number.ToString();

        foreach(char c in num)
            result += UnicodeSubsctipts[Array.IndexOf(digits, c)];

        return result;
    }

    #endregion

    #region Randoms

    public static int RandInt()
        => new Random().Next(); 

    public static int RandInt(int minValue, int maxValue)
        => new Random().Next(minValue, maxValue);

    public static int RandPosInt()
        => RandInt(0, int.MaxValue);

    public static int RandPosInt(int maxValue)
        => RandInt(0, maxValue);

    public static int RandNegInt()
        => -RandPosInt();

    public static int RandNegInt(int minValue)
        => -RandPosInt(minValue);

    public static double RandDouble()
        => new Random().NextDouble();

    public static double RandNum()
        => RandDouble() + RandInt();

    #endregion

    public static Function ToFunction(this double number)
        => new(number);

    public static Function ToFunction(this int number)
        => new(number);

    public static Function ToFunction(this Symbol symbol)
            => new(symbol);

    public static Function ToFunction(this Polynomial polynomial)
        => new(polynomial);

    public static Function ToFunction(this object obj) => obj.GetType().Name switch
    { 
        nameof(Double) => ToFunction((Double) obj),
        nameof(Symbol) => ToFunction((Symbol) obj),
        nameof(Polynomial) => ToFunction((Polynomial) obj),
        _ => throw new CnumsException(),
    };

}

/// <summary>
///     Provides a list of most used mathematics constants.
/// </summary>
public static class Consts
{

    /// <summary>
    ///     Represents the natural logarithmic base, specified by the constant, e.
    /// </summary>
    public const double E = 2.7182818284590451; //1 / 10 ^ 16 precision 

    /// <summary>
    ///     Represents the ratio of the circumference of a circle to its diameter, specified
    ///     by the constant, π.
    /// </summary>  
    public const double PI = 3.1415926535897931; //1 / 10 ^ 16 precision 

    /// <summary>
    ///     Represents the number of radians in one turn, specified by the constant, τ.
    /// </summary>
    public const double Tau = 6.2831853071795862; //1 / 10 ^ 16 precision 

    ///<summary>
    ///     Represents the Euler-Mascheroni constant.
    ///</summary>
    public const double Gamma = 0.57721566490153286060; //1 / 10 ^ 20 precision 

    ///<summary>
    ///     Represents the golden ratio, specified by the constant φ.
    /// </summary>
    public const double Phi = 1.61803398874989484820; //1 / 10 ^ 20 precision 

    /// <summary>
    /// Represents the System.double.PositiveInfinity, named with double o's bc it looks close to the infinity shape.
    /// </summary>
    public const double oo = double.PositiveInfinity;

    //Used for Cordic algorithm.
    //Table of consts representing Atan( (1/2)^(0:59) )
    internal static double[] Angles = {
    7.8539816339744830962E-01,
    4.6364760900080611621E-01,
    2.4497866312686415417E-01,
    1.2435499454676143503E-01,
    6.2418809995957348474E-02,
    3.1239833430268276254E-02,
    1.5623728620476830803E-02,
    7.8123410601011112965E-03,
    3.9062301319669718276E-03,
    1.9531225164788186851E-03,
    9.7656218955931943040E-04,
    4.8828121119489827547E-04,
    2.4414062014936176402E-04,
    1.2207031189367020424E-04,
    6.1035156174208775022E-05,
    3.0517578115526096862E-05,
    1.5258789061315762107E-05,
    7.6293945311019702634E-06,
    3.8146972656064962829E-06,
    1.9073486328101870354E-06,
    9.5367431640596087942E-07,
    4.7683715820308885993E-07,
    2.3841857910155798249E-07,
    1.1920928955078068531E-07,
    5.9604644775390554414E-08,
    2.9802322387695303677E-08,
    1.4901161193847655147E-08,
    7.4505805969238279871E-09,
    3.7252902984619140453E-09,
    1.8626451492309570291E-09,
    9.3132257461547851536E-10,
    4.6566128730773925778E-10,
    2.3283064365386962890E-10,
    1.1641532182693481445E-10,
    5.8207660913467407226E-11,
    2.9103830456733703613E-11,
    1.4551915228366851807E-11,
    7.2759576141834259033E-12,
    3.6379788070917129517E-12,
    1.8189894035458564758E-12,
    9.0949470177292823792E-13,
    4.5474735088646411896E-13,
    2.2737367544323205948E-13,
    1.1368683772161602974E-13,
    5.6843418860808014870E-14,
    2.8421709430404007435E-14,
    1.4210854715202003717E-14,
    7.1054273576010018587E-15,
    3.5527136788005009294E-15,
    1.7763568394002504647E-15,
    8.8817841970012523234E-16,
    4.4408920985006261617E-16,
    2.2204460492503130808E-16,
    1.1102230246251565404E-16,
    5.5511151231257827021E-17,
    2.7755575615628913511E-17,
    1.3877787807814456755E-17,
    6.9388939039072283776E-18,
    3.4694469519536141888E-18,
    1.7347234759768070944E-18 };

    //Used for Cordic algorithm.
    //K(33) = 1 / sqrt ( 1 + (1/2)^(2 * 33) ). 
    internal static double KProd = 0.60725293500888125617;

    ////Used for Cordic algorithm.
    //real A(1:25) = exp((1/2)^(1:25) ).
    internal static double[] ExpValues = {
    1.648721270700128,
    1.284025416687742,
    1.133148453066826,
    1.064494458917859,
    1.031743407499103,
    1.015747708586686,
    1.007843097206488,
    1.003913889338348,
    1.001955033591003,
    1.000977039492417,
    1.000488400478694,
    1.000244170429748,
    1.000122077763384,
    1.000061037018933,
    1.000030518043791,
    1.0000152589054785,
    1.0000076294236351,
    1.0000038147045416,
    1.0000019073504518,
    1.0000009536747712,
    1.0000004768372719,
    1.0000002384186075,
    1.0000001192092967,
    1.0000000596046466,
    1.0000000298023228
    };
}
//How are you Julia?