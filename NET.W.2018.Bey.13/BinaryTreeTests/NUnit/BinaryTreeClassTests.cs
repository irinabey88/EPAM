using BinaryTree;
using BinaryTreeTests.Comparer;
using BinaryTreeTests.Comparer.Class;
using BinaryTreeTests.CustomObject;
using NUnit.Framework;

namespace BinaryTreeTests.NUnit
{
    [TestFixture]
    public class BinaryTreeClassTests
    {
        [Test]
        public void BinaryTree_Create_DefaultBookComparer_Preoder_Test()
        {
            var book1 = new Book { Author = "ivanov", ISBN = "11111", Name = "book1", Price = 145, Year = 2000 };
            var book2 = new Book { Author = "petrov", ISBN = "1", Name = "book2", Price = 14, Year = 1988 };
            var book3 = new Book { Author = "sidorov", ISBN = "7899", Name = "book3", Price = 456, Year = 1993 };
            var book4 = new Book { Author = "gromov", ISBN = "4562", Name = "book4", Price = 789, Year = 2013 };
            var book5 = new Book { Author = "samoilov", ISBN = "666", Name = "book5", Price = 234, Year = 2014 };

            Book[] result = { book1, book2, book3, book4, book5 };

            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(new ComparerBookDefault(), book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);
            binarySearchTree.Insert(book4);
            binarySearchTree.Insert(book5);

            Book[] array = new Book[5];
            var i = 0;

            foreach (var node in binarySearchTree.Preorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_CustomBookComparer_Preoder_Test()
        {
            var book1 = new Book { Author = "ivanov", ISBN = "11111", Name = "book1", Price = 145, Year = 2000 };
            var book2 = new Book { Author = "petrov", ISBN = "1", Name = "book2", Price = 14, Year = 1988 };
            var book3 = new Book { Author = "sidorov", ISBN = "7899", Name = "book3", Price = 456, Year = 1993 };
            var book4 = new Book { Author = "gromov", ISBN = "4562", Name = "book4", Price = 789, Year = 2013 };
            var book5 = new Book { Author = "samoilov", ISBN = "666", Name = "book5", Price = 234, Year = 2014 };

            Book[] result = { book1, book2, book3, book4, book5 };

            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(new CompareBookCustom(), book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);
            binarySearchTree.Insert(book4);
            binarySearchTree.Insert(book5);

            Book[] array = new Book[5];
            var i = 0;

            foreach (var node in binarySearchTree.Preorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_DefaultBookComparer_Postoder_Test()
        {
            var book1 = new Book { Author = "ivanov", ISBN = "11111", Name = "book1", Price = 145, Year = 2000 };
            var book2 = new Book { Author = "petrov", ISBN = "1", Name = "book2", Price = 14, Year = 1988 };
            var book3 = new Book { Author = "sidorov", ISBN = "7899", Name = "book3", Price = 456, Year = 1993 };
            var book4 = new Book { Author = "gromov", ISBN = "4562", Name = "book4", Price = 789, Year = 2013 };
            var book5 = new Book { Author = "samoilov", ISBN = "666", Name = "book5", Price = 234, Year = 2014 };

            Book[] result = { book2, book1, book4, book5, book3 };

            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(new ComparerBookDefault(), book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);
            binarySearchTree.Insert(book4);
            binarySearchTree.Insert(book5);

            Book[] array = new Book[5];
            var i = 0;

            foreach (var node in binarySearchTree.Postoder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_DefaultIntComparer_Inorder_Test()
        {
            var book1 = new Book { Author = "ivanov", ISBN = "11111", Name = "book1", Price = 145, Year = 2000 };
            var book2 = new Book { Author = "petrov", ISBN = "1", Name = "book2", Price = 14, Year = 1988 };
            var book3 = new Book { Author = "sidorov", ISBN = "7899", Name = "book3", Price = 456, Year = 1993 };
            var book4 = new Book { Author = "gromov", ISBN = "4562", Name = "book4", Price = 789, Year = 2013 };
            var book5 = new Book { Author = "samoilov", ISBN = "666", Name = "book5", Price = 234, Year = 2014 };

            Book[] result = { book1, book2, book3, book4, book5 };

            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(new ComparerBookDefault(), book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);
            binarySearchTree.Insert(book4);
            binarySearchTree.Insert(book5);

            Book[] array = new Book[5];
            var i = 0;

            foreach (var node in binarySearchTree.Inorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_CustomIntComparer_Inorder_Test()
        {
            var book1 = new Book { Author = "ivanov", ISBN = "11111", Name = "book1", Price = 145, Year = 2000 };
            var book2 = new Book { Author = "petrov", ISBN = "1", Name = "book2", Price = 14, Year = 1988 };
            var book3 = new Book { Author = "sidorov", ISBN = "7899", Name = "book3", Price = 456, Year = 1993 };
            var book4 = new Book { Author = "gromov", ISBN = "4562", Name = "book4", Price = 789, Year = 2013 };
            var book5 = new Book { Author = "samoilov", ISBN = "666", Name = "book5", Price = 234, Year = 2014 };

            Book[] result = { book1, book2, book4, book3, book5 };

            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(new CompareBookCustom(), book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);
            binarySearchTree.Insert(book4);
            binarySearchTree.Insert(book5);

            Book[] array = new Book[5];
            var i = 0;

            foreach (var node in binarySearchTree.Inorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }
    }
}
