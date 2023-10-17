using System;
using System.Text.RegularExpressions;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        var _reference = new Reference();
        var _words = scriptureInput.Split("").Select(w => new Word(w)).ToList();
        var scripture = new Scripture (_reference, _words);
        Console.Clear();
        DisplayScripture(scripture);

        Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
        string input = Console.ReadLine();

        while (scripture.HasHiddenWords() && input !="quit")
        {
            if (input == "")
            {
                scripture.HideRandomWord();
                Console.Clear();
                DisplayScripture(scripture);
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to hide more words or type 'quit' to exit.");
            }
            input = Console.ReadLine();
        }
        static void DisplayScripture(Scripture scripture)
        {
            Console.WriteLine(scripture.Render());
        }
    }
}


