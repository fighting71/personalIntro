using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Design.Inherit
{
    public class OptmizeLinkedList<T> : ILinkedList<T>
    {
        protected LinkNode<T> Root;

        protected LinkNode<T> Tail;

        private int _size;

        public int Count
        {
            get { return _size; }
        }

        /// <summary>
        /// 查找优化 根据位置从头/尾 部开始搜索
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LinkNode<T> GetNode(int index)
        {
            LinkNode<T> eachNode = null;

            int eachIndex = 0;

            if (Tail != null && index >= Count / 2)
            {
                eachNode = Tail;
                while (++eachIndex != (Count - index))
                {
                    eachNode = eachNode.Prev;
                }
            }
            else
            {
                eachNode = Root;
                while (eachIndex++ != index)
                {
                    eachNode = eachNode.Next;
                }
            }

            return eachNode;
        }

        public T GetInfo(int index)
        {
            if (index >= Count)
            {
                return default(T);
            }

            return GetNode(index).Node;
        }

        public T this[int index]
        {
            get => GetInfo(index);

            set => throw new NotImplementedException();
        }

        public void AddAtHead(T info)
        {
            AddAtIndex(0, info);
        }

        public void AddAtTail(T info)
        {
            AddAtIndex(Count, info);
        }

        public void AddAtIndex(int index, T info)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            LinkNode<T> node = new LinkNode<T>();
            node.Node = info;

            if (index == 0)
            {
                if (Root != null)
                {
                    Root.Prev = node;
                    node.Next = Root;
                }

                Root = node;
            }
            //            else if (index == Count)
            //            {
            //            }
            else if (index <= Count)
            {
                LinkNode<T> eachNode = GetNode(index - 1);

                node.Prev = eachNode;
                node.Next = eachNode.Next;
                eachNode.Next = node;
            }


            if (Count > 2 && index < Count && Tail == null)
            {
                Tail = GetNode(Count - 1);
            }
            else if (index == Count)
            {
                Tail = node;
            }
            else if (index == Count - 1)
            {
                Tail.Prev = node;
            }

            _size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= Count)
            {
                //throw new IndexOutOfRangeException();
            }

            LinkNode<T> eachNode = GetNode(index);

            if (Count <= 2)
            {
                Tail = null;
            }
            else if (index == Count - 1)
            {
                Tail = Tail.Prev;
            }
            else if (index == Count - 2)
            {
                Tail.Prev = eachNode.Prev;
            }

            if (eachNode.Next != null)
            {
                eachNode.Prev.Next = eachNode.Next;
            }
            else
            {
                eachNode.Prev.Next = null;
            }

            _size--;
        }
    }
}