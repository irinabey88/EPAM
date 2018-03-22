// <copyright file="BinaryViewTests.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._03.Tests.NUnitTests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides tests for <permission cref="BinaryView"></permission>
    /// </summary>
    [TestFixture]
    public class BinaryViewTests
    {
        /// <summary>
        /// Tests for methods GetBinaryView of class <permission cref="BinaryView"/>
        /// </summary>
        /// <param name="arg1">Input number</param>
        /// <returns>Binary view</returns>
        [TestCase(-0.255, ExpectedResult = "111111111110100000101000111101011100001010001111010111000010100")]
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string BinaryView_GetBinaryView_Test(double arg1)
        {
            return arg1.GetBinaryView();
        }
    }
}
