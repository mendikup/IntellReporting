namespace Models
{


    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecretCode { get; set; }

        public string Type { get; set; }  // "reporter", "target", "both", "potential_agent"

        public int NumReports { get; set; } = 0;

        public int NumMentions { get; set; } = 0;





        public Person(int id, string firstName, string lastName, string secretCode, string type, int numReports, int numMentions)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SecretCode = secretCode;
            Type = type;
            NumReports = numReports;
            NumMentions = numMentions;
        }

        public Person(string firstName, string lastName, string secretCode, string type, int numReports = 0, int numMentions = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            SecretCode = secretCode;
            Type = type;
            NumReports = numReports;
            NumMentions = numMentions;
        }



        public void PrintObject()
        {
            System.Console.WriteLine($"person detailes- id: {Id} ||| first name: {FirstName} ||| last name: {LastName} ||| secret code: {SecretCode} ||| type: {Type} ||| num reports: {NumReports}||| num mentions {NumMentions}");
        }

    }

        
    
}