namespace BinarySearch
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides algorithm of binary search 
    /// </summary>
    /// <typeparam name="T">Type of elements in array</typeparam>
    public static class BinarySearch<T>
    {
        private const int NotFound = -1;

        /// <summary>
        /// Find element in given array <paramref name="array"/>
        /// </summary>
        /// <param name="element">Element that should be found</param>
        /// <param name="array">Array of elements</param>
        /// <param name="comparer">Object implements compare function</param>
        /// <returns><value>-1 - if element wasn't found</value>
        /// <value>index of found elemnt in given array</value></returns>
        public static int Search(T element, T[] array, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"Array {nameof(array)} length = 0");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            var startIndex = 0;
            var endIndex = array.Length - 1;
            var centerIndex = endIndex / 2;

            while (startIndex <= endIndex)
            {
                var compareResult = comparer.Compare(array[centerIndex], element);

                if (compareResult == 0)
                {
                    return centerIndex;
                }

                if (compareResult > 0)
                {
                    endIndex = centerIndex - 1;
                }
                else
                {
                    startIndex = centerIndex + 1;
                }

                centerIndex = startIndex + ((endIndex - startIndex) / 2);
            }

            return NotFound;
        }
    }
} 
