// <copyright file="PolynomialTests.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace Polynomial.NUnitTests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides test for class Polynomial
    /// </summary>
    [TestFixture]
    public class PolynomialTests
    {       
        /// <summary>
        /// Test for class Polynomial
        /// </summary>
        /// <param name="arg1">Array polynomial</param>
        /// <returns>Polynomial string</returns>
        [TestCase(new double[] { 2, -3, 0, 1, -5 }, ExpectedResult = "-5*x^4+1*x^3-3*x+2")]
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, ExpectedResult = "7*x^4+4*x^3+3*x")]
        [TestCase(new double[] { 1, 4, 0, 1, -0.1 }, ExpectedResult = "-0,1*x^4+1*x^3+4*x+1")]
        public string Polynomial_ToString_ValidData_Test(double[] arg1)
        {
            var polinomial = new Polynomial(arg1);

            return polinomial.ToString();
        }

        /// <summary>
        /// Test for class Polynomial
        /// </summary>
        /// <param name="arg1">Array polynomial1</param>
        /// <param name="arg2">Array polynomial2</param>
        /// <returns>Polynomial string</returns>
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 0, 3, 0, 4, 7 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 2, -3, 0, 1, -5 }, ExpectedResult = false)]
        public bool Polynomial_Equals_ValidData_Test(double[] arg1, double[] arg2)
        {
            var polinomial1 = new Polynomial(arg1);
            var polinomial2 = new Polynomial(arg2);

            return polinomial1.Equals(polinomial2);
        }

        /// <summary>
        /// Test for class Polynomial
        /// </summary>
        /// <param name="arg1">Array polynomial1</param>
        /// <param name="arg2">Array polynomial2</param>
        /// <returns>Polynomial string</returns>
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 1, 2, 4, -2, -3 }, ExpectedResult = "4*x^4+2*x^3+4*x^2+5*x+1")]
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 2, -3, 0, 1, -5 }, ExpectedResult = "2*x^4+5*x^3+2")]
        public string Polynomial_OperatorPlus_ValidData_Test(double[] arg1, double[] arg2)
        {
            var polinomial1 = new Polynomial(arg1);
            var polinomial2 = new Polynomial(arg2);

            return (polinomial1 + polinomial2).ToString();
        }

        /// <summary>
        /// Test for class Polynomial
        /// </summary>
        /// <param name="arg1">Array polynomial1</param>
        /// <param name="arg2">Array polynomial2</param>
        /// <returns>Polynomial string</returns>
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 1, 2, 4, -2, -3 }, ExpectedResult = "10*x^4+6*x^3-4*x^2+1*x-1")]
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 2, -3, 0, 1, -5 }, ExpectedResult = "12*x^4+3*x^3+6*x-2")]
        public string Polynomial_OperatorMinus_ValidData_Test(double[] arg1, double[] arg2)
        {
            var polinomial1 = new Polynomial(arg1);
            var polinomial2 = new Polynomial(arg2);

            return (polinomial1 - polinomial2).ToString();
        }

        /// <summary>
        /// Test for class Polynomial
        /// </summary>
        /// <param name="arg1">Array polynomial1</param>
        /// <param name="arg2">Array polynomial2</param>
        /// <returns>Polynomial string</returns>
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 1, 2, 4, -2, -3 }, ExpectedResult = "-21*x^4-8*x^3+6*x")]
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 2, -3, 0, 1, -5 }, ExpectedResult = "-35*x^4+4*x^3-9*x")]
        public string Polynomial_OperatorMultiply_ValidData_Test(double[] arg1, double[] arg2)
        {
            var polinomial1 = new Polynomial(arg1);
            var polinomial2 = new Polynomial(arg2);

            return (polinomial1 * polinomial2).ToString();
        }

        /// <summary>
        /// Test for class Polynomial
        /// </summary>
        /// <param name="arg1">Array polynomial1</param>
        /// <param name="arg2">Array polynomial2</param>
        /// <returns>Polynomial string</returns>
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 0, 3, 0, 4, 7 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 2, -3, 0, 1, -5 }, ExpectedResult = false)]
        public bool Polynomial_OperatorEquality_ValidData_Test(double[] arg1, double[] arg2)
        {
            var polinomial1 = new Polynomial(arg1);
            var polinomial2 = new Polynomial(arg2);

            return polinomial2 == polinomial1;
        }

        /// <summary>
        /// Test for class Polynomial
        /// </summary>
        /// <param name="arg1">Array polynomial1</param>
        /// <param name="arg2">Array polynomial2</param>
        /// <returns>Polynomial string</returns>
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 0, 3, 0, 4, 7 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 3, 0, 4, 7 }, new double[] { 2, -3, 0, 1, -5 }, ExpectedResult = true)]
        public bool Polynomial_OperatorotEquality_ValidData_Test(double[] arg1, double[] arg2)
        {
            var polinomial1 = new Polynomial(arg1);
            var polinomial2 = new Polynomial(arg2);

            return polinomial2 != polinomial1;
        }
    }
}