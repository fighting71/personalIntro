using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Design.Inherit
{
    public class TreeNode<T>
    {

        public TreeNode<T> ParentNode { get; set; }

        public TreeNode<T> LeftNode { get; set; }

        public TreeNode<T> RightNode { get; set; }

        public int Value { get; set; }

        public TreeNode() { }

        public TreeNode(int value)
        {
            Value = value;
        }

        public TreeNode( int value,TreeNode<T> parentNode, TreeNode<T> leftNode, TreeNode<T> rightNode)
        {
            ParentNode = parentNode;
            LeftNode = leftNode;
            RightNode = rightNode;
            Value = value;
        }

        /// <summary>
        /// 不能一次性构建完的对象都是耍流氓 :)
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="rightNode"></param>
        /// <returns></returns>
        public TreeNode<T> AddChildrenNode(TreeNode<T> leftNode, TreeNode<T> rightNode)
        {
            if (leftNode != null)
            {
                LeftNode = leftNode;
                leftNode.ParentNode = this;
            }

            if (rightNode != null)
            {
                RightNode = rightNode;
                rightNode.ParentNode = this;
            }

            return this;

        }

    }
}
