namespace FibonacciNumbersTests.NUnitTests
{
    using System;
    using System.Collections.Generic;
    using FibonacciList;
    using NUnit.Framework;

    [TestFixture]
    public class FibonacciNumbersTests
    {
        [TestCase((ulong)6, ExpectedResult = new ulong[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase((ulong)2, ExpectedResult = new ulong[] { 0, 1 })]
        [TestCase((ulong)10, ExpectedResult = new ulong[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
        public IEnumerable<ulong> FibonacciNumbers_Generate_ValidData_Test(ulong count)
        {
            List<ulong> fibonucciList = new List<ulong>();

            foreach (var number in FibonacciNumbers.Generate(count))
            {
                fibonucciList.Add(number);
            }

            return fibonucciList;
        }

        [TestCase((ulong)0)]
        public void FibonacciNumbers_Generate_InvalidData_Test(ulong count)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                foreach (var number in FibonacciNumbers.Generate(count))
                {                    
                }
            });
        }
    }
}
