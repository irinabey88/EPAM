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
            string[] result = { "adcd", "dfge", "rt", "rtyeuyyu", "aaaaa" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault());
            binarySearchTree.Add("adcd");
            binarySearchTree.Add("dfge");
            binarySearchTree.Add("aaaaa");
            binarySearchTree.Add("rt");
            binarySearchTree.Add("rtyeuyyu");

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
            string[] result = { "adcd", "dfge", "rt", "rtyeuyyu", "aaaaa" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault());
            binarySearchTree.Add("adcd");
            binarySearchTree.Add("dfge");
            binarySearchTree.Add("aaaaa");
            binarySearchTree.Add("rt");
            binarySearchTree.Add("rtyeuyyu");

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
            string[] result = { "rtyeuyyu", "rt", "dfge", "aaaaa", "adcd" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault());
            binarySearchTree.Add("adcd");
            binarySearchTree.Add("dfge");
            binarySearchTree.Add("aaaaa");
            binarySearchTree.Add("rt");
            binarySearchTree.Add("rtyeuyyu");

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
            string[] result = { "rtyeuyyu", "aaaaa", "dfge", "rt", "adcd", };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringLength());
            binarySearchTree.Add("adcd");
            binarySearchTree.Add("dfge");
            binarySearchTree.Add("aaaaa");
            binarySearchTree.Add("rt");
            binarySearchTree.Add("rtyeuyyu");

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
            string[] result = { "rtyeuyyu", "rt", "dfge", "adcd", "aaaaa" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringDefault());
            binarySearchTree.Add("adcd");
            binarySearchTree.Add("dfge");
            binarySearchTree.Add("aaaaa");
            binarySearchTree.Add("rt");
            binarySearchTree.Add("rtyeuyyu");

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
            string[] result = { "rtyeuyyu", "aaaaa", "dfge", "adcd", "rt" };

            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(new ComparerStringLength());
            binarySearchTree.Add("adcd");
            binarySearchTree.Add("dfge");
            binarySearchTree.Add("aaaaa");
            binarySearchTree.Add("rt");
            binarySearchTree.Add("rtyeuyyu");

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
