using System;
using System.Xml.XPath;

class Program
{
    static void Main(string[] args)
    {
        //DisplayWelcome - Displays the message, "Welcome to the Program!"
        DisplayWelcome("Welcome to the Program!");
        //PromptUserName - Asks for and returns the user's name (as a string)
        string Name = PromptUserName();
        //PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
        int Number= PromptUserNumber();
        //SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
        int Square= SquareNumber(Number);
        //DisplayResult - Accepts the user's name and the squared number and displays them.
        DisplayResult(Name, Square);

    }
    static void DisplayWelcome(string message)
    {
        Console.WriteLine(message);
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;     
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;     
    }
    static int SquareNumber(int number)
    {
        int square= number * number;
        return square;     
    }      
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }  

}