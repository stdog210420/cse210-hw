using System;

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public string Street()
    {
        return _street;
    }
    public string City()
    {
        return _city;
    }
        public string State()
    {
        return _state;
    }
        public string Country()
    {
        return _country;
    }
    public Address (string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        //This line is equal to the following: 
        return _country == "USA";
        //if (_country.ToUpper() == "USA")
        // {
        //     return true;
        // }
        // else
        // return false;
    }
    public string GetFullAddress()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}