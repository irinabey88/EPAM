namespace FibonacciList
{
    using System;
    using System.Collections.Generic;

    public static class FibonacciNumbers
    {
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
