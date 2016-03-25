using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Wintellect.PowerCollections;

namespace BigListTests
{
    [TestClass]
    public class InsertItemInBigListTests
    {
        [TestMethod]
        public void Test_InsertItemAtGivenIndexInNonEmptyBigList_ItemShouldHaveGivenIndex()
        {
            // Arrange
            int numberOfBigListItems = 7;
            int insertedItemIndex = 4;

            var bigList = new BigList<int>();
            var expextedItems = new List<int>();
            for (int item = 0; item < numberOfBigListItems; item++)
            {
                bigList.Add(item);
                if (item >= insertedItemIndex)
                {
                    expextedItems.Add(item);
                }
            }

            // Act
            int insertedItem = 8;
            var movedItems = new List<int>();
            bigList.Insert(insertedItemIndex, insertedItem);
            for (int index = insertedItemIndex + 1; index < bigList.Count; index++)
            {
                int item = bigList[index];
                movedItems.Add(item);
            }

            // Assert
            Assert.AreEqual(insertedItemIndex, bigList.IndexOf(insertedItem), "Inserted item does not have the given index.");
            Assert.AreEqual(numberOfBigListItems + 1, bigList.Count, "The count of big list items after operation insert is not increased with 1.");
            CollectionAssert.AreEqual(expextedItems, movedItems, "The items at indexes equal to or greater than given index do not move up one index.");
        }

        [TestMethod]
        public void Test_InsertItemAtIndexZeroInEmptyBigList_ItemShouldHaveIndexZero()
        {
            // Arrange
            int insertedItemIndex = 0;
            int insertedItem = 8;
            var bigList = new BigList<int>();
            
            // Act
            bigList.Insert(insertedItemIndex, insertedItem);

            // Assert
            Assert.AreEqual(insertedItemIndex, bigList.IndexOf(insertedItem), "Inserted item does not have index 0.");
            Assert.AreEqual(1, bigList.Count, "The count of big list items after insert operation insert is not 1.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_InsertItemAtGivenIndexInEmptyBigList_ExceptionShouldBeTrown()
        {
            // Arrange
            int insertedItemIndex = 1;
            int insertedItem = 8;
            var bigList = new BigList<int>();

            // Act
            bigList.Insert(insertedItemIndex, insertedItem);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_InsertItemWithNegativeIndexInBigList_ExceptionShouldBeTrown()
        {
            // Arrange
            int numberOfBigListItems = 7;
            int insertedItem = 8;
            int insertedItemIndex = -4;

            var bigList = new BigList<int>();
            for (int item = 0; item < numberOfBigListItems; item++)
            {
                bigList.Add(item);
            }

            // Act
            bigList.Insert(insertedItemIndex, insertedItem);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_InsertItemWithIndexGreaterThanBigListCount_ExceptionShouldBeTrown()
        {
            // Arrange
            int numberOfBigListItems = 7;
            int insertedItem = 8;
            int insertedItemIndex = 8;

            var bigList = new BigList<int>();
            for (int item = 0; item < numberOfBigListItems; item++)
            {
                bigList.Add(item);
            }

            // Act
            bigList.Insert(insertedItemIndex, insertedItem);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore]
        public void Test_InsertItemInBigListWithMaxCountOfItems_ExceptionShouldBeTrown()
        {
            // Arrange
            var mock = new Mock<BigList<int>>();
            mock.SetupGet(s => s.Count).Returns(int.MaxValue - 1);
            var mockObject = mock.Object;
            int currentIndex = 0;
            int insertedItem = 8;
            int insertedItemIndex = 2;

            // Act
            mockObject.Insert(insertedItemIndex, insertedItem);

            // Assert
        }
    }
}