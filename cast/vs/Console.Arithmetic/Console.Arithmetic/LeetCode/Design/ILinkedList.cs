using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Design
{

    /// <summary>
    /// source:https://leetcode.com/problems/design-linked-list/description/
    /// </summary>
    public interface ILinkedList<T>
    {
        //get(index) : Get the value of the index-th node in the linked list.If the index is invalid, return -1.

        T this[int index] { get; set; }


        //addAtHead(val) : Add a node of value val before the first element of the linked list.After the insertion, the new node will be the first node of the linked list.

        void AddAtHead(T info);

        //addAtTail(val) : Append a node of value val to the last element of the linked list.

        void AddAtTail(T info);

        //addAtIndex(index, val) : Add a node of value val before the index-th node in the linked list.If index equals to the length of linked list, the node will be appended to the end of linked list.If index is greater than the length, the node will not be inserted.
        void AddAtIndex(int index, T info);

        //deleteAtIndex(index) : Delete the index-th node in the linked list, if the index is valid.
        void DeleteAtIndex(int index);

    }
}
