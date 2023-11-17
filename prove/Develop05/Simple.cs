using System;
using System.Diagnostics.Contracts;

public class Simple:Goal
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
        string _finished = "false";
        if (GetAchieve() != 0)
        {
            _finished = "True";
        }
        _saveGoal = $"SimpleGoal: {GetName()}, {GetDescription()}, {GetScore()}, {_finished}"; 
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
            _grade += GetScore();
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
    }

    public override void IsComplete()
    {        
        return " ";
    }
    public override void RecordEvent()
    {        
        
    }
    
}