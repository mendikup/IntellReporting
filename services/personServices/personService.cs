using MySql.Data.MySqlClient;
using Data;
using Models;
using utils;


namespace services
{
    public static class PersonService
    {



        public static Person CreateOrFinde(string input)
        {
            Person person = null;

            if (InputValidator.IsSecretCode(input))
            {
                person = DBManeger.GetBySecretCode(input);

                if (person != null)
                {
                    return person;

                }

            }


            string[] parts = input.Trim().Split(' ');
            string firstName = parts[0];
            string lastName = parts.Length > 1 ? parts[1] : "";

            person = DBManeger.GetByName(firstName, lastName);

            return person;







            // string secretCode = "hjyt"; //put some value!!!



            // Person Newperson = new Person
            // (
            //     firstName,
            //     lastName,
            //     secretCode,
            //     "reporter"


            // );









        }






    }

}