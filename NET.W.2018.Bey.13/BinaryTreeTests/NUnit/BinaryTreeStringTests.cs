using BinaryTree;
using BinaryTreeTests.Comparer;
using BinaryTreeTests.Comparer.StringComparer;
using NUnit.Framework;

namespace BinaryTreeTests.NUnit
{
    [TestFixture]
    public class BinaryTreeStringTests
    {
        [Test]
        public void BinaryTree_Create_CustomStringComparer_Preoder_Test()
        {
            string[] result = { "adcd", "aaaaa", "dfge", "rt", "rtyeuyyu" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault(), "adcd");
            binarySearchTree.Insert("dfge");
            binarySearchTree.Insert("aaaaa");
            binarySearchTree.Insert("rt");
            binarySearchTree.Insert("rtyeuyyu");

            string[] array = new string[5];
            var i = 0;

            foreach (var node in binarySearchTree.Preorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_DefaultStringComparer_Preoder_Test()
        {
            string[] result = { "adcd", "aaaaa", "dfge", "rt", "rtyeuyyu" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault(), "adcd");
            binarySearchTree.Insert("dfge");
            binarySearchTree.Insert("aaaaa");
            binarySearchTree.Insert("rt");
            binarySearchTree.Insert("rtyeuyyu");

            string[] array = new string[5];
            var i = 0;

            foreach (var node in binarySearchTree.Preorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_DefaultStringComparer_Postoder_Test()
        {
            string[] result = { "aaaaa", "adcd", "rtyeuyyu", "rt", "dfge" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault(), "adcd");
            binarySearchTree.Insert("dfge");
            binarySearchTree.Insert("aaaaa");
            binarySearchTree.Insert("rt");
            binarySearchTree.Insert("rtyeuyyu");

            string[] array = new string[5];
            var i = 0;

            foreach (var node in binarySearchTree.Postoder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_CustomStringComparer_Postoder_Test()
        {
            string[] result = { "rt", "adcd", "rtyeuyyu", "aaaaa", "dfge" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringLength(), "adcd");
            binarySearchTree.Insert("dfge");
            binarySearchTree.Insert("aaaaa");
            binarySearchTree.Insert("rt");
            binarySearchTree.Insert("rtyeuyyu");

            string[] array = new string[5];
            var i = 0;

            foreach (var node in binarySearchTree.Postoder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_DefaultStringComparer_Inorder_Test()
        {
            string[] result = { "adcd", "aaaaa", "dfge", "rt", "rtyeuyyu" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault(), "adcd");
            binarySearchTree.Insert("dfge");
            binarySearchTree.Insert("aaaaa");
            binarySearchTree.Insert("rt");
            binarySearchTree.Insert("rtyeuyyu");

            string[] array = new string[5];
            var i = 0;

            foreach (var node in binarySearchTree.Inorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_CustomStringComparer_Inorder_Test()
        {
            string[] result = { "adcd", "rt", "dfge", "aaaaa", "rtyeuyyu" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringLength(), "adcd");
            binarySearchTree.Insert("dfge");
            binarySearchTree.Insert("aaaaa");
            binarySearchTree.Insert("rt");
            binarySearchTree.Insert("rtyeuyyu");

            string[] array = new string[5];
            var i = 0;

            foreach (var node in binarySearchTree.Inorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }
    }
}
