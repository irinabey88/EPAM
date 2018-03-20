using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2018.Bey._01.Tests
{
    [TestClass]
    public class ArraySortTest
    {
        private int[] _testArr1 = { 255, 457, 34564, 1442, 4795, 4422, 10, 0, 1124, 3424 };
        private int[] _resultArr1 = { 0, 10, 255, 457, 1124, 1442, 3424, 4422, 4795, 34564 };
        private int[] _testArr2 = { 45, 1, 2, 67, 0, 0, 23, 75, 65, 34 };
        private int[] _resultArr2 = { 0, 0, 1, 2, 23, 34, 45, 65, 67, 75 };

        [TestMethod]
        public void MergeSort_ValidInputData_Test()
        {
            var result1 = ArraySort.MergeSort(_testArr1);
            CollectionAssert.AreEqual(_resultArr1, result1);

            var result2 = ArraySort.MergeSort(_testArr2);
            CollectionAssert.AreEqual(_resultArr2, result2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_InvalidInputData_Test()
        {
            var result1 = ArraySort.MergeSort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuickSort_InvalidInputData_Test()
        {
            var result1 = ArraySort.QuickSort(_testArr1, -6, _testArr1.Length - 1);
        }

        [TestMethod]
        public void QuickSort_ValidInputData_Test()
        {
            var result1 = ArraySort.QuickSort(_testArr1, 0, _testArr1.Length - 1);
            CollectionAssert.AreEqual(_resultArr1, result1);

            var result2 = ArraySort.QuickSort(_testArr2, 0, _testArr2.Length - 1);
            CollectionAssert.AreEqual(_resultArr2, result2);
        }
    }
}
