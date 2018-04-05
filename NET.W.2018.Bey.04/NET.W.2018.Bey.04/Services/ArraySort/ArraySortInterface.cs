// <copyright file="ArraySort.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._04.Services
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
        /// <param name="comparator">Comparator values</param>                
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentNullException">Invalid input array</exception>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static int[][] BubleSort(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            foreach (var inputArrays in jaggedArray)
            {
                if (inputArrays == null || inputArrays.Length == 0)
                {
                    throw new ArgumentException($"{nameof(inputArrays)}");
                }
            }

            Func<int[][], IComparer<int[]>, int[][]> algoritm = (array, compar) =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = array.Length - 1; j > i; j--)
                    {
                        if (compar.Compare(array[j - 1], array[j]) > 0)
                        {
                            var buf = array[j - 1];
                            array[j - 1] = array[j];
                            array[j] = buf;
                        }
                    }
                }

                return array;
            };

            return BubleSort(algoritm, jaggedArray, comparator);
        }

        #endregion

        #region Private methods

        private static int[][] BubleSort(Func<int[][], IComparer<int[]>, int[][]> algoritm, int[][] jaggedArray, IComparer<int[]> comparator
            )
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

            if (algoritm == null)
            {
                throw new ArgumentException(nameof(algoritm));
            }

            return algoritm(jaggedArray, comparator);
        }

        #endregion
    }
}