using System;
using NET.W._2018.Bey._03.Properties;

namespace NET.W._2018.Bey._03
{
    public static class BinaryView
    {
        /// <summary>
        /// Form binary representation of number
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Binary representation of number</returns>
        public static string GetBinaryView(this double number)
        {
            switch (number)
            {
                case 0.0:
                    return Resources.ZeroValue;
                case double.Epsilon:
                    return Resources.Epsilon;
                case double.MaxValue:
                    return Resources.MaxValue;
                case double.MinValue:
                    return Resources.MinValue;
                case double.NegativeInfinity:
                    return Resources.NegativeInfinity;
                case double.PositiveInfinity:
                    return Resources.PositiveInfinity;
                case double.NaN:
                    return Resources.Nan;
            }

            //Get binary representation sign
            var sign = number < 0 ? "1" : "0";
            number = Math.Abs(number);

            //Get binary representation integer part
            var integerPart = FormIntegerBinaryPart((uint)number);

            //Get binary representation real part
            var realPart = FormRealBinaryPart(number - (long) number,
                Convert.ToInt32(Resources.MantissaSize) - integerPart.Length - 1);

            //Get exponent of result number
            var exponentNumber = Convert.ToInt32(Resources.ExponentialBias) + integerPart.Length - 1;
            //Get binary representation of exponent
            var exponent = FormIntegerBinaryPart(exponentNumber);

            char pad = '0';
            //Get mantissa from integer and real part
            var mantissa =
                $"{integerPart.Substring(1)}{realPart}".PadRight(Convert.ToInt32(Resources.MantissaSize), pad);

            var result = $"{sign}{exponent}{mantissa}";

            return result;
        }

        /// <summary>
        /// Form binary representation of integer part number
        /// </summary>
        /// <param name="number">Integer part number</param>
        /// <returns>Binary representation</returns>
        static string FormIntegerBinaryPart(long number)
        {
            var result = string.Empty;
            uint baseNumberSystem = Convert.ToUInt32(Resources.BaseOfBinaryNumberSystem);

            if (number == 0)
            {
                return "0";
            }

            while (number > 0)
            {
                var mod = number % baseNumberSystem;
                number /= baseNumberSystem;
                result = $"{mod}{result}";
            }

            return result;
        }

        /// <summary>
        /// Form binary representation of real part number
        /// </summary>
        /// <param name="number">Real part number</param>
        /// <param name="exponent">Exponent</param>
        /// <returns>Binary representation</returns>
        static string FormRealBinaryPart(double number, int exponent)
        {
            if (number > 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(number)}");
            }

            var result = string.Empty;
            int baseNumberSystem = Convert.ToInt32(Resources.BaseOfBinaryNumberSystem);

            for (int i = 0; i < exponent; i++)
            {
                number *= baseNumberSystem;
                var integerPart = (int)number;
                number -= integerPart;
                result = $"{result}{integerPart}";
            }

            return result;
        }
    }
}