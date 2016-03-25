using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wintellect.PowerCollections;

namespace BigListTests
{
    [TestClass]
    public class ClearBigListTests
    {
        [TestMethod]
        public void Test_ClearNonEmptyBigList_BigListShouldBeEmpty()
        {
            // Arrange
            int numberOfBigListItems = 101;
            BigList<int> bigList = new BigList<int>();
            for (int item = 0; item < numberOfBigListItems; item++)
            {
                bigList.Add(item);
            }

            // Act
            bigList.Clear();

            // Assert
            Assert.AreEqual(0, bigList.Count, "Big list count is not zero.");
        }

        [TestMethod]
        public void Test_ClearEmptyBigList_BigListShouldBeEmpty()
        {
            // Arrange
            BigList<int> bigList = new BigList<int>();

            // Act
            bigList.Clear();

            // Assert
            Assert.AreEqual(0, bigList.Count, "Big list count is not zero.");
        }
    }
}
