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
                person = DBManeger.GetBySecretCode(input);
                if (person != null)
                    return person;
            }

            // if not code ,search by name 
            string[] parts = input.Trim().Split(' ');
            string firstName = parts[0];
            string lastName = parts.Length > 1 ? parts[1] : "";

            person = DBManeger.GetByName(firstName, lastName);
            if (person != null)
                return person;


            // if person not found create a new one
            string code = "djkfig";
            person = new Person
            (
                firstName,
                lastName,
                code,
                "reporter",
                0,
                0
            );

            DBManeger.insertNewPerson(person);
            return person;
        }














    }

}