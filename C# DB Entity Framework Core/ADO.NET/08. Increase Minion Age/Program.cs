using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08._Increase_Minion_Age
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            string updateMinionsString =
                @"UPDATE Minions
                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                 WHERE Id = @Id";

            SqlCommand updateMinions = new SqlCommand(updateMinionsString, con);

            for (int i = 0; i < ids.Length; i++)
            {
                updateMinions.Parameters.AddWithValue("@Id", ids[i]);
                updateMinions.ExecuteNonQuery();
                updateMinions.Parameters.Clear();
            }

            string minionsInfoString = @"SELECT Name, Age FROM Minions";

            SqlCommand minionsInfo = new SqlCommand(minionsInfoString, con);
            var reader = minionsInfo.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }
        }
    }
}
