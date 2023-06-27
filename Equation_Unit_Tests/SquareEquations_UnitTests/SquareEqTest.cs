using Xunit;
using SquareEquationLib;
namespace SquareEquations_UnitTests;

public class UnitTest1
{
    [Fact]
    public void FistArgumentZero()
    {
        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(0, 0, 0));
    }
    [Theory]
    [InlineData(double.NaN,1,1)]
    [InlineData(1,double.NaN,1)]
    [InlineData(1,1,double.NaN)]
    [InlineData(double.PositiveInfinity,1,1)]
    [InlineData(1,double.PositiveInfinity,1)]
    [InlineData(1,1,double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity,1,1)]
    [InlineData(1,double.NegativeInfinity,1)]
    [InlineData(1,1,double.NegativeInfinity)]
    public void AnyInvalidArgument(double a,double b, double c)
    {
        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }
    [Fact]
    public void D_CloseToZero()
    {
        double[] expected_roots = new double[]{-0.5};
        double[] roots = SquareEquation.Solve(1,1,0.24999999995);
        if (roots.Length!=expected_roots.Length)
        {
            Assert.Fail("Amount of roots does not match");
        }
        Assert.Equal(roots[0],expected_roots[0]);

    }
    [Theory]
        [InlineData(1, 0, 1, new double[] {})]
        [InlineData(1,0,0, new double[] {0})]
        [InlineData(1,4,4, new double[] {-2})]
        [InlineData(1,-3,2, new double[] {1, 2})]

        public void RootCorrectness(double a, double b, double c, double[] expectedRoots)
        {
            
            double[] roots = SquareEquation.Solve(a, b, c);
            Array.Sort(roots);
            Array.Sort(expectedRoots);

            if (expectedRoots.Length != roots.Length)
            {
                Assert.Fail("Amount of roots does not match");
            }

            for (int i = 0; i < expectedRoots.Length; i++)
            {
                Assert.Equal(expectedRoots[i], roots[i], 6);
            }
        }
}