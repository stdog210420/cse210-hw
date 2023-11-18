using System;

public class Eternal:Goal
{

    private int _grade;
    public override string GetGoal(int i = 0)
    {
        return $"{i}. [{GetCheck()}] {GetName()} ({GetDescription()})"; 
    }
    public override string SaveGoal()
    {

        return $"EternalGoal: {GetName()}, {GetDescription()}, {GetScore()}"; 
    }
    public override string ListItem(int i = 0)
    {
        return $"{i}.{GetName()}";
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
    public override string IsComplete()
    {        
        return "";
    }
    public override void RecordEvent()
    {        
        
    }   
}