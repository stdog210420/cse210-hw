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
    public override float Speed()
    {
        return Distance() / timeLength() * 60 ;
    }
    public override float Pace()
    {
        return timeLength() / Distance();
    }
    public override string Type()
    {
        return "Running";
    }
}