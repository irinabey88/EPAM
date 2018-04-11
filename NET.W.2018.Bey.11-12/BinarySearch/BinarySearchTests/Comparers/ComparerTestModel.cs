namespace BinarySearchTests.Comparers
{
    using System.Collections.Generic;
    using Models;

    public class ComparerTestModel : IComparer<TestModel> 
    {
        public int Compare(TestModel lhs, TestModel rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return 1;
            }

            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }

            return lhs.CompareTo(rhs);
        }
    }
}