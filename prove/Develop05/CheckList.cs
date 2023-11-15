using System;

public class Checklist:Goal
{

    private int _grade;    
    private int _time;
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
        _time = GetTime();
        return "X";
    }
}