using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryCollections
{
    public class BinarySearchTree <T>
    {
        #region Private fields
        private Node<T> _node;
        private readonly Comparison<T> _comparer;
        #endregion

        #region Properties
        public int Count { get; private set; }
        #endregion

        #region .ctors
        public BinarySearchTree()
        {
            _comparer = Comparer<T>.Default.Compare;
        }

        public BinarySearchTree(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can't be equal to null!");
            }

            _comparer = Comparer<T>.Default.Compare;
            InsertRange(collection);
        }

        public BinarySearchTree(Comparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null!");
            }

            _comparer = comparer.Compare;
        }

        public BinarySearchTree(IEnumerable<T> collection,Comparer<T> comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can't be equal to null!");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null!");
            }

            _comparer = comparer.Compare;
            InsertRange(collection);
        }
        #endregion

        #region Public API
        public void Clear()
        {
            _node = null;
        }

        public bool Contains(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null!");
            }

            return ContainsInner(value);
        }

        public IEnumerable<T> InOrder() => InOrderInner(_node);

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

        public IEnumerable<T> PostOrder() => PostOrderInner(_node);

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