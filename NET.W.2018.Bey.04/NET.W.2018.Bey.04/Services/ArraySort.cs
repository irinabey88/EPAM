// <copyright file="ArraySort.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._04.Services
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represent jagged jaggedArray sort by diffrent mark
    /// </summary>
    public static class ArraySort
    {
        #region Public methods

        /// <summary>
        /// Provides buble sort for <paramref name="jaggedArray"/> in 
        /// ascending/descending order bu given <paramref name="function"/> for inner arrays
        /// </summary>
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="function">Function for inner arrays</param>
        /// <param name="ascending"><value>true - ascending order</value>
        /// <value>false - descending order</value></param>
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static double[][] BubleSort(this double[][] jaggedArray, Func<double[], double> function, bool ascending = true)
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
                    var valueJ = function(jaggedArray[j]);
                    var valueJm1 = function(jaggedArray[j - 1]);
                    
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
    }
}