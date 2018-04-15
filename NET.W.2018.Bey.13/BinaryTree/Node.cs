namespace BinaryTree
{
    public class Node<T>
    {
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