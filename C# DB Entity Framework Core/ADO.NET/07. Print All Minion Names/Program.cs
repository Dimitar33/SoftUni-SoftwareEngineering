using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07._Print_All_Minion_Names
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            string minionNamesString = @"SELECT Name FROM Minions";

            SqlCommand minionNames = new SqlCommand(minionNamesString, con);
            var reader = minionNames.ExecuteReader();
        
            List<string> minions = new List<string>();
            while (reader.Read())
            {
                minions.Add((string)reader["Name"]);
            }

            for (int i = 0; i < minions.Count/2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - i -1]);
            }
            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2 + 1]);
            }
        }
    }
}
