using System;
using System.Diagnostics.Contracts;

public class Simple:Goal
{
    private bool _check;
    private int _perform;
    public bool Check()
    {
        return _check;
    }
    public override void SetPerform(int perform)
    {
        _perform += perform;
    }
    public int SimplePerform()
    {
        return _perform;
    }
    public Simple(int itemNo, string type, string name, string description, int score, int perform, bool check):base(itemNo, type, name, description, score, perform)
    {
        _check = check;
    }
    public override string ListItem()
    {
        if (SimplePerform()== 0)
        {
            return $"{ItemNo()}. [ ] {Name()} ({Description()})";
        } 
        else if (SimplePerform() == 1)
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
        if (SimplePerform() ==0)
        {
            grade = 0;
            return grade;
        }
        else if (SimplePerform() ==1)
        {
            grade  +=  SimplePerform() * Score();
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