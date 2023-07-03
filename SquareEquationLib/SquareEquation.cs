// using System;

namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = Math.Pow(10, -6);

        if (a < eps && -eps < a) throw new System.ArgumentException();
        if (new[] { a, b, c }.Any(double.IsInfinity)) throw new System.ArgumentException();
        if (Double.IsNaN(a) || Double.IsNaN(b) || Double.IsNaN(c)) throw new System.ArgumentException();

        double D = b * b - 4 * a * c;

        if (D <= -eps)
        {
            double[] result = new double[0];
            return result;
        }
        else if (-eps < D & D < eps)
        {
            double x1 = (-b) / 2 * a;
            double[] result = { x1 };
            return result;
        }
        else
        {
            double x1;
            if (Math.Sign(b)==0)
                x1 = -(b + Math.Sqrt(D)) / 2*a; 
            else 
                x1 = (2 * c) / -(b + Math.Sign(b) * Math.Sqrt(D)); 
            double x2 = c /(a*x1);
            return(new double[] { x1, x2 });
        }
    }
}
