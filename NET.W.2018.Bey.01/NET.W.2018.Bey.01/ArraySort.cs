using System;

namespace NET.W._2018.Bey._01
{
    public static class ArraySort
    {
        /// <summary>
        /// Merge sort
        /// </summary>
        /// <param name="inputArray">Input array</param>
        /// <returns>Sorted array</returns>
        /// <exception cref="ArgumentException">Invalid input parameters</exception>
        public static int[] MergeSort(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
                throw new ArgumentException($"{nameof(inputArray)}");

            //Array consists of 1 element
            if (inputArray.Length == 1)
            {
                return inputArray;
            }

            var leftArray = new int[inputArray.Length / 2];

            //if input array has unpaired number of elements
            var rightArray = new int[inputArray.Length - leftArray.Length];

            Array.Copy(inputArray, 0, leftArray, 0, leftArray.Length);
            Array.Copy(inputArray, leftArray.Length, rightArray, 0, rightArray.Length);

            if (leftArray.Length > 1)
                leftArray = MergeSort(leftArray);

            if (rightArray.Length > 1)
                rightArray = MergeSort(rightArray);

            //merging arrays
            inputArray = MergeSortArrays(leftArray, rightArray);
            return inputArray;
        }

        /// <summary>
        /// Quick sort
        /// </summary>
        /// <param name="inputArray">Input array</param>
        /// <param name="startIndex">Start index </param>
        /// <param name="endIndex">End index</param>
        /// <returns>Sorted array</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int[] QuickSort(int[] inputArray, int startIndex, int endIndex)
        {
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(inputArray)}");
            }

            if ( startIndex < 0 || endIndex < 0)
                throw new ArgumentOutOfRangeException($"{nameof(startIndex)} or {nameof(endIndex)}");

            int leftIndex = startIndex;
            int righEndIndex = endIndex;
            //checked element - with it compaere others elements
            int x = inputArray[(startIndex + endIndex) / 2];

            while (leftIndex <= righEndIndex)
            {
                //compare with checked element
                while (inputArray[leftIndex] < x) leftIndex++;
                while (inputArray[righEndIndex] > x) righEndIndex--;

                if (leftIndex <= righEndIndex)
                {
                    int buff = inputArray[leftIndex];
                    inputArray[leftIndex] = inputArray[righEndIndex];
                    inputArray[righEndIndex] = buff;
                    leftIndex++;
                    righEndIndex--;
                }
            }

            if (startIndex < righEndIndex) QuickSort(inputArray, startIndex, righEndIndex);
            if (leftIndex < endIndex) QuickSort(inputArray, leftIndex, endIndex);

            return inputArray;
        }



        /// <summary>
        /// Merge 2 sorted arrays 
        /// </summary>
        /// <param name="leftArray">Array for merge</param>
        /// <param name="rightArray">Array for merge</param>
        /// <returns>Sorted merged array</returns>
        /// <exception cref="ArgumentOutOfRangeException">Invalid input parameters</exception>
        static int[] MergeSortArrays(int[] leftArray, int[] rightArray)
        {
            if (leftArray == null || leftArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(leftArray));
            }
            if(rightArray == null || rightArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rightArray));
            }

            var resultArray = new int[leftArray.Length + rightArray.Length];

            var leftIndex = 0;
            var rightIndex = 0;

            for (int i = 0; i < resultArray.Length; i++)
            {
                //if there is no elements in the rigth side
                if (rightIndex >= rightArray.Length)
                {
                    resultArray[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                //if there is no elements in the left side
                else if (leftIndex >= leftArray.Length)
                {
                    resultArray[i] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    resultArray[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    resultArray[i] = rightArray[rightIndex];
                    rightIndex++;
                }
            }

            return resultArray;
        }
    }
}