namespace ArraySort
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides instance of IComparer 
    /// </summary>
    public class AdapterComparer : IComparer<int[]>
    {
        /// <summary>
        ///Instance of DecorartorComparer
        /// </summary>
        /// <param name="comparer"> Compare function</param>
        public AdapterComparer(Comparison<int[]> comparer)
        {
            this.Comparer = comparer;
        }

        /// <summary>
        ///Comparation function
        /// </summary>
        public Comparison<int[]> Comparer { get; }

        /// <summary>
        /// Compare 2 objects
        /// </summary>
        /// <param name="lhs">Left object</param>
        /// <param name="rhs">Right object</param>
        /// <returns></returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            return this.Comparer(lhs, rhs);
        }
    }
}