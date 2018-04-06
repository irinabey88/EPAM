using System.Collections.Generic;

namespace NET.W._2018.Bey._04.Comparers
{
    using System;
    using System.Linq;

    public class MinElementComparer : IComparer<int[]>
    {
        private bool _ascending;

        public MinElementComparer(bool ascending)
        {
            this._ascending = ascending;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return (lhs.Min() - rhs.Min()) * (this._ascending ? 1 : -1);
        }
    }
}