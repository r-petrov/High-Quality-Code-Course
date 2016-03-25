namespace LinkedListTests
{
    using System;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    class MethodRemoveAtTests
    {
        [TestMethod]
        public void Test_RemoveElementAtGivenIndexFromDynamicList_ShouldRemoveFromListAndReturnTheElement()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = 1;
            var intendedElement = dynamicList[indexOfIntendedElement];
            var resultListLength = dynamicList.Count - 1;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);

            // Assert
            Assert.AreEqual(intendedElement, resultElement, string.Format("The element with index {0} from dynamic list was not returned.", indexOfIntendedElement));
            Assert.AreEqual(resultListLength, dynamicList.Count, "The intended element was not returned from dynamic list.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Removing an element with index value which is bigger than list length should throw an exception.")]
        public void Test_RemoveElementWithNegativeIndexFromDynamicList_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = -1;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Removing an element with index which is equal to list length should throw an exception.")]
        public void Test_RemoveElementWithIndexEqualToDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = dynamicList.Count;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Removing an element with index value which is bigger than list length should throw an exception.")]
        public void Test_RemoveElementWithIndexBiggerThanDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = dynamicList.Count + 1;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Removing an element with given index from empty list length should throw an exception.")]
        public void Test_RemoveElementAtGivenIndexFromEmptyDynamicList_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();

            var indexOfIntendedElement = dynamicList.Count + 1;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }
    }
}
