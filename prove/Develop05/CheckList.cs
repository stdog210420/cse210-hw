using System;
using System.Data;

public class CheckList:Goal
{
    private int _time;    
    private int _finish; 
    private int _bonus;
    public int Time()
    {
        return _time;
    }
    public int Finish()
    {
        return _finish;
    }
    public int Bonus()
    {
        return _bonus;
    }
    public CheckList(int itemNo, string type, string name, string description, int score, int perform, int time, int finish, int bonus):base(itemNo, type, name, description, score, perform)
    {   
        _time = time;
        _finish = finish; 
        _bonus = bonus;
    }
    public override string ListItem()
    {
        if (Perform() < Time())
        {
        return $"{ItemNo()}. [ ] {Name()} ({Description()}) -- Currently completed: {Finish()}/{Time()} ";            
        }
        else if (Perform() == Time())
        {
            return $"{ItemNo()}. [X] {Name()} ({Description()}) -- Currently completed: {Finish()}/{Time()} ";
        }
        else
        {
            return $"This goal has completed.";
        }
    }
    public override int CalculateScore(int grade)
    {
        if (Perform() ==0)
        {
            grade = 0;
            return grade;
        }
        else if (Perform() < Time())
        {
            grade  +=  Perform() * Score();
            return grade;
        }
        else if (Perform() == Time())
        {
            grade  +=  Perform() * Score() + Bonus();
            return grade;
        }
        return grade;
    }
    public override string SaveGoal()  
    {
        return $"{Type()}: {Name()}, {Description()}, {Score()}, {Bonus()}, {Time()}, {Finish()}";
    }
}