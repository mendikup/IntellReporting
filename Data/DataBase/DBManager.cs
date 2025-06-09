using MySql.Data.MySqlClient;
using Models;

namespace Data
{
    public static class DBManeger
    {
        private static DbConnectionFactory Connection = new DbConnectionFactory("server=127.0.0.1;user=root;password=;database=malshinon;");


        public static Person GetBySecretCode(string input)
        {

            Person person = null;


            try
            {
                //open connection in Db
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand($"SELECT * FROM people WHERE secret_code =@input ", conn))
                {
                    command.Parameters.AddWithValue("@input", input);

                    using (var reader = command.ExecuteReader())

                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string firstname = reader.GetString("first_name");
                            string lastname = reader.GetString("last_name");
                            string secretCode = reader.GetString("secret_code");
                            string type = reader.GetString("type");
                            int numReprots = reader.GetInt32("num_reports");
                            int numMentions = reader.GetInt32("num_mention");

                            // creats an object of person 
                            person = new Person(id, firstname, lastname, secretCode, type, numMentions, numReprots);
                            return person;
                        }

                }

                return person;
            }



            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            return person;


        }


        public static Person GetByName(string firstName, string lastName)
        {
            Person person = null;

            try
            {

                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand($"SELECT * FROM people WHERE first_name =@firstName AND last_name =@lastName ", conn))
                {
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);

                    using (var reader = command.ExecuteReader())

                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string firstname = reader.GetString("first_name");
                            string lastname = reader.GetString("last_name");
                            string secretCode = reader.GetString("secret_code");
                            string type = reader.GetString("type");
                            int numReprots = reader.GetInt32("num_reports");
                            int numMentions = reader.GetInt32("num_mention");

                            // creats an object of person 
                            person = new Person(id, firstname, lastname, secretCode, type, numMentions, numReprots);
                            return person;
                        }

                }
 
               return person;
            }



                  catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            return person;


        }

        public static void insertNewPerson(Person person)
        {

        }


    }
}