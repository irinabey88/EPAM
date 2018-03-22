// <copyright file="IPolynomial.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._04.Interfaces
{
    /// <summary>
    /// Provides methods for polinomial
    /// </summary>
    public interface IPolynomial
    {
        /// <summary>
        /// This methods calculate value of <paramref name="number"/>
        /// for polinomial
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Polinomial number</returns>
        double Calculate(double number);
    }
}