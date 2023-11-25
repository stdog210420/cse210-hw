using System;
class Lectures: Event
{
    private string _name;
    private int _capacity;
    public string Name()
    {
        return _name;
    }
    public int Capacity()
    {
        return _capacity;
    }
    public Lectures(string name, int capacity, string title, string description, DateTime date, TimeSpan time, Address address): base(title, description, date, time, address)
    {
        _name = name;
        _capacity = capacity;
    }  
    public override string Type()
    {
        return $"Lectures";
    }
    public override string FullDetails()
    {
        return $"{StandardDetails()}, (Type of event){Type()}, (Speaker name){Name()}, (Capacity){Capacity()}";
    }
}