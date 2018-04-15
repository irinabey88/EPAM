namespace BinaryTree
{
    public interface IBinaryTree<T>
    {
        /// <summary>
        /// Create new binary node in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        void Add(T data);

        /// <summary>
        /// Find data in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns><value>Node with find value</value>
        /// <value>null - otherwise</value></returns>
        Node<T> Find(T data);       
    }
}