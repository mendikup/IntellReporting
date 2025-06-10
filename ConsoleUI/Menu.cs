using Data;
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
                        var user= PersonService.CreateOrFind(NameOrCode);
                        Console.WriteLine($"Hi {user.FirstName} welcome to malshinon system");
                        Console.WriteLine();



            string input = "";
            while (input != "5")
            {
                Console.WriteLine("what would you like to do:");
                System.Console.WriteLine("  1.submmit report");
                System.Console.WriteLine("  2.view system Analitycs");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        System.Console.WriteLine("enter The name of the person you want to report. ( first and last name)  ");
                        string fullName = Console.ReadLine();
                        var target= PersonService.CreateOrFind(fullName);
                        DBManeger.IncrementTargetReports(target);
                        DBManeger.IncrementReportertReports(user);
                        Console.WriteLine();

                        break;

                }


            }


        }

    }


}