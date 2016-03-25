namespace LinkedListTests
{
    using System;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void Test_CreateEmptyDynamicList_ShouldHaveNoItemsAndZeroCount()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();

            // Act

            // Assert
            Assert.IsNotNull(dynamicList, "Created list should not be null.");
            Assert.AreEqual(0, dynamicList.Count, "Created list should have 0 elements.");
        }

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
            Assert.AreEqual(resultListLength, dynamicList.Count,
                string.Format("The number of elements of list should be {0}.", resultListLength));
            Assert.AreEqual(element, dynamicList[elementIndex],
                string.Format("The added element is not with index {0}", elementIndex));
        }

        [TestMethod]
        public void Test_AddMultipleElementsToEmptyDynamicList_DynamicListLengthShouldBeTheNumberOfAddedElements()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var elements = new string[] {"Pesho", "Tosho", "Gosho", "Milka"};
            int resultListLength = elements.Length;

            // Act
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
                var lastIndex = dynamicList.Count - 1;
                Assert.AreEqual(elements[i], dynamicList[lastIndex],
                    string.Format("The last added element is not with last index {0}", lastIndex));
            }

            // Assert
            Assert.AreEqual(resultListLength, dynamicList.Count,
                string.Format("The number of elements of list should be {0}.", resultListLength));
        }

        [TestMethod]
        public void
            Test_AddElementToNonEmptyDynamicList_TheListLengthShouldBeIncrementedByOneAndAddedElementShouldHaveLastIndex
            ()
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
            Assert.AreEqual(resultListLength, dynamicList.Count,
                string.Format("The number of elements of list should be {0}.", resultListLength));
            Assert.AreEqual(secondElement, dynamicList[resultListLength - 1],
                string.Format("The added element is not with last index {0}", (resultListLength - 1)));
        }

        [TestMethod]
        public void
            Test_AddMultypleElementsToNonEmptyDynamicList_TheListLengthShouldBeIncrementedWithAddedElementsNumber()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            string firstElement = "Yoana";
            dynamicList.Add(firstElement);
            int initialListLength = dynamicList.Count;

            var elements = new string[] {"Pesho", "Tosho", "Gosho", "Milka"};
            int resultListLength = initialListLength + elements.Length;

            // Act
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
                var lastIndex = dynamicList.Count - 1;
                Assert.AreEqual(elements[i], dynamicList[lastIndex],
                    string.Format("The last added element is not with last index {0}", lastIndex));
            }

            // Assert
            Assert.AreEqual(resultListLength, dynamicList.Count,
                string.Format("The number of elements of list should be {0}.", resultListLength));
        }

        [TestMethod]
        public void Test_GetElementWithGivenIndexFromDynamicList_ShouldReturnRelevantElement()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var elements = new string[] {"pesho", "gosho", "mariika"};
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            int indexOfIntendedElement = 1;
            var expectedElement = elements[indexOfIntendedElement];

            // Act
            var resultElement = dynamicList[indexOfIntendedElement];

            // Assert
            Assert.AreEqual(expectedElement, resultElement,
                String.Format("The returned element is not {0}.", expectedElement));
        }

        /*[TestMethod]
        public void Test_GetSeveralElementsFromDynamicList_ShouldReturnRelevantElements()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var elements = new string[] { "pesho", "gosho", "mariika", "Gloria", "Magda", "Sevda" };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var startIndex = 2;
            var endIndex = 4;
            var receivedElements = new List<string>();

            // Act
            for (int index = startIndex; index <= endIndex; index++)
            {
                receivedElements.Add(dynamicList[index]);
            }

            // Assert
            Assert.AreEqual(secondString, resultElement, String.Format("The returned element is not {0}.", secondString));
        }*/

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Getting an element from empty list should throw an exception.")]
        public void Test_GetElementFromEmptyDynamicList_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            int index = 0;

            // Act
            var resultElement = dynamicList[index];
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Getting an element with negative index from list should throw an exception.")]
        public void Test_GetElementWithGivenNegativeIndexFromDynamicList_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var firstString = "pesho";

            dynamicList.Add(firstString);

            // Act
            var resultElement = dynamicList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Getting an element with index value which is equal to list length should throw an exception.")]
        public void Test_GetElementWithIndexEqualToDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var firstString = "pesho";

            dynamicList.Add(firstString);
            var dynamicListLength = dynamicList.Count;

            // Act
            var resultElement = dynamicList[dynamicListLength];
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Getting an element with index value which bigger than list length should throw an exception.")]
        public void Test_GetElementWithIndexBiggerThanDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var firstString = "pesho";

            dynamicList.Add(firstString);
            var dynamicListLength = dynamicList.Count;

            // Act
            var resultElement = dynamicList[dynamicListLength + 1];
        }

        [TestMethod]
        public void Test_SetElementInDynamicListWithGivenIndex_TheElementWithGivenIndexShouldHasTheSettedValue()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var elements = new string[] {"pesho", "gosho", "mariika"};
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            int indexOfIntendedElement = 1;
            string resultElement = "Yoana";

            // Act
            dynamicList[indexOfIntendedElement] = resultElement;

            // Assert
            Assert.AreEqual(resultElement, dynamicList[indexOfIntendedElement],
                string.Format("The element with index {0} from dynamic list was not setted with value {1}",
                    indexOfIntendedElement, resultElement));
        }

        /*[TestMethod]
        public void Test_SetMultipleElementsInDynamicList_TheRelevantElementsShouldHaveSettedValues()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var firstElement = "pesho";
            var secondElement = "gosho";
            var thirdElement = "mariika";
            var fourthElement = "milka";
            var fifthElement = "ganka";
            
            dynamicList.Add(firstElement);
            dynamicList.Add(secondElement);
            dynamicList.Add(thirdElement);
            dynamicList.Add(fourthElement);
            dynamicList.Add(fifthElement);

            int indexOfUnchangedElement = 0;
            int startIndex = 1;
            int endIndex = 4;
            string resultElement = "Yoana";

            // Act
            for (int index = startIndex; index <= endIndex; index++)
            {
                dynamicList[index] = resultElement;
            }

            // Assert
            for (int index = startIndex; index < endIndex; index++)
            {
                Assert.AreEqual(resultElement, dynamicList[index], string.Format("The element with index {0} from dynamic list does not have the result value", index));
            }

            Assert.AreEqual(firstElement, dynamicList[indexOfUnchangedElement], string.Format("The element with index {0} from dynamic list shouldn't be changed.", indexOfUnchangedElement));
        }*/

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Setting an element with negative index in the list should throw an exception.")]
        public void Test_SetElementInDynamicListWithNegativeIndex_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var firstElement = "pesho";

            dynamicList.Add(firstElement);

            int index = -1;
            string resultElement = "Yoana";

            // Act
            dynamicList[index] = resultElement;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Setting an element with index value which is equal to list length should throw an exception.")]
        public void Test_SetElementWithIndexEqualToDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var firstElement = "pesho";

            dynamicList.Add(firstElement);

            int index = dynamicList.Count;
            string resultElement = "Yoana";

            // Act
            dynamicList[index] = resultElement;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Setting an element with index value which is bigger than list length should throw an exception.")]
        public void Test_SetElementWithIndexBiggerThanDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            var firstElement = "pesho";

            dynamicList.Add(firstElement);

            int index = dynamicList.Count + 1;
            string resultElement = "Yoana";

            // Act
            dynamicList[index] = resultElement;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Getting an element from empty list should throw an exception.")]
        public void Test_SetElementInEmptyDynamicList_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<string>();
            int index = 0;
            var resultElement = "Yoana";

            // Act
            dynamicList[index] = resultElement;
        }

        [TestMethod]
        public void Test_RemoveElementAtGivenIndexFromDynamicList_ShouldRemoveFromListAndReturnTheElement()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] {1, 2, 3, 5, 8, 7};
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
            Assert.AreEqual(intendedElement, resultElement,
                string.Format("The element with index {0} from dynamic list was not returned.", indexOfIntendedElement));
            Assert.AreNotEqual(intendedElement, dynamicList[indexOfIntendedElement],
                string.Format("The element with index {0} from dynamic list was not removed.", indexOfIntendedElement));
            Assert.AreEqual(resultListLength, dynamicList.Count, "The length of dynamic list was not reduced with 1.");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Removing an element with index value which is bigger than list length should throw an exception.")]
        public void Test_RemoveElementWithNegativeIndexFromDynamicList_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] {1, 2, 3, 5, 8, 7};
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = -1;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Removing an element with index which is equal to list length should throw an exception.")]
        public void Test_RemoveElementWithIndexEqualToDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] {1, 2, 3, 5, 8, 7};
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = dynamicList.Count;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Removing an element with index value which is bigger than list length should throw an exception.")]
        public void Test_RemoveElementWithIndexBiggerThanDynamicListLength_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] {1, 2, 3, 5, 8, 7};
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = dynamicList.Count + 1;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Removing an element with given index from empty list length should throw an exception.")]
        public void Test_RemoveElementAtGivenIndexFromEmptyDynamicList_ShouldThrowException()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();

            var indexOfIntendedElement = dynamicList.Count + 1;

            // Act
            var resultElement = dynamicList.RemoveAt(indexOfIntendedElement);
        }

        [TestMethod]
        public void Test_RemoveExistingElementFromDynamicList_ShouldRemoveTheElementAndReturnItsIndex()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] {1, 2, 3, 5, 8, 7};
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendedElement = 2;
            var intendedElement = dynamicList[indexOfIntendedElement];

            var resultListLength = dynamicList.Count - 1;

            // Act
            var resultIndex = dynamicList.Remove(intendedElement);

            // Assert
            Assert.AreEqual(indexOfIntendedElement, resultIndex, "The index of removed element from list was not returned.");
            Assert.AreNotEqual(intendedElement, dynamicList[indexOfIntendedElement], string.Format("The element with index {0} from dynamic list was not removed.", indexOfIntendedElement));
            Assert.AreEqual(resultListLength, dynamicList.Count, "The length of dynamic list was not reduced with 1.");
        }
        
        [TestMethod]
        public void Test_RemoveNonExistingElementFromDynamicList_ShouldReturnMinusOne()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] {1, 2, 3, 5, 8, 7};
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var intendedElement = 4;
            var expectedResultIndex = -1;
            var expectedResultListLength = dynamicList.Count;

            // Act
            var actualResultIndex = dynamicList.Remove(intendedElement);

            // Assert
            Assert.AreEqual(expectedResultIndex, actualResultIndex, "The return result is not -1.");
            Assert.AreEqual(expectedResultListLength, dynamicList.Count, "The length of dynamic list should be the same after method calling.");
        } 
        
        [TestMethod]
        public void Test_RemoveElementFromEmptyDynamicList_ShouldReturnMinusOne()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var intendedElement = 4;
            var expectedResultIndex = -1;

            // Act
            var actualResultIndex = dynamicList.Remove(intendedElement);

            // Assert
            Assert.AreEqual(expectedResultIndex, actualResultIndex, "The return result is not -1.");
        }
        
        [TestMethod]
        public void Test_FindIndexOfExistingElementInDynamicList_ShouldReturnTheIndexOfElement()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var indexOfIntendentElement = 2;
            var intendedElement = dynamicList[indexOfIntendentElement];

            // Act
            var actualResultIndex = dynamicList.IndexOf(intendedElement);

            // Assert
            Assert.AreEqual(indexOfIntendentElement, actualResultIndex, "The return actual result index is not the searched index of passed element.");
        }
        
        [TestMethod]
        public void Test_FindIndexOfNonExistingElementInDynamicList_ShouldReturnMinusOne()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var intendedElement = 4;
            var expectedResultIndex = -1;

            // Act
            var actualResultIndex = dynamicList.IndexOf(intendedElement);

            // Assert
            Assert.AreEqual(expectedResultIndex, actualResultIndex, "The return result is not -1.");
        }
        
        [TestMethod]
        public void Test_FindIndexOfElementInEmptyDynamicList_ShouldReturnMinusOne()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();

            var intendedElement = 4;
            var expectedResultIndex = -1;

            // Act
            var actualResultIndex = dynamicList.IndexOf(intendedElement);

            // Assert
            Assert.AreEqual(expectedResultIndex, actualResultIndex, "The return result is not -1.");
        }
        
        [TestMethod]
        public void Test_ContainsExistingElementInDynamicList_ShouldReturnTrue()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var intendedElement = 7;

            // Act
            var isFound = dynamicList.Contains(intendedElement);

            // Assert
            Assert.IsTrue(isFound, "The existing element was not found in the list - the result should be true.");
        }
        
        [TestMethod]
        public void Test_ContainsNonExistingElementInDynamicList_ShouldReturnFalse()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();
            var elements = new int[] { 1, 2, 3, 5, 8, 7 };
            for (int i = 0; i < elements.Length; i++)
            {
                dynamicList.Add(elements[i]);
            }

            var intendedElement = 4;

            // Act
            var isFound = dynamicList.Contains(intendedElement);

            // Assert
            Assert.IsFalse(isFound, "The non existing element was found in the list - the result should be false.");
        }
        
        [TestMethod]
        public void Test_ContainsElementInEmptyDynamicList_ShouldReturnFalse()
        {
            // Arrange
            var dynamicList = new DynamicList<int>();

            var intendedElement = 4;

            // Act
            var isFound = dynamicList.Contains(intendedElement);

            // Assert
            Assert.IsFalse(isFound, "The non existing element was found in the empty list - the result should be false.");
        }
    }
}
