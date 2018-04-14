using BinaryTree;
using BinaryTreeTests.Comparer.StringComparer;
using BinaryTreeTests.Comparer.Struct;
using BinaryTreeTests.CustomObject;
using NUnit.Framework;

namespace BinaryTreeTests.NUnit
{
    [TestFixture]
    public class BinaryTreeStructTests
    {
        [Test]
        public void BinaryTree_Create_StructComparer_Preoder_Test()
        {
            Point[] result = {new Point(1,2), new Point(-1, 3), new Point(-4, 2), new Point(3, 4), new Point(7,8) };

            BinarySearchTree<Point> binarySearchTree =new BinarySearchTree<Point>(new ComparerStruct(), new Point(1, 2));
            binarySearchTree.Insert(new Point(3, 4));
            binarySearchTree.Insert(new Point(-1, 3));
            binarySearchTree.Insert(new Point(-4, 2));
            binarySearchTree.Insert(new Point(7, 8));

            Point[] array = new Point[5];
            var i = 0;

            foreach (var node in binarySearchTree.Preorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_StructComparer_Postoder_Test()
        {
            Point[] result = { new Point(-4, 2), new Point(-1, 3), new Point(1, 2), new Point(7, 8), new Point(3, 4) };

            BinarySearchTree<Point> binarySearchTree = new BinarySearchTree<Point>(new ComparerStruct(), new Point(1, 2));
            binarySearchTree.Insert(new Point(3, 4));
            binarySearchTree.Insert(new Point(-1, 3));
            binarySearchTree.Insert(new Point(-4, 2));
            binarySearchTree.Insert(new Point(7, 8));

            Point[] array = new Point[5];
            var i = 0;

            foreach (var node in binarySearchTree.Postoder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void BinaryTree_Create_StructComparer_Inorder_Test()
        {
            Point[] result = { new Point(1, 2), new Point(-1, 3), new Point(3, 4), new Point(-4, 2), new Point(7, 8) };

            BinarySearchTree<Point> binarySearchTree = new BinarySearchTree<Point>(new ComparerStruct(), new Point(1, 2));
            binarySearchTree.Insert(new Point(3, 4));
            binarySearchTree.Insert(new Point(-1, 3));
            binarySearchTree.Insert(new Point(-4, 2));
            binarySearchTree.Insert(new Point(7, 8));

            Point[] array = new Point[5];
            var i = 0;

            foreach (var node in binarySearchTree.Inorder)
            {
                array[i++] = node;
            }

            CollectionAssert.AreEqual(array, result);
        }
    }
}