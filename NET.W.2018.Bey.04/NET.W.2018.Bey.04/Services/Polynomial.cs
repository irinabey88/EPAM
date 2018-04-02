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
    public sealed class Polynomial : IPolynomial
    {
        /// <summary>
        /// Error value
        /// </summary>
        private const double Eps = 0.00000001;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="factors"> Factors array </param>
        /// <exception cref="ArgumentOutOfRangeException">Inccorect polinomial</exception>
        public Polynomial(params double[] factors)
        {
            if (factors == null || factors.Length < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(factors)}");
            }

            this.Factors = factors;
        }

        /// <summary>
        /// Gets lhs value of polinomial factors and powers
        /// </summary>
        public double[] Factors { get; }

        #region Operators

        /// <summary>
        /// This methods adds 2 polynomials
        /// </summary>
        /// <param name="lhs">Polynomial lhs</param>
        /// <param name="rhs">Polinomial rhs</param>
        /// <returns>Result polinomial</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return AddOrSubstract(lhs, rhs, Sign.Add);
        }

        /// <summary>
        /// This methods substracts 2 polynomials
        /// </summary>
        /// <param name="lhs">Polynomial lhs</param>
        /// <param name="rhs">Polinomial rhs</param>
        /// <returns>Result polinomial</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return AddOrSubstract(lhs, rhs, Sign.Substruct);
        }

        /// <summary>
        /// This methods multiplies 2 polynomials
        /// </summary>
        /// <param name="lhs">Polynomial lhs</param>
        /// <param name="rhs">Polinomial rhs</param>
        /// <returns>Result polinomial</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (lhs?.Factors == null || lhs.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(lhs)}");
            }

            if (rhs?.Factors == null || rhs.Factors.Length < 1)
            {
                throw new ArgumentException($"{nameof(rhs)}");
            }

            var resultLength = lhs.Factors.Length > rhs.Factors.Length ? lhs.Factors.Length : rhs.Factors.Length;
            var resultFactors = new double[resultLength];

            for (int i = 0; i < resultLength; i++)
            {
                if (i < lhs.Factors.Length && i < rhs.Factors.Length)
                {
                    resultFactors[i] = lhs.Factors[i] * rhs.Factors[i];
                }
                else
                {
                    if (i < lhs.Factors.Length)
                    {
                        resultFactors[i] = lhs.Factors[i];
                    }
                    else
                    {
                        resultFactors[i] = rhs.Factors[i];
                    }
                }
            }

            return new Polynomial(resultFactors);
        }

        /// <summary>
        /// This methods compare 2 polynomials for equality
        /// </summary>
        /// <param name="lhs">Polynomial lhs</param>
        /// <param name="rhs">Polinomial rhs</param>
        /// <returns><value>true - polynomials has equals value</value>
        /// <value>false - otherwise</value></returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (ReferenceEquals(lhs, null))
            {
                return false;
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// This methods compare 2 polynomials for not equality
        /// </summary>
        /// <param name="lhs">Polynomial lhs</param>
        /// <param name="rhs">Polinomial rhs</param>
        /// <returns><value>false - polynomials has equals value</value>
        /// <value>true - otherwise</value></returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return false;
            }

            if (ReferenceEquals(lhs, null))
            {
                return true;
            }

            return !lhs.Equals(rhs);
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
                if (!string.IsNullOrWhiteSpace(polinomial) && Math.Abs(this.Factors[i]) > Eps)
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
                else if (Math.Abs(this.Factors[i]) > Eps)
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
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
        }

        /// <summary>
        /// This methods check are the polynomial function equals
        /// </summary>
        /// <param name="other">Polinomial object</param>
        /// <returns><value>true - polinomial are equals</value>
        /// <value>false - otherwise</value></returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Factors.Length != other.Factors.Length)
            {
                return false;
            }

            for (var i = 0; i < this.Factors.Length; i++)
            {
                if (!this.Factors[i].Equals(other.Factors[i]))
                {
                    return false;
                }
            }

            return true;
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
        /// This methods add or substruct 2 polinomials
        /// </summary>
        /// <param name="a">Polinomial lhs</param>
        /// <param name="b">Polinomial rhs</param>
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
