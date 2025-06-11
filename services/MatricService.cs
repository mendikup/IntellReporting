using Models;
using Data;
using Models.intel;

namespace services
{
    public static class MatricService
    {
        public static void UpdeteAftereport(Person reporter, Person target, Intel report)
        {



            int averageCaharactersInReport = DBManeger.GetAverageCarecters(reporter);

            int numberOfReports = DBManeger.GetNumberOfReports(reporter);

            int numOfTargetMention = DBManeger.GetNumOfmention(target);

            int numOfReporterMention = DBManeger.GetNumOfmention(reporter);




            //check if the roprter is a potential agent or target ,if so update his status
            if (averageCaharactersInReport > 35 && numberOfReports >= 11 && reporter.Type != "potential_agent")
            {
                DBManeger.updateStatus(reporter, "potential_agent");

                Console.WriteLine($"reporter: {reporter.FirstName} || number of reports is: {reporter.NumReports} and he is a potential agant");
            }



            if (numOfTargetMention == 0)

            {

                //before updating to type "target" checks if the repoter did not ever report . otherwise he his "both" not "target"
                if (numberOfReports == 0)
                {
                    DBManeger.updateStatus(target, "target");
                }

            }



            if (numOfReporterMention > 0 || reporter.Type != "both" || reporter.Type != "potential_agent")

            {
                DBManeger.updateStatus(reporter, "both");

            }

            //checks if the target is dangerous 

            if (numOfTargetMention > 20 && target.IsDangerous == 0)
            {
                DBManeger.MarkAsDangerous(target);
                Console.WriteLine($"[ALERT]{target.FirstName} {target.LastName} is dangerous!! ");


            }

            // if the target is already dangerous just allert.
            else if (numOfTargetMention > 20 && target.IsDangerous > 0)
            {
                Console.WriteLine($"[ALERT]{target.FirstName} {target.LastName} is dangerous!! ");

            }
            

            DBManeger.IncrementTargetReports(target);
            DBManeger.IncrementReporterNumOfReports(reporter);

        }


    }
}