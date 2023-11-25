using System;
class Event
{
    private string _title;
    private string _description;
    private DateTime _date; 
    private TimeSpan _time;
    private  Address _address;
    // public string Title()
    // {
    //     return _title;
    // }
    // public string Description()
    // {
    //     return _description;
    // }
    // public DateTime Date()
    // {
    //     return _date;
    // }
    // public TimeSpan TimeSpan()
    // {
    //     return _time;
    // }
    // public Address Address()
    // {
    //     return _address;
    // }
    public Event (string title, string description, DateTime date, TimeSpan time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }
    public virtual string Type()
    {
        return $"Generic Event";
    }
    public string StandardDetails()
    {
        return $"(Title){_title} (Description){_description}, (Date){_date}, (Time){_time}, (Address){_address}";
    }
    public virtual string FullDetails()
    {
        return $"{StandardDetails()}";
    }

    public string ShortDescription()
    {
        return $"(the type of event){Type()}, (Title){_title}, (Date){_date}";

    }


}
