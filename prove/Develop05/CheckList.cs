using System;

public class Checklist:Goal
{

    private int _grade;    
    private  int _time = 0;
    private  int _bonus = 0;
    private  string _goal;
    private  string _saveGoal;
    private  string _check;
    public override string GetGoal(int i = 0)
    {
        _goal = $"{i}. [{Check()}] {GetName()} ({GetDescription()})--Currently completed {GetAchieve()}/{_time}"; 
        return _goal;
    }
    public override string SaveGoal()
    {
        _saveGoal = $"CheckListGoal: {GetName()}, {GetDescription()}, {GetScore()}, {GetBonus()}, {GetAchieve()}, {GetTime()}"; 
        return _saveGoal;
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
    public override int Grades()
    {
        if (GetAchieve() == 0)
        {
            Console.WriteLine ($"\nYou have 0 points.");
            _grade = 0;
            return _grade;
        }
        else
        {
            _grade += GetScore() * GetAchieve() + GetBonus();
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
    }
    public override string Check()
    {
        if (GetAchieve() < GetTime())
        {
            return " ";
        }
        else if(GetAchieve() == GetTime())
        {
            return "X";
        }     
            return "X";
    }
    public override void IsComplete()
    {        
        if (GetAchieve() < GetTime())
        {
            _check =  " ";
        }
        else if(GetAchieve() == GetTime())
        {
            _check =  "X";
        }        
    }
    public override void RecordEvent()
    {        
        
    }
}