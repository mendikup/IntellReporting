using Models;
using Data;
using Models.intel; 

namespace services
{
    public static class MatricService
    {
        public static void UpdeteAftereport(Person reporter, Person target, Intel report)
        {
            DBManeger.IncrementTargetReports(target);

            DBManeger.IncrementReporterNumOfReports(reporter);

            int averageCaharactersInReport = DBManeger.GetAverageCarecters(reporter);
            int numberOfReports = DBManeger.GetNumberOfReports(reporter);


            if (averageCaharactersInReport > 35 && numberOfReports >= 7 && reporter.Type!= "potential_agent")
            {
                DBManeger.updateStatus(reporter, "potential_agent");

                Console.WriteLine($"reporter: {reporter.FirstName} || number of reports is: {reporter.NumReports} and he is a potential agant");
            }

          
        


        }

    
    }
}