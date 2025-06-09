namespace Models.intel
{
    public class Intel
    {
        public int Id;
        public int RporterId;
        public int TargetId;

        public string Content;

        public string Time;


        public Intel(int id, int reportId, int targetId, string content, string time)
        {
            Id = id;
            RporterId = reportId;
            TargetId = targetId;
            Content = content;
            Time = time;
          
        }

    }
}