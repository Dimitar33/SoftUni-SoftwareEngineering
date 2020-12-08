using System;
using System.Linq;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {                
            Console.WriteLine(string.Join("", Console.ReadLine().Select(c => (char)(c + 3)).ToArray()));
        }
    }
}
