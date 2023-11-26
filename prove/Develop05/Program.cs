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
    public static int _grade;
    public static int _itemNo= 0;
    static void Main(string[] args)
    {
        // Design Requirements
        string  _choice = "0";
        string _fileName;
        while (_choice != "7")
        {            
            Console.ForegroundColor = ConsoleColor.Blue;    
            Console.WriteLine("\nMenu Options:");              
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Events"); 
            Console.WriteLine("  6. Number Guessing Game"); 
            Console.WriteLine("  7. Quit"); 
            Console.Write("Select a choice from the menu: "); 
            _choice = Console.ReadLine();
            switch(_choice)
            {
                // choice 1. Create New Goal
                case "1":
                {        
                    Console.ForegroundColor = ConsoleColor.Blue;    
                    Console.WriteLine("\nThe types of Goals are:");              
                    Console.WriteLine("  1. Simple Goal");
                    Console.WriteLine("  2. Eternal Goals");
                    Console.WriteLine("  3. Checklist Goals");
                    Console.Write("Which type of goal would you like to create? ");
                    _choice = Console.ReadLine();
                    Console.Write("What is name of your goal? ");
                    string _name = Console.ReadLine();        
                    Console.Write("What is a short description of it? ");
                    string _description = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    int _score = int.Parse(Console.ReadLine());
                    switch(_choice)
                    {
                        case "1":
                        {
                            _itemNo ++;
                            string _type = "SimpleGoal";
                            Simple simple = new Simple(_itemNo, _type, _name, _description, _score, 0, false);
                            Console.WriteLine($"You have {simple.CalculateScore(_grade)} points.");
                            _goals.Add(simple);  // Add the goal to the list                                                 
                            break;
                        }
                        case "2":
                        {
                            _itemNo ++;
                            string _type = "EternalGoal";
                            Eternal eternal = new Eternal(_itemNo, _type, _name, _description, _score, 0);
                            Console.WriteLine($"You have {eternal.CalculateScore(_grade)} points.");
                            _goals.Add(eternal);  // Add the goal to the list 
                            break;
                        }
                        case "3":
                        {
                            _itemNo ++;
                            Console.Write("How many times does this goal need to be accomplished for a bonus ? ");
                            int _time = int.Parse(Console.ReadLine());
                            Console.Write("What is bonus for accomplishing it that many times? ");
                            int _bonus = int.Parse(Console.ReadLine());
                            string _type = "CheckListGoal";
                            CheckList checkList = new CheckList(_itemNo, _type, _name, _description, _score, 0, _time, _bonus);
                            Console.WriteLine($"You have {checkList.CalculateScore(_grade)} points.");
                            _goals.Add(checkList);  // Add the goal to the list     
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
                case "6":
                {
                    NumberGuessGame();
                    break;
                }
                // choice 7. Quit  
                case "7":
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
        Console.WriteLine("The goals are: ");
        foreach (Goal go in _goals)
        {
            Console.WriteLine($"{go.ListItem()}");
        }
        Console.WriteLine($"You have {_grade} points.");  
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
        using (StreamWriter outputFile = new StreamWriter(FileName, false)) // 使用 true 參數表示追加模式, false表示非追加模式
        {
            //write grade in the first line
            outputFile.WriteLine(_grade);
            // Write new goals into the file
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
            if (int.TryParse(line, out int grade))
            {
                _grade = grade;
            }
            else
            {
                Goal goal = CreateGoalFromLine(line);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
        // 现在_goals列表包含從文件中加載的所有目標
        ListGoal();
    }
    public static Goal CreateGoalFromLine(string line)
    {
        string[] parts = line.Split(": ");

        if (parts.Length > 1)
        {
            // SimpleGoal: Give a talk, Speak in Sacrament meeting when asked., 200, false
            //_goalType= SimpleGoal
            //_goalData= Give a talk, Speak in Sacrament meeting when asked, 200, flase
            string _goalType = parts[0];
            string _goalData = parts[1];

            switch (_goalType)
            {
                case "SimpleGoal":
                    return CreateSimpleGoal(_goalData);
                case "EternalGoal":
                    return CreateEternalGoal(_goalData);
                case "CheckListGoal":
                    return CreateCheckListGoal(_goalData);
                default:
                    Console.WriteLine($"Unknown goal type: {_goalType}");
                    return null;
            }
        }
        return null;
    }
    // SimpleGoal: Give a talk, Speak in Sacrament meeting when asked., 200, false
    public static Simple CreateSimpleGoal(string data)
    {
        _itemNo ++;
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
            string _Loadname = _parts[0];
            string _LoadDescription = _parts[1];
            int _loadScore = int.Parse(_parts[2]);
            bool _loadCheck  =bool.Parse(_parts[3]);
            if (_loadCheck == true)
            {         
                Simple loadSimple = new Simple(_itemNo, "SimpleGoal",_Loadname, _LoadDescription, _loadScore, 1, _loadCheck);
                return loadSimple;
            }
            else
            {
                Simple loadSimple = new Simple(_itemNo, "SimpleGoal",_Loadname, _LoadDescription, _loadScore, 0, _loadCheck);
                return loadSimple;
            }
        }
        else
        {
            Console.WriteLine("Invalid data format.");
            return null;
        }
    }
    // EternalGoal: Study scripture, Study scripture for 10 minutes every day., 50
    public static Eternal CreateEternalGoal(string data)
    {
        _itemNo ++;
        // 将字符串分割成子字符串数组
        string[] _parts = data.ToString().Split(',');
        // 移除各个部分的前后空格
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i] = _parts[i].Trim();
        }
        // 确保我们有足够的部分
        if (_parts.Length == 3)
        {
            string _Loadname = _parts[0];
            string _LoadDescription = _parts[1];
            int _loadScore = int.Parse(_parts[2]);

            Eternal loadEternal = new Eternal(_itemNo, "EternalGoal",_Loadname, _LoadDescription, _loadScore, 0);
            return loadEternal;
        }
        else
        {
            Console.WriteLine("Invalid data format.");
            return null;
        }
    }
    // CheckListGoal: Attend the temple, Attend and perform any ordinance, 200, 1000, 0, 3
    public static CheckList CreateCheckListGoal(string data)
    {
        _itemNo ++;
        // 将字符串分割成子字符串数组
        string[] _parts = data.ToString().Split(',');
        // 移除各个部分的前后空格
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i] = _parts[i].Trim();
        }
        // 确保我们有足够的部分
        if (_parts.Length == 6)
        {
            string _Loadname = _parts[0];
            string _LoadDescription = _parts[1];
            int _loadScore = int.Parse(_parts[2]);
            int _loadBonus = int.Parse(_parts[3]);
            int _loadTime = int.Parse(_parts[4]);
            int _loadPerform = int.Parse(_parts[5]);
            CheckList CheckList = new CheckList(_itemNo, "CheckListGoal",_Loadname, _LoadDescription, _loadScore, _loadPerform, _loadTime, _loadBonus);
            return CheckList;
        }
        else
        {
            Console.WriteLine("Invalid data format.");
            return null;
        }
    }
    public static void RecordEvent()
    {
        Console.WriteLine("The goals are: ");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.ListItem());
        }
        Console.Write("Which goal did you accomplish? ");
        int _accomplishedGoalIndex = int.Parse(Console.ReadLine()) - 1;
        if (_accomplishedGoalIndex >= 0 && _accomplishedGoalIndex < _goals.Count)
        {
            _goals[_accomplishedGoalIndex].SetPerform (1);
            _grade = _goals[_accomplishedGoalIndex].CalculateScore(_grade);
            if (_goals[_accomplishedGoalIndex].IsCompleted())
            {

                Console.WriteLine($"You now have {_grade} scores.");
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {_goals[_accomplishedGoalIndex].Score()} points.");  
                Console.WriteLine($"You now have {_grade} scores.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
    public static void NumberGuessGame()
    {
        NumberGuess numberGuess = new NumberGuess();
        numberGuess.StartGame();
        Console.WriteLine($"The winning number is: {numberGuess.RandomNumber()}");
        if (numberGuess.PlayerNumber() == numberGuess.RandomNumber())
        {
            Console.WriteLine($"Congratulation! You guess it. You win {numberGuess.PlayerBet()} points.");
            _grade += numberGuess.PlayerBet();
            Console.WriteLine($"You now have {_grade} scores.");
        }
        else
        {
            Console.WriteLine($"Sorry! You guess it wrong. You loss {numberGuess.PlayerBet()} points."); 
            _grade -= numberGuess.PlayerBet();
            Console.WriteLine($"You now have {_grade} scores.");
        }
    }
    
}