

namespace Models.intel
{
    public class Intel
    {
        public int Id;
        public int RporterId;
        public int TargetId;

        public string Content;

        public DateTime Time;


        public Intel(int id, int reportId, int targetId, string content, DateTime time)
        {
            Id = id;
            RporterId = reportId;
            TargetId = targetId;
            Content = content;
            Time = time;

        }


        public Intel(int reportId, int targetId, string content, DateTime time)
        {

            RporterId = reportId;
            TargetId = targetId;
            Content = content;
            Time = time;

        }

    }
}