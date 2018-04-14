using System.Collections.Generic;
using BinaryTree.Interfaces;

namespace BinaryTree
{
    /// <summary>
    /// Provides binary tree and binary tree node
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class BinarySearchTree<T> : IBinaryTree<T>
    {
        /// <summary>
        /// Comparer 
        /// </summary>
        private IBinaryComparer<T> _comparer;

        /// <summary>
        /// Provides instance of binary tree and binary tree node
        /// </summary>
        /// <param name="comparer"></param>
        public BinarySearchTree(IBinaryComparer<T> comparer)
        {
            this.Parent = null;
            this._comparer = comparer;
        }

        // <summary>
        // Provides instance of binary tree and binary tree node
        // </summary>
        // <param name="comparer"></param>
        // <param name="data"></param>
        public BinarySearchTree(IBinaryComparer<T> comparer, T data) : this(comparer)
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
        public BinarySearchTree<T> Left { get; set; }

        /// <summary>
        /// Right child
        /// </summary>
        public BinarySearchTree<T> Right { get; set; }

        /// <summary>
        /// Parent current node
        /// </summary>
        public BinarySearchTree<T> Parent { get; set; }

        /// <summary>
        /// Provides binary tree in preoder
        /// </summary>
        public IEnumerable<T> Preorder
        {
            get
            {
                var top = this;
                while (this.Parent != null)
                {
                    top = top.Parent;
                }

                Stack<BinarySearchTree<T>> stack = new Stack<BinarySearchTree<T>>();
                while (top != null || stack.Count != 0)
                {
                    if (stack.Count != 0)
                    {
                        top = stack.Pop();
                    }

                    while (top != null)
                    {
                        yield return top.Data;

                        if (top.Right != null)
                        {
                            stack.Push(top.Right);
                        }

                        top = top.Left;
                    }
                }
            }
        }

        /// <summary>
        /// Provides binary tree in postoder
        /// </summary>
        public IEnumerable<T> Postoder
        {
            get
            {
                var parent = this;               
                bool wasInRight = false;

                Stack<BinarySearchTree<T>> stack = new Stack<BinarySearchTree<T>>();
                while (parent != null || stack.Count != 0)
                {
                    if (stack.Count != 0)
                    {
                        parent = stack.Pop();

                        yield return parent.Data;

                        if (parent.Right != null)
                        {
                            if (!wasInRight)
                            {
                                parent = parent.Right;

                                if (parent.Left == null)
                                {
                                    while (parent.Right != null && parent.Left == null)
                                    {
                                        stack.Push(parent);
                                        parent = parent.Right;
                                    }

                                    wasInRight = true;
                                }                               
                            }
                            else
                            {
                                if (stack.Count != 0 && !stack.Peek().Equals(parent.Parent))
                                {
                                    stack.Push(parent.Parent);
                                }

                                parent = parent.Left;
                            }
                        }
                        else
                        {                            
                            parent = null;
                        }
                    }

                    while (parent != null)
                    {
                        stack.Push(parent);
                        parent = parent.Left;
                    }
                }
            }
        }

        /// <summary>
        /// Provides binary tree in postoder
        /// </summary>
        public IEnumerable<T> Inorder
        {
            get
            {
                var parent = this;

                Queue<BinarySearchTree<T>> queue = new Queue<BinarySearchTree<T>>();
                do
                {
                    yield return parent.Data;

                    if (parent.Left != null)
                    {
                        queue.Enqueue(parent.Left);
                    }

                    if (parent.Right != null)
                    {
                        queue.Enqueue(parent.Right);
                    }

                    if (parent.Left == null && parent.Right == null && queue.Count == 0)
                    {
                        parent = null;
                    }

                    if (queue.Count != 0)
                    {
                        parent = queue.Dequeue();
                    }
                }
                while (queue.Count != 0 || parent != null);
            }
        }       

        /// <summary>
        /// Create new binary node in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        public void Insert(T data)
        {
            if (this._comparer.Compare(this.Data, data) > 0)
            {
                if (Left == null)
                {
                    Left = new BinarySearchTree<T>(this._comparer);
                }

                Insert(data, Left, this);
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinarySearchTree<T>(this._comparer);
                }

                Insert(data, Right, this);
            }
        }

        /// <summary>
        /// Find data in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns><value>Node with find value</value>
        /// <value>null - otherwise</value></returns>
        public BinarySearchTree<T> Find(T data)
        {
            if (this._comparer.Compare(this.Data, data) == 0)
            {
                return this;
            }

            if (this._comparer.Compare(this.Data, data) > 0)
            {
                return Find(data, this.Left);
            }

            return Find(data, this.Right);
        }   

        private void Insert(T data, BinarySearchTree<T> node, BinarySearchTree<T> parent)
        {
            if ((typeof(T).IsValueType && node.Data.Equals(default(T))) || (!typeof(T).IsValueType && node.Data == null))
            {
                node.Data = data;
                node.Parent = parent;
            }
            else if (this._comparer.Compare(node.Data, data) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinarySearchTree<T>(this._comparer);
                }

                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinarySearchTree<T>(this._comparer);
                }

                Insert(data, node.Right, node);
            }
        }

        private BinarySearchTree<T> Find(T data, BinarySearchTree<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (this._comparer.Compare(this.Data, data) == 0)
            {
                return node;
            }

            if (this._comparer.Compare(this.Data, data) > 0)
            {
                return Find(data, node.Left);
            }

            return Find(data, node.Right);
        }
    }
}
