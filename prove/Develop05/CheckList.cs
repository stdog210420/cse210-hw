using System;

public class Checklist:Goal
{

    private int _grade;    
    public override string GetGoal(int i = 0)
    {
        return $"{i}. [{GetCheck}] {GetName()} ({GetDescription()})--Currently completed {GetAchieve()}/{GetTime()}"; 
    }
    public override string SaveGoal()
    {
        return $"CheckListGoal: {GetName()}, {GetDescription()}, {GetScore()}, {GetBonus()}, {GetAchieve()}, {GetTime()}";
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
            _grade += GetScore() * GetAchieve() + GetBonus();
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
    }

    public override string IsComplete()
    {        
        if (GetAchieve() < GetTime())
        {
            return  " ";
        }
        else if(GetAchieve() == GetTime())
        {
            return  "X";
        } 
        return "X";
    }
    public override void RecordEvent()
    {        
        
    }
}