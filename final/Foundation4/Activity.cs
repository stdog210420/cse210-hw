using System;
using System.Globalization;
class Activity
{
    private string _date;
    private int _timeLength;
    private float _distance = 0;
    private float _speed;
    private float _pace;
    //track the date
    public string Date()
    {
        return _date;
    }
    //track the length of the activity in minutes
    public int timeLength()
    {
        return _timeLength;
    }
    public Activity(DateTime date, int timeLength)
    {
        string _newDate;
        _newDate = date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        _date = _newDate;
        _timeLength = timeLength;
    }
    public virtual float Distance()
    {
        return _distance;
    }
    //The speed (miles per hour or kilometers per hour)
    public virtual float Speed()
    {
        _speed = Distance() / _timeLength * 60;
        return _speed;
    }
    //The pace (minutes per mile or minutes per kilometer)
    public virtual float Pace()
    {
        _pace = _timeLength / Distance();
        return _pace;
    }
    public virtual string Type()
    {
        return "Activity";
    }
//     03 Nov 2022 Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile
// 03 Nov 2022 Running (30 min): Distance 4.8 km, Speed: 9.7 kph, Pace: 6.9 min per km
    public virtual string GetSummary()
    {
        return $"{Date()} {Type()} ({_timeLength} min)- Distance {Distance()} km, Speed {Speed()} kph, Pace: {Pace()} min per km";
    }
}