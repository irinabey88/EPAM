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
                ArraySortDelegate.BubleSort(BubleSortFunction, arr1, new SumElementComparer(false)),
                resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_SumAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 5, -2, -4, -3 }, new[] { 1, -2, 7, -4 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(BubleSortFunction, arr1, new SumElementComparer(true)), resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MinDescending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(BubleSortFunction, arr1, new MinElementComparer(false)),
                resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MinAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(BubleSortFunction, arr1, new MinElementComparer(true)), resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MaxDescending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(
                ArraySortDelegate.BubleSort(BubleSortFunction, arr1, new MaxElementComparer(false)),
                resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MaxAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 } };

            CollectionAssert.AreEqual(resultArr1, ArraySortDelegate.BubleSort(BubleSortFunction, arr1, new MaxElementComparer(true)));
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array</param>
        [TestCase(null)]
        public void ArraySort_InvalidData_Test(int[][] arg1)
        {
            Assert.Throws<ArgumentNullException>(() => ArraySortDelegate.BubleSort(BubleSortFunction, arg1, new SumElementComparer(false)));
        }



        /// <summary>
        /// Provides buble sort for <paramref name="jaggedArray"/> in 
        /// ascending/descending order bu given 
        /// </summary>
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="comparator">Comparator values</param>
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentNullException">Invalid input array</exception>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        private static int[][] BubleSortFunction(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
            {
                throw new ArgumentException(nameof(jaggedArray));
            }

            foreach (var inputArrays in jaggedArray)
            {
                if (inputArrays == null || inputArrays.Length == 0)
                {
                    throw new ArgumentException(nameof(inputArrays));
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = jaggedArray.Length - 1; j > i; j--)
                {
                    if (comparator.Compare(jaggedArray[j - 1], jaggedArray[j]) > 0)
                    {
                        var buf = jaggedArray[j - 1];
                        jaggedArray[j - 1] = jaggedArray[j];
                        jaggedArray[j] = buf;
                    }
                }
            }

            return jaggedArray;
        }
    }
}
