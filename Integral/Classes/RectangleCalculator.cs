using System;

namespace Integral.Classes
{
    class RectangleCalculator : ICalculator
    {
        public double Calculate(double a, double b, int n, Func<double, double> f)
        {
            double h = (b - a) / n;
            double s = 0;
            for(int i = 0; i<n; i++)
            {
                s += f(a + h * i);
            }
            return h*s;
        }
    }
}
