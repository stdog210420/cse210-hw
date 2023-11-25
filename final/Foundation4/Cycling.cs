using System;

class Cycling: Activity
{
    private float _speed;
    public Cycling(DateTime date, int timeLength, float speed): base(date, timeLength)
    {
        _speed = speed;
    }
    public override float Distance()
    {
        return _speed * timeLength() / 60;
    }
    public override float Speed()
    {
        return _speed ;
    }
    public override string Type()
    {
        return "Cycling";
    }
}