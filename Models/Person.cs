namespace Models.Person
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string SecretName;
        public int Type;
        public int NumReports;
        public int NumMentions;

        public Person(int id, string firstName, string lastName, int type, int numeRports, int numMentions)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            NumReports = numeRports;
            NumMentions = numMentions;
        }

    }
}