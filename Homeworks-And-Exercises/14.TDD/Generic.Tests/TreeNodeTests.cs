using System.Collections.Generic;
using Generic.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generic.Tests
{
    [TestClass]
    public class TreeNodeTests
    {
        [TestMethod]
        public void Test_TreeNodeEmptyConstructor_ShouldCreateTheTreeNode()
        {
            var node = new TreeNode<int>();

            Assert.IsNotNull(node);
        }

        [TestMethod]
        public void Test_TreeNodeEmptyConstructor_ShouldHaveTheDefaultValue()
        {
            var node = new TreeNode<int>();

            Assert.IsNotNull(node);
            Assert.AreEqual(default(int), node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeEmptyConstructor_WithReferenceTypes_ShouldHaveTheDefaultValue()
        {
            var node = new TreeNode<string>();

            Assert.IsNotNull(node);
            Assert.AreEqual(default(string), node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeConstructor_ShouldHaveTheRequestedValue()
        {
            var node = new TreeNode<int>(5);

            Assert.IsNotNull(node);
            Assert.AreEqual(5, node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeConstructor_WithReferenceTypes_ShouldHaveTheDefaultValue()
        {
            var node = new TreeNode<List<string>>(new List<string>(){ "pesho", "gosho" });

            Assert.IsInstanceOfType(node.Value, typeof(List<string>));
            CollectionAssert.AreEqual(new List<string>() { "pesho", "gosho" }, node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeConstructor_ShouldHaveChildren()
        {
            var node = new TreeNode<int>(5);

            Assert.IsNotNull(node.Children);
            Assert.AreEqual(0, node.Children.Count);
        }

        [TestMethod]
        public void Test_TreeNodeConstructorWithChildren_ShouldHaveRequestedChildren()
        {
            var node = new TreeNode<int>(5, new List<TreeNode<int>>());

            Assert.IsNotNull(node.Children);
            Assert.AreEqual(0, node.Children.Count);
        }

        [TestMethod]
        public void Test_TreeNodeConstructorWithNonEmptyChildren_ShouldHaveRequestedChildren()
        {
            var children = new List<TreeNode<int>>();
            var firstNode = new TreeNode<int>(2);
            var secondNode = new TreeNode<int>(4);
            children.Add(firstNode);
            children.Add(secondNode);

            var node = new TreeNode<int>(5, children);

            int count = node.Children.Count;

            Assert.IsNotNull(node.Children);
            Assert.AreEqual(2, node.Children.Count);
            Assert.AreSame(firstNode, node.Children[0]);
            Assert.AreSame(secondNode, node.Children[1]);
        }
    }
}
