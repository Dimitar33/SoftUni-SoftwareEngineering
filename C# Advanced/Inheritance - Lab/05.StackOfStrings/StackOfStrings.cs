using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
   public class StackOfStrings : Stack<string>
    {
        //public StackOfStrings()
        //{
        //    MyStack = new Stack<string>();
        //}

       // public Stack<string> MyStack { get; set; }

        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            return false;
        }

        public  void AddRange(IEnumerable<string> colection)
        {

            foreach (var item in colection)
            {
                this.Push(item);
            }          
        }              
    }
}
