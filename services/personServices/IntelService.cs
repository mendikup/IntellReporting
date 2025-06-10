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
        public static void CreateIntelreport(Person reporete, Person target, string intel)
        {
            Intel report = new Intel(reporete.Id, target.Id, intel, DateTime.Now);

            DBManeger.InsertNewRreport(report);
            
            
            
        }
    }
}