using System;

public class Checklist:Goal
{

    private int _grade;    
    public override int Grades()
    {
        if (GetAchieve() == 0)
        {
            Console.WriteLine ($"You have 0 points.");
            _grade = 0;
            return _grade;
        }
        else
        {
            _grade += GetScore() * GetAchieve() + GetBonus();
            Console.WriteLine ($"You have {_grade} points.");        
            return _grade;
        }
    }
    public override string Check()
    {
    
        return "X";
    }
}