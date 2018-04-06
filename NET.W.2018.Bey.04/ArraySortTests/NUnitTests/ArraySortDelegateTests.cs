using System.Collections.Generic;

namespace NET.W._2018.Bey._04.Tests.NUnitTests.ArraySortTests
{
    using System;
    using Comparers;
    using NUnit.Framework;
    using Services;

    /// <summary>
    /// Provides test for class ArraySort
    /// </summary>
    [TestFixture]
    public class ArraySortDelegateTests
    {
        [Test]
        public void ArraySort_ValidData_SumDescending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(arr1, new SumElementComparer(false).Compare),
                resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_SumAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 5, -2, -4, -3 }, new[] { 1, -2, 7, -4 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(arr1, new SumElementComparer(true).Compare), resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MinDescending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(arr1, new MinElementComparer(false).Compare),
                resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MinAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(arr1, new MinElementComparer(true).Compare), resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MaxDescending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(arr1, new MaxElementComparer(false).Compare),
                resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MaxAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 } };

            CollectionAssert.AreEqual(resultArr1, ArraySortDelegate.BubleSort(arr1, new MaxElementComparer(true).Compare));
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array</param>
        [TestCase(null)]
        public void ArraySort_InvalidData_Test(int[][] arg1)
        {
            Assert.Throws<ArgumentNullException>(() => ArraySortDelegate.BubleSort(arg1, new SumElementComparer(false).Compare));
        }
    }
}
