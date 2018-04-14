using BinaryTree.Interfaces;

namespace BinaryTreeTests.Comparer.StringComparer
{
    public class ComparerStringLength : IBinaryComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(x))
            {
                return -y.Length;
            }

            if (string.IsNullOrEmpty(y))
            {
                return x.Length;
            }

            return x.Length - y.Length;
        }
    }
}