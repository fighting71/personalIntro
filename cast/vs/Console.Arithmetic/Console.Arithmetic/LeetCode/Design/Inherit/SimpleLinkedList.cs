using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Design.Inherit
{
    public class SimpleLinkedList<T> : ILinkedList<T>
    {
        protected LinkNode<T> Root;

        private int _size;

        public int Count
        {
            get { return _size; }
        }

        public LinkNode<T> GetNode(int index)
        {
            LinkNode<T> eachNode = Root;

            int eachIndex = 0;

            while (eachIndex++ != index)
            {
                eachNode = eachNode.Next;
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

            _size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= Count)
            {
                //throw new IndexOutOfRangeException();
            }

            LinkNode<T> eachNode = GetNode(index);

            if (eachNode.Next != null)
            {
                eachNode.Prev.Next = eachNode.Next;
            }
            else
            {
                eachNode.Prev.Next = null;
            }


        }
    }

}