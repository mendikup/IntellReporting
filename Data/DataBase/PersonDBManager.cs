using MySql.Data.MySqlClient;
using Models;
using utils;
using System.Data;
using System.Linq.Expressions;
using Models.intel;
using System.Dynamic;

namespace Data
{
    public static class PersonDBManeger
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



        public static List<Person> GetAllPeople()
        {
            List<Person> people = new List<Person>();

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT * FROM people ", conn))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Builds and returns a Person object from the database row
                            Person person = ReaderUtils.BuildPerson(reader);
                            people.Add(person);
                        }
                    }
                }

                return people;
            }

            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            return people;

        }




        public static List<Person> GetDangerous()
        {
            List<Person> people = new List<Person>();

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT * FROM people WHERE is_dangerous=1 ", conn))
                {


                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Builds and returns a Person object from the database row
                            Person person = ReaderUtils.BuildPerson(reader);
                            people.Add(person);
                        }
                    }
                }

                return people;
            }

            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            return people;
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



        public static void IncrementTargetReports(Person target)
        {
            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("UPDATE people SET num_mention = num_mention+1 WHERE id = @id ", conn))
                {
                    command.Parameters.AddWithValue("@id", target.Id);

                    command.ExecuteNonQuery();


                }

            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }



        public static void IncrementReporterNumOfReports(Person reporter)
        {

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("UPDATE people SET num_reports = num_reports+1 WHERE id = @id ", conn))
                {
                    command.Parameters.AddWithValue("@id", reporter.Id);

                    command.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }




     





        public static int GetNumberOfReports(Person reporter)
        {
            int counter = 0;

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT num_reports FROM people WHERE id = @id;", conn))
                {
                    command.Parameters.AddWithValue("@id", reporter.Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            counter = reader.GetInt32(0);
                        }
                    }
                }
                return counter;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


            return counter;
        }

        public static int GetNumOfmention(Person target)
        {
            int counter = 0;

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT num_mention FROM people WHERE id = @id;", conn))
                {
                    command.Parameters.AddWithValue("@id", target.Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            counter = reader.GetInt32(0);
                        }
                    }
                }
                return counter;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


            return counter;
        }





        public static void updateStatus(Person person, string status)
        {

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("UPDATE people SET type = @type WHERE id = @id ", conn))
                {
                    command.Parameters.AddWithValue("@id", person.Id);
                    command.Parameters.AddWithValue("@type", status);

                    command.ExecuteNonQuery();


                }

            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }


        public static void MarkAsDangerous(Person person)
        {

            try
            {
                using var conn = Connection.GetOpenConnection();
                using var command = new MySqlCommand("UPDATE people SET is_dangerous= 1 WHERE id = @id ", conn);
                {
                    command.Parameters.AddWithValue("@id", person.Id);
                    command.ExecuteNonQuery();

                }

            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }

    }
}

