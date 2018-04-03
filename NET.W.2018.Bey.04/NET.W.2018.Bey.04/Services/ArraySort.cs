// <copyright file="ArraySort.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>

using System.Collections.Generic;
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
        /// ascending/descending order bu given 
        /// </summary>
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="comparator">Comparator values</param>
        /// <param name="ascending"><value>true - ascending order</value>
        /// <value>false - descending order</value></param>
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static int[][] BubleSort(this int[][] jaggedArray, IComparer<int[]> comparator, bool ascending = true)
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
                    if (ascending)
                    {
                        if (comparator.Compare(jaggedArray[j - 1], jaggedArray[j]) > 0)
                        {
                            var buf = jaggedArray[j - 1];
                            jaggedArray[j - 1] = jaggedArray[j];
                            jaggedArray[j] = buf;
                        }

                        continue;
                    }

                    if (comparator.Compare(jaggedArray[j - 1], jaggedArray[j]) < 0)
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
    }
}