using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05._Change_Town_Names_Casing
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            string countryInput = Console.ReadLine();

            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            string updateTownsText =
                @"UPDATE Towns
                   SET Name = UPPER(Name)
                 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name =    @countryName)";

            SqlCommand updateTowns = new SqlCommand(updateTownsText, con);
            updateTowns.Parameters.AddWithValue("@countryName", countryInput);
            int count = updateTowns.ExecuteNonQuery();       

            string findTownText = 
                @" SELECT t.Name 
                    FROM Towns as t
                    JOIN Countries AS c ON c.Id = t.CountryCode
                   WHERE c.Name = @countryName";

            SqlCommand findTown = new SqlCommand(findTownText, con);
            findTown.Parameters.AddWithValue("@countryName", countryInput);
            var reader = findTown.ExecuteReader();

            List<string> towns = new List<string>();

            while (reader.Read())
            {                
                towns.Add((string)reader["Name"]);
            }
            if (towns.Count == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            Console.WriteLine($"{count} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", towns)}]");
        }
    }
}
