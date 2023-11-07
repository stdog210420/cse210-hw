using System;

class Program
{
    static void Main(string[] args)
    {
        // Design Requirements
        Simple mySimple = new Simple();
        Eternal myEternal = new Eternal();
        Checklist myChecklist = new Checklist();
        Tracker myTracker = new Tracker();
        Goal myGoal = new Goal();
        string  _choice = "0";
        int i = 0; int j = 0; int k =0;

        while (_choice != "6")
        {

            Console.ForegroundColor = ConsoleColor.Blue;            
            myTracker.TrackerOptions();
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
    }
}