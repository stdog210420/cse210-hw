using System;

public class Checklist:Goal
{

    private int _grade;    
    private  string _goal;
    private  string _saveGoal;
    private  string _check;
    public override string GetGoal(int i = 0)
    {
        _goal = $"{i}. [{GetCheck}] {GetName()} ({GetDescription()})--Currently completed {GetAchieve()}/{GetTime()}"; 
        return _goal;
    }
    public override string SaveGoal()
    {
        _saveGoal = $"CheckListGoal: {GetName()}, {GetDescription()}, {GetScore()}, {GetBonus()}, {GetAchieve()}, {GetTime()}"; 
        return _saveGoal;
    }


    public override int CalculateScore()
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