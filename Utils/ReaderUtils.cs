
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

        
        Person person = new Person
        (
            id ,
            firstName,
             lastName,
             secretCode,
             type,
             numReports,
             numMentions
        );

        return person;
    }
}


    
}