using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Program
{
    public static List<string> _goalList;  
    public static string _goal;
    static void Main(string[] args)
    {
        // Design Requirements

        Tracker myTracker = new Tracker();
        string  _choice = "0";
        string _fileName;
        Simple mySimple = new Simple();
        Eternal myEternal = new Eternal();
        Checklist myChecklist = new Checklist();
        

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
                            mySimple.SetScore();
                            mySimple.Grades();
                            GetGoalList(mySimple);
                            break;
                        }
                        case "2":
                        {
                            myEternal.CreateNewGoal();
                            myEternal.SetScore();
                            myEternal.Grades();
                            GetGoalList(myEternal);
                            break;
                        }
                        case "3":
                        {
                            myChecklist.CreateNewGoal();
                            myChecklist.SetScore();
                            myChecklist.SetBonus();
                            myChecklist.Grades();
                            GetGoalList(myChecklist);
                            break;
                        }  
                    }                        
                    
                    break;
                }
                // choice 2. List Goals
                case "2":
                {                
                    
                    ListGoal();
                    
                    break;
                }
                // choice 3. Save Goals  
                case "3":
                {
                    Console.WriteLine("What is the filename for the goal file? ");
                    _fileName = Console.ReadLine();
                    SaveGoal(_fileName, mySimple);

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
  
    public static void GetGoalList(Goal g)
    {   
        _goalList = new List<string>();
        _goalList.Add(g.GetGoal());      
    }
    
    public static void ListGoal()
    {      
        Console.WriteLine("Display all goals:");
        for (int j = 0; j < _goalList.Count; j++)
        {
            Console.WriteLine($"{_goalList[j]}");
        }
    }
    public static void SaveGoal(string FileName, Goal goal)
    {
        // check if the user type a filename, if not, ask to type one.
        if (string.IsNullOrEmpty(FileName))
        {
            Console.WriteLine("What is the filename? ");
            FileName = Console.ReadLine();
        }

        // Open the file in append mode, create it if it doesn't exist.
        using (StreamWriter outputFile = new StreamWriter(FileName, true)) // 使用 true 參數表示追加模式
        {
            // Write new entries into the file
            foreach (string _goal in _goalList)
            {
                outputFile.WriteLine(_goal);
            }
        }
        Console.WriteLine("Goals saved successfully in " + FileName);

    }


  //creat a list to store all entries
    //set an intialized value to Filename

    // public void LoadGoal()
    // {

    // }
    // public void RecordEvent()
    // {
    
}