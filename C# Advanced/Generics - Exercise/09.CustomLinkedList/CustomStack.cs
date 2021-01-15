using System;
using System.Collections.Generic;
using System.Text;

namespace Create_Custom_Data_Structures
{
    class CustomStack
    {
        private const int inicialCapacity = 4;

        private int[] stack;

        private int count;
        public CustomStack()
        {
            stack = new int[inicialCapacity];
            count = 0;
        }
        public int Count { get => count; set => Count = count ; }

        public void Push(int num)
        {
            if (Count == stack.Length)
            {
                int[] temp = new int[stack.Length * 2];

                for (int i = 0; i < stack.Length; i++)
                {
                    temp[i] = stack[i];
                }
                stack = temp;
            }

            stack[Count] = num;
            count++;
        }

        public int Pop()
        {
            if (stack.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = stack[Count - 1];
            count--;
            return temp;
        }

        public int Peek()
        {
            if (stack.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            return stack[Count - 1];
        }

        public void ForEach(Action<object> action)
        {
          
            for (int i = 0; i < Count; i++)
            {
                action(stack[i]);
            }
        }
    }
}
