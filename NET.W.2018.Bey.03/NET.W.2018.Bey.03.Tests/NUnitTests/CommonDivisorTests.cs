// <copyright file="CommonDivisorTests.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._03.Tests.NUnitTests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Provides tests for class <permission cref="CommonDivisor"/>
    /// </summary>
    [TestFixture]
    public class CommonDivisorTests
    {
        /// <summary>
        /// Test for method FindGcdEvklid
        /// </summary>
        /// <param name="arg1">Input Array</param>
        /// <returns>The greatest common divisor</returns>
        [TestCase(new[] { 20, 160, -80, 0, 200, -460 }, ExpectedResult = 20)]
        [TestCase(new[] { 30, 600, -6, 0, 48, 72 }, ExpectedResult = 6)]
        [TestCase(new[] { 7, 156, -80, 75, 200, -13 }, ExpectedResult = 1)]
        [TestCase(new[] { 2, 8, -6, -150, 78, -4 }, ExpectedResult = 2)]
        public int CommonDivisor_FindGcdByEvklig_ValidData_Test(int[] arg1)
        {
            return CommonDivisor.FindGcdEvklid(arg1);
        }

        /// <summary>
        /// Test for method FindGcdBinary
        /// </summary>
        /// <param name="arg1">Input Array</param>
        /// <returns>The greatest common divisor</returns>
        [TestCase(new[] { 20, 160, -80, 0, 200, -460 }, ExpectedResult = 20)]
        [TestCase(new[] { 30, 600, -6, 0, 48, 72 }, ExpectedResult = 6)]
        [TestCase(new[] { 7, 156, -80, 75, 200, -13 }, ExpectedResult = 1)]
        [TestCase(new[] { 2, 8, -6, -150, 78, -4 }, ExpectedResult = 2)]
        public int CommonDivisor_FindGcdByBinary_ValidData_Test(int[] arg1)
        {
            return CommonDivisor.FindGcdBinary(arg1);
        }

        /// <summary>
        /// Test for method FindGcdEvklid
        /// </summary>
        /// <param name="arg1">Input Array</param>
        [TestCase(new[] { 2 })]
        [TestCase(new int[] { })]
        public void CommonDivisor_FindGcdByEvklig_InvalidData_Test(int[] arg1)
        {
            Assert.Throws<ArgumentException>(() => CommonDivisor.FindGcdEvklid(arg1));
        }

        /// <summary>
        /// Test for method GetRunTimeGcdEvklid
        /// </summary>
        /// <param name="arg1">Input Array</param>
        [TestCase(new[] { 20, 160, -80, 0, 200, -460 })]
        [TestCase(new[] { 30, 600, -6, 0, 48, 72 })]
        [TestCase(new[] { 7, 156, -80, 75, 200, -13 })]
        [TestCase(new[] { 2, 8, -6, -150, 78, -4 })]
        public void CommonDivisor_FindGcdByEvklid_CalculateRunTime_ValidData_Test(int[] arg1)
        {
            Assert.Greater(CommonDivisor.GetRunTimeGcdEvklid(arg1), 0);
        }

        /// <summary>
        /// Test for method GetRunTimeGcdEvklid
        /// </summary>
        /// <param name="arg1">Input Array</param>
        [TestCase(new[] { 2 })]
        [TestCase(new int[] { })]
        public void CommonDivisor_FindGcdByEvklid_InvalidData_Test(int[] arg1)
        {
            Assert.Throws<ArgumentException>(() => CommonDivisor.GetRunTimeGcdEvklid(arg1));
        }

        /// <summary>
        /// Test for method GetRunTimeGcdBinary
        /// </summary>
        /// <param name="arg1">Input Array</param>
        [TestCase(new[] { 20, 160, -80, 0, 200, -460 })]
        [TestCase(new[] { 30, 600, -6, 0, 48, 72 })]
        [TestCase(new[] { 7, 156, -80, 75, 200, -13 })]
        [TestCase(new[] { 2, 8, -6, -150, 78, -4 })]
        public void CommonDivisor_FindGcdByBinary_CalculateRunTime_ValidData_Test(int[] arg1)
        {
            Assert.Greater(CommonDivisor.GetRunTimeGcdBinary(arg1), 0);
        }

        /// <summary>
        /// Test for method GetRunTimeGcdBinary
        /// </summary>
        /// <param name="arg1">Input Array</param>
        [TestCase(new[] { 2 })]
        [TestCase(new int[] { })]
        public void CommonDivisor_FindGcdByBinary_CalculateRunTime_InvalidData_Test(int[] arg1)
        {
            Assert.Throws<ArgumentException>(() => CommonDivisor.GetRunTimeGcdBinary(arg1));
        }
    }
}
