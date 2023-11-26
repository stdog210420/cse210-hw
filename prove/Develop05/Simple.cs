using System;
using System.Diagnostics.Contracts;

public class Simple:Goal
{
    private bool _check;
    public bool Check()
    {
        return _check;
    }
    public Simple(int itemNo, string type, string name, string description, int score, int perform, bool check):base(itemNo, type, name, description, score, perform)
    {
        _check = check;
    }
    public override string ListItem()
    {
        if (Perform() == 0)
        {
            return $"{ItemNo()}. [ ] {Name()} ({Description()})";
        } 
        else if (Perform() == 1)
        {
            return $"{ItemNo()}. [X] {Name()} ({Description()})";
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
        else if (Perform() ==1)
        {
            grade  +=  Perform() * Score();
            return grade;
        }
        else 
        return grade;
    }
    public override string SaveGoal()  
    {
        return $"{Type()}: {Name()}, {Description()}, {Score()}, {Check()}";
    }
    
}