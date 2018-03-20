using System;
using System.Diagnostics;

namespace NET.W._2018.Bey._03
{
    public static class CommonDivisor
    {
        /// <summary>
        /// Find the greatest common divisor from numbers in array
        /// by euclidean algorithm
        /// </summary>
        /// <param name="numbersArray">Array of numbers</param>
        /// <returns>Greatest common divisor</returns>
        public static int FindGcdEvklid(int[] numbersArray)
        {
            Func<int, int, int> extractMethod = GetGcdEvklid;

            return FindGcd(numbersArray, extractMethod);
        }

        /// <summary>
        /// Find the greatest common divisor from numbers in array
        /// by binary algorithm
        /// </summary>
        /// <param name="numbersArray">Array of numbers</param>
        /// <returns>Greatest common divisor</returns>
        public static int FindGcdBinary(int[] numbersArray)
        {
            Func<int, int, int> extractMethod = GetGcdBinary;

            return FindGcd(numbersArray, extractMethod);
        }

        /// <summary>
        /// Calculate run time
        /// </summary>
        /// <param name="numbersArray">Array of numbers</param>
        /// <returns>Time in miliseconds</returns>
        public static double GetRunTimeGcdEvklid(int[] numbersArray)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            FindGcdEvklid(numbersArray);

            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Calculate run time
        /// </summary>
        /// <param name="numbersArray">Array of numbers</param>
        /// <returns>Time in miliseconds</returns>
        public static double GetRunTimeGcdBinary(int[] numbersArray)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            FindGcdBinary(numbersArray);

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
        /// <exception cref="ArgumentException"></exception>
        static int FindGcd(int[] numbersArray, Func<int, int, int> algorithm)
        {
            if (numbersArray == null || numbersArray.Length < 2)
            {
                throw new ArgumentException($"{nameof(numbersArray)}");
            }

            if (algorithm == null)
            {
                throw new ArgumentException($"{nameof(algorithm)}");
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
        /// <param name="a">Number</param>
        /// <param name="b">Number</param>
        /// <returns>Greatest common divisor</returns>
        static int GetGcdEvklid(int a, int b)
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
        /// <param name="a">Number</param>
        /// <param name="b">Number</param>
        /// <returns>Greatest common divisor</returns>
        static int GetGcdBinary(int a, int b)
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
