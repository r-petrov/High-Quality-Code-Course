using System.Collections.Generic;
using System.Linq;

namespace SoftUni.Collections.Generic.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StackTests
    {
        private const int DefaultStackCapacity = 4;

        [TestMethod]
        public void Test_CreateEmptyStack_ShouldHaveNoEmptyItems()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            // Nothing here

            // Assert
            Assert.IsNotNull(stack);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(DefaultStackCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Test_CreateStackWithGivenCapacity_ShouldHaveNoEmptyItems()
        {
            // Arrange
            int capacity = 10;
            var stack = new Stack<int>(capacity);

            // Act
            // Nothing here

            // Assert
            Assert.IsNotNull(stack);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(capacity, stack.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Stack with non-positive capacity should throw an exceptions.")]
        public void Test_CreateStackWithZeroCapacity_ShouldHaveNoEmptyItems()
        {
            // Arrange
            int capacity = 0;
            var stack = new Stack<int>(capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Stack with non-positive capacity should throw an exceptions.")]
        public void Test_CreateStackWithNegativeCapacity_ShouldThrowException()
        {
            // Arrange
            int capacity = -10;
            var stack = new Stack<int>(capacity);
        }

        [TestMethod]
        public void Test_PushToEmptyStack_ShouldAddTheItem()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Push(1);

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void Test_PushManyItemsToEmptyStack_ShouldAddAllItems()
        {
            // Arrange
            var stack = new Stack<int>();
            int maxItems = 10;

            // Act
            for (int item = 0; item < maxItems; item++)
            {
                stack.Push(item);
            }

            // Assert
            Assert.AreEqual(maxItems, stack.Count);
        }

        [TestMethod]
        public void Test_PushNullItemsToEmptyStack_ShouldAddAllItems()
        {
            // Arrange
            var stack = new Stack<string>();
            int maxItems = 10;

            // Act
            for (int item = 0; item < maxItems; item++)
            {
                stack.Push(null);
            }

            // Assert
            Assert.AreEqual(maxItems, stack.Count);
        }

        [TestMethod]
        public void Test_PopItemFromStack_ShouldReturnTheItem()
        {
            // Arrange
            var stack = new Stack<int>();
            int expectedTopValue = 5;
            stack.Push(expectedTopValue);

            // Act
            int actualTopValue = stack.Pop();

            // Assert
            Assert.AreEqual(expectedTopValue, actualTopValue);
        }

        [TestMethod]
        public void Test_PopManyItemsFromStack_ShouldBeInCorrectOrder()
        {
            // Arrange
            var stack = new Stack<int>();
            int maxItems = 10;
            int[] expectedItems = new int[maxItems];
            for (int item = 1; item <= maxItems; item++)
            {
                stack.Push(item);
                expectedItems[item - 1] = item;
            }

            Array.Reverse(expectedItems);

            // Act
            var returnedItems = new List<int>();
            for (int index = 0; index < maxItems; index++)
            {
                int poppedItem = stack.Pop();
                returnedItems.Add(poppedItem);
            }

            // Assert
            CollectionAssert.AreEqual(expectedItems, returnedItems);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PopFromEmptyStack_ShouldThrowException()
        {
            // Arrange
            var stack = new Stack<int>();
            
            // Act
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_TooManyPopsFromStack_ShouldThrowException()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            for (int i = 0; i < 3; i++)
            {
                stack.Pop(); 
            }
        }
        
        [TestMethod]
        public void Test_PeekInStack_ShouldReturnTheItem()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            int item = stack.Peek();

            // Assert
            Assert.AreEqual(2, item);
            Assert.AreEqual(2, stack.Count);
        }
    }
}
