using System;

public class Eternal:Goal
{

    private int _grade;
    private  string _goal;
    private  string _saveGoal;
    public override string GetGoal(int i = 0)
    {
        _goal = $"{i}. [{GetCheck()}] {GetName()} ({GetDescription()})"; 
        return _goal;
    }
    public override string SaveGoal()
    {
        _saveGoal = $"EternalGoal: {GetName()}, {GetDescription()}, {GetScore()}"; 
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
            _grade += GetScore() * GetAchieve();
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
    }
    public override void IsComplete()
    {        
        
    }
    public override void RecordEvent()
    {        
        
    }   
}