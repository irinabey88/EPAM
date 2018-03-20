using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2018.Bey._02.MsUnit.Tests
{
    [TestClass]
    public class MathOperationsMsUnitTests
    {
        private int[] inputArr1 = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
        private int[] resultArr1 = { 7, 70, 17 };

        [TestMethod]
        public void MathOperations_FilterDigit_ValidData_Test()
        {
            CollectionAssert.AreEqual(MathOperations.FilterDigit(inputArr1, 7), resultArr1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MathOperations_FilterDigit_InvalidData_Test()
        {
            MathOperations.FilterDigit(inputArr1, 45);
        }

        [TestMethod]
        public void MathOperations_FindNextBigNumber_ValidData_Test()
        {
            Assert.AreEqual(MathOperations.FindNextBigNumber(12), 21);
            Assert.AreEqual(MathOperations.FindNextBigNumber(513), 531);
            Assert.AreEqual(MathOperations.FindNextBigNumber(2017), 2071);
            Assert.AreEqual(MathOperations.FindNextBigNumber(414), 441);
            Assert.AreEqual(MathOperations.FindNextBigNumber(144), 414);
            Assert.AreEqual(MathOperations.FindNextBigNumber(1234321), 1241233);
            Assert.AreEqual(MathOperations.FindNextBigNumber(1234126), 1234162);
            Assert.AreEqual(MathOperations.FindNextBigNumber(3456432), 3462345);
            Assert.AreEqual(MathOperations.FindNextBigNumber(10), -1);
            Assert.AreEqual(MathOperations.FindNextBigNumber(20), -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MathOperations_FindNextBigNumber_InvalidData_Test()
        {
            MathOperations.FindNextBigNumber(-90);
        }

        [TestMethod]
        public void MathOperations_InsertNumber_ValidData_Test()
        {
            Assert.AreEqual(MathOperations.InsertNumber(8, 15, 3, 8), 120);
            Assert.AreEqual(MathOperations.InsertNumber(8, 15, 0, 0), 9);
            Assert.AreEqual(MathOperations.InsertNumber(15, 15, 0, 0), 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MathOperations_InsertNumber_InvalidData_Test()
        {
            MathOperations.InsertNumber(8, 15, 8, 3);
        }

        [TestMethod]
        public void FindNthRootTest()
        {
            Assert.AreEqual(MathOperations.FindNthRoot(1, 5, 0.0001), 1);
            Assert.AreEqual(MathOperations.FindNthRoot(8, 3, 0.0001), 2);
            Assert.AreEqual(MathOperations.FindNthRoot(0.001, 3, 0.0001), 0.1);
            Assert.AreEqual(MathOperations.FindNthRoot(0.04100625, 4, 0.0001), 0.45);
            Assert.AreEqual(MathOperations.FindNthRoot(8, 3, 0.0001), 2);
            Assert.AreEqual(MathOperations.FindNthRoot(0.0279936, 7, 0.0001), 0.6);
            Assert.AreEqual(MathOperations.FindNthRoot(0.0081, 4, 0.1), 0.4);
            Assert.AreEqual(MathOperations.FindNthRoot(-0.008, 3, 0.1), -0.2);
            Assert.AreEqual(MathOperations.FindNthRoot(0.004241979, 9, 0.00000001), 0.545);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidInputDataTest()
        {
            MathOperations.FindNthRoot(0.004241979, 9, -0.01);
        }
    }
}
