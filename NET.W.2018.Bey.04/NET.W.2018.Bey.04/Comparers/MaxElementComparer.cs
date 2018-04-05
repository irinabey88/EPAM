namespace NET.W._2018.Bey._04.Comparers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxElementComparer : IComparer<int[]>
    {
        public MaxElementComparer(bool ascending)
        {
            this._ascending = ascending;
        }

        private bool _ascending;

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

            return lhs.Max().CompareTo(rhs.Max()) * (this._ascending ? 1 : -1);
        }
    }
}