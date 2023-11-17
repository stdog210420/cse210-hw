using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Program
{
    //在使用 _goalList 之前確保它不是 null，可以在程式開始時初始化它。
    public static List<string> _goalList = new List<string>();
    public static List<string> _saveGoalList = new List<string>();
    public static string _goal;
    public static string _saveGoal;
    public static int j = 1;
    public static string _item;
    static void Main(string[] args)
    {
        // Design Requirements

        Tracker myTracker = new Tracker();
        string  _choice = "0";
        string _fileName;
        Simple mySimple = new Simple();
        Eternal myEternal = new Eternal();
        Checklist myChecklist = new Checklist();
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
                            mySimple.CreateNewGoal();
                            mySimple.CalculateScore();
                            _goal = mySimple.GetGoal(j);
                            _saveGoal = mySimple.SaveGoal();                           
                            break;
                        }
                        case "2":
                        {
                            myEternal.CreateNewGoal();
                            myEternal.CalculateScore();
                            _goal = myEternal.GetGoal(j);
                            _saveGoal = myEternal.SaveGoal();    
                            break;
                        }
                        case "3":
                        {

                            myChecklist.CreateNewGoal();
                            myChecklist.CreateBonus();
                            myChecklist.CalculateScore();
                            _goal = myChecklist.GetGoal(j);
                            _saveGoal = myChecklist.SaveGoal();    
                            break;
                        }  
                    }                        
                    _goalList.Add(_goal);
                    _saveGoalList.Add(_saveGoal);
                    j ++;
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

    // public static void GetGoalList(Goal g)
    // {   
    //     _goalList = new List<string>();
    //     _goalList.Add(g.GetGoal());      
    // }
    
    public static void ListGoal()
    {      
        Console.WriteLine("\nDisplay all goals:");
        for (int j = 0; j < _goalList.Count; j++)
        {
            Console.WriteLine($"{_goalList[j]}");
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
            foreach (string _item in _saveGoalList)
            {
                outputFile.WriteLine(_item);
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
        Console.WriteLine("Select a choice from the menu: ");
        _item = Console.ReadLine();
        Console.WriteLine("The goals are:");
        Console.WriteLine($"{_goalList}");        
    }
    
}