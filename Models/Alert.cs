namespace Models
{
    public class Alert
    {
       public int Id { get; set; }
       public int TargetId { get; set; }
       public string Reasone { get; set; }
       public DateTime Time_Of_creation { get; set; }

        public Alert(int id, int targetId, string reasone ,DateTime timeOfCreation)
        {
            Id = id;
            TargetId = targetId;
            Reasone = reasone;
            Time_Of_creation = timeOfCreation;

        }

        //anoter construction for insert Alert to the DB id auotomatically created
        public Alert(int targetId, string reasone)
        {

            TargetId = targetId;
            Reasone = reasone;
            Time_Of_creation = DateTime.Now;

        }
    }
}