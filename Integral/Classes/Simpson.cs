using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral.Classes
{
    class Simpson : ICalculator
    {
        public double Calculate(double a, double b, int n, Func<double, double> f)
        {
            double h = (b - a) / n;
            double s = 0;
            if (n % 2 == 1)
            {
                h /= 2;
                n *= 2;
            }
            double S;
            S = f(a) + f(b);
            for (int i = 1; i <= n / 2; i++)
            {
                S += 4 * f(a + (2 * i - 1) * h);
            }
            for (int i = 1; i < n / 2; i++)
            {
                S += 2 * f(a + 2 * i * h);
            }
            return h * S / 3;
        }
    }
}
