using System;

public class Eternal:Goal
{
    public Eternal (int i, string check):base(i, check)
    {
        _GoalList.Add(_GoalText);
        i++;
    }
    public override int Grades()
    {
        return _Score * _Achieve;
    }
    public override string Check()
    {
    
        return " ";
    }   
}