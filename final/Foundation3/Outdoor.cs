class Outdoor: Event
{
    private string _weather;
    public string Weather()
    {
        return _weather;
    }
    public Outdoor(string weather, string title, string description, DateTime date, TimeSpan time, Address address): base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public override string Type()
    {
        return $"Outdoor gatherings";
    }   
    public override string FullDetails()
    {
        return $"{StandardDetails()}, (the type of event){Type()}, (weather){Weather()}";
    }
}