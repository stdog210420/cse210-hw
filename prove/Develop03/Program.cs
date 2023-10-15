using System;
using System.Text.RegularExpressions;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string scriptureInput = "Proverbs 3:5-6: Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        var scripture = new Scripture (scriptureInput);
        Console.Clear();
        DisplayScripture(scripture);

        while (scripture.HasHiddenWords)
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input == "quit")
                break;
            scripture.HideRandomWord();
            Console.Clear;
            DisplayScripture(scripture);
        }
        static void DisplayScripture(Scripture scripture)
        {
            Console.WriteLine(scripture.Render());
        }
    }
}


