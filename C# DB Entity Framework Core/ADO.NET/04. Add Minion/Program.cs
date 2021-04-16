using Microsoft.Data.SqlClient;
using System;

namespace _04._Add_Minion
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            SqlCommand minion = new SqlCommand();
            SqlCommand villain = new SqlCommand();

        }
    }
}
