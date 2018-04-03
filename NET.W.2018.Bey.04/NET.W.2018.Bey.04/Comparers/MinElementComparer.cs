namespace NET.W._2018.Bey._04.Comparers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MinElementComparer : IComparer<double[]>
    {
        public int Compare(double[] lhs, double[] rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return lhs.Min().CompareTo(rhs.Min());
        }
    }
}