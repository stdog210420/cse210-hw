using System;

public class Eternal:Goal
{

    private int _grade;
    private  string _goal;
    public override string GetGoal(int i = 0)
    {
        _goal = $"{i}. [{Check()}] {GetName()} ({GetDescription()})"; 
        return _goal;
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
}