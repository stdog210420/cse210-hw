using System;
using System.Text.RegularExpressions;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture ();
        Console.Clear();
        scripture.HideRandomWord();

        Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
        string input = Console.ReadLine();

        while (scripture.HasHiddenWords() && input !="quit")
        {
            if (input == "")
            {
                scripture.HideRandomWord();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to hide more words or type 'quit' to exit.");
            }
            input = Console.ReadLine();
        }

    }
}


