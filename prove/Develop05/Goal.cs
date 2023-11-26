using System;
using System.Data;
using System.IO;

public abstract class Goal
{   
    private int _itemNo;
    private  string _name;
    private  string _description;
    private  int _score = 0;
    private string _type;
    private int _perform;
    public int ItemNo()
    {
        return _itemNo;
    }
    public string Name()
    {
        return _name;
    }
    public string Description()
    {
        return _description;
    }
    public int Score()
    {
        return _score;
    }
    public string Type()
    {
        return _type;
    }
    public void SetPerform(int perform)
    {
        _perform += perform;
    }
    public int Perform()
    {
        return _perform;
    }

    public Goal(int itemNo, string type, string name, string description, int score, int perform)
    {   
        _itemNo = itemNo;
        _type = type;
        _name = name;
        _description = description;
        _score = score;
        _perform = perform;
    } 
    public virtual string ListItem()
    {
        return $"{ItemNo()}. [ ] {Name()} ({Description()})";
    }
    public abstract int CalculateScore(int grade);
    public abstract string SaveGoal();


}