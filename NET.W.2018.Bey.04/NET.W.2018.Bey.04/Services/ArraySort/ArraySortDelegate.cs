namespace NET.W._2018.Bey._04.Services
{
    using System;
    using System.Collections.Generic;

    public class ArraySortDelegate
    {
        #region Public methods    

        /// <summary>
        /// Provides buble sort for <paramref name="jaggedArray"/> in 
        /// ascending/descending order bu given 
        /// </summary>
        /// <param name="algoritm">Function for sorting array</param>
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="comparator">Comparator values</param>                
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentNullException">Invalid input array</exception>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static int[][] BubleSort(Func<int[][], IComparer<int[]>, int[][]> algoritm, int[][] jaggedArray, IComparer<int[]> comparator)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            foreach (var inputArrays in jaggedArray)
            {
                if (inputArrays == null || inputArrays.Length == 0)
                {
                    throw new ArgumentException(nameof(inputArrays));
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