using System;

public class Eternal:Goal
{

    private int _grade;
    private  string _goal;
    private  string _saveGoal;
    public override string GetGoal(int i = 0)
    {
        _goal = $"{i}. [{Check()}] {GetName()} ({GetDescription()})"; 
        return _goal;
    }
    public override string SaveGoal()
    {
        _saveGoal = $"EternalGoal: {GetName()}, {GetDescription()}, {GetScore()}"; 
        return _saveGoal;
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
            _grade += GetScore() * GetAchieve();
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
    }

    public override string Check()
    {
    
        return " ";
    }
    public override void IsComplete()
    {        
        
    }
    public override void RecordEvent()
    {        
        
    }   
}