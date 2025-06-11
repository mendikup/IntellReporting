using MySql.Data.MySqlClient;
using Data;
using Models;
using utils;
using Microsoft.VisualBasic;
using Models.intel;


namespace services
{
    public static class IntelService
    {
        public static Intel CreateAndInsertIntelReport(Person reporete, Person target, string intel)
        {
            Intel report = new Intel(reporete.Id, target.Id, intel, DateTime.Now);

            try
            {
                IntelDBManeger.InsertNewRreport(report);
                Console.WriteLine("[LOG]: new intel report was created successfully");

            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            
             

            



            
            return report;
            
            
            
        }
    }
}