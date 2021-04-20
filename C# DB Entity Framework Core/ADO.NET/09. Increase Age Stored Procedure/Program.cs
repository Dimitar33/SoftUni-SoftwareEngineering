using Microsoft.Data.SqlClient;
using System;

namespace _09._Increase_Age_Stored_Procedure
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            //string createProcString = 
            //    @"CREATE PROC usp_GetOlder @id INT
            //      AS
            //      UPDATE Minions
            //         SET Age += 1
            //       WHERE Id = @id";

            //SqlCommand createProc = new SqlCommand(createProcString, con);
            //createProc.ExecuteNonQuery();

            string useProcString = @"EXEC usp_GetOlder @Id";
            SqlCommand useProc = new SqlCommand(useProcString, con);
            useProc.Parameters.AddWithValue("@Id", id);
            useProc.ExecuteNonQuery();

            string minionInfoString = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            SqlCommand minionInfo = new SqlCommand(minionInfoString, con);
            minionInfo.Parameters.AddWithValue("@Id", id);
            var reader = minionInfo.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} – {reader[1]} years old");
            }
        }
    }
}
