using Models;
using Data;
using Models.intel;

namespace services
{
    public static class MatricService
    {
        public static void UpdeteAftereport(Person reporter, Person target, Intel report)
        {



            int averageCaharactersInReport = IntelDBManeger.GetAverageCarecters(reporter);

            int numberOfReports = PersonDBManeger.GetNumberOfReports(reporter);

            int numOfTargetMention = PersonDBManeger.GetNumOfmention(target);

            int numOfReporterMention = PersonDBManeger.GetNumOfmention(reporter);




            //check if the roprter is a potential agent or target ,if so update his status
            if (averageCaharactersInReport > 35 && numberOfReports >= 11 && reporter.Type != "potential_agent")
            {
                PersonDBManeger.updateStatus(reporter, "potential_agent");

                Console.WriteLine($"reporter: {reporter.FirstName} || number of reports is: {reporter.NumReports} and he is a potential agant");
            }



            if (numOfTargetMention == 0 && target.Type == "reporter")
            {
                PersonDBManeger.updateStatus(target, "target");
            }



            if (numOfReporterMention > 0 && numberOfReports > 0 && reporter.Type == "reporter")

            {
                PersonDBManeger.updateStatus(reporter, "both");

            }

            //checks if the target is dangerous 

            if (numOfTargetMention > 20 && target.IsDangerous == 0)
            {
                PersonDBManeger.MarkAsDangerous(target);
                Console.WriteLine($"[ALERT]{target.FirstName} {target.LastName} is dangerous!! ");


            }

            // if the target is already dangerous just allert.
            else if (numOfTargetMention > 20 && target.IsDangerous > 0)
            {
                Console.WriteLine($"[ALERT]{target.FirstName} {target.LastName} is dangerous!! ");

            }


            PersonDBManeger.IncrementTargetReports(target);
            PersonDBManeger.IncrementReporterNumOfReports(reporter);

        }
        




        public static void FindRapiedReport(Person target)
        {
            List<DateTime> theLastTreeRepotTimeStamp = IntelDBManeger.GetTheLastThreeReports(target);
            DateTime theFirst = theLastTreeRepotTimeStamp[1];
            DateTime theLast = theLastTreeRepotTimeStamp[0];

            TimeSpan diff = theLast - theFirst;



            if (diff.TotalMinutes <= 15)
            {
                Console.WriteLine($"Atention: new Alert was created");

                Alert alert = new Alert(target.Id, $"Atention: {target.FirstName} has more than 3 reports less than 15 minuets !!");
                AlertDBManeger.InsertNewAlert(alert); 
            }




        }


    }
}