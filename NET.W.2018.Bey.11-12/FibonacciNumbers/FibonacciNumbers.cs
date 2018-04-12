namespace FibonacciList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class provides fibonacci numbers list
    /// </summary>
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Generate fibonacci list
        /// </summary>
        /// <param name="count">Count of numbers in list</param>
        /// <returns>Fibonacci list</returns>
        public static IEnumerable<ulong> Generate(ulong count)
        {
            if (count < 1)
            {
                throw new ArgumentException($"Count numbers shoul be greater than 0!");
            }

            yield return 0;
            yield return 1;

            ulong previous = 0;
            ulong next = 1;

            for (ulong i = 0; i < count - 2; i++)
            {
                ulong sum = previous + next;
                previous = next;
                next = sum;

                yield return sum;
            }
        }
    }
}
