using System;
using System.Collections.Generic;
using System.Text;
using Cons.Arithmetic.LeetCode.Design.Inherit;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    public class PathSumIII
    {
        //Description:
        //        You are given a binary tree in which each node contains an integer value.
        //
        //            Find the number of paths that sum to a given value.
        //
        //            The path does not need to start or end at the root or a leaf, but it must go downwards(traveling only from parent nodes to child nodes).
        //
        //        The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

        public int Simple(TreeNode<int> root, int sum)
        {
            int count = 0;
            ForeachNode(root, (node =>
            {
                int num = node.Value;

                while ((node = node.ParentNode) != null)
                {
                    num += node.Value;
                    if (num >= sum) break;
                }

                if (num == sum) count++;
            }));

            return count;
        }

        public void ForeachNode(TreeNode<int> root, Action<TreeNode<int>> func)
        {
            if (root == null)
            {
                return;
            }

            func.Invoke(root);

            ForeachNode(root.LeftNode, func);
            ForeachNode(root.RightNode, func);
        }
    }
}