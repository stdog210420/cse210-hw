using System;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        // Design Requirements
        Activity activity = new Activity();
        Breathing myBreathing = new Breathing();
        Reflection myReflection = new Reflection();
        Listing myListing = new Listing();
        string  _choice = "0";
        
        while (_choice != "4")
        {
            activity.ActivityOptions();
            _choice = Console.ReadLine();

            switch(_choice)
            {
                // choice 1. Breathing Activity
                case "1":
                {
                    myBreathing.BreathingActivity();
                    break;
                }
                // choice 2. Reflection Activity
                case "2":
                {                
                    myReflection.ReflectionActivity();
                    break;
                }
                // choice 3. Listing Activity  
                case "3":
                {
                    myListing.ListingActivity();
                    break;
                }
                // choice 4. Quit  
                case "4":
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Already Quit!");
                    break;
                }
            }
        }
    }
}