using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Dynamic;
using System.Diagnostics;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Reference _reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture (_reference, "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        
        Console.WriteLine(scripture.Render());
        Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit or type 'reveal' to reveal.");
        //force the input text to be converted to lowercase
        string input = Console.ReadLine().ToLower();

        while (input != "quit")
        {   Console.Clear();
            //If the user presses the Enter key
            //check if scripture.HasHiddenWords() and input ="" these two conditions are met.   
            if (input == ""  && scripture.HasHiddenWords())
            {   //HideRandomWord method on the scripture object to randomly hide words, and the count of hidden words is stored in the _wordsToHide variable.
                scripture.HideRandomWord();
                Console.WriteLine(scripture.Render());   

            }
            else if (input == "reveal")
            {   //HideRandomWord method on the scripture object to randomly hide words, and the count of hidden words is stored in the _wordsToHide variable.
                scripture.revealRandomWord();
                Console.WriteLine(scripture.revealRender());   

            }
            else if(!scripture.HasHiddenWords())
            {
                Console.WriteLine("All words are hidden.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to hide more words or type 'quit' to exit or type 'reveal' to reveal.");
                Console.Clear();
            }          
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit or type 'reveal' to reveal.");
            input = Console.ReadLine().ToLower();
        }
        // Move the rendering of the scripture here, after the while loop has finished
        Console.WriteLine(scripture.Render());   

    }
}
