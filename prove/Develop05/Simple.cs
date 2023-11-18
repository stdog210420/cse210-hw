using System;
using System.Diagnostics.Contracts;

public class Simple:Goal
{
    private int _grade;
    public override string GetGoal(int i = 0)
    {
        return $"{i}. [{GetCheck()}] {GetName()} ({GetDescription()})";
    }
    public override string SaveGoal()
    {   
        string _finished = "false";
        if (GetAchieve() != 0)
        {
            _finished = "True";
        }
        return $"SimpleGoal: {GetName()}, {GetDescription()}, {GetScore()}, {_finished}"; 
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
        }
        else if (GetAchieve() == 1)
        {
            _grade += GetScore();
            Console.WriteLine ($"\nYou have {_grade} points.");        
        }
        return _grade;
    }

    public override string IsComplete()
    { 
        if (GetAchieve()== 0)
        {
            return " "; 
        } 
        else
        {   
            Console.WriteLine($"The goal {GetName()} was accomplished.");                                                                                                                             
            return "X"; 
        }   
    }
    
}