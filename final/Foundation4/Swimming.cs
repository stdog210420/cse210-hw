class Swimming: Activity
{
    private int _laps;
    public int Laps()
    {
        return _laps;
    }
    public Swimming(DateTime date, int timeLength, int laps): base(date, timeLength)
    {
        _laps = laps;
    }
    //Distance (km) = swimming laps * 50 / 1000，  the length of a lap in the lap pool is 50 meters.
    public override float Distance()
    {
        return Laps() * 50 / 1000;
    }
    public override float Speed()
    {
        return Distance() / timeLength() *60;
    }
    public override float Pace()
    {
        return timeLength() / Distance();
    }
    public override string Type()
    {
        return "Swimming";
    }
}