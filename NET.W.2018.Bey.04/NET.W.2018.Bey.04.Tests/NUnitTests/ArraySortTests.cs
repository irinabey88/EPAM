// <copyright file="ArraySortTests.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._04.Tests.NUnitTests
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Comparers;
    using NUnit.Framework;
    using Services;

    /// <summary>
    /// Provides test for class ArraySort
    /// </summary>
    [TestFixture]
    public class ArraySortTests
    {
        /// <summary>
        /// Separator for string represintation array
        /// </summary>
        private const string SeparatorArrays = "|";

        /// <summary>
        /// Separator for string represintation array
        /// </summary>
        private const string SeparatorElements = ";";         

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array in string</param>
        /// <returns>Jagged array in string</returns>
        [TestCase("1.0;-2.0;7.0;-4.0;|5.0;-2.0;-4.0;-3.0;|2.0;5.0;-3.0|", ExpectedResult = "2;5;-3;|1;-2;7;-4;|5;-2;-4;-3;|")]
        [TestCase("-8.0;-9.0;-7.0;-4.0;|0.0;-0.0;-4.0;-3.0;|8.0;-2.0;-1.0|", ExpectedResult = "8;-2;-1;|0;0;-4;-3;|-8;-9;-7;-4;|")]
        public string ArraySort_ValidData_SumDescending_Test(string arg1)
        {
            var array = ConvertStringToArray(arg1);
            var sortedArray = array.BubleSort(new SumElementComparer(), false);
            var strSortedArray = this.ConvertArrayToString(sortedArray);

            return strSortedArray;
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array in string</param>
        /// <returns>Jagged array in string</returns>
        [TestCase("1.0;-2.0;7.0;-4.0;|5.0;-2.0;-4.0;-3.0;|2.0;5.0;-3.0|", ExpectedResult = "5;-2;-4;-3;|1;-2;7;-4;|2;5;-3;|")]
        [TestCase("-8.0;-9.0;-7.0;-4.0;|0.0;-0.0;-4.0;-3.0;|8.0;-2.0;-1.0|", ExpectedResult = "-8;-9;-7;-4;|0;0;-4;-3;|8;-2;-1;|")]
        public string ArraySort_ValidData_SumAscending_Test(string arg1)
        {
            var array = ConvertStringToArray(arg1);
            var sortedArray = array.BubleSort(new SumElementComparer());
            var strSortedArray = this.ConvertArrayToString(sortedArray);

            return strSortedArray;
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array in string</param>
        /// <returns>Jagged array in string</returns>
        [TestCase("1.0;-2.0;7.0;-4.0;|5.0;-2.0;-4.0;-3.0;|2.0;5.0;-3.0|", ExpectedResult = "2;5;-3;|1;-2;7;-4;|5;-2;-4;-3;|")]
        [TestCase("-8.0;-9.0;-7.0;-4.0;|0.0;-0.0;-4.0;-3.0;|8.0;-2.0;-1.0|", ExpectedResult = "8;-2;-1;|0;0;-4;-3;|-8;-9;-7;-4;|")]
        public string ArraySort_ValidData_MinDescending_Test(string arg1)
        {
            var array = ConvertStringToArray(arg1);
            var sortedArray = array.BubleSort(new MinElementComparer(), false);
            var strSortedArray = this.ConvertArrayToString(sortedArray);

            return strSortedArray;
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array in string</param>
        /// <returns>Jagged array in string</returns>
        [TestCase("1.0;-2.0;7.0;-4.0;|5.0;-2.0;-4.0;-3.0;|2.0;5.0;-3.0|", ExpectedResult = "1;-2;7;-4;|5;-2;-4;-3;|2;5;-3;|")]
        [TestCase("-8.0;-9.0;-7.0;-4.0;|0.0;-0.0;-4.0;-3.0;|8.0;-2.0;-1.0|", ExpectedResult = "-8;-9;-7;-4;|0;0;-4;-3;|8;-2;-1;|")]
        public string ArraySort_ValidData_MinAscending_Test(string arg1)
        {
            var array = ConvertStringToArray(arg1);
            var sortedArray = array.BubleSort(new MinElementComparer());
            var strSortedArray = this.ConvertArrayToString(sortedArray);

            return strSortedArray;
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array in string</param>
        /// <returns>Jagged array in string</returns>
        [TestCase("1.0;-2.0;7.0;-4.0;|5.0;-2.0;-4.0;-3.0;|2.0;5.0;-3.0|", ExpectedResult = "1;-2;7;-4;|5;-2;-4;-3;|2;5;-3;|")]
        [TestCase("-8.0;-9.0;-7.0;-4.0;|0.0;-0.0;-4.0;-3.0;|8.0;-2.0;-1.0|", ExpectedResult = "8;-2;-1;|0;0;-4;-3;|-8;-9;-7;-4;|")]
        public string ArraySort_ValidData_MaxDescending_Test(string arg1)
        {
            var array = ConvertStringToArray(arg1);
            var sortedArray = array.BubleSort(new MaxElementComparer(), false);
            var strSortedArray = this.ConvertArrayToString(sortedArray);

            return strSortedArray;
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array in string</param>
        /// <returns>Jagged array in string</returns>
        [TestCase("1.0;-2.0;7.0;-4.0;|5.0;-2.0;-4.0;-3.0;|2.0;5.0;-3.0|", ExpectedResult = "5;-2;-4;-3;|2;5;-3;|1;-2;7;-4;|")]
        [TestCase("-8.0;-9.0;-7.0;-4.0;|0.0;-0.0;-4.0;-3.0;|8.0;-2.0;-1.0|", ExpectedResult = "-8;-9;-7;-4;|0;0;-4;-3;|8;-2;-1;|")]
        public string ArraySort_ValidData_MaxAscending_Test(string arg1)
        {
            var array = ConvertStringToArray(arg1);
            var sortedArray = array.BubleSort(new MaxElementComparer());
            var strSortedArray = this.ConvertArrayToString(sortedArray);

            return strSortedArray;
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array</param>
        [TestCase(null)]
        public void ArraySort_InvalidData_Test(double[][] arg1)
        {
            Assert.Throws<ArgumentException>(() => arg1.BubleSort(new SumElementComparer()));
        }

        #region Private methods

        /// <summary>
        /// Provides jagged array from string representation
        /// </summary>
        /// <param name="strArray">String representation array</param>
        /// <returns>Jagged array</returns>
        private static double[][] ConvertStringToArray(string strArray)
        {
            if (string.IsNullOrWhiteSpace(strArray))
            {
                throw new ArgumentNullException($"{nameof(strArray)}");
            }

            Regex regex = new Regex($@"([\d.]+;|)+");

            if (!regex.IsMatch(strArray))
            {
                throw new ArgumentException($"{nameof(strArray)} incorrect format oof string");
            }

            var arraysString = strArray.Split('|');
            double[][] jaggedArray = new double[arraysString.Length - 1][];
            var i = 0;

            foreach (var innerArrayStr in arraysString)
            {
                if (!string.IsNullOrWhiteSpace(innerArrayStr))
                {
                    var modifiedStr = innerArrayStr.Substring(0, innerArrayStr.Length - 1);
                    var elements = modifiedStr.Split(';');

                    var innerArray = Array.ConvertAll(elements, item => Convert.ToDouble(item, CultureInfo.InvariantCulture));

                    jaggedArray[i] = innerArray;
                    i++;
                }
            }

            return jaggedArray;
        }

        /// <summary>
        /// Provides a string representation of the array
        /// </summary>
        /// <returns>String representaion of array</returns>
        /// <param name="array">Input array</param>
        private string ConvertArrayToString(double[][] array)
        {
            var strArray = string.Empty;

            foreach (var innerArray in array)
            {
                foreach (var element in innerArray)
                {
                    if (string.IsNullOrWhiteSpace(strArray))
                    {
                        strArray = $"{element}{SeparatorElements}";
                    }
                    else
                    {
                        strArray = $"{strArray}{element}{SeparatorElements}";
                    }
                }

                strArray = $"{strArray}{SeparatorArrays}";
            }

            return strArray;
        }

        #endregion
    }
}
