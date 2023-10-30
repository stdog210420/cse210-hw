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
        int i = 0; int j = 0; int k =0;

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
                    i ++;
                    break;
                }
                // choice 2. Reflection Activity
                case "2":
                {                
                    myReflection.ReflectionActivity();
                    j ++;
                    break;
                }
                // choice 3. Listing Activity  
                case "3":
                {
                    myListing.ListingActivity();
                    k ++;
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
        Console.WriteLine($"\nToday's Activity Statistics:\n");
        Console.WriteLine($"Breathing activity: {i} 次, totoal duration: {activity.Duration} seconds");
        Console.WriteLine($"Reflection activity: {j} 次, totoal duration: {activity.Duration} seconds");
        Console.WriteLine($"Listing activity: {k} 次, totoal duration: {activity.Duration} seconds");

    }
}