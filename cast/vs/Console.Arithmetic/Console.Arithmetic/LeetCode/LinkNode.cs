using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    
    /// <summary>
    /// 双向节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkNode<T>
    {
        /// <summary>
        /// 头节点的引用指向
        /// </summary>
        public LinkNode<T> Prev;

        public T Node;

        public LinkNode<T> Next;

    }
}
