namespace Models
{
    public class Alert
    {
        int Id { get; set; }
        int TargetId { get; set; }
        string Reasone { get; set; }
        DateTime Time_Of_creation { get; set; }

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