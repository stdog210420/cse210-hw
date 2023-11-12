using System;
using System.Data;
using System.IO;

public abstract class Goal
{   
    private static int i = 1;
    private  int _achieve;
    private  string _goal;
    private  List<string> _goals = new List<string>();
    private  string _check = "";
    private  string _name;
    private  string _description;
    private  int _score = 0;
    private  int _grade = 0;

    public Goal(int i, string check)
    {
        i = 0;
        check = "";
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
    }
    public string _Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string _Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public int _Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public string _GoalText
    {
        get { return _goal; }
        set { _goal = value; }
    }
    public List<string> _GoalList
    {
        get { return _goals; }
        set { _goals = value; }
    }

    public int _Achieve
    {
        get { return _achieve; }
        set { _achieve = value; }
    }

    public abstract int Grades();
    public abstract string Check();


}