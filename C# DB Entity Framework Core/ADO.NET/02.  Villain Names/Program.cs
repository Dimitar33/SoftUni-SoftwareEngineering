using System;
using Microsoft.Data.SqlClient;

namespace _02.__Villain_Names
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();
            {
                string queryText =
                @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                    FROM Villains AS v 
                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                GROUP BY v.Id, v.Name 
                  HAVING COUNT(mv.VillainId) > 3 
                ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand cmd = new SqlCommand(queryText, con))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }

                }
            }
        }
    }
}
