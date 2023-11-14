using System;
using System.Data;
using System.IO;

public abstract class Goal
{   
    private  int i = 1;
    private  int _achieve = 0;
    private  string _goal;
    // private  List<string> _goals = new List<string>();
    private  string _name;
    private  string _description;
    private  int _score = 0;
    private  int _time = 0;
    private  int _bonus = 0;


    public void CreateNewGoal()
    {
        Console.Write("What is name of your goal? ");
        _name = Console.ReadLine();        
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        // Console.Write("What is the amount of points associated with this goal? ");
        // _score = int.Parse(Console.ReadLine());
        // Console.WriteLine($"Goal: {_name}  Description: {_description}  Grade: {_score}");
    }
    // public string GetName()
    // {
    //     return _name; 
    // }
    // public void SetName()
    // {
    //     Console.Write("What is name of your goal? ");
    //     _name = Console.ReadLine(); 
    // }

    // public string GetDescription()
    // {
    //     return _description;
    // }
    // public void SetDescription()
    // {
    //     Console.Write("What is a short description of it? ");
    //     _description = Console.ReadLine();
    // }

    public int GetScore()
    {
        return _score;
    }
    public void SetScore()
    {
        Console.Write("What is the amount of points associated with this goal? ");
        _score = int.Parse(Console.ReadLine());
    }

    public int GetTime()
    {
        return _time;
    }
    public void SetTime()
    {
        Console.Write("How many times does this goal need to be accomplished for a bonus ? ");
        _time = int.Parse(Console.ReadLine());
    }
    public int GetBonus()
    {
        return _bonus;
    }
    public void SetBonus()
    {
        Console.Write("What is bonus for accomplishing it that many times? ");
        _bonus = int.Parse(Console.ReadLine());
    }
    public int GetAchieve()
    {
        return _achieve;
    }
    public void SetAchieve()
    {
        _achieve ++;        
    }
    public string GetGoal()
    {
        _goal = $"{i}. [{Check()}] {_name} ({_description})"; 
        i ++;
        return _goal;
    }

    public abstract int Grades();
    public abstract string Check();


}