// <copyright file="ArraySortTests.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._04.Tests.NUnitTests
{
    using NET.W._2018.Bey._04.Services;
    using NUnit.Framework;

    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 2,-3,0,1,-5 }, 3.0, ExpectedResult = -385.0)]
        [TestCase(new double[] { 2, -3, 0, 1, -5 }, -3.0, ExpectedResult = -421.0)]
        public double Polynomial_Calc_ValidData_Test(double[] arg1, double arg2)
        {
            var polinomial = new Polynomial(arg1);
            
            return polinomial.Calculate(arg2);
        }
    }
}