using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        // Design Requirements

        Tracker myTracker = new Tracker();
        string  _choice = "0";
        string _fileName;
        Simple mySimple = new Simple(1, "");
        Eternal myEternal = new Eternal(1, "");
        Checklist myChecklist = new Checklist(1, "");

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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;            
                    myTracker.CreateGoal();
                    _choice = Console.ReadLine();
                    switch(_choice)
                    {
                        case "1":
                        {
                            mySimple.CreateNewGoal();
                            mySimple.Grades();
                            break;
                        }
                        case "2":
                        {
                            myEternal.CreateNewGoal();
                            myEternal.Grades();
                            break;
                        }
                        case "3":
                        {
                            myChecklist.CreateNewGoal();
                            myChecklist.CreateBonus();
                            myChecklist.Grades();
                            break;
                        }  
                    }                        
                    
                    break;
                }
                // choice 2. List Goals
                case "2":
                {                
                    myTracker.ListGoal();

                    break;
                }
                // choice 3. Save Goals  
                case "3":
                {
                    Console.WriteLine("What is the filename for the goal file? ");
                    _fileName = Console.ReadLine();
                    myTracker.SaveGoal(_fileName);

                    break;
                }
                // choice 4. Load Goals  
                case "4":
                {
                    // myTracker.LoadGoal();

                    break;
                }
                // choice 5. Record Events 
                case "5":
                {
                    // myTracker.RecordEvent();

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