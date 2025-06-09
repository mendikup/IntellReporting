using Data;
using services;
using Models;

public class Program
{
    public static void Main(string[] args)
    {
        // var person = PersonService.CreateOrFinde("qwertyui");
        var person = PersonService.CreateOrFinde("yosi cohen");
        System.Console.WriteLine(person.FirstName+" "+person.LastName);
    }
}