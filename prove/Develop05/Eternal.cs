using System;

public class Eternal:Goal
{

    private int _grade;
    private int _perform = 0;
    public Eternal(int itemNo, string type, string name, string description, int score, int perform):base(itemNo, type, name, description, score, perform)
    {
        
    }
    public override string ListItem()
    {
        return $"{ItemNo()}. [ ] {Name()} ({Description()})";
    }
    public override int CalculateScore(int grade)
    {
        if (Perform() ==0)
        {
            grade = 0;
            return grade;
        }
        else 
        {
            grade  +=  Perform() * Score();
            return grade;
        }
    }
    public override string SaveGoal()  
    {
        return $"{Type()}: {Name()}, {Description()}, {Score()}";
    }


}