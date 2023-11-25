class Receptions: Event
{
    private string _eMail;
    public string Email()
    {
        return _eMail;
    }
    public Receptions(string eMail, string title, string description, DateTime date, TimeSpan time, Address address): base(title, description, date, time, address)
    {
        _eMail = eMail;
    } 
    public override string Type()
    {
        return $"Receptions";
    } 
    public override string FullDetails()
    {
        return $"{StandardDetails()}, (the type of event){Type()}, (E-mail){Email()}";
    }
}