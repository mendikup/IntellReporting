using MySql.Data.MySqlClient;
using Models;
using utils;
using System.Data;
using System.Linq.Expressions;
using Models.intel;
using System.Dynamic;
using Org.BouncyCastle.Asn1.X509;

namespace Data
{
    public static class IntelDBManeger
    {
        // Creates a database connection factory with MySQL connection string
        private static DbConnectionFactory Connection =
            new DbConnectionFactory("server=127.0.0.1;user=root;password=;database=malshinon;");

        public static void InsertNewRreport(Intel report)
        {
            try
            {

                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("INSERT INTO intelreports(reporter_id,target_id,content) " +
                                                        "VALUES(@reporterid,@targetId,@content)", conn))

                {
                    command.Parameters.AddWithValue("@reporterid", report.RporterId);
                    command.Parameters.AddWithValue("@targetId", report.TargetId);
                    command.Parameters.AddWithValue("@content", report.Content);

                    command.ExecuteNonQuery();


                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }


        }

        public static int GetAverageCarecters(Person reporter)
        {
            int AVG = 0;

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT AVG(CHAR_LENGTH(content)) FROM IntelReports WHERE target_id = @target_id;", conn))
                {
                    command.Parameters.AddWithValue("@target_id", reporter.Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            AVG = Convert.ToInt32(reader.GetDouble(0));
                        }
                    }
                }
                return AVG;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return AVG;
        }



        public static List<DateTime> GetTheLastThreeReports(Person target)
        {

            List<DateTime> recentReport = new List<DateTime>();
            DateTime timeStamp;

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT time_of_report FROM intelreports " +
                                                        "WHERE  target_id = @targetId " +
                                                        "ORDER BY time_of_report DESC LIMIT 3", conn))

                {
                    command.Parameters.AddWithValue("@targetId", target.Id);
                    using (var reader = command.ExecuteReader())

                    {
                        while (reader.Read())
                        {
                            timeStamp = reader.GetDateTime("time_of_report");
                            recentReport.Add(timeStamp);


                        }




                    }

                    return recentReport;




                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return recentReport;





        }

    }
}