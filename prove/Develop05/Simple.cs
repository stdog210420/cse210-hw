using System;
using System.Diagnostics.Contracts;

public class Simple:Goal
{
    public Simple (int i, string check):base(i, check)
    {
        _GoalList.Add(_GoalText);
        i++;
    }
    public override int Grades()
    {
        return _Score;
    }
    public override string Check()
    {
    
        return "X";
    }
    
}