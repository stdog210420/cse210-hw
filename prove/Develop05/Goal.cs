using System;
using System.Data;
using System.IO;

public abstract class Goal
{   
    private  string _name;
    private  string _description;
    private  int _score = 0;
    private  int _time = 0;
    private  int _bonus = 0;
    private  int _achieve = 0;
    public void CreateNewGoal()
    {
        Console.Write("What is name of your goal? ");
        _name = Console.ReadLine();        
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _score = int.Parse(Console.ReadLine());
    }

    public void CreateBonus()
    {
        Console.Write("How many times does this goal need to be accomplished for a bonus ? ");
        _time = int.Parse(Console.ReadLine());
        Console.Write("What is bonus for accomplishing it that many times? ");
        _bonus = int.Parse(Console.ReadLine());
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetName()
    {
        return _name; 
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetScore(int score)
    {
        _score = score;
    }
    public int GetScore()
    {
        return _score;
    }
    public int GetBonus()
    {
        return _bonus;
    }
    public int GetTime()
    {
        return _time;
    }
    public void SetAchieve(int achieve)
    {
        _achieve = achieve;
    }
    public int GetAchieve(int perform)
    { 
        if (perform == 0)
        {
            _achieve = 0;
            return _achieve;
        }
        else
        _achieve ++;
        return _achieve;
    }  

    public abstract string GetGoal(int i = 0);
    public abstract string SaveGoal();
    public abstract string ListItem(int i = 0);
    public abstract string IsComplete();
    public abstract int CalculateScore();


}