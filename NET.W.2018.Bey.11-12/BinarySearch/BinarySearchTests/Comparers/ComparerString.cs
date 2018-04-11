namespace BinarySearchTests.Comparers
{
    using System;
    using System.Collections.Generic;

    public class ComparerString : IComparer<string>
    {
        public int Compare(string lhs, string rhs)
        {
            return string.Compare(lhs, rhs, StringComparison.Ordinal);
        }
    }
}