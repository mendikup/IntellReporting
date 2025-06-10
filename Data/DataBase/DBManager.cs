using MySql.Data.MySqlClient;
using Models;
using utils;
using System.Data;
using System.Linq.Expressions;

namespace Data
{
    public static class DBManeger
    {
        // Creates a database connection factory with MySQL connection string
        private static DbConnectionFactory Connection =
            new DbConnectionFactory("server=127.0.0.1;user=root;password=;database=malshinon;");



        // Retrieves a person by their secret code
        public static Person GetBySecretCode(string input)
        {
            Person person = null;

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT * FROM people WHERE secret_code = @input", conn))
                {
                    command.Parameters.AddWithValue("@input", input);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Builds and returns a Person object from the database row
                            person = ReaderUtils.BuildPerson(reader);
                            return person;
                        }
                    }
                }

                return person;
            }
            catch (Exception Ex)
            {
                // Logs any database errors to the console
                Console.WriteLine(Ex.Message);
            }

            return person;
        }



        // Retrieves a person by first and last name
        public static Person GetByName(string firstName, string lastName)
        {
            Person person = null;

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT * FROM people WHERE first_name = @firstName AND last_name = @lastName", conn))
                {
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Builds and returns a Person object from the database row
                            person = ReaderUtils.BuildPerson(reader);
                            return person;
                        }
                    }
                }

                return person;
            }
            catch (Exception Ex)
            {
                // Logs any database errors to the console
                Console.WriteLine(Ex.Message);
            }

            return person;
        }



        // Inserts a new person into the database
        public static void insertNewPerson(Person p)
        {
            try
            {

                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("INSERT INTO people(first_name,last_name,secret_code,type,num_reports,num_mention) " +
                                                        "VALUES(@fn,@ln,@sc,@type,@nr,@nm)", conn))

                {
                    command.Parameters.AddWithValue("@fn", p.FirstName);
                    command.Parameters.AddWithValue("@ln", p.LastName);
                    command.Parameters.AddWithValue("@sc", p.SecretCode);
                    command.Parameters.AddWithValue("@type", p.Type);
                    command.Parameters.AddWithValue("@nr", p.NumReports);
                    command.Parameters.AddWithValue("@nm", p.NumMentions);

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
    

