using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class DoublyLinkedList
    {
       
        private ListNode head;

        private ListNode tail;

        public int Count { get; set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var temp = new ListNode(element);
                temp.Next = head;
                head.Previous = temp;
                head = temp;
            }
            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var temp = new ListNode(element);
                temp.Previous = tail;
                tail.Next = temp;
                tail = temp;
            }
            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var first = head.Value;
            head = head.Next;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }

            Count--;
            head.Previous = null;
            return first;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var last = tail.Value;
            tail = tail.Previous;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }

            Count--;
            tail.Next = null;
            return last;
        }

        public void ForEach(Action<int> action)
        {
            var temp = head;

            while (temp != null)
            {
                action(temp.Value);
                temp = temp.Next;

            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int counter = 0;
            var temp = head;

            while (counter < array.Length)
            {
                array[counter] = temp.Value;
                temp = temp.Next;
                counter++;
            }
            return array;
        }
    }
}
