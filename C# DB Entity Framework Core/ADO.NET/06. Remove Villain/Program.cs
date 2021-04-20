using Microsoft.Data.SqlClient;
using System;

namespace _06._Remove_Villain
{
    class Program
    {
        const string SQLCon = "Server=.;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            int villainIdInput = int.Parse(Console.ReadLine());

            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            string findVillainString = @"SELECT Name FROM Villains WHERE Id = @villainId";

            SqlCommand findVillain = new SqlCommand(findVillainString, con);
            findVillain.Parameters.AddWithValue("@villainId", villainIdInput);
            string villain = (string)findVillain.ExecuteScalar();

            if (villain == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            string releaseMinionsString =
                @"DELETE FROM MinionsVillains 
                     WHERE VillainId = @villainId";
            string deleteVillainString =
                @"DELETE FROM Villains
                     WHERE Id = @villainId";

            SqlCommand releaseMinions = new SqlCommand(releaseMinionsString, con);
            releaseMinions.Parameters.AddWithValue("@villainId", villainIdInput);
            int count = 0;

            try
            {
                count = releaseMinions.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ArgumentException (e.Message);
            }

            SqlCommand deleteVillain = new SqlCommand(deleteVillainString, con);
            deleteVillain.Parameters.AddWithValue("@villainId", villainIdInput);

            try
            {
                deleteVillain.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ArgumentException (e.Message);
            }

            Console.WriteLine($"{villain} was deleted.");
            Console.WriteLine($"{count} minions were released.");
        }
    }
}
