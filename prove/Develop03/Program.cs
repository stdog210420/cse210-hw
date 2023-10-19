using System;
using System.Text.RegularExpressions;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture ("Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        int _wordsToHide = 0;
        
        Console.Clear();

        Console.WriteLine(scripture.Render());

        Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
        string input = Console.ReadLine();

        while (scripture.HasHiddenWords() && input !="quit")
        {
            if (input == "")
            {
                scripture.HideRandomWord();
                Console.Clear();
                Console.WriteLine(scripture.Render());
                _wordsToHide ++;
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to hide more words or type 'quit' to exit.");
            }
            input = Console.ReadLine();
        }

    }
}


