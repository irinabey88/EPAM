namespace BinaryTree
{
    /// <summary>
    /// Provides class node for <see cref="BinarySearchTree{T}"/>
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Provides instance of <see cref="Node{T}"/>
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Left child
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right child
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Parent current node
        /// </summary>
        public Node<T> Parent { get; set; }
    }
}