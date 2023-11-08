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
                // choice 1. Create New Goal
                case "1":
                {
                    
                    while (_choice != "")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;            
                        myTracker.CreateGoal();
                        _choice = Console.ReadLine();
                        switch(_choice)
                        {
                            case "1":
                            {
                                break;
                            }
                            case "2":
                            {
                                break;
                            }
                            case "3":
                            {
                                break;
                            }  
                        }                      
                    }                    
                    
                    break;
                }
                // choice 2. List Goals
                case "2":
                {                
                    myTracker.ListGoal();
                    j ++;

                    break;
                }
                // choice 3. Save Goals  
                case "3":
                {
                    myTracker.ListingActivity();
                    k ++;  
                    break;
                }
                // choice 4. Load Goals  
                case "4":
                {
                    myTracker.ListingActivity();
                    k ++;  
                    break;
                }
                // choice 5. Record Events 
                case "5":
                {
                    myTracker.ListingActivity();
                    k ++;  
                    break;
                }
                // choice 6. Quit  
                case "6":
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine("Already Quit!");
                    break;
                }
            }

        }
    }
}