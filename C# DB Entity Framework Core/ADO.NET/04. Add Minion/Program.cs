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

            string minionName = minionInfo[1];
            string villainName = villainInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];
            int townId = 0;
            int villainId = 0;
            int minionId = 0;

            using SqlConnection con = new SqlConnection(SQLCon);
            con.Open();

            string selectVilainQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
            string selectMinionnQuery = @"SELECT Id FROM Minions WHERE Name = @Name";
            string selectTownQuery = @"SELECT Id FROM Towns WHERE Name = @townName";

            SqlCommand town = new SqlCommand(selectTownQuery, con);
            town.Parameters.AddWithValue("@townName", townName);
            var validTownId = town.ExecuteScalar();

            if (validTownId == null)
            {
                string insertTownQuerry = @"INSERT INTO Towns (Name) VALUES (@townName)";

                SqlCommand insertTown = new SqlCommand(insertTownQuerry, con);
                insertTown.Parameters.AddWithValue(@townName, townName);

                try
                {
                    insertTown.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }               

                town.Parameters.AddWithValue("@townName", townName);
                townId = (int)town.ExecuteScalar();

                Console.WriteLine($"Town {townName} was added to the database.");
            }
            else
            {
                townId = (int)validTownId;
            }

            SqlCommand villain = new SqlCommand(selectVilainQuery, con);
            villain.Parameters.AddWithValue("@Name", villainName);
            var vaildVillainId = villain.ExecuteScalar();

            if (vaildVillainId == null)
            {
                string insertVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                SqlCommand insertVillain = new SqlCommand(insertVillainQuery, con);
                insertVillain.Parameters.AddWithValue(@villainName, villainName);
                try
                {
                    insertVillain.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

                villain.Parameters.AddWithValue("@Name", villainName);
                villainId = (int)villain.ExecuteScalar();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            else
            {
                villainId = (int)vaildVillainId;
            }

            string addMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            SqlCommand addMinion = new SqlCommand(addMinionQuery, con);
            addMinion.Parameters.AddWithValue("@name", minionName);
            addMinion.Parameters.AddWithValue("age", minionAge);
            addMinion.Parameters.AddWithValue("townId", townId);

            try
            {
                addMinion.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            SqlCommand minion = new SqlCommand(selectMinionnQuery, con);
            minion.Parameters.AddWithValue("@Name", minionName);
            minionId = (int)minion.ExecuteScalar();

            string minionToVilainQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            SqlCommand minionToVilain = new SqlCommand(minionToVilainQuery, con);
            minionToVilain.Parameters.AddWithValue("@villainId", villainId);
            minionToVilain.Parameters.AddWithValue("@minionId", minionId);

            try
            {
                minionToVilain.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}
