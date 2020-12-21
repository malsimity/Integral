using Integral.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Integral_Tests
{
    [TestClass]
    public class Rectangle_Tests
    {
        [TestMethod]
        public void R_xx_0_10()
        {
            //arrange
            double expected = 333.333;
            double a = 0;
            double b = 10;
            int n = 1000000;
            ICalculator calcul = new RectangleCalculator();

            //act
            double actual = calcul.Calculate(a, b, n, x => x * x);

            //assert
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}
