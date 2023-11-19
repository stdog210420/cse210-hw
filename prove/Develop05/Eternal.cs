using System;

public class Eternal:Goal
{

    private int _grade;
    private int _perform = 0;
    public override string GetGoal(int i = 0)
    {
        return $"{i}. [{IsComplete()}] {GetName()} ({GetDescription()})"; 
    }
    public override string LoadGoal(int i, string _finished, string _name, string _description, int _score, int bonus, int time)
    {
        return $"{i}. {_finished} {_name} ({_description})";
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
        if (GetAchieve(_perform) == 0)
        {
            Console.WriteLine ($"\nYou have 0 points.");
            _grade = 0;
            return _grade;
        }
        else
        {
            _grade += GetScore() * GetAchieve(_perform);
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
    }
    public override string IsComplete()
    {        
        return " ";
    }

}