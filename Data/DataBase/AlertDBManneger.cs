using MySql.Data.MySqlClient;
using Models;
using utils;
using System.Data;
using System.Linq.Expressions;
using Models.intel;
using System.Dynamic;

namespace Data
{
    public static class AlertDBManeger
    {
        // Creates a database connection factory with MySQL connection string
        private static DbConnectionFactory Connection =
            new DbConnectionFactory("server=127.0.0.1;user=root;password=;database=malshinon;");

        public static void InsertNewAlert(Alert alert)
        {
            try
            {

                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("INSERT INTO alerts(target_id,reasone,time_of_creation) " +
                                                        "VALUES(@targetId,@reasone,@timofCreation)", conn))

                {
                    command.Parameters.AddWithValue("@targetId", alert.TargetId);
                    command.Parameters.AddWithValue("@reasone", alert.Reasone);
                    command.Parameters.AddWithValue("@timofCreation", alert.Time_Of_creation);

                    command.ExecuteNonQuery();


                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }


        }
    }
}