using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
class Activity
{
    public int _duration;
    private List<string> _animationStrings = new List<string>
    {
        "|", "/", "-", "\\",
        "|", "/", "-", "\\"
    };
    public List<string> animationStrings
    {
        get { return _animationStrings; }
    }
        // animationStrings = new List<string>
        // public List<string> animationStrings = list;
        // animationStrings.Add("|");
        // animationStrings.Add("/");
        // animationStrings.Add("-");
        // animationStrings.Add("\\");
        // animationStrings.Add("|");
        // animationStrings.Add("/");
        // animationStrings.Add("-");
        // animationStrings.Add("\\");

    public void ActivityOptions()
    {   Console.ForegroundColor = ConsoleColor.Blue;    
        Console.WriteLine("Menu Options:");              
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit"); 
        Console.Write("Select a choice from the menu: "); 
    } 
    public void Message(string activity, string text)
    {
        Console.WriteLine($"Welcome to the {activity} Activity.");
        Console.WriteLine();
        Console.WriteLine(text);
        Console.WriteLine();
        Console.Write($"How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.Write($"Get ready");
        // Change text color to green
        Console.ForegroundColor = ConsoleColor.Green;
        Waiting();
        Console.WriteLine();
    }

    public int Duration
    {
        get { return _duration; }
    }
    public void Waiting()
    {
        for (int i = 3; i>0 ; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
    }
    public void CountDown()
    {
        for (int i = 5; i>0 ; i--)
        {
            // Change text color to green
            Console.ForegroundColor = ConsoleColor.Green;            
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public void Done(string activity)
    {
        // Change text color to blue
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {activity} Activity.");
        Console.WriteLine();
        Thread.Sleep(1000);
        // Change text color back to the default (usually white)
        Console.ResetColor();
        //Ater finishing the activity, update the value of _duration
        _duration += _duration;
    }

}