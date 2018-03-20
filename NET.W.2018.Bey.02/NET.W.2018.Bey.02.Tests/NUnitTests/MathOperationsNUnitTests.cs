using System;
using NET.W._2018.Bey._02;
using NUnit.Framework;

namespace NET.W._2018.Bey._02.NUnit.Tests
{
    [TestFixture]
    public class MathOperationsNunitTest
    {

        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new[] { 7, 70, 17 })]
        public int[] MathOperations_FilterDigit_ValidData_Test(int[] arg1)
        {
            return MathOperations.FilterDigit(arg1, 7);

        }

        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 })]
        public void MathOperations_FilterDigit_InvalidData_Test(int[] arg1)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathOperations.FilterDigit(arg1, 78));
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(110, ExpectedResult = -1)]
        public long MathOperations_FindNextBigNumber_ValidData_Test(long arg1)
        {
            return MathOperations.FindNextBigNumber(arg1);

        }

        [TestCase(-567)]
        public void MathOperations_FindNextBigNumber_InvalidData_Test(int arg1)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathOperations.FindNextBigNumber(arg1));
        }

        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        public long MathOperations_InsertNumber_ValidData_Test(long arg1, long arg2, int arg3, int arg4)
        {
            return MathOperations.InsertNumber(arg1, arg2, arg3, arg4);
        }

        [Test]
        public void MathOperations_InsertNumber_InValidData_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathOperations.InsertNumber(8, 15, 8, 3));
        }

        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.4)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double MathOperations_InsertNumber_FindNthRoot_ValidData_Test(double arg1, int arg2, double arg3)
        {
            return MathOperations.FindNthRoot(arg1, arg2, arg3);
        }

        [TestCase(8, 15, -5)]
        [TestCase(8, 15, -0.1)]
        public void MathOperations_InsertNumber_FindNthRoot_InvalidData_Test(double arg1, int arg2, double arg3)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathOperations.FindNthRoot(arg1, arg2, arg3));
        }

        [TestCase(12)]
        [TestCase(513)]
        [TestCase(2017)]
        [TestCase(414)]
        [TestCase(144)]
        [TestCase(1234321)]
        [TestCase(1234126)]
        [TestCase(3456432)]
        [TestCase(10)]
        [TestCase(20)]
        public void MathOperations_FindNextBigNumber_CalcTimeStopWatch_Test(long arg1)
        {
            Assert.Greater(MathOperations.CalculateTimeStopWatch(arg1), 0);
        }

        [TestCase(12)]
        [TestCase(513)]
        [TestCase(2017)]
        [TestCase(414)]
        [TestCase(144)]
        [TestCase(1234321)]
        [TestCase(1234126)]
        [TestCase(3456432)]
        [TestCase(10)]
        [TestCase(20)]
        public void MathOperations_FindNextBigNumber_CalcDateTime_Test(long arg1)
        {
            Assert.GreaterOrEqual(MathOperations.CalculateTimeDateTime(arg1), 0);
        }
    }
}
