using Data;
using Models;
using Models.intel;
using services;

namespace ConsoleUI
{
    public static class Menu
    {
        public static void start()
        {
            Console.WriteLine("-----WELCOME TO TO MALSHINON SYSTEM-----");

            Console.WriteLine("enter first and last name  seperetd by space or provide your secret code");
            string NameOrCode = Console.ReadLine();
            var user = PersonService.CreateOrFind(NameOrCode);
            Console.WriteLine($"Hi {user.FirstName} welcome to malshinon system");
            Console.WriteLine();



            string input = "";
            while (input != "5")
            {
                Console.WriteLine("what would you like to do:");
                System.Console.WriteLine("  1.submmit report");
                System.Console.WriteLine("  2.view all dangerous");
                System.Console.WriteLine("  3.view system Analitycs");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        System.Console.WriteLine("enter The name of the person you want to report. ( first and last name)  ");
                        Console.WriteLine();
                        string fullName = Console.ReadLine();
                        var target = PersonService.CreateOrFind(fullName);

                        Console.WriteLine("please enter your report");
                        string report = Console.ReadLine();


                        //creates and insert intel instance to the DB and return the instance
                        Intel intel = IntelService.CreateAndInsertIntelReport(user, target, report);


                        //updetes the data base with necessay fields after reporting
                        MatricService.UpdeteAftereport(user, target, intel);
                        MatricService.FindRapiedReport(target);

                        Console.WriteLine();

                        break;


                    case "2":

                        List<Person> Dangerous = PersonService.GetAllDengerous();


                        Console.WriteLine("the most Dangerous people are:");

                        foreach (Person d in Dangerous)
                        {

                            System.Console.WriteLine($"    {d.FirstName} {d.LastName} [{d.NumMentions} reports were reported]");
                            System.Console.WriteLine();
                            System.Console.WriteLine();

                        }






                        break;


                }


            }


        }

    }


}