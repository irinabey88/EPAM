// <copyright file="Polynomial.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._04.Services
{
    using System;
    using System.Linq;
    using Enum;
    using Interfaces;

    /// <summary>
    /// Represent mathematical polynomial
    /// </summary>
    public class Polynomial : IPolynomial
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="factors"> Factors array </param>
        /// <exception cref="ArgumentOutOfRangeException">Inccorect polinomial</exception>
        public Polynomial(double[] factors)
        {
            if (factors == null || factors.Length < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(factors)}");
            }

            this.Factors = factors;
        }

        /// <summary>
        /// Gets a value of polinomial factors and powers
        /// </summary>
        public double[] Factors { get; }

        #region Operators

        /// <summary>
        /// This methods adds 2 polynomials
        /// </summary>
        /// <param name="a">Polynomial a</param>
        /// <param name="b">Polinomial b</param>
        /// <returns>Result polinomial</returns>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            return AddOrSubstract(a, b, Sign.Add);
        }

        /// <summary>
        /// This methods substracts 2 polynomials
        /// </summary>
        /// <param name="a">Polynomial a</param>
        /// <param name="b">Polinomial b</param>
        /// <returns>Result polinomial</returns>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            return AddOrSubstract(a, b, Sign.Substruct);
        }

        /// <summary>
        /// This methods multiplies 2 polynomials
        /// </summary>
        /// <param name="a">Polynomial a</param>
        /// <param name="b">Polinomial b</param>
        /// <returns>Result polinomial</returns>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            if (a?.Factors == null || a.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(a)}");
            }

            if (b?.Factors == null || b.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(b)}");
            }

            var resultLength = a.Factors.Length > b.Factors.Length ? a.Factors.Length : b.Factors.Length;
            var resultFactors = new double[resultLength];

            for (int i = 0; i < resultLength; i++)
            {
                if (i < a.Factors.Length && i < b.Factors.Length)
                {
                    resultFactors[i] = a.Factors[i] * b.Factors[i];
                }
                else
                {
                    if (i < a.Factors.Length)
                    {
                        resultFactors[i] = a.Factors[i];
                    }
                    else
                    {
                        resultFactors[i] = b.Factors[i];
                    }
                }
            }

            return new Polynomial(resultFactors);
        }

        /// <summary>
        /// This methods compare 2 polynomials for equality
        /// </summary>
        /// <param name="a">Polynomial a</param>
        /// <param name="b">Polinomial b</param>
        /// <returns><value>true - polynomials has equals value</value>
        /// <value>false - otherwise</value></returns>
        public static bool operator ==(Polynomial a, Polynomial b)
        {
            if (a?.Factors == null || a.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(a)}");
            }

            if (b?.Factors == null || b.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(b)}");
            }

            return CompareArray(a.Factors, b.Factors);
        }

        /// <summary>
        /// This methods compare 2 polynomials for not equality
        /// </summary>
        /// <param name="a">Polynomial a</param>
        /// <param name="b">Polinomial b</param>
        /// <returns><value>false - polynomials has equals value</value>
        /// <value>true - otherwise</value></returns>
        public static bool operator !=(Polynomial a, Polynomial b)
        {
            if (a?.Factors == null || a.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(a)}");
            }

            if (b?.Factors == null || b.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(b)}");
            }

            return !(a == b);
        }

        #endregion

        #region Overrides methods

        /// <summary>
        /// This methods provide string object representation
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            var polinomial = string.Empty;
            for (int i = this.Factors.Length - 1; i >= 0; i--)
            {
                if (!string.IsNullOrWhiteSpace(polinomial) && this.Factors[i] != 0.0)
                {
                    switch (i)
                    {
                        case 0:
                            polinomial = this.Factors[i] > 0
                                ? $"{polinomial}+{this.Factors[i]}"
                                : $"{polinomial}{this.Factors[i]}";
                            break;
                        case 1:
                            polinomial = this.Factors[i] > 0
                                ? $"{polinomial}+{this.Factors[i]}*x"
                                : $"{polinomial}{this.Factors[i]}*x";
                            break;
                            default:
                                polinomial = this.Factors[i] > 0
                                    ? $"{polinomial}+{this.Factors[i]}*x^{i}"
                                    : $"{polinomial}{this.Factors[i]}*x^{i}";
                            break;
                    }                    
                }
                else if (this.Factors[i] != 0.0)
                {
                    polinomial = $"{this.Factors[i]}*x^{i}";
                }
            }

            return polinomial;
        }

        /// <summary>
        /// This methods get object hashCode
        /// </summary>
        /// <returns>Hashcode value</returns>
        public override int GetHashCode()
        {
            return (int)this.Factors.Sum() << this.Factors.Length;
        }

        /// <summary>
        /// This methods check are the polynomial function equals
        /// </summary>
        /// <param name="obj">Polinomial object</param>
        /// <returns><value>true - polinomial are equals</value>
        /// <value>false - otherwise</value></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial))
            {
                return false;
            }

            return CompareArray(this.Factors, ((Polynomial)obj).Factors);
        }

        #endregion

        #region Interface methods

        /// <summary>
        /// This methods calculate value of <paramref name="number"/>
        /// for polinomial
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Polinomial number</returns>
        public double Calculate(double number)
        {
            var result = 0.0;

            for (int i = 0; i < this.Factors.Length; i++)
            {
                result += Math.Pow(number, i) * this.Factors[i];
            }

            return result;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This methods compares 2 arrays
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns><value>true - value in arrays are equals</value>
        /// <value>false - otherwise</value></returns>
        /// <exception cref="ArgumentOutOfRangeException">Incorrect arrays</exception>
        private static bool CompareArray(double[] array1, double[] array2)
        {
            if (array1 == null || array1.Length < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(array1)}");
            }

            if (array2 == null || array2.Length < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(array2)}");
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This methods add or substruct 2 polinomials
        /// </summary>
        /// <param name="a">Polinomial a</param>
        /// <param name="b">Polinomial b</param>
        /// <param name="sign"><value>Add</value>
        /// <value>Substruct</value></param>
        /// <returns>Result polynomial</returns>
        private static Polynomial AddOrSubstract(Polynomial a, Polynomial b, Sign sign)
        {
            if (a?.Factors == null || a.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(a)}");
            }

            if (b?.Factors == null || b.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(b)}");
            }

            var resultLength = a.Factors.Length > b.Factors.Length ? a.Factors.Length : b.Factors.Length;
            var resultFactors = new double[resultLength];

            for (int i = 0; i < resultLength; i++)
            {
                if (i < a.Factors.Length && i < b.Factors.Length)
                {
                    resultFactors[i] = a.Factors[i] + (b.Factors[i] * (int)sign);
                }
                else
                {
                    if (i < a.Factors.Length)
                    {
                        resultFactors[i] = a.Factors[i];
                    }
                    else
                    {
                        resultFactors[i] = b.Factors[i] * (int)sign;
                    }
                }
            }

            return new Polynomial(resultFactors);
        }

        #endregion
    }
}
