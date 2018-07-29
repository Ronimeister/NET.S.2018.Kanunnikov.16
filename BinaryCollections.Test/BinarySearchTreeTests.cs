using System.Collections.Generic;
using NUnit.Framework;

namespace BinaryCollections.Test
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Int32 tests
        [Test]
        public void BinarySearchTree_DifferentCtor_Int_IsCorrect()
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>();
            actual.Insert(1);
            actual.Insert(2);
            BinarySearchTree<int> expected = new BinarySearchTree<int>(new int[] { 1, 2 });
            CollectionAssert.AreEqual(expected.InOrder(), actual.InOrder());
        }

        [Test]
        public void BinarySearchTree_DefaultComparer_InOrder_IsCorrect()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 });
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4}, tree.InOrder());
        }

        [Test]
        public void BinarySearchTree_CustomComparer_InOrder_IsCorrect()
        {
            int compare(int a, int b)
            {
                if (a > b) return 1;
                if (a < b) return -1;
                return 0;
            }

            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 }, Comparer<int>.Create(compare));
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, tree.InOrder());
        }

        [Test]
        public void BinarySearchTree_DefaultComparer_PreOrder_IsCorrect()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 });
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, tree.PreOrder());
        }

        [Test]
        public void BinarySearchTree_CustomComparer_PreOrder_IsCorrect()
        {
            int compare(int a, int b)
            {
                if (a > b) return 1;
                if (a < b) return -1;
                return 0;
            }

            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 }, Comparer<int>.Create(compare));
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, tree.PreOrder());
        }

        [Test]
        public void BinarySearchTree_DefaultComparer_PostOrder_IsCorrect()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 });
            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 1 }, tree.PostOrder());
        }

        [Test]
        public void BinarySearchTree_CustomComparer_PostOrder_IsCorrect()
        {
            int compare(int a, int b)
            {
                if (a > b) return 1;
                if (a < b) return -1;
                return 0;
            }

            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 }, Comparer<int>.Create(compare));
            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 1 }, tree.PostOrder());
        }

        [TestCase(3, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        public bool BinarySearchTree_Contains_IsCorrect(int number)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4 });
            return tree.Contains(number);
        }
        #endregion

        #region String tests
        [Test]
        public void BinarySearchTree_DifferentCtor_String_IsCorrect()
        {
            BinarySearchTree<string> actual = new BinarySearchTree<string>();
            actual.Insert("1");
            actual.Insert("2");
            BinarySearchTree<string> expected = new BinarySearchTree<string>(new string[] { "1", "2" });
            CollectionAssert.AreEqual(expected.InOrder(), actual.InOrder());
        }

        [Test]
        public void BinarySearchTree_String_DefaultComparer_InOrder_IsCorrect()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" });
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, tree.InOrder());
        }

        [Test]
        public void BinarySearchTree_String_CustomComparer_InOrder_IsCorrect()
        {
            int compare(string a, string b)
            {
                if (a.CompareTo(b) > 0) return 1;
                if (a.CompareTo(b) < 0) return -1;
                return 0;
            }

            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" }, Comparer<string>.Create(compare));
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, tree.InOrder());
        }

        [Test]
        public void BinarySearchTree_String_DefaultComparer_PreOrder_IsCorrect()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" });
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, tree.PreOrder());
        }

        [Test]
        public void BinarySearchTree_String_CustomComparer_PreOrder_IsCorrect()
        {
            int compare(string a, string b)
            {
                if (a.CompareTo(b) > 0) return 1;
                if (a.CompareTo(b) < 0) return -1;
                return 0;
            }

            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" }, Comparer<string>.Create(compare));
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, tree.PreOrder());
        }

        [Test]
        public void BinarySearchTree_String_DefaultComparer_PostOrder_IsCorrect()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" });
            CollectionAssert.AreEqual(new string[] { "2", "3", "4", "1" }, tree.PostOrder());
        }

        [Test]
        public void BinarySearchTree_String_CustomComparer_PostOrder_IsCorrect()
        {
            int compare(string a, string b)
            {
                if (a.CompareTo(b) > 0) return 1;
                if (a.CompareTo(b) < 0) return -1;
                return 0;
            }

            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" }, Comparer<string>.Create(compare));
            CollectionAssert.AreEqual(new string[] { "2", "3", "4", "1" }, tree.PostOrder());
        }

        [TestCase("3", ExpectedResult = true)]
        [TestCase("0", ExpectedResult = false)]
        public bool BinarySearchTree_String_Contains_IsCorrect(string number)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "1", "2", "3", "4" });
            return tree.Contains(number);
        }
        #endregion

        #region Book tests
        [Test]
        public void BinarySearchTree_DifferentCtor_Book_IsCorrect()
        {
            BinarySearchTree<Book> actual = new BinarySearchTree<Book>();
            Book[] books = { new Book(1), new Book(2) };
            actual.InsertRange(books);
            BinarySearchTree<Book> expected = new BinarySearchTree<Book>(books);
            CollectionAssert.AreEqual(expected.InOrder(), actual.InOrder());
        }

        [Test]
        public void BinarySearchTree_Book_DefaultComparer_InOrder_IsCorrect()
        {
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books);
            CollectionAssert.AreEqual(books, tree.InOrder());
        }

        [Test]
        public void BinarySearchTree_Book_CustomComparer_InOrder_IsCorrect()
        {
            int compare(Book a, Book b)
            {
                if (a.Cost > b.Cost) return 1;
                if (a.Cost < b.Cost) return -1;
                return 0;
            }
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books, Comparer<Book>.Create(compare));
            CollectionAssert.AreEqual(books, tree.InOrder());
        }

        [Test]
        public void BinarySearchTree_Book_DefaultComparer_PreOrder_IsCorrect()
        {
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books);
            CollectionAssert.AreEqual(books, tree.PreOrder());
        }

        [Test]
        public void BinarySearchTree_Book_CustomComparer_PreOrder_IsCorrect()
        {
            int compare(Book a, Book b)
            {
                if (a.Cost > b.Cost) return 1;
                if (a.Cost < b.Cost) return -1;
                return 0;
            }
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books, Comparer<Book>.Create(compare));
            CollectionAssert.AreEqual(books, tree.PreOrder());
        }

        [Test]
        public void BinarySearchTree_Book_DefaultComparer_PostOrder_IsCorrect()
        {
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books);
            CollectionAssert.AreEqual(new Book[] { books[1], books[2], books[3], books[0] }, tree.PostOrder());
        }

        [Test]
        public void BinarySearchTree_Book_CustomComparer_PostOrder_IsCorrect()
        {
            int compare(Book a, Book b)
            {
                if (a.Cost > b.Cost) return 1;
                if (a.Cost < b.Cost) return -1;
                return 0;
            }
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books, Comparer<Book>.Create(compare));
            CollectionAssert.AreEqual(new Book[] { books[1], books[2], books[3], books[0] }, tree.PostOrder());
        }

        [TestCase(3, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        public bool BinarySearchTree_Book_Contains_IsCorrect(int data)
        {
            Book searched = new Book(data);
            Book[] books = { new Book(1), new Book(2), new Book(3), new Book(4) };
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books);

            return tree.Contains(searched);
        }
        #endregion

        #region Point tests
        //will be added soon
        #endregion
    }
}