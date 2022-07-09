using System.Data;
using System.Data.SqlClient;

namespace api_with_ado.net.DB
{
    public class Database
    {
        public static string dataSource = @"Server=.\SQLEXPRESS;Database=University;Trusted_Conection=True";

        public DataTable GetData(string comand)
        {
            DataTable dt = new DataTable();

            SqlDataReader sqlReader;

            using(SqlConnection sqlCon = new SqlConnection(dataSource))
            {
                sqlCon.Open();

                using(SqlCommand cmd = new SqlCommand(comand, sqlCon))
                {
                    sqlReader = cmd.ExecuteReader();
                    dt.Load(sqlReader);

                    sqlReader.Close();
                    sqlCon.Close();
                }
            }

            return dt;
        }

        public int ExecuteData(string comand, params IDataParameter[] sqlParams)
        {
            int rows = -1;

            using(SqlConnection sqlCon = new SqlConnection(dataSource))
            {
                sqlCon.Open();

                using(SqlCommand cmd = new SqlCommand(comand , sqlCon))
                {
                    if (sqlParams != null)
                    {
                        foreach (var p in sqlParams)
                        {
                            cmd.Parameters.Add(p);
                        }
                        rows = cmd.ExecuteNonQuery();
                    }
                }
            }

            return rows;
        }
    }
}
