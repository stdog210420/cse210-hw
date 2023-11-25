using System;

class Running: Activity
{
    private float _distance;
    public Running(DateTime date, int timeLength, float distance): base(date, timeLength)
    {   
        _distance = distance;
    }
    public override float Distance()
    {
        return _distance;
    }
    public override string Type()
    {
        return "Running";
    }
}