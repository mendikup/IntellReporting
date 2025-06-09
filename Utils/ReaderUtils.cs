using MySql.Data.MySqlClient;
using Models;
using Microsoft.VisualBasic;

public static class RederUtils
{

    public static Person BuildPerson(MySqlDataReader reader)
    {
        int id = reader.GetInt32("id");
        string firstname = reader.GetString("first_name");
        string lastname = reader.GetString("last_name");
        string secretCode = reader.GetString("secret_code");
        string type = reader.GetString("type");
        int numReprots = reader.GetInt32("num_reports");
        int numMentions = reader.GetInt32("num_mention");

        // creats an object of person 
        Person person = new Person(id, firstname, lastname, secretCode, type, numMentions, numReprots);

        return person;
    }

}