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
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="comparer"></param>
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentNullException">Invalid input array</exception>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static int[][] BubleSort(int[][] jaggedArray, Func<int[], int[], int> comparer)
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

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            var arrayLength = jaggedArray.GetLength(0);

            for (int j = arrayLength; j > 0; j--)
            {
                for (int i = 0; i < arrayLength - 1; i++)
                {
                    if (comparer(jaggedArray[i], jaggedArray[i + 1]) > 0)
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
        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            if (lhs == null)
            {
                new ArgumentNullException(nameof(lhs));
            }

            if (rhs == null)
            {
                new ArgumentNullException(nameof(rhs));
            }

            var temp = lhs;

            lhs = rhs;

            rhs = temp;
        }
        #endregion
    }
}