using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryCollections
{
    /// <summary>
    /// Class that provides binary search tree representation
    /// </summary>
    /// <typeparam name="T">Needed node type</typeparam>
    public class BinarySearchTree <T>
    {
        #region Private fields
        private Node<T> _node;
        private readonly Comparison<T> _comparer;
        #endregion

        #region Properties
        /// <summary>
        /// Represent current amount of not-default nodes in tree
        /// </summary>
        public int Count { get; private set; }
        #endregion

        #region .ctors
        /// <summary>
        /// Constructor for <see cref="BinarySearchTree{T}"/>
        /// </summary>
        public BinarySearchTree()
        {
            _comparer = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Constructor for <see cref="BinarySearchTree{T}"/>
        /// </summary>
        /// <param name="collection">Input <see cref="IEnumerable{T}"/> collection</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="collection"/> is equal to null</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="collection"/> is empty</exception>
        public BinarySearchTree(IEnumerable<T> collection)
        {
            _comparer = Comparer<T>.Default.Compare;
            InsertRange(collection);
        }

        /// <summary>
        /// Constructor for <see cref="BinarySearchTree{T}"/>
        /// </summary>
        /// <param name="comparer">Needed <see cref="Comparer{T}"/> elements comparer</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="comparer"/> is equal to null</exception>
        public BinarySearchTree(Comparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null!");
            }

            _comparer = comparer.Compare;
        }

        /// <summary>
        /// Constructor for <see cref="BinarySearchTree{T}"/>
        /// </summary>
        /// <param name="collection">Input <see cref="IEnumerable{T}"/> collection</param>
        /// <param name="comparer">Needed <see cref="Comparer{T}"/> elements comparer</param>
        /// <exception cref="ArgumentNullException">Throws when:
        /// 1) <paramref name="collection"/> is equal to null
        /// 2) <paramref name="comparer"/> is equal to null
        /// </exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="collection"/> is empty</exception>
        public BinarySearchTree(IEnumerable<T> collection,Comparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null!");
            }

            _comparer = comparer.Compare;
            InsertRange(collection);
        }
        #endregion

        #region Public API
        /// <summary>
        /// Clear binary search tree
        /// </summary>
        public void Clear()
        {
            _node = null;
        }

        /// <summary>
        /// Check if this tree contains <paramref name="value"/>
        /// </summary>
        /// <param name="value">Needed value</param>
        /// <returns>bool search result</returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="value"/> is equal to null</exception>
        public bool Contains(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null!");
            }

            return ContainsInner(value);
        }

        /// <summary>
        /// Return InOrder representation of tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when tree is empty</exception>
        /// <returns>InOrder representation of tree</returns>
        public IEnumerable<T> InOrder() => InOrderInner(_node);

        /// <summary>
        /// Insert <paramref name="value"/> in tree
        /// </summary>
        /// <param name="value">Inserted value</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="value"/> is equal to null</exception>
        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null!");
            }

            if (_node == null)
            {
                _node = new Node<T>(value);
                Count++;
                return;
            }

            InnerInsert(_node, value);
        }

        /// <summary>
        /// Insert <paramref name="collection"/> of <see cref="T"/> in tree
        /// </summary>
        /// <param name="collection">collection of <see cref="T"/> values needed to be inserted</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="collection"/> is equal to null</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="collection"/> is empty</exception>
        public void InsertRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can't be equal to null!");
            }

            if (collection.Count() == 0)
            {
                throw new ArgumentException($"{nameof(collection)} can't be empty!");
            }

            foreach (T item in collection)
            {
                Insert(item);
            }
        }

        /// <summary>
        /// Return PostOrder representation of tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when tree is empty</exception>
        /// <returns>PostOrder representation of tree</returns>
        public IEnumerable<T> PostOrder() => PostOrderInner(_node);

        /// <summary>
        /// Return PreOrder representation of tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when tree is empty</exception>
        /// <returns>PreOrder representation of tree</returns>
        public IEnumerable<T> PreOrder() => PreOrderInner(_node);
        #endregion

        #region Private methods
        private void InnerInsert(Node<T> node,T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }

            int comparissonResult = _comparer(value, node.Data);

            if (comparissonResult < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                    Count++;
                }
                else
                {
                    InnerInsert(node.Left, value);
                }
            }
            else if (comparissonResult >= 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                    Count++;
                }
                else
                {
                    InnerInsert(node.Right, value);
                }
            }
        }

        private IEnumerable<T> InOrderInner(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException($"{nameof(node)} can't be equal to null!");
            }

            if (node.Left != null)
            {
                foreach(var n in InOrderInner(node.Left))
                {
                    yield return n;
                }
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (var n in InOrderInner(node.Right))
                {
                    yield return n;
                }
            }
        }

        private bool ContainsInner(T data)
        {
            Node<T> current = _node;

            while(current != null)
            {
                if (_comparer(data, current.Data) == 0)
                {
                    return true;
                }
                else if (_comparer(data, current.Data) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }

            return false;
        }

        private IEnumerable<T> PostOrderInner(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException($"{nameof(node)} can't be equal to null!");
            }

            if (node.Left != null)
            {
                foreach (var n in InOrderInner(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in InOrderInner(node.Right))
                {
                    yield return n;
                }
            }

            yield return node.Data;
        }

        private IEnumerable<T> PreOrderInner(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException($"{nameof(node)} can't be equal to null!");
            }

            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var n in InOrderInner(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in InOrderInner(node.Right))
                {
                    yield return n;
                }
            }
        }
        #endregion

        /// <summary>
        /// Helper class representing tree node
        /// </summary>
        /// <typeparam name="T">Needed type of the values</typeparam>
        internal sealed class Node <T>
        {
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public T Data { get; }

            public Node(T data)
            {
                Data = data;
            }
        }
    }
}