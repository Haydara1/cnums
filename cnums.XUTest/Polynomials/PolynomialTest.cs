namespace cnums.XUTest.Polynomials;

using cnums.Main.Polynomials;
using cnums.Main.Fields;

public class PolynomialTest
{
    [Fact]
    public void TestIntPolynomial()
    {
        
        Polynomial<Integer> p1 = new Polynomial<Integer>(
            (Integer[])[Integer.MultiplicativeIdentity,
            Integer.MultiplicativeIdentity, Integer.MultiplicativeIdentity]);
        
        Polynomial<Integer> p2 = new Polynomial<Integer>((Integer[])[new(1), new(1),
            new(1), new(0), new(0)]);
        
        Polynomial<Integer> p3 = new Polynomial<Integer>((Integer[])[new(2), new(2),
            new(2), new(0)]);
        
        Assert.True(p1.Equals(p2));
        Assert.True(p3.Equals(p2 + p1));
        Assert.True(p1.Equals(p3 - p2));
        Assert.True(p3.Equals(new Integer(2) *  p1));
    }
}