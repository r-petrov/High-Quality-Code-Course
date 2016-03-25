namespace LinkedListTests
{
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    class MethodAddTests
    {
        [TestMethod]
        public void Test_AddElementToEmptyDynamicList_DynamicListShouldHaveOneElementWithIndexZero()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            string element = "Yoana";
            int elementIndex = 0;
            int resultListLength = 1;

            // Act
            dynamicList.Add(element);

            // Assert
            Assert.AreEqual(resultListLength, dynamicList.Count, string.Format("The number of elements of list should be {0}.", resultListLength));
            Assert.AreEqual(element, dynamicList[elementIndex], string.Format("The added element is not with index {0}", elementIndex));
        }

        [TestMethod]
        public void Test_AddMultipleElementsToEmptyDynamicList_DynamicListLengthShouldBeTheNumberOfAddedElements()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var elements = new string[] { "Pesho", "Tosho", "Gosho", "Milka" };
            int resultListLength = elements.Length;

            // Act
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
                var lastIndex = dynamicList.Count - 1;
                Assert.AreEqual(elements[i], dynamicList[lastIndex], string.Format("The last added element is not with last index {0}", lastIndex));
            }

            // Assert
            Assert.AreEqual(resultListLength, dynamicList.Count, string.Format("The number of elements of list should be {0}.", resultListLength));
        }

        [TestMethod]
        public void Test_AddElementToNonEmptyDynamicList_TheListLengthShouldBeIncrementedByOneAndAddedElementShouldHaveLastIndex()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            string firstElement = "Yoana";
            dynamicList.Add(firstElement);
            int initialListLength = dynamicList.Count;

            string secondElement = "Pesho";
            int resultListLength = initialListLength + 1;

            // Act
            dynamicList.Add(secondElement);

            // Assert
            Assert.AreEqual(resultListLength, dynamicList.Count, string.Format("The number of elements of list should be {0}.", resultListLength));
            Assert.AreEqual(secondElement, dynamicList[resultListLength - 1], string.Format("The added element is not with last index {0}", (resultListLength - 1)));
        }

        [TestMethod]
        public void Test_AddMultypleElementsToNonEmptyDynamicList_TheListLengthShouldBeIncrementedWithAddedElementsNumber()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            string firstElement = "Yoana";
            dynamicList.Add(firstElement);
            int initialListLength = dynamicList.Count;

            var elements = new string[] { "Pesho", "Tosho", "Gosho", "Milka" };
            int resultListLength = initialListLength + elements.Length;

            // Act
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
                var lastIndex = dynamicList.Count - 1;
                Assert.AreEqual(elements[i], dynamicList[lastIndex], string.Format("The last added element is not with last index {0}", lastIndex));
            }

            // Assert
            Assert.AreEqual(resultListLength, dynamicList.Count, string.Format("The number of elements of list should be {0}.", resultListLength));
        }
    }
}
