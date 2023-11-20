using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Program
{
    //在使用 _goalList 之前確保它不是 null，可以在程式開始時初始化它。
    private static List<Goal> _goals = new List<Goal>();
    public static int j = 1;
    public static int _perform = 0;
    static void Main(string[] args)
    {
        // Design Requirements

        Tracker myTracker = new Tracker();
        string  _choice = "0";
        string _fileName;
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
                            newGoal.CreateBonus();
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
                    RecordEvent();
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
        int i = 0;
        Console.WriteLine("\nDisplay all goals:");
        foreach (var goal in _goals) 
        {
            i ++;
            Console.WriteLine(goal.GetGoal(i));
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
        foreach (string line in _lines)
        {
                Goal goal = CreateGoalFromLine(line);
            if (goal != null)
            {
                _goals.Add(goal);
            }
            ListGoal();
            // string[] _parts = _lines[i].Split("");
            // foreach (string part in _parts)
            // {
            //     Console.WriteLine(part);
            // }
        }
    }
    public static Goal CreateGoalFromLine(string line)
    {
        string[] parts = line.Split(": ");

        if (parts.Length < 2)
        {
            Console.WriteLine($"Invalid data format: {line}");
            return null;
        }

        string goalType = parts[0];
        string goalData = parts[1];

        switch (goalType)
        {
            case "SimpleGoal":
                return CreateSimpleGoal(goalData);
            case "EternalGoal":
                return CreateEternalGoal(goalData);
            case "CheckListGoal":
                return CreateCheckListGoal(goalData);
            default:
                Console.WriteLine($"Unknown goal type: {goalType}");
                return null;
        }
    }
    public string name;
    public static Simple CreateSimpleGoal(string data)
    {
        int k = 0;
        // 将字符串分割成子字符串数组
        string[] _parts = data.ToString().Split(',');
        // 移除各个部分的前后空格
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i] = _parts[i].Trim();
        }
        // 确保我们有足够的部分
        if (_parts.Length == 4)
        {
            string name = _parts[0];
            string description = _parts[1];
            int score = int.Parse(_parts[2]);
            bool finish = bool.Parse(_parts[3]);
            int achieve;
            if (finish)
            {            
                achieve= 1;
            }
            else
            {
                achieve= 0;
            }

            // 现在您可以使用这些变量进行后续处理
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Mark: {finish}");
            // 创建 Simple 实例并返回
            mySimple.SetName(name);
            mySimple.SetDescription(description);
            mySimple.SetScore(score);
            mySimple.SetAchieve(achieve);
        }
        else
        {
            Console.WriteLine("Invalid data format.");
        }
        foreach (string part in _parts)
        {
            Console.WriteLine(part);
        }
        k ++;
        return $"{k}. [{simpleGoal.GetAchieve(achieve)}] {name} ({description})";
        // SimpleGoal: Give a talk, Speak in Sacrament meeting when asked., 200, false
        // EternalGoal: Study scripture, Study scripture for 10 minutes every day., 50
        // CheckListGoal: Attend the temple, Attend and perform any ordinance, 200, 1000, 0, 3
        
    }
    public static void RecordEvent()
    {
        Console.WriteLine("The goals are: ");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.ListItem());
        }
        Console.WriteLine("Which goal did you accomplish? ");
        int _accomplishedGoalIndex = int.Parse(Console.ReadLine()) - 1;
        int _sumScore = 0;
        _perform ++;

        if (_accomplishedGoalIndex >= 0 && _accomplishedGoalIndex < _goals.Count)
        {
            _goals[_accomplishedGoalIndex].GetAchieve(_perform);
            _goals[_accomplishedGoalIndex].IsComplete();
            _sumScore += _goals[_accomplishedGoalIndex].GetScore();
            Console.WriteLine($"Congratulations! You have earned {_goals[_accomplishedGoalIndex].GetScore()}2 points.");  
            Console.WriteLine($"You now have {_goals[_accomplishedGoalIndex].CalculateScore()} scores.");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }

    }
    
}