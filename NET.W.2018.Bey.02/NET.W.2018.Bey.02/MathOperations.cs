using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace NET.W._2018.Bey._02
{
    public class MathOperations
    {
        private const int NotFound = -1;
        private const int SizeNumber = 32;

        /// <summary>
        /// Recive from input array, array of numbers, which contais given digit
        /// </summary>
        /// <param name="inputArray">Input array</param>
        /// <param name="findNumber">Digit, which is looking for</param>
        /// <returns>Filtered array</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int[] FilterDigit(int[] inputArray, byte findNumber)
        {
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(inputArray)}");
            }

            if (findNumber > 9)
            {
                throw new ArgumentOutOfRangeException($"{nameof(findNumber)}");
            }

            string resultArrayStr = string.Empty;

            foreach (var element in inputArray)
            {
                if (element.ToString().Contains(findNumber.ToString()) && !resultArrayStr.Contains(element.ToString()))
                {
                    resultArrayStr = string.IsNullOrWhiteSpace(resultArrayStr)
                        ? $"{element}"
                        : $"{resultArrayStr},{element}";
                }
            }

            return Array.ConvertAll(resultArrayStr.Split(','), int.Parse);
        }       

        /// <summary>
        /// Get next big nubmer from diggits of current number, or -1 if such nuber doesn't exists
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns><value>Number if such number exists</value>
        /// <value>-1 otherwise</value></returns>
        /// <exception cref="ArgumentOutOfRangeException">Invalid input data</exception>
        public static long FindNextBigNumber(long number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(number)}");
            }

            var numberArray = number.ToString().ToCharArray();

            //Number consists of 1 digit
            if (numberArray.Length == 1)
            {
                return NotFound;
            }

            var position = numberArray.Length - 1;
            bool isFound = false;

            //Find first digig that less than previous and swap them
            for (int i = numberArray.Length - 1; i > 0; i--)
            {
                if (numberArray[i] > numberArray[i - 1])
                {
                    isFound = true;
                    position = i;
                    var buf = numberArray[i];
                    numberArray[i] = numberArray[i - 1];
                    numberArray[i - 1] = buf;
                    break;
                }
            }

            if (!isFound)
            {
                return NotFound;
            }

            //Sort all digits after digits, that was swaped
            Array.Sort(numberArray, position, numberArray.Length - position);
            long.TryParse(new string(numberArray), out var result);

            return result == 0 ? NotFound : result;
        }

        /// <summary>
        /// Calculate executing time with stopwatch
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Executing time in miliseconds</returns>
        public static double CalculateTimeStopWatch(long number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            FindNextBigNumber(number);

            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Calculate executing time with DateTime
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Executing time in miliseconds</returns>
        public static double CalculateTimeDateTime(long number)
        {
            var before = DateTime.Now.Millisecond;

            FindNextBigNumber(number);

            var after = DateTime.Now.Millisecond;

            return after - before;
        }

        /// <summary>
        /// Inserts some bits of number2 to bits from i to j number1
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2"></param>
        /// <param name="i">Start position for inset</param>
        /// <param name="j">End position for insert</param>
        /// <returns>Resul number</returns>
        /// <exception cref="ArgumentOutOfRangeException">Invalid input data</exception>
        public static long InsertNumber(long number1, long number2, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)}");
            }

            //Form mask for number1 right side
            long mask11 = FormMask(0, i);

            //Form mask for number1 left side
            long mask12 = FormMask(0, SizeNumber - 1);
            mask12 <<= j;

            //Result mask for number1
            var resultMask1 = mask12 | mask11;

            //modify number1 for insert
            number1 &= resultMask1;

            //Form mask for number2, set 1 in bits from i to j, in others bits set 0
            long mask2 = FormMask(0, j - i);

            //modify number2 for insert 
            number2 = (number2 & mask2) << i;

            return number1 | number2;
        }

        /// <summary>
        /// Calculate the n-power root from the a 
        /// by the Newton algorithm with a given accuracy
        /// </summary>
        /// <param name="a">Number</param>
        /// <param name="n">the power of root</param>
        /// <param name="eps">Accurancy</param>
        /// <returns>N-power root from</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double FindNthRoot(double a, int n, double eps)
        {
            if (eps <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(eps)}");
            }

            var x0 = a / n;
            var x1 = (1.0 / n) * (((n - 1) * x0) + (a / Math.Pow(x0, n - 1)));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1.0 / n) * (((n - 1) * x0) + (a / Math.Pow(x0, n - 1)));
            }

            return Math.Round(x1, GetRoundNumber(eps));
        }

        /// <summary>
        /// Get the number of digits after the dot
        /// </summary>
        /// <param name="eps">Accurancy</param>
        /// <returns>Number of digits after dot</returns>
        private static int GetRoundNumber(double eps)
        {
            var str = eps.ToString(CultureInfo.InvariantCulture);
            var indexPot = str.LastIndexOf(".", StringComparison.Ordinal);
            var strAfterPot = str.Substring(indexPot + 1);
            var roundNumber = strAfterPot.Length;

            return roundNumber;
        }

        /// <summary>
        /// Form mask for bits 
        /// </summary>
        /// <param name="startIndex"> start position</param>
        /// <param name="endIndex">end position</param>
        /// <returns>mask</returns>
        /// <exception cref="ArgumentOutOfRangeException">Invalid input data</exception>
        private static long FormMask(int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startIndex)}");
            }

            return endIndex - startIndex == 0 ? 1 : (((1 << endIndex) - startIndex) - 1);
        }
    }
}