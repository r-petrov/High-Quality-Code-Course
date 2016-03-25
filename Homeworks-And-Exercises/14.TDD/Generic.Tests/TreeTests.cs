using Generic.Tree;

namespace Generic.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void Test_TreeConstructor_ShouldCreateEmptyTree()
        {
            var root = new TreeNode<int>();
            var tree = new Tree<int>(root);

            Assert.AreSame(root, tree.Root);
            Assert.IsNotNull(tree.Root.Children);
            Assert.AreEqual(0, tree.Root.Children.Count);
        }

        [TestMethod]
        public void Test_TreeConstructor_WithChildren_ShouldCreateNonEmptyTree()
        {
            var root = new TreeNode<int>(0);
            root.AddChild(1);
            root.AddChild(2);
            var tree = new Tree<int>(root);

            Assert.AreSame(root, tree.Root);
            Assert.IsNotNull(tree.Root.Children);
            Assert.AreEqual(2, tree.Root.Children.Count);
        }
    }
}
