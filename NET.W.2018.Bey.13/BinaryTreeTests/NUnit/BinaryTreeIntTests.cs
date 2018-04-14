using BinaryTree;
using BinaryTreeTests.Comparer;
using NUnit.Framework;

namespace BinaryTreeTests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void BinaryTree_Create_CustomIntComparer_Preoder_Test()
        {
            int[] result = { 1, 3, 8, 10, -5 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntCustom(), 1);
            binarySearchTree.Insert(3);           
            binarySearchTree.Insert(-5);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(10);

            int[] array = new int[5];
            var i = 0;

            foreach (var node in binarySearchTree.Preorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_DefaultIntComparer_Preoder_Test()
        {
            int[] result = { 1, -5, 3, 8, 10 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntDefault(), 1);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(-5);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(10);

            int[] array = new int[5];
            var i = 0;

            foreach (var node in binarySearchTree.Preorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_DefaultIntComparer_Postoder_Test()
        {
            int[] result = { -5, 1, 10, 8, 3 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntDefault(), 1);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(-5);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(10);

            int[] array = new int[5];
            var i = 0;

            foreach (var node in binarySearchTree.Postoder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_CustomIntComparer_Postoder_Test()
        {
            int[] result = { 10, 8, 3, 1, -5 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntCustom(), 1);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(-5);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(10);

            int[] array = new int[5];
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
            int[] result = { 1, -5, 3, 8, 10 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntDefault(), 1);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(-5);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(10);

            int[] array = new int[5];
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
            int[] result = { 1, 3, -5, 8, 10 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntCustom(), 1);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(-5);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(10);

            int[] array = new int[5];
            var i = 0;

            foreach (var node in binarySearchTree.Inorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }
    }
}
