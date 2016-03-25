using System.Collections.Generic;

namespace Generic.Tree
{
    public class TreeNode<T>
    {
        public TreeNode(T value, List<TreeNode<T>> children)
        {
            this.Value = value;
            this.Children = children;
        }
        public TreeNode(T value) : this(value, new List<TreeNode<T>>())
        {
        }

        public TreeNode() : this(default (T))
        {
        }

        public T Value { get; private set; }

        public IList<TreeNode<T>> Children { get; private set; }

        public void AddChild(T childValue)
        {
            this.Children.Add(new TreeNode<T>(childValue));
        }
    }
}
