using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }

        public ListNode AddNext(ListNode node)
        {
            next = node;
            return this;
        }
    }

    /// <summary>
    /// source:https://leetcode.com/problems/add-two-numbers-ii/description/
    ///
    /// description:
    ///
    ///     You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
    ///     You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    ///
    /// Follow up:
    ///     What if you cannot modify the input lists? In other words, reversing the lists is not allowed.
    /// 
    /// 
    /// </summary>
    public class AddTwoNumbersII
    {
        public ListNode Simple(ListNode l1, ListNode l2)
        {
            var num = 0;
            var num2 = 0;

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    num *= 10;
                    num += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    num2 *= 10;
                    num2 += l2.val;
                    l2 = l2.next;
                }
            }

            int k = 10, sum = num2 + num;

            ListNode node = null;

            while (sum > 0)
            {
                var item = new ListNode(sum % k);
                item.next = node;
                node = item;
                sum /= 10;
            }

            return node;
        }

        /// <summary>
        /// 先将两个链的每个节点值进行求和
        /// 再通过和的值生成一个链
        /// 先简单破解下~
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode Solution(ListNode l1, ListNode l2)
        {
            BigInteger num = 0;
            BigInteger num2 = 0L;

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    num *= 10;
                    num += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    num2 *= 10;
                    num2 += l2.val;
                    l2 = l2.next;
                }
            }

            BigInteger k = 10, sum = num2 + num;

            if (sum < 10) return new ListNode((int) sum);

            ListNode node = null;

            while (sum > 0)
            {
                var item = new ListNode((int) (sum % k))
                {
                    next = node
                };
                node = item;
                sum /= 10;
            }

            return node;
        }

        /// <summary>
        /// to be continue~
        /// 差不多就这样子了~
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode Optmize(ListNode l1, ListNode l2)
        {
            var list = new List<int>();//可调整为其他

            var list2 = new List<int>();

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    list.Add(l1.val);
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    list2.Add(l2.val);
                    l2 = l2.next;
                }
            }

            int  excess = 0, sum;
            ListNode node = null;

            for (int i = list.Count - 1, j = list2.Count - 1; i >= 0 || j >= 0 || excess != 0; i--, j--)
            {
                sum = ((i < 0 ? 0 : list[i]) + (j < 0 ? 0 : list2[j]) + excess);
                var item = new ListNode(sum % 10)
                {
                    next = node
                };
                node = item;
                excess = sum / 10;
            }

            return node;
        }



    }
}