// <copyright file="CommonDivisor.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._03
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Provides methods to get the greatest common divisor
    /// </summary>
    public static class CommonDivisor
    {
        /// <summary>
        /// Calculate run time
        /// </summary>
        /// <param name="numbersArray">Array of numbers</param>
        /// <returns>Time in miliseconds</returns>
        public static double GetRunTimeGcdEvklid(params int[] numbersArray)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Func<int, int, int> extractMethod = GetGcdEvklid;
            FindGcd(extractMethod, numbersArray);

            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Calculate run time
        /// </summary>
        /// <param name="numbersArray">Array of numbers</param>
        /// <returns>Time in miliseconds</returns>
        public static double GetRunTimeGcdBinary(params int[] numbersArray)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Func<int, int, int> extractMethod = GetGcdBinary;
            FindGcd(extractMethod, numbersArray);

            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Find the greatest common divisor from numbers in array
        /// by the given algorithm
        /// </summary>
        /// <param name="numbersArray">Array of numbers</param>
        /// <param name="algorithm">Method of finding the greatest common divisor</param>
        /// <returns>Greatest common divisor</returns>
        /// <exception cref="ArgumentNullException">Null array value</exception>
        /// <exception cref="ArgumentException">Indvalid array length</exception>
        public static int FindGcd( Func<int, int, int> algorithm, params int[] numbersArray)
        {
            if (numbersArray == null)
            {
                throw new  ArgumentNullException(nameof(numbersArray));
            }

            if ( numbersArray.Length < 2)
            {
                throw new ArgumentException($"Invalid length {nameof(numbersArray)}. Array length should be more than 1 element!");
            }

            if (algorithm == null)
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            int greatestDivisor = algorithm(numbersArray[0], numbersArray[1]);

            for (int i = 2; i < numbersArray.Length; i++)
            {
                greatestDivisor = algorithm(greatestDivisor, numbersArray[i]);
            }

            return greatestDivisor;
        }

        /// <summary>
        /// Get the greatest common divisor from 2 numbers 
        /// by euclidean algorithm
        /// </summary>
        /// <param name="a">Number a</param>
        /// <param name="b">Number b</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGcdEvklid(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b)
            {
                return a;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        /// <summary>
        /// Get the greatest common divisor from 2 numbers 
        /// by binary algorithm
        /// </summary>
        /// <param name="a">Number a</param>
        /// <param name="b">Number b</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGcdBinary(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b)
            {
                return a;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return GetGcdBinary(a >> 1, b);
                }

                return GetGcdBinary(a >> 1, b >> 1) << 1;
            }

            if ((~b & 1) != 0)
            {
                return GetGcdBinary(a, b >> 1);
            }

            if (a > b)
            {
                return GetGcdBinary((a - b) >> 1, b);
            }

            return GetGcdBinary((b - a) >> 1, a);
        }
    }
}
