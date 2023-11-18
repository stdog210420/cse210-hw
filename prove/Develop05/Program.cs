using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Program
{
    //在使用 _goalList 之前確保它不是 null，可以在程式開始時初始化它。
    private static List<Goal> _goals = new List<Goal>();
    public static int j = 1;
    public static string _item;
    static void Main(string[] args)
    {
        // Design Requirements

        Tracker myTracker = new Tracker();
        string  _choice = "0";
        string _fileName;

        int _achieve = 0;

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

                            Goal newGoal = new Simple();
                            newGoal.CreateNewGoal();
                            newGoal.CalculateScore();
                            _goals.Add(newGoal);  // Add the goal to the list

                            j++;                                                  
                            break;
                        }
                        case "2":
                        {
                            Goal newGoal = new Eternal();
                            newGoal.CreateNewGoal();
                            newGoal.CalculateScore();
                            _goals.Add(newGoal);  // Add the goal to the list

                            j++;    
                            break;
                        }
                        case "3":
                        {

                            Goal newGoal = new Checklist();
                            newGoal.CreateNewGoal();
                            newGoal.CalculateScore();
                            _goals.Add(newGoal);  // Add the goal to the list

                            j++;      
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
                    SaveGoal(_fileName);
                    break;
                }
                // choice 4. Load Goals  
                case "4":
                {
                    LoadGoal();

                    break;
                }
                // choice 5. Record Events 
                case "5":
                {
                    Console.WriteLine("");
                    myTracker.CreateGoal();
                    _choice = Console.ReadLine();
                    _achieve ++;
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
    
    public static void ListGoal()
    {     
        Console.WriteLine("\nDisplay all goals:");
        foreach (var goal in _goals) 
        {
            Console.WriteLine(goal.GetGoal());
        }
    }
    public static void SaveGoal(string FileName)
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
            foreach (var goal in _goals) 
            {
                outputFile.WriteLine(goal.SaveGoal());
            }
        }
        Console.WriteLine("Goals saved successfully in " + FileName);
    }
    public static void LoadGoal()
    {  
        Console.WriteLine("What is the filename? ");
        string _FileName = Console.ReadLine();                
        Console.WriteLine("Display all journals from " + _FileName + "：");  
        string[] _lines = File.ReadAllLines(_FileName);
        foreach (string goal in _lines)
        {
            string[] _parts = goal.Split("");
            foreach (string part in _parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    public static void RecordEvent()
    {
        Console.WriteLine("The goals are: ");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.ListItem());
        }
        Console.WriteLine("Which goal did you accomplish? ");
        int accomplishedGoalIndex = int.Parse(Console.ReadLine()) - 1;

        if (accomplishedGoalIndex >= 0 && accomplishedGoalIndex < _goals.Count)
        {
            _goals[accomplishedGoalIndex].GetAchieve();
            _goals[accomplishedGoalIndex].IsComplete();
            Console.WriteLine($"Congratulations! You have earned {_goals[accomplishedGoalIndex].GetScore()} points.");  
            Console.WriteLine($"You now have {_goals[accomplishedGoalIndex].CalculateScore()} scores.");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }

    }
    
}