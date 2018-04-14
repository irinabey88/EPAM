using System;
using CustomQueue;
using NUnit.Framework;

namespace CustomQueueTests.NUnit
{
    [TestFixture]
    public class CustomQueueTests
    {
        [Test]
        public void CustomQueue_Constructor_Int_Test()
        {
            var customQueue = new CustomQueue<int>();

            Assert.AreEqual(customQueue.Capacity, 8);           
            Assert.AreEqual(customQueue.Count, 0);
        }

        [Test]
        public void CustomQueue_Enqueue_Int_Test()
        {
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);

            Assert.AreEqual(customQueue.Capacity, 8);
            Assert.AreEqual(customQueue.Count, 5);
        }

        [Test]
        public void CustomQueue_Peek_Int_Test()
        {
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);

            Assert.AreEqual(customQueue.Peek(), 1);            
        }

        [Test]
        public void CustomQueue_Dequeue_Int_Test()
        {
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(7);

            Assert.AreEqual(customQueue.Deque(), 1);
            Assert.AreEqual(customQueue.Count, 6);            
        }

        [Test]
        public void CustomQueue_Contains_Int_Test()
        {
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(7);

            Assert.IsTrue(customQueue.Contains(4));
            Assert.IsFalse(customQueue.Contains(18));
        }

        [Test]
        public void CustomQueue_Clear_Int_Test()
        {
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(7);
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(7);

            Assert.AreEqual(customQueue.Capacity, 16);
            Assert.AreEqual(customQueue.Count, 14);

            customQueue.Clear();

            Assert.AreEqual(customQueue.Capacity, 8);
            Assert.AreEqual(customQueue.Count, 0);
        }

        [Test]
        public void CustomQueue_CopyTo_Int_Test()
        {
            var array = new[] { 7, 7, 7, 7, 7, 7, 7, 7 };
            var resultArray = new[] { 7, 7, 1, 2, 3, 4, 7, 7 };
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);

            customQueue.CopyTo(array, 2);
            
            CollectionAssert.AreEqual(array, resultArray);
        }

        [Test]
        public void CustomQueue_CopyTo_NullArray_Test()
        {           
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);

            Assert.Throws<ArgumentNullException>(() => customQueue.CopyTo(null, 2));
        }

        [Test]
        public void CustomQueue_CopyTo_InvalidIndex_NotEnoughPlaceForInsert_Test()
        {
            var array = new[] { 7, 7, 7, 7, 7, 7, 7, 7 };           
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);

            Assert.Throws<ArgumentException>(() => customQueue.CopyTo(array, 6));
        }

        [Test]
        public void CustomQueue_CopyTo_InvalidBigIndex_Test()
        {
            var array = new[] { 7, 7, 7, 7, 7, 7, 7, 7 };
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);

            Assert.Throws<InvalidOperationException>(() => customQueue.CopyTo(array, 20));
        }

        [Test]
        public void CustomQueue_CopyTo_NegativeIndex_Test()
        {
            var array = new[] { 7, 7, 7, 7, 7, 7, 7, 7 };
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);

            Assert.Throws<ArgumentOutOfRangeException>(() => customQueue.CopyTo(array, -2));
        }

        [Test]
        public void CustomQueue_ToArray_Int_Test()
        {
            var resultArray = new[] { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7 };
            var customQueue = new CustomQueue<int>();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(7);
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(7);

            CollectionAssert.AreEqual(customQueue.ToArray(), resultArray);
        }
    }
}
