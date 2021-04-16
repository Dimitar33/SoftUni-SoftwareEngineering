using Microsoft.Data.SqlClient;
using System;

namespace _03._Minion_Names
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            string selectVilainText = @"SELECT Name FROM Villains WHERE Id = @Id";

            SqlCommand selectVilain = new SqlCommand(selectVilainText, con);
            selectVilain.Parameters.AddWithValue("Id", id);

            var vilain = (string)selectVilain.ExecuteScalar();

            if (vilain == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Vilain: {vilain}");
            }

            string vilainMinionsTesxt =
                @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                           m.Name, 
                           m.Age
                      FROM MinionsVillains AS mv
                      JOIN Minions As m ON mv.MinionId = m.Id
                     WHERE mv.VillainId = @Id
                  ORDER BY m.Name";

            SqlCommand vilainMinions = new SqlCommand(vilainMinionsTesxt, con);
            vilainMinions.Parameters.AddWithValue("@Id", id);
            var reader = vilainMinions.ExecuteReader();
            int count = 0;

            while (reader.Read())
            {
                count++;
                Console.WriteLine($"{count}. {reader["Name"]} {reader["Age"]}");
            }
           
        }
    }
}
