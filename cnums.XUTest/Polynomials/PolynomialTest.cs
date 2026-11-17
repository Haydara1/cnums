namespace cnums.XUTest.Polynomials;

using cnums.Main.Polynomials;

public class PolynomialTest
{
    [Fact]
    public void TestIntPolynomial()
    {
        Polynomial<int> p1 = new Polynomial<int>((int[])[1, 1, 1]);
        Polynomial<int> p2 = new Polynomial<int>((int[])[1, 1, 1, 0, 0]);
        Polynomial<int> p3 = new Polynomial<int>((int[])[2, 2, 2, 0]);
        
        Assert.True(p1.Equals(p2));
        Assert.True(p3.Equals(p2 + p1));
        Assert.True(p1.Equals(p3 - p2));
        Assert.True(p3.Equals(2 *  p1));
    }
}