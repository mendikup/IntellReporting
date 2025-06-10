using Data;
using services;
using Models;

public class Program
{
    public static void Main(string[] args)
    {
        // var person = PersonService.CreateOrFind("C3D4E5F6");
        var person1 = PersonService.CreateOrFind("yoni lalo");
        // System.Console.WriteLine(person1.FirstName + " " + person1.LastName);

        person1.PrintObject();
    }
}