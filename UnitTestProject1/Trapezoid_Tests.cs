using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integral.Classes;

namespace Integral_Tests
{
    [TestClass]
    public class Trapezoid_Tests
    {
        [TestMethod]
        public void T_xx_0_10()
        {
            //arrange
            double expected = 333.333;
            double a = 0;
            double b = 10;
            int n = 10000;
            ICalculator calcul = new TrapezoidCalc();

            //act
            double actual = calcul.Calculate(a, b, n, x => x * x);

            //assert
            Assert.AreEqual(expected, actual, 0.001);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void T_xx_Negative_Step()
        {
            //arrange
            double expected = 333.333;
            double a = 0;
            double b = 10;
            int n = -10000;
            ICalculator calcul = new TrapezoidCalc();

            //act
            double actual = calcul.Calculate(a, b, n, x => x * x);

            //assert
            Assert.AreEqual(expected, actual, 0.001);
        }   
        [TestMethod]
        public void T_xx_10_0()
        {
            //arrange
            double expected = -333.333;
            double a = 10;
            double b = 0;
            int n = 10000;
            ICalculator calcul = new TrapezoidCalc();

            //act
            double actual = calcul.Calculate(a, b, n, x => x * x);

            //assert
            Assert.AreEqual(expected, actual, 0.001);
        }
        [TestMethod]
        public void T_Step_0()
        {
            //arrange
            double expected = 0;
            double a = 10;
            double b = 10;
            int n = 10000;
            ICalculator calcul = new TrapezoidCalc();

            //act
            double actual = calcul.Calculate(a, b, n, x => x * x);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Integral_Trapezoid_0_0_10_Correct()
        {

            //arrange
            double expected = 0;
            double a = 0;
            double b = 10;
            int n = 10000;
            ICalculator calcul = new TrapezoidCalc();

            //act
            double actual = calcul.Calculate(a, b, n, x => 0);

            //assert
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}
