using System;

class Program
{
    static void Main(string[] args)
    {
        Address _addressLecture = new Address("South Las Vegas Boulevard", "Las Vegas", "Nevada","United States");
        Address _addressReception = new Address("South Las Vegas Boulevard", "Las Vegas", "Nevada","United States");
        Address _addressOutdoor = new Address("South Las Vegas Boulevard", "Las Vegas", "Nevada","United States");       
        // string name, int capacity, string title, string description, DateTime date, TimeSpan time, Address address): base(title, description, date, time, address
        Lectures _lectures = new Lectures("Bill Gates", 16800, "The Road Ahead", "This speech focuses on the future direction of computer technology, emphasizing the impact of the digital revolution on society.", DateTime.Parse("1995/01/01").Date, TimeSpan.Parse("10:00"), _addressLecture);
        Receptions _receptions = new Receptions("services@mail.cna.com.tw", "We Shall Fight on the Beaches", "This speech was delivered during World War II, is a powerful testament to Britain's resolve against surrender in the face of adversity.",DateTime.Parse("1940/06/04").Date, TimeSpan.Parse("15:00"), _addressReception);
        Outdoor _outdoor = new Outdoor("Sunny and cloudless weather", "Quit India", "The speech was delivered in the context of the Quit India Movement, a crucial moment in India's struggle for independence.", DateTime.Parse("1942/08/08").Date, TimeSpan.Parse("10:00"), _addressOutdoor);
        List<Event> _events = new List<Event>();
        _events.Add(_lectures);
        _events.Add(_receptions);
        _events.Add(_outdoor);
        foreach (Event eve in _events)
        {
            DisplayEvent(eve);
        }
    }
    public static void DisplayEvent(Event eve)
    {
        Console.WriteLine($"{eve.Type()}\n");
        Console.WriteLine($"Standard Details: {eve.StandardDetails()}\n");
        Console.WriteLine($"Full Details: {eve.FullDetails()}\n");
        Console.WriteLine($"Short Description: {eve.ShortDescription()}\n");
        Console.WriteLine();
    }
}