// <copyright file="ArraySort.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>

namespace ArraySort
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represent jagged jaggedArray sort by diffrent mark
    /// </summary>
    public static class ArraySortInterface
    {
        #region Public methods

        /// <summary>
        /// Provides buble sort for <paramref name="jaggedArray"/> 
        /// </summary>
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="comparator">object compareres 2 int[] arrays</param>                
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentNullException">Invalid input array</exception>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static int[][] BubleSort(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            if (jaggedArray.Length == 0)
            {
                throw new ArgumentException(nameof(jaggedArray));
            }

            foreach (var inputArrays in jaggedArray)
            {
                if (inputArrays == null)
                {
                    throw new ArgumentNullException($"{nameof(inputArrays)}");
                }

                if (inputArrays.Length == 0)
                {
                    throw new ArgumentException($"{nameof(inputArrays)}");
                }
            }

            var arrayLength = jaggedArray.GetLength(0);

            for (int j = arrayLength; j > 0; j--)
            {
                for (int i = 0; i < arrayLength - 1; i++)
                {
                    if (comparator.Compare(jaggedArray[i], jaggedArray[i + 1]) > 0)
                    {
                        Swap(ref jaggedArray[i], ref jaggedArray[i + 1]);
                    }
                }
            }

            return jaggedArray;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Change line-arrays in jagged array
        /// </summary>
        /// <param name="lhs">Left array</param>
        /// <param name="rhs">Right array</param>
        /// <exception cref="ArgumentNullException">Null value argument</exception>
        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            if (lhs == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs == null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            var temp = lhs;          

            lhs = rhs;

            rhs = temp;
        }
        #endregion
    }
}