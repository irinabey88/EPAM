// <copyright file="ArraySort.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>

using System.Linq;
using NET.W._2018.Bey._04.Enum;

namespace NET.W._2018.Bey._04.Services
{
    using System;

    /// <summary>
    /// Represent jagged jaggedArray sort by diffrent mark
    /// </summary>
    public static class ArraySort
    {
        #region Public methods

        /// <summary>
        /// Provides buble sort for <paramref name="jaggedArray"/> in 
        /// ascending/descending order bu given <paramref name="sortFunction"/> for inner arrays
        /// </summary>
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="sortFunction">Function for inner arrays</param>
        /// <param name="ascending"><value>true - ascending order</value>
        /// <value>false - descending order</value></param>
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static double[][] BubleSort (this double[][] jaggedArray, SortFunction sortFunction, bool ascending = true)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(jaggedArray)}");
            }

            foreach (var inputArrays in jaggedArray)
            {
                if (inputArrays == null || inputArrays.Length == 0)
                {
                    throw new ArgumentException($"{nameof(inputArrays)}");
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = jaggedArray.Length - 1; j > i; j--)
                {
                    double valueJ;
                    double valueJm1;

                    (valueJ, valueJm1) = CalculateSortedValue(jaggedArray[j], jaggedArray[j - 1], sortFunction);
                   
                    if (ascending)
                    {
                        if (valueJm1 > valueJ)
                        {
                            var buf = jaggedArray[j - 1];
                            jaggedArray[j - 1] = jaggedArray[j];
                            jaggedArray[j] = buf;
                        }

                        continue;
                    }

                    ////descending order
                    if (valueJm1 < valueJ)
                    {
                        var buf = jaggedArray[j - 1];
                        jaggedArray[j - 1] = jaggedArray[j];
                        jaggedArray[j] = buf;
                    }
                }
            }

            return jaggedArray;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets value for sorting by function
        /// </summary>
        /// <param name="inputArrayJ">First value</param>
        /// <param name="inputArrayJm1">Second value</param>
        /// <param name="sortFunction">Sorted function</param>
        /// <returns>Two values fo sorting</returns>
        private static (double,  double) CalculateSortedValue(double[] inputArrayJ, double[] inputArrayJm1, SortFunction sortFunction)
        {
            if (inputArrayJ == null || inputArrayJ.Length == 0)
            {
                throw new ArgumentException($"{nameof(inputArrayJ)}");
            }

            if (inputArrayJm1 == null || inputArrayJm1.Length == 0)
            {
                throw new ArgumentException($"{nameof(inputArrayJm1)}");
            }

            double valueJ;
            double valueJm1;

            switch (sortFunction)
            {
                case SortFunction.Sum:
                    valueJ = inputArrayJ.Sum();
                    valueJm1 = inputArrayJm1.Sum();
                    break;
                case SortFunction.MaxValue:
                    valueJ = inputArrayJ.Max();
                    valueJm1 = inputArrayJm1.Max();
                    break;
                case SortFunction.MinValue:
                    valueJ = inputArrayJ.Min();
                    valueJm1 = inputArrayJm1.Min();
                    break;
                default:
                    throw new ArgumentException($"{nameof(sortFunction)}");
            }

            return (valueJ, valueJm1);
        }

        #endregion
    }
}