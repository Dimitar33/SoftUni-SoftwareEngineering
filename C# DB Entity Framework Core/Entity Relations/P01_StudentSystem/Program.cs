using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
