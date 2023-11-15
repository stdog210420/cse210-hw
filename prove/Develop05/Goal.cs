using System;
using System.Data;
using System.IO;

public abstract class Goal
{   
    private  int _achieve = 0;
    private  string _goal;
    // private  List<string> _goals = new List<string>();
    private  string _name;
    private  string _description;
    private  int _score = 0;
    private int _check = 0;

    public void CreateNewGoal()
    {
        Console.Write("What is name of your goal? ");
        _name = Console.ReadLine();        
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
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


    public int GetAchieve()
    {
        return _achieve;
    }
    public void SetAchieve()
    {
        _achieve ++;        
    }
    public int GetCheck()
    {
        return _check;
    }
    public void SetCheck()
    {
        _check ++;        
    }
    public string GetGoal(int i = 0)
    {
        _goal = $"{i}. [{Check()}] {_name} ({_description})"; 
        return _goal;
    }

    public abstract int Grades();
    public abstract string Check();


}