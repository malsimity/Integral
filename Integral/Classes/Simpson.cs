using System;

namespace Integral.Classes
{
    public class Simpson : ICalculator
    {
        public double Calculate(double a, double b, int n, Func<double, double> f)
        {
            if (n <= 0)
            {
                Exception ex = new ArgumentException("Некорректное значение разбиений");
                throw ex;
            }
            if (n % 2 == 1) // проверка четности количества разбиений
            {
                Exception ex = new ArgumentException("Нечётное число разбиений");
                throw ex;
            }
            double h = (b - a) / n;
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
            //return h * S / 3;
            return S;
        }
    }
}
