// <copyright file="BinaryView.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._03
{
    using System;

    /// <summary>
    /// Provides get binary view of real number
    /// </summary>
    public static class BinaryView
    {
        #region Constant
        /// <summary>
        /// Base of binary system
        /// </summary>
        private const int BaseOfBinaryNumberSystem = 2;

        /// <summary>
        /// Beas of exponent
        /// </summary>
        private const int ExponentialBias = 1023;

        /// <summary>
        /// Mantissa size
        /// </summary>
        private const int MantissaSize = 52;

        /// <summary>
        /// Binary zero value
        /// </summary>
        private const string ZeroValue = "0000000000000000000000000000000000000000000000000000000000000000";

        /// <summary>
        /// Binary epsilon value
        /// </summary>
        private const string Epsilon = "0000000000000000000000000000000000000000000000000000000000000001";

        /// <summary>
        /// Binary maxvalue
        /// </summary>
        private const string MaxValue = "0111111111101111111111111111111111111111111111111111111111111111";

        /// <summary>
        /// Binary minvalue
        /// </summary>
        private const string MinValue = "1111111111101111111111111111111111111111111111111111111111111111";

        /// <summary>
        /// Binary negativeinfinity value
        /// </summary>
        private const string NegativeInfinity = "1111111111110000000000000000000000000000000000000000000000000000";

        /// <summary>
        /// Binary positiveinfinity value
        /// </summary>
        private const string PositiveInfinity = "0111111111110000000000000000000000000000000000000000000000000000";

        /// <summary>
        /// Binary nan value
        /// </summary>
        private const string Nan = "1111111111111000000000000000000000000000000000000000000000000000";
        #endregion

        /// <summary>
        /// Form binary representation of number
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Binary representation of number</returns>
        public static string GetBinaryView(this double number)
        {
            switch (number)
            {
                case 0.0:
                    return ZeroValue;
                case double.Epsilon:
                    return Epsilon;
                case double.MaxValue:
                    return MaxValue;
                case double.MinValue:
                    return MinValue;
                case double.NegativeInfinity:
                    return NegativeInfinity;
                case double.PositiveInfinity:
                    return PositiveInfinity;
                case double.NaN:
                    return Nan;
            }

            ////Get binary representation sign
            var sign = number < 0 ? "1" : "0";
            number = Math.Abs(number);

            ////Get binary representation integer part
            var integerPart = FormIntegerBinaryPart((long)number);

            ////Get binary representation real part
            var realPart = FormRealBinaryPart(number - (long)number, MantissaSize - integerPart.Length - 1);

            ////Get exponent of result number
            var exponentNumber = ExponentialBias + integerPart.Length - 1;
            
            ////Get binary representation of exponent
            var exponent = FormIntegerBinaryPart(exponentNumber);

            char pad = '0';

            ////Get mantissa from integer and real part
            var mantissa =
                $"{integerPart.Substring(1)}{realPart}".PadRight(MantissaSize, pad);

            var result = $"{sign}{exponent}{mantissa}";

            return result;
        }

        /// <summary>
        /// Form binary representation of integer part number
        /// </summary>
        /// <param name="number">Integer part number</param>
        /// <returns>Binary representation</returns>
        private static string FormIntegerBinaryPart(long number)
        {
            var result = string.Empty;           

            if (number == 0)
            {
                return "0";
            }

            while (number > 0)
            {
                var mod = number % BaseOfBinaryNumberSystem;
                number /= BaseOfBinaryNumberSystem;
                result = $"{mod}{result}";
            }

            return result;
        }

        /// <summary>
        /// Form binary representation of real part number
        /// </summary>
        /// <param name="number">Real part number</param>
        /// <param name="exponent">Exponent value</param>
        /// <returns>Binary representation</returns>
        private static string FormRealBinaryPart(double number, int exponent)
        {
            if (number > 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(number)}");
            }

            var result = string.Empty;           

            for (int i = 0; i < exponent; i++)
            {
                number *= BaseOfBinaryNumberSystem;
                var integerPart = (int)number;
                number -= integerPart;
                result = $"{result}{integerPart}";
            }

            return result;
        }
    }
}