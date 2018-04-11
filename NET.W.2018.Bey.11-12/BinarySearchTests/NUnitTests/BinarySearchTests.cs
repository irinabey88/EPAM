using System;

namespace BinarySearchTests.NUnitTests
{
    using BinarySearch;
    using Comparers;
    using Models;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(new[] { 1, 2, 3, 6, 10, 75 }, 6,  ExpectedResult = 3)]
        [TestCase(new[] { -10, -2, 8, 17, 70, 75 }, -2, ExpectedResult = 1)]
        [TestCase(new[] { -10, -2, 8, 17, 70, 75 }, 1, ExpectedResult = -1)]
        public int Search_ValidData_Int_Test(int[] array, int element)
        {
            return BinarySearch<int>.Search(element, array, new ComparerInt());
        }

        [TestCase(new[] { "a", "b", "c", "d", "e" }, "e", ExpectedResult = 4)]
        [TestCase(new[] { "a", "b", "c", "d", "e" }, "j", ExpectedResult = -1)]
        public int Search_ValidData_String_Test(string[] array, string element)
        {
            return BinarySearch<string>.Search(element, array, new ComparerString());
        }

        [Test]
        public void Search_ValidData_ReferenceTypeObject_Test()
        {
            var testObj = new TestModel("a", 2);
            ComparerTestModel testComparer = new ComparerTestModel();
            TestModel[] testArray = { new TestModel("b", 18), testObj, new TestModel("c", 20) };

            Assert.AreEqual(BinarySearch<TestModel>.Search(testObj, testArray, testComparer), 1); 
        }

        [Test]
        public void Search_InvalidData_ArrayNull_Test()
        {
            var testObj = new TestModel("a", 2);
            ComparerTestModel testComparer = new ComparerTestModel();            

            Assert.Throws<ArgumentNullException>(() => BinarySearch<TestModel>.Search(testObj, null, testComparer));
        }

        [Test]
        public void Search_InvalidData_EmptyArray_Test()
        {
            var testObj = new TestModel("a", 2);
            ComparerTestModel testComparer = new ComparerTestModel();
            TestModel[] testArray = { };

            Assert.Throws<ArgumentException>(() => BinarySearch<TestModel>.Search(testObj, testArray, testComparer));
        }

        [Test]
        public void Search_InvalidData_NullComparerValue_Test()
        {
            var testObj = new TestModel("a", 2);
            TestModel[] testArray = { testObj };

            Assert.Throws<ArgumentNullException>(() => BinarySearch<TestModel>.Search(testObj, testArray, null));
        }
    }   
}
