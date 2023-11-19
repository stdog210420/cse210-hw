using System;
using System.Data;

public class Checklist:Goal
{

    private int _grade;    
    private int _perform = 0;
    public override string GetGoal(int i = 0)
    {
        return $"{i}. [{IsComplete()}] {GetName()} ({GetDescription()})--Currently completed {GetAchieve(_perform)}/{GetTime()}"; 
    }
    public override string LoadGoal(int i, string _finished, string _name, string _description, int _score, int bonus, int time)
    {
        return $"{i}. {_finished} {_name} ({_description}--Currently completed {GetAchieve(_perform)}/{GetTime()})";
    }
    public override string SaveGoal()
    {
        return $"CheckListGoal: {GetName()}, {GetDescription()}, {GetScore()}, {GetBonus()}, {GetAchieve(_perform)}, {GetTime()}";
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
        else if (GetAchieve(_perform) < GetTime())
        {

            _grade += GetScore() * GetAchieve(_perform);
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
        else if (GetAchieve(_perform) == GetTime())
        {

            _grade += GetScore() + GetBonus();
            Console.WriteLine ($"\nYou have {_grade} points.");        
            return _grade;
        }
            return _grade;
    }

    public override string IsComplete()
    {        
        if (GetAchieve(_perform) < GetTime())
        {
            return  " ";
        }
        else 
        {
            Console.WriteLine($"The goal {GetName()} was accomplished.");    
            return  "X";
        } 

    } 
}