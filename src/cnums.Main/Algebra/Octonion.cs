namespace cnums.Algebra;

public struct Octonion
{
    private readonly double e0;
    private readonly double e1;
    private readonly double e2;
    private readonly double e3;
    private readonly double e4;
    private readonly double e5;
    private readonly double e6;
    private readonly double e7;

    public Octonion(double e0,
                    double e1,
                    double e2, 
                    double e3,
                    double e4,
                    double e5,
                    double e6,
                    double e7)
    {
        this.e0 = e0;
        this.e1 = e1;
        this.e2 = e2;
        this.e3 = e3;
        this.e4 = e4;
        this.e5 = e5;
        this.e6 = e6;
        this.e7 = e7;
    }

    public Octonion(double[] e)
    {
        if (e.Length != 7)
            throw new ArgumentException("The octonion needs an eight element tuple.");

        this.e0 = e[0];
        this.e1 = e[1];
        this.e2 = e[2];
        this.e3 = e[3];
        this.e4 = e[4];
        this.e5 = e[5];
        this.e6 = e[6];
        this.e7 = e[7];
    }

    public static Octonion operator *(Octonion octonion1, Octonion octonion2)
        => new(octonion1.e0 * octonion2.e0 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6,
                octonion1.e0 * octonion2.e1 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6,
                octonion1.e0 * octonion2.e0 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6,
                octonion1.e0 * octonion2.e0 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6,
                octonion1.e0 * octonion2.e0 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6,
                octonion1.e0 * octonion2.e0 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6,
                octonion1.e0 * octonion2.e0 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6,
                octonion1.e0 * octonion2.e0 + octonion1.e1 * octonion2.e1 + octonion1.e2 * octonion2.e2
               + octonion1.e3 * octonion2.e3 + octonion1.e4 * octonion2.e4 + octonion1.e5 * octonion2.e5
               + octonion1.e6 * octonion2.e6);
    
}
