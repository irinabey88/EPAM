using System.Collections;
using System.Collections.Generic;
using BinaryTree.Interfaces;

namespace BinaryTree
{
    /// <summary>
    /// Provides binary tree and binary tree node
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>, IBinaryTree<T>
    {
        /// <summary>
        /// Comparer 
        /// </summary>
        private IBinaryComparer<T> _comparer;

        /// <summary>
        /// Tree root node
        /// </summary>
        private Node<T> _root;

        /// <summary>
        /// Provides instance of binary tree and binary tree node
        /// </summary>
        /// <param name="comparer"></param>
        public BinarySearchTree(IBinaryComparer<T> comparer)
        {
            this._root = null;
            this._comparer = comparer;
        }

        /// <summary>
        /// Provides preoder sequence
        /// </summary>
        public IEnumerable<T> Preorder => PreOrderSequence(this._root);

        /// <summary>
        /// Provides postoder sequence
        /// </summary>
        public IEnumerable<T> Postoder => PostOderSequence(this._root);

        /// <summary>
        /// Provides inoder sequence
        /// </summary>
        public IEnumerable<T> Inorder => InOderSequence(this._root);

        /// <summary>
        /// Iterator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Inorder.GetEnumerator();
        }

        /// <summary>
        /// Create new binary node in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        public void Add(T data)
        {            
            this._root = AddNode(data, this._root);
        }

        /// <summary>
        /// Create new binary node in binary tree
        /// </summary>
        /// <param name="data"></param>
        void IBinaryTree<T>.Add(T data)
        {
            Add(data);
        }

        /// <summary>
        /// Find data in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns><value>Node with find value</value>
        /// <value>Null - otherwise</value></returns>
        public Node<T> Find(T data)
        {
            if (this._comparer.Compare(this._root.Data, data) == 0)
            {
                return this._root;
            }

            if (this._comparer.Compare(this._root.Data, data) > 0)
            {
                return Find(data, this._root.Left);
            }

            return Find(data, this._root.Right);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Add node to binary tree
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="node">Node</param>
        /// <returns>Added node</returns>
        private Node<T> AddNode(T data, Node<T> node)
        {
            if (node == null)
            {
                return new Node<T>(data);
            }

            if (this._comparer.Compare(node.Data, data) > 0)
            {
                node.Right = AddNode(data, node.Right);
            }
            else
            {
                node.Left = AddNode(data, node.Left);
            }

            return node;
        }

        /// <summary>
        /// Find Node in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="node">Node</param>
        /// <returns><value>Node - if such exists</value>
        /// <value>Null - otherwise</value></returns>
        private Node<T> Find(T data, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (this._comparer.Compare(node.Data, data) == 0)
            {
                return node;
            }

            if (this._comparer.Compare(this._root.Data, data) > 0)
            {
                return Find(data, node.Left);
            }

            return Find(data, node.Right);
        }

        private IEnumerable<T> PreOrderSequence(Node<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var n in PreOrderSequence(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PreOrderSequence(node.Right))
                {
                    yield return n;
                }                
            }
        }

        private IEnumerable<T> PostOderSequence(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in PostOderSequence(node.Left))
                {
                    yield return n;
                }                
            }

            if (node.Right != null)
            {
                foreach (var n in PostOderSequence(node.Right))
                {
                    yield return n;
                }                
            }

            yield return node.Data;
        }

        private IEnumerable<T> InOderSequence(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in InOderSequence(node.Left))
                {
                    yield return n;
                }                
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (var n in InOderSequence(node.Right))
                {
                    yield return n;
                }                
            }
        }           
    }
}
