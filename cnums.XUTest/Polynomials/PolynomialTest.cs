namespace cnums.XUTest.Polynomials;

using cnums.Main.Polynomials;
using cnums.Main.Fields;

public class PolynomialTest
{
    [Fact]
    public void TestIntPolynomial()
    {
        
        Polynomial<Natural> p1 = new Polynomial<Natural>(
            (Natural[])[Natural.MultiplicativeIdentity,
            Natural.MultiplicativeIdentity, Natural.MultiplicativeIdentity]);
        
        Polynomial<Natural> p2 = new Polynomial<Natural>((Natural[])[new(1), new(1),
            new(1), new(0), new(0)]);
        
        Polynomial<Natural> p3 = new Polynomial<Natural>((Natural[])[new(2), new(2),
            new(2), new(0)]);
        
        Assert.True(p1.Equals(p2));
        Assert.True(p3.Equals(p2 + p1));
        Assert.True(p1.Equals(p3 - p2));
        Assert.True(p3.Equals(new Natural(2) *  p1));
    }
}