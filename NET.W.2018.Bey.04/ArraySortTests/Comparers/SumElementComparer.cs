namespace ArraySort.Comparers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumElementComparer : IComparer<int[]>
    {
        private bool _ascending;

        public SumElementComparer(bool ascending)
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
            
            return (lhs.Sum() - rhs.Sum()) * (this._ascending ? 1 : -1);
        }       
    }
}