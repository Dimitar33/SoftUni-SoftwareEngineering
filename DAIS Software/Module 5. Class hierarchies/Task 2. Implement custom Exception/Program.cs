using System;
using System.Diagnostics;
using System.Reflection;

namespace Task_2._Implement_custom_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SuperDetailedException ex = new SuperDetailedException();

            ex.CatchEx();
        }

        internal class SuperDetailedException : SystemException
        {
            public SuperDetailedException()
                : base()
            {

            }
            public SuperDetailedException(string message)
                : base(message)
            {

            }

            public SuperDetailedException(string message, Exception inner)
                : base(message, inner)
            {

            }

            private string methodName;

            public DateTime Time => DateTime.Now;

            public string Details { get; set; }

            public string MethodName => new StackTrace(this).GetFrame(0).GetMethod().Name;

            public void ThrowExeption()
            {
                throw new SuperDetailedException(Details = "Detailed message");
            }

            public void CatchEx()
            {
                try
                {
                    ThrowExeption();
                }
                catch (SuperDetailedException e)
                {

                    Console.WriteLine($"{e.Message}, {e.Time}, {e.MethodName}");
                }

            }
        }
    }
}