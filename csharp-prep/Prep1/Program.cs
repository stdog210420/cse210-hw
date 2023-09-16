using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?");
        String name1 = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        String name2 = Console.ReadLine();
        Console.WriteLine($"Your name is {name1}, {name1} {name2}.");


    }
}