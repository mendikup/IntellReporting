
using MySql.Data.MySqlClient;

using Models;

namespace utils
{
    public static class ReaderUtils
    {
        public static Person BuildPerson(MySqlDataReader reader)
        {

            int id = reader.GetInt32("id");
            string firstName = reader.GetString("first_name");
            string lastName = reader.GetString("last_name");
            string secretCode = reader.GetString("secret_code");
            string type = reader.GetString("type");
            int numReports = reader.GetInt32("num_reports");
            int numMentions = reader.GetInt32("num_mention");
            int isDangerous = reader.GetInt32("is_dangerous");


            Person person = new Person
            (
                id,
                firstName,
                 lastName,
                 secretCode,
                 type,
                 numReports,
                 numMentions,
                 isDangerous


            );

            return person;
        }


        public static Alert BuildAlert(MySqlDataReader reader)
        {

            int id = reader.GetInt32("id");
            int targetId = reader.GetInt32("Target_id");
            string reason = reader.GetString("reasone");
            DateTime timeOfCration = reader.GetDateTime("Time_of_creation");


            Alert alert = new Alert
            (
                id,
                targetId,
                reason,
                timeOfCration

            );

            return alert ;
        }
    }




}