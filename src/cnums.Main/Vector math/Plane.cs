namespace cnums.Vector_math;

public struct Plane
{
    private readonly double a;
    private readonly double b;
    private readonly double c;
    private readonly double d;

    public double A => a;
    public double B => b;
    public double C => c;
    public double D => d;

    public Plane(double a, double b, double c, double d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }
}
