using System;
using System.Data;

public class CheckList:Goal
{
    private int _time;    
    private int _bonus;
    private int _perform;
    public override void SetPerform(int perform)
    {
        _perform += perform;
    }
    public int CheckListPerform()
    {
        return _perform;
    }
    public int Time()
    {
        return _time;
    }
    public int Bonus()
    {
        return _bonus;
    }
    public CheckList(int itemNo, string type, string name, string description, int score, int perform, int time, int bonus):base(itemNo, type, name, description, score, perform)
    {   
        _time = time;
        _bonus = bonus;
    }
    public override string ListItem()
    {
        if (CheckListPerform() < Time())
        {
        return $"{ItemNo()}. [ ] {Name()} ({Description()}) -- Currently completed: {CheckListPerform()}/{Time()} ";            
        }
        else if (CheckListPerform() == Time())
        {
            return $"{ItemNo()}. [X] {Name()} ({Description()}) -- Currently completed: {CheckListPerform()}/{Time()} ";
        }
        else
        {
            return $"This goal has completed.";
        }
    }
    public override int CalculateScore(int grade)
    {
        if (CheckListPerform() ==0)
        {
            grade = 0;
            return grade;
        }
        else if (CheckListPerform() < Time())
        {
            grade  += Score();
            return grade;
        }
        else if (CheckListPerform() == Time())
        {
            grade  += Bonus();
            return grade;
        }
        Console.WriteLine($"This goal has completed.");
        return grade;
    }
    public override string SaveGoal()  
    {
        return $"{Type()}: {Name()}, {Description()}, {Score()}, {Bonus()}, {Time()}, {CheckListPerform()}";
    }
}