using System;
using System.IO;

public abstract class Goal
{   private int _achieve = 0;
    private int i = 1;
    private string _goal;
    private List<string> _goals = new List<string>();
    private string _check = "";
    private string _name;
    private string _description;
    private int _score = 0;
    private int _grade = 0;
    private int _time = 0;
    private int _bonus= 0;

    public string GetName()
    {
        return _name;
    }
    public string GetDescrition()
    {
        return _description;
    }
    public string GetCheck()
    {
        return _check;
    }
    public int GetScore()
    {
        return _score;
    }
    public string GetGoal()
    {
        return _goal;
    }
    public int GetAchieve()
    {
        return _achieve;
    }
    public void CreateNewGoal()
    {   
        Console.Write("What is name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _score = int.Parse(Console.ReadLine());
        Console.WriteLine($"Goal: {_name}  Description: {_description}  Grade: {_score}");
        _goal = $"{i}. [{_check}] {_name} ({_description})";
        _goals.Add(_goal);
        i++;
    }

    public void CreateBonus()
    {
        Console.Write("How many times does this goal need to be accomplished for a bonus ? ");
        _time = int.Parse(Console.ReadLine());
        Console.Write("What is bonus for accomplishing it that many times? ");
        _bonus = int.Parse(Console.ReadLine());
        Console.WriteLine($"time: {_time}  bonus: {_bonus} ");
    }

    public int Grades()
    {
        
        _grade = _grade + _score * _achieve + _bonus;
        Console.WriteLine($"You have {_grade} points.");
        return _grade;
    }
    public void ListGoal()
    {
        Console.WriteLine("Display all goals:");
        for (int j = 0; j < _goals.Count; j++)
        {
            Console.WriteLine($"{j + 1}. {_goals[j]}");
        }
    }
    public void SaveGoal(string FileName)
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
            foreach (string goal in _goals)
            {
                outputFile.WriteLine(goal);
            }
        }
        Console.WriteLine("Goals saved successfully in " + FileName);

    }

    public abstract int GetGrade();
  //creat a list to store all entries
    //set an intialized value to Filename

    // public void LoadGoal()
    // {

    // }
    // public void RecordEvent()
    // {

    

}