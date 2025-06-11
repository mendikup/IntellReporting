using MySql.Data.MySqlClient;
using Data;
using Models;
using utils;
using Microsoft.VisualBasic;


namespace services
{
    public static class PersonService
    {


        public static Person CreateOrFind(string input)
        {
            Person person = null;

            if (InputValidator.IsSecretCode(input))
            {
                person = PersonDBManeger.GetBySecretCode(input);
                if (person != null)
                    return person;
            }

            // if not code ,search by name 
            string[] parts = input.Trim().Split(' ');
            string firstName = parts[0];
            string lastName = parts.Length > 1 ? parts[1] : "";

            person = PersonDBManeger.GetByName(firstName, lastName);
            if (person != null)
                return person;


            // if person not found create a new one
            string code = "FB2H86";
            person = new Person
            (
                firstName,
                lastName,
                code,
                "reporter",
                0,
                0
            );

            PersonDBManeger.insertNewPerson(person);
            return person;
        }

        public static List<Person> GetAllDengerous ()
        {
            List<Person> People = PersonDBManeger.GetDangerous();

            return People;
        }














    }

}