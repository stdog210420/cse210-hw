using System;

class Program
{
    //    public Activity(DateTime date, int timeLength)
    static void Main(string[] args)
    {
        List<Activity> _activities= new List<Activity>();
        Running _running = new Running(DateTime.Parse("2023/11/25"), 30, 3);
        Cycling _cycling= new Cycling(DateTime.Parse("2023/11/25"), 30, 15);
        Swimming _swimming = new Swimming(DateTime.Parse("2023/11/25"), 30, 40);
        _activities.Add(_running);
        _activities.Add(_cycling);
        _activities.Add(_swimming);
        foreach (Activity act in _activities)
        {
            GetSummary(act);
        }
    }
    public static void GetSummary(Activity act)
    {
        Console.WriteLine($"{act.GetSummary()}");
    }
}