using System;

public class Checklist:Goal
{
    
    private  int _time = 0;
    private  int _bonus= 0;
    public Checklist (int i, string check):base(i, check)
    {
        _GoalList.Add(_GoalText);
        i++;
    }
    public void CreateBonus()
    {
        Console.Write("How many times does this goal need to be accomplished for a bonus ? ");
        _time = int.Parse(Console.ReadLine());
        Console.Write("What is bonus for accomplishing it that many times? ");
        _bonus = int.Parse(Console.ReadLine());
        Console.WriteLine($"time: {_time}  bonus: {_bonus} ");
    }    
    public override int Grades()
    {
        return _Score * _Achieve + _bonus;
    }
    public override string Check()
    {
    
        return "X";
    }
}