using System;

public class Eternal:Goal
{
    private int _perform;
    public override void SetPerform(int perform)
    {
        _perform += perform;
    }
    public int EternalPerform()
    {
        return _perform;
    }
    public Eternal(int itemNo, string type, string name, string description, int score, int perform):base(itemNo, type, name, description, score, perform)
    {

    }
    public override string ListItem()
    {
        return $"{ItemNo()}. [ ] {Name()} ({Description()})";
    }
    public override int CalculateScore(int grade)
    {
        if (EternalPerform() ==0)
        {
            grade = 0;
            return grade;
        }
        else 
        {
            grade  +=  EternalPerform() * Score();
            return grade;
        }
    }
    public override string SaveGoal()  
    {
        return $"{Type()}: {Name()}, {Description()}, {Score()}";
    }


}