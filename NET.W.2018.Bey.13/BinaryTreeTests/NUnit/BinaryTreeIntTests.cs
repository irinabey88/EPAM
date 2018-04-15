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
            int[] result = { 1, -5, 3, 8, 10 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntCustom());
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);           
            binarySearchTree.Add(-5);
            binarySearchTree.Add(8);
            binarySearchTree.Add(10);

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
            int[] result = { 1, 3, 8, 10, - 5 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntDefault());
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);
            binarySearchTree.Add(-5);
            binarySearchTree.Add(8);
            binarySearchTree.Add(10);

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
            int[] result = { 10, 8, 3, -5, 1 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntDefault());
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);
            binarySearchTree.Add(-5);
            binarySearchTree.Add(8);
            binarySearchTree.Add(10);

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
            int[] result = { -5, 10, 8, 3, 1 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntCustom());
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);
            binarySearchTree.Add(-5);
            binarySearchTree.Add(8);
            binarySearchTree.Add(10);

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
            int[] result = { 10, 8, 3, 1, -5 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntDefault());
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);
            binarySearchTree.Add(-5);
            binarySearchTree.Add(8);
            binarySearchTree.Add(10);

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
            int[] result = { -5, 1, 3, 8, 10 };

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(new ComparerIntCustom());
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);
            binarySearchTree.Add(-5);
            binarySearchTree.Add(8);
            binarySearchTree.Add(10);

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
